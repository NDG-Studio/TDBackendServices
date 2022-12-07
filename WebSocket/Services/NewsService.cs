using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SharedLibrary.Enums;
using WebSocket.Entities;
using WebSocket.Enums;
using WebSocket.Interfaces;
using WebSocket.Models;
using SharedLibrary.Helpers;
using SharedLibrary.Models;
using WebSocket;
using WebSocket.Socket;

namespace PlayerBaseApi.Services
{
    public class NewsService : INewsService
    {
        private readonly ILogger<NewsService> _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public NewsService(ILogger<NewsService> logger, IMapper mapper, IConfiguration configuration)
        {
            _logger = logger;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<TDResponse> SendImportantNews(ImportantNews req)
        {
            TDResponse response = new TDResponse();
            try
            {
                using (var _context = new WebSocketContext())
                {
                    var imN = new News()
                    {
                        Title = req.Title,
                        Detail = req.Detail,
                        Date = DateTimeOffset.Now,
                        UserId = null,
                        IsActive = true,
                        Seen = false,
                        TypeId = (int)NewsType.ImportantNews
                    };
                    await _context.ImportantNews.AddAsync(imN);
                    await _context.SaveChangesAsync();
                    response.SetSuccess();
                }
                Player.SendAllNewsRefreshNeeded();

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
            }
            return response;

        }

        public async Task<TDResponse> SendAnnouncment(ImportantNews req)
        {
            TDResponse response = new TDResponse();
            try
            {
                using (var _context = new WebSocketContext())
                {
                    var imN = new News()
                    {
                        Title = req.Title,
                        Detail = req.Detail,
                        Date = DateTimeOffset.Now,
                        UserId = null,
                        IsActive = true,
                        Seen = false,
                        TypeId = (int)NewsType.Announcment
                    };
                    await _context.ImportantNews.AddAsync(imN);
                    await _context.SaveChangesAsync();
                    response.SetSuccess();
                }
                Player.SendAllNewsRefreshNeeded();

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
            }
            return response;

        }
        
        
        public async Task<TDResponse> SendScoutNews(ScoutInfoDTO req)
        {
            TDResponse response = new TDResponse();
            try
            {
                /*using (var _context = new WebSocketContext())
                {
                    var imN = new News()
                    {
                        Title = req.Title,
                        Detail = req.Detail,
                        Date = DateTimeOffset.Now,
                        UserId = null,
                        IsActive = true,
                        Seen = false,
                        TypeId = (int)NewsType.Announcment
                    };
                    await _context.ImportantNews.AddAsync(imN);
                    await _context.SaveChangesAsync();
                    response.SetSuccess();
                }*/
                //Todo: NewsOLarak da ekleencek
                
                Player.SendScoutInfoTest(req.SenderUserId,req);
                Player.SendScoutInfoTest(req.TargetUserId,req);

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
            }
            return response;

        }


        
        public async Task<TDResponse> SendAttackNews(AttackInfoDTO req)
        {
            TDResponse response = new TDResponse();
            try
            {

                using (var _context = new WebSocketContext())
                {
                    switch ((req.ResultData, req.IsActive))
                    {
                        case (null, true):
                            await _context.AddAsync(new News()
                            {
                                UserId = req.DefenserUserId,
                                Title = $"ATTACK COMING",
                                Seen = false,
                                Date = DateTimeOffset.UtcNow,
                                Detail = $"Attack coming from { req.AttackerUserId }",
                                IsActive = true,
                                TypeId = (int)NewsType.Attack
                            });
                            Player.SendNewsRefreshNeeded(req.DefenserUserId);
                            break;                        
                        case (not null, true):
                            var resultData = JsonConvert.DeserializeObject<AttackResultData>(req.ResultData);
                            await _context.AddAsync(new News()
                            {
                                UserId = req.DefenserUserId,
                                Title = req.WinnerSide == (byte)AttackSideEnum.Defenser ? "DEFENSE SUCCEED" : "DEFENCE FAILED",
                                Seen = false,
                                Date = DateTimeOffset.UtcNow,
                                Detail = $"Defence to { req.AttackerUserId }",
                                IsActive = true,
                                TypeId = (int)NewsType.Attack,
                                Casualities =resultData.TargetsDeadTroop,
                                Prisoners = resultData.PrisonerCount,
                                Wounded = resultData.TargetsWoundedTroop,
                                LostResource = resultData.LootedScrap,
                            });
                            Player.SendNewsRefreshNeeded(req.DefenserUserId);
                            
                            await _context.AddAsync(new News()
                            {
                                UserId = req.AttackerUserId,
                                Title = req.WinnerSide == (byte)AttackSideEnum.Attacker ? "ATTACK SUCCEED" : "ATTACK FAILED",
                                Seen = false,
                                Date = DateTimeOffset.UtcNow,
                                Detail = $"Attack coming from { req.AttackerUserId }",
                                IsActive = true,
                                TypeId = (int)NewsType.Attack,
                                Casualities =resultData.AttackersDeadTroop,
                                Prisoners = resultData.PrisonerCount,
                                Wounded = resultData.AttackersWoundedTroop,
                                LostResource = resultData.LootedScrap
                            });
                            Player.SendNewsRefreshNeeded(req.AttackerUserId);
                            
                            break; 
                        case (not null, false):
                            var resultData2 = JsonConvert.DeserializeObject<AttackResultData>(req.ResultData);
                            await _context.AddAsync(new News()
                            {
                                UserId = req.AttackerUserId,
                                Title = $"YOUR TROOPS BACK TO HOME",
                                Seen = false,
                                Date = DateTimeOffset.UtcNow,
                                Detail = $"Your troops comeback. Check hospital",
                                IsActive = true,
                                TypeId = (int)NewsType.Attack,
                                Prisoners = resultData2.PrisonerCount,
                                Wounded = resultData2.AttackersWoundedTroop,
                                LostResource = resultData2.LootedScrap
                            });
                            Player.SendNewsRefreshNeeded(req.AttackerUserId);
                            
                            break;
                    }
                }

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
            }
            return response;

        }



    }
}
