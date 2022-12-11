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
using System.Numerics;

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

        public async Task<TDResponse> CreateGang(BaseRequest<CreateGangRequest> req, UserDto user, string token)
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
                if (await _context.Gang.AnyAsync(l => l.ShortName == req.Data.ShortName && l.IsActive))
                {
                    response.SetError(OperationMessages.GangShortNameTaken);
                    info.AddInfo(OperationMessages.GangShortNameTaken);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var spendMoneyRes = await DbService.SpendGangCreateMoney(token, req.Info);
                if (spendMoneyRes != null && !spendMoneyRes.HasError)
                {
                    var gang = new Gang()
                    {
                        ShortName = req.Data.ShortName,
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
                        UserId = user.Id,
                        UserName = user.Username,
                        Power = 0//todo: power hesaplaması yapılacak
                    };
                    await _context.AddAsync(gangMember);
                    await _context.SaveChangesAsync();
                    await CreateGangChat(new BaseRequest<Guid>() { Info = req.Info, Data = gang.Id }, user);
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

        private async Task<TDResponse> CreateGangChat(BaseRequest<Guid> req, UserDto user)
        {
            TDResponse response = new TDResponse();
            var info = InfoDetail.CreateInfo(req, "GetPlayerBaseInfo");

            try
            {
                var gang = await _context.Gang.Where(l => l.Id == req.Data).FirstOrDefaultAsync();

                var chatRoom = new ChatRoom()
                {
                    ChatRoomTypeId = (int)ChatRoomTypeEnum.GangChat,
                    CreatedDate = DateTimeOffset.UtcNow,
                    IsActive = true,
                    LastChangeDate = DateTimeOffset.UtcNow,
                    Name = req.Data.ToString()
                };
                await _context.AddAsync(chatRoom);
                await _context.SaveChangesAsync();

                var chatRoomMember = new ChatRoomMember()
                {
                    ChatRoomId = chatRoom.Id,
                    IsActive = true,
                    JoinedRoomDate = DateTimeOffset.UtcNow,
                    LastSeen=DateTimeOffset.UtcNow,
                    UserId=user.Id,
                    Username=user.Username
                };
                await _context.AddAsync(chatRoomMember);
                await _context.SaveChangesAsync();
                Player.SendGangChatId(user.Id, chatRoom.Id.ToString());

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;
        }
        public async Task<TDResponse> SendGangInvitation(BaseRequest<long> req, UserDto user)
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
                    .Include(l => l.MemberType).ThenInclude(l => l.Gang)
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
                    AGangId = query.MemberType.Gang.Id.ToString(),
                    AGangName = $"[{query.MemberType.Gang.ShortName}]{query.MemberType.Gang.Name}",
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
        public async Task<TDResponse<GangInfo>> GetGangInfo(BaseRequest<long?> req, UserDto user)
        {
            TDResponse<GangInfo> response = new TDResponse<GangInfo>();
            var info = InfoDetail.CreateInfo(req, "GetGangInfo");
            try
            {
                var userId = req.Data ?? user.Id;
                var c = await _context.GangMember
                    .Include(l => l.MemberType).ThenInclude(l => l.Gang)
                    .Where(l => l.UserId == userId && l.MemberType.Gang.IsActive).FirstOrDefaultAsync();
                if (c == null)
                {
                    response.Data = null;
                    response.SetSuccess(OperationMessages.Success);
                    return response;
                }
                var owner = await _context.GangMember
                    .Include(l => l.MemberType).ThenInclude(l => l.Gang)
                    .Where(l => l.UserId == c.MemberType.Gang.OwnerId && l.MemberType.Gang.IsActive).FirstOrDefaultAsync();
                response.Data = new GangInfo()
                {
                    Id = c.MemberType.Gang.Id,
                    Capacity = c.MemberType.Gang.Capacity,
                    Description = c.MemberType.Gang.Description,
                    MemberCount = c.MemberType.Gang.MemberCount,
                    Name = c.MemberType.Gang.Name,
                    Power = c.MemberType.Gang.Power,
                    ShortName = c.MemberType.Gang.ShortName,
                    Owner = new GangMemberInfo()
                    {
                        Power = owner.Power,
                        MemberTypeName = owner.MemberType.Name,
                        UserName = owner.UserName,
                        UserId = owner.UserId
                    }
                };

                response.SetSuccess();
            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                info.SetException(e);
                _logger.LogError(info.ToString());
            }
            return response;
        }

        public async Task<TDResponse<List<GangMemberInfo>>> GetGangMembers(BaseRequest<string> req, UserDto user)
        {
            TDResponse<List<GangMemberInfo>> response = new TDResponse<List<GangMemberInfo>>();
            var info = InfoDetail.CreateInfo(req, "GetGangInfo");
            try
            {
                if (req.Data == null)
                {
                    response.SetError(OperationMessages.InputError);
                    info.AddInfo(OperationMessages.InputError);
                    _logger.LogInformation(info.ToString());
                    return response;
                }
                var gangId = new Guid(req.Data);
                var query = await _context.GangMember
                    .Include(l => l.MemberType)
                    .Where(l => l.MemberType.Gang.Id == gangId && l.MemberType.Gang.IsActive && l.MemberType.Name != "Owner")
                    .OrderByDescending(l => l.Power).ThenBy(l => l.UserName)
                    .Select(l => new GangMemberInfo()
                    {
                        Power = l.Power,
                        MemberTypeName = l.MemberType.Name,
                        UserName = l.UserName,
                        UserId = l.UserId
                    }).ToListAsync();
                response.Data = query;
                response.SetSuccess();
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
