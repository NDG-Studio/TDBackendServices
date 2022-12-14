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
using SharedLibrary.Models.Loot;
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
                using (var _context = new WebSocketContext())
                {
                    switch ((req.ScoutedData,req.IsActive))
                    {
                        case (null,true):
                            Player.SendNewInteraction(req.SenderUserId,new NewsDTO() 
                            {
                                Title = $"SCOUT (not necessary)",
                                Seen = false,
                                Date = req.ComeBackDate,
                                Detail = $"not necessary",
                                IsActive = true,
                                TypeId = (int)NewsType.Scout,
                                ACoord = DbService.GetUserCoordinate(req.SenderUserId).Result.Data,
                                AGangId = _context.GangMember.Where(l=>l.UserId==req.SenderUserId)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                AUsername = req.SenderUserName,
                                AGangName = _context.GangMember.Where(l=>l.UserId==req.SenderUserId)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                AUserId = req.SenderUserId,
                                ProcessDate = req.ArrivedDate,
                                TCoord = DbService.GetUserCoordinate(req.TargetUserId).Result.Data,
                                TUsername = req.TargetUserName,
                                TGangId = _context.GangMember.Where(l=>l.UserId==req.TargetUserId)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                TGangName = _context.GangMember.Where(l=>l.UserId==req.TargetUserId)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                TUserId = req.TargetUserId,
                                Id = req.Id.ToString(),
                            });
                             
                             Player.SendNewInteraction(req.TargetUserId,new NewsDTO()
                             {
                                 Title = $"SCOUT (not necessary)",
                                 Seen = false,
                                 Date = req.ComeBackDate,
                                 Detail = $"not necessary",
                                 IsActive = true,
                                 TypeId = (int)NewsType.Scout,
                                 ACoord = DbService.GetUserCoordinate(req.SenderUserId).Result.Data,
                                 AGangId = _context.GangMember.Where(l=>l.UserId==req.SenderUserId)
                                     .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                 AUsername = req.SenderUserName,
                                 AGangName = _context.GangMember.Where(l=>l.UserId==req.SenderUserId)
                                     .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                 AUserId = req.SenderUserId,
                                 ProcessDate = req.ArrivedDate,
                                 TCoord = DbService.GetUserCoordinate(req.TargetUserId).Result.Data,
                                 TUsername = req.TargetUserName,
                                 TGangId = _context.GangMember.Where(l=>l.UserId==req.TargetUserId)
                                     .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                 TGangName = _context.GangMember.Where(l=>l.UserId==req.TargetUserId)
                                     .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                 TUserId = req.TargetUserId,
                                 Id = req.Id.ToString(),
                             });

                            break;
                        case (not null,true):
                            var scoutedData = JsonConvert.DeserializeObject<ScoutedData>(req.ScoutedData);
                            await _context.AddAsync(new News()
                            {
                                UserId = req.TargetUserId,
                                Title = $"YOUR BASE SCOUTED",
                                Seen = false,
                                Date = DateTimeOffset.UtcNow,
                                Detail = $"You have been scouted by { req.SenderUserName }",
                                IsActive = true,
                                TypeId = (int)NewsType.Scout,
                                ACoord = DbService.GetUserCoordinate(req.SenderUserId).Result.Data,
                                AGangId = _context.GangMember.Where(l=>l.UserId==req.SenderUserId)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                AUsername = req.SenderUserName,
                                AGangName = _context.GangMember.Where(l=>l.UserId==req.SenderUserId)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                AUserId = req.SenderUserId,
                                ProcessDate = DateTimeOffset.UtcNow,
                                TCoord = DbService.GetUserCoordinate(req.TargetUserId).Result.Data,
                                TScrap = scoutedData.ScrapCount,
                                TTroop = scoutedData.TroopCount,
                                TWall = scoutedData.WallLevel,
                                TUsername = req.TargetUserName,
                                TUserId = req.TargetUserId,
                                TGangId = _context.GangMember.Where(l=>l.UserId==req.TargetUserId)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                TGangName = _context.GangMember.Where(l=>l.UserId==req.TargetUserId)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                
                            });
                            await _context.SaveChangesAsync();
                            Player.SendNewsRefreshNeeded(req.TargetUserId);
                            
                            await _context.AddAsync(new News()
                            {
                                UserId = req.SenderUserId,
                                Title = $"SCOUTED MISSION SUCCEED",
                                Seen = false,
                                Date = DateTimeOffset.UtcNow,
                                Detail = $"Your scout mission succeed to { req.TargetUserName }",
                                IsActive = true,
                                TypeId = (int)NewsType.Scout,
                                ACoord = DbService.GetUserCoordinate(req.SenderUserId).Result.Data,
                                AGangId = _context.GangMember.Where(l=>l.UserId==req.SenderUserId)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                AUsername = req.SenderUserName,
                                AGangName = _context.GangMember.Where(l=>l.UserId==req.SenderUserId)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                AUserId = req.SenderUserId,
                                ProcessDate = DateTimeOffset.UtcNow,
                                TCoord = DbService.GetUserCoordinate(req.TargetUserId).Result.Data,
                                TScrap = scoutedData.ScrapCount,
                                TTroop = scoutedData.TroopCount,
                                TWall = scoutedData.WallLevel,
                                TUsername = req.TargetUserName,
                                TUserId = req.TargetUserId,
                                TGangId = _context.GangMember.Where(l=>l.UserId==req.TargetUserId)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                TGangName = _context.GangMember.Where(l=>l.UserId==req.TargetUserId)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                
                            });
                            await _context.SaveChangesAsync();
                            Player.SendNewsRefreshNeeded(req.SenderUserId);
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
                            Player.SendNewInteraction(req.AttackerUserId,new NewsDTO()
                            {
                                Title = $"ATTACK (not necessary)",
                                Seen = false,
                                Date = req.ComeBackDate,
                                Detail = $"not necessary",
                                IsActive = true,
                                TypeId = (int)NewsType.Attack,
                                ACoord = DbService.GetUserCoordinate(req.AttackerUserId).Result.Data,
                                AGangId = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                AUsername = req.AttackerUsername,
                                AGangName = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                AUserId = req.AttackerUserId,
                                ProcessDate = req.ArriveDate,
                                TCoord = DbService.GetUserCoordinate(req.DefenserUserId).Result.Data,
                                TUsername = req.DefenserUsername,
                                TGangId = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                TGangName = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                TUserId = req.DefenserUserId,
                                Id = req.Id.ToString(),
                            });
                            Player.SendNewInteraction(req.DefenserUserId,new NewsDTO()
                            {
                                Title = $"ATTACK (not necessary)",
                                Seen = false,
                                Date = req.ComeBackDate,
                                Detail = $"not necessary",
                                IsActive = true,
                                TypeId = (int)NewsType.Attack,
                                ACoord = DbService.GetUserCoordinate(req.AttackerUserId).Result.Data,
                                AGangId = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                AUsername = req.AttackerUsername,
                                AGangName = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                AUserId = req.AttackerUserId,
                                ProcessDate = req.ArriveDate,
                                TCoord = DbService.GetUserCoordinate(req.DefenserUserId).Result.Data,
                                TUsername = req.DefenserUsername,
                                TGangId = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                TGangName = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                TUserId = req.DefenserUserId,
                                Id = req.Id.ToString(),
                            });
                            break;                        
                        case (not null, true):
                            var resultData = JsonConvert.DeserializeObject<AttackResultData>(req.ResultData);
                            await _context.AddAsync(new News()
                            {
                                UserId = req.DefenserUserId,
                                Title = req.WinnerSide == (byte)AttackSideEnum.Defenser ? "DEFENSE SUCCEED" : "DEFENSE FAILED",
                                Seen = false,
                                Date = DateTimeOffset.UtcNow,
                                Detail = $"Results of '{req.AttackerUsername}'s attack ",
                                IsActive = true,
                                TypeId = (int)NewsType.Attack,
                                ACoord = DbService.GetUserCoordinate(req.AttackerUserId).Result.Data,
                                ATroop = req.AttackerTroopCount,
                                AGangId = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                AUsername = req.AttackerUsername,
                                AGangName = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                AUserId = req.AttackerUserId,
                                ADead = resultData.AttackersDeadTroop,
                                APrisoner = req.WinnerSide == (byte)AttackSideEnum.Attacker ? resultData.PrisonerCount:0,
                                TPrisoner = req.WinnerSide == (byte)AttackSideEnum.Defenser ? resultData.PrisonerCount:0,
                                AWounded = resultData.AttackersWoundedTroop,
                                TWounded = resultData.TargetsWoundedTroop,
                                ProcessDate = req.ArriveDate.ToDateTimeOffsetUtc(),
                                TCoord = DbService.GetUserCoordinate(req.DefenserUserId).Result.Data,
                                TDead = resultData.TargetsDeadTroop,
                                WarLoot = resultData.LootedScrap,
                                TWall = resultData.WallLevel,
                                TUserId = req.DefenserUserId,
                                TTroop = resultData.TargetsTroop,
                                TUsername = resultData.TargetUsername,
                                TScrap = resultData.DefenserScrap,
                                VictorySide = req.WinnerSide,
                                TGangId = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                TGangName = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                
                            });
                            await _context.SaveChangesAsync();
                            Player.SendNewsRefreshNeeded(req.DefenserUserId);
                            
                            await _context.AddAsync(new News()
                            {
                                UserId = req.AttackerUserId,
                                Title = req.WinnerSide == (byte)AttackSideEnum.Attacker ? "ATTACK SUCCEED" : "ATTACK FAILED",
                                Seen = false,
                                Date = DateTimeOffset.UtcNow,
                                Detail = $"Results of your attack ",
                                IsActive = true,
                                TypeId = (int)NewsType.Attack,
                                ACoord = DbService.GetUserCoordinate(req.AttackerUserId).Result.Data,
                                ATroop = req.AttackerTroopCount,
                                AGangId = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                AUsername = req.AttackerUsername,
                                AGangName = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                AUserId = req.AttackerUserId,
                                ADead = resultData.AttackersDeadTroop,
                                APrisoner = req.WinnerSide == (byte)AttackSideEnum.Attacker ? resultData.PrisonerCount:0,
                                TPrisoner = req.WinnerSide == (byte)AttackSideEnum.Defenser ? resultData.PrisonerCount:0,
                                AWounded = resultData.AttackersWoundedTroop,
                                TWounded = resultData.TargetsWoundedTroop,
                                ProcessDate = req.ArriveDate.ToDateTimeOffsetUtc(),
                                TCoord = DbService.GetUserCoordinate(req.DefenserUserId).Result.Data,
                                TDead = resultData.TargetsDeadTroop,
                                WarLoot = resultData.LootedScrap,
                                TWall = resultData.WallLevel,
                                TUserId = req.DefenserUserId,
                                TTroop = resultData.TargetsTroop,
                                TUsername = resultData.TargetUsername,
                                TScrap = resultData.DefenserScrap,
                                VictorySide = req.WinnerSide,
                                TGangId = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                TGangName = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                            });
                            await _context.SaveChangesAsync();
                            Player.SendNewsRefreshNeeded(req.AttackerUserId);
                            
                            break; 
                        case (not null, false):
                            var resultData2 = JsonConvert.DeserializeObject<AttackResultData>(req.ResultData);
                            await _context.AddAsync(new News()
                            {
                                UserId = req.AttackerUserId,
                                Title = "YOUR TROOPS COME BACK",
                                Seen = false,
                                Date = DateTimeOffset.UtcNow,
                                Detail = $"Your troops come to back your base. Check the hospital.",
                                IsActive = true,
                                TypeId = (int)NewsType.Attack,
                                ACoord = DbService.GetUserCoordinate(req.AttackerUserId).Result.Data,
                                ATroop = req.AttackerTroopCount,
                                AGangId = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                AUsername = req.AttackerUsername,
                                AGangName = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                AUserId = req.AttackerUserId,
                                ADead = resultData2.AttackersDeadTroop,
                                APrisoner = req.WinnerSide == (byte)AttackSideEnum.Attacker ? resultData2.PrisonerCount:0,
                                TPrisoner = req.WinnerSide == (byte)AttackSideEnum.Defenser ? resultData2.PrisonerCount:0,
                                AWounded = resultData2.AttackersWoundedTroop,
                                TWounded = resultData2.TargetsWoundedTroop,
                                ProcessDate = req.ArriveDate.ToDateTimeOffsetUtc(),
                                TCoord = DbService.GetUserCoordinate(req.DefenserUserId).Result.Data,
                                TDead = resultData2.TargetsDeadTroop,
                                WarLoot = resultData2.LootedScrap,
                                TWall = resultData2.WallLevel,
                                TUserId = req.DefenserUserId,
                                TTroop = resultData2.TargetsTroop,
                                TUsername = resultData2.TargetUsername,
                                TScrap = resultData2.DefenserScrap,
                                VictorySide = req.WinnerSide,
                                TGangId = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                TGangName = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                            });
                            await _context.SaveChangesAsync();
                            Player.SendNewsRefreshNeeded(req.AttackerUserId);
                            break;
                    }

                    
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                response.SetError(OperationMessages.DbError);
            }
            return response;

        }

        public async Task<TDResponse> CollectLootRunByNewsId(string newsId)
        {
            TDResponse response = new TDResponse();
            try
            {
                using (var _context = new WebSocketContext())
                {
                    var newsGuid = new Guid(newsId);
                    var collectable =await _context.News
                        .Where(l => l.Id == newsGuid && l.IsCollected == false && l.TypeId==(int)NewsType.LootRun)
                        .FirstOrDefaultAsync();
                    if (collectable?.GainedResources==null)
                    {
                        response.SetError();
                        return response;
                    }
                    var resources =
                        JsonConvert.DeserializeObject<LootRunDoneInfoDTO>(collectable.GainedResources);
                    if (resources==null)
                    {
                        response.SetError();
                        return response;
                    }
                    var result=await DbService.SendLootGifts(new PlayerBaseInfoDTO()
                    {
                        Gems = resources.GemCount,
                        Scraps = resources.ScrapCount,
                        BluePrints = resources.BluePrintCount,
                        UserId = collectable.UserId ?? 1,
                    });
                    if (!result.HasError)
                    {
                        collectable.IsCollected = true;
                        await _context.SaveChangesAsync();
                    }
                    response.SetSuccess();
                }

            }
            catch (Exception e)
            {
                response.SetError(OperationMessages.DbError);
                Console.WriteLine(e);
            }
            return response;

        }

    }
}
