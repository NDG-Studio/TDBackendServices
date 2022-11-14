using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebSocket.Entities;
using WebSocket.Interfaces;
using WebSocket.Models;
using SharedLibrary.Helpers;
using SharedLibrary.Models;
using WebSocket;
using WebSocket.Socket;
using Newtonsoft.Json;
using SharedLibrary.Models.Loot;
using System.Net.Http.Headers;
using System.Text;
using WebSocket.Enums;

namespace PlayerBaseApi.Services
{
    public class GangService : IGangService
    {
        private readonly ILogger<GangService> _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly WebSocketContext _context;

        public GangService(ILogger<GangService> logger, IMapper mapper, IConfiguration configuration, WebSocketContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _configuration = configuration;
            _context = context;
        }

        public async Task<TDResponse> CreateGang(BaseRequest<CreateGangRequest> req, UserDto user,string token)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "GetPlayerBaseInfo");
            try
            {
                if (req.Data == null)
                {
                    response.SetError(OperationMessages.InputError);
                    info.AddInfo(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var query = await _context.GangMember.Where(l => l.UserId == user.Id && l.MemberType.Gang.IsActive).FirstOrDefaultAsync();
                if (query != null)
                {
                    response.SetError(OperationMessages.PlayerAllreadyGangMember);
                    info.AddInfo(OperationMessages.PlayerAllreadyGangMember);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (await _context.Gang.AnyAsync(l => l.Name == req.Data.Name && l.IsActive))
                {
                    response.SetError(OperationMessages.GangAllreadyExist);
                    info.AddInfo(OperationMessages.GangAllreadyExist);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var spendMoneyRes = await DbService.SpendGangCreateMoney(token, req.Info);
                if (spendMoneyRes != null && !spendMoneyRes.HasError)
                {
                    var gang = new Gang()
                    {
                        Name = req.Data.Name,
                        Description = req.Data.Description,
                        OwnerId = user.Id,
                        OwnerName = user.Username
                    };
                    await _context.AddAsync(gang);
                    await _context.SaveChangesAsync();
                    var memberType = new MemberType()
                    {
                        Name = "Member",
                        GangId = gang.Id
                    };
                    var ownerType = new MemberType()
                    {
                        Name = "Owner",
                        GangId = gang.Id,
                        CanAcceptMember = true,
                        CanDistributeMoney = true,
                        CanKick = true,
                        CanMemberChangeType = true,
                        CanStartWar = true,
                        GateManager = true,
                        IsActive = true
                    };
                    await _context.AddAsync(memberType);
                    await _context.AddAsync(ownerType);
                    await _context.SaveChangesAsync();

                    var gangMember = new GangMember()
                    {
                        MemberTypeId = ownerType.Id,
                        UserId = user.Id
                    };
                    await _context.AddAsync(gangMember);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;

        }


        public async Task<TDResponse> SendGangInvitation (BaseRequest<long> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "SendGangInvitation");
            try
            {
                if (req == null)
                {
                    response.SetError(OperationMessages.InputError);
                    info.AddInfo(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var query = await _context.GangMember
                    .Include(l=>l.MemberType).ThenInclude(l=>l.Gang)
                    .Where(l => l.UserId == user.Id && l.MemberType.Gang.IsActive).FirstOrDefaultAsync();
                var queryForInvitation = await _context.GangMember.Where(l => l.UserId == req.Data && l.MemberType.Gang.IsActive).FirstOrDefaultAsync();
                if (queryForInvitation != null)
                {
                    response.SetError(OperationMessages.PlayerAllreadyGangMember);
                    info.AddInfo(OperationMessages.PlayerAllreadyGangMember);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                if (query == null)
                {
                    response.SetError(OperationMessages.PlayerIsNotInGangMember);
                    info.AddInfo(OperationMessages.PlayerIsNotInGangMember);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                if (!query.MemberType.CanAcceptMember)
                {
                    response.SetError(OperationMessages.PlayerNotHavePermission);
                    info.AddInfo(OperationMessages.PlayerNotHavePermission);
                    _logger.LogInformation(info.ToString());
                    return response;
                }

                var gangInvitations = new News()
                {
                    Title = "Gang Invitation",
                    Detail = $" {user.Username} invites you to join '{query.MemberType.Gang.Name}' gang",
                    Date = DateTimeOffset.Now,
                    UserId = req.Data,
                    IsActive = true,
                    Seen = false,
                    TypeId = (int)NewsType.GangInvitation
                };
                await _context.AddAsync(gangInvitations);
                await _context.SaveChangesAsync();
                response.SetSuccess();


                Player.SendNewsRefreshNeeded(req.Data);


            
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;

        }

        private static async Task<LootRunResponse?> GetPlayerBaseInfo(long userId, string token, InfoDto info)
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) =>
                { return true; }; //TODO: Prodda silinmeli

            using (HttpClient client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", token);

                var response = client.PostAsync(new Uri(Player.PlayerBaseUrl + "/api/PlayerBase/GetActiveLootRunsForSocket"),
                    new StringContent(JsonConvert.SerializeObject(
                        new BaseRequest<string>()
                        {
                            Data = token,
                            Info = info
                        }
                        ), Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var res = JsonConvert.DeserializeObject<TDResponse<LootRunResponse>>(content)?.Data;
                    return res;
                }
                return null;
            }
        }




    }
}
