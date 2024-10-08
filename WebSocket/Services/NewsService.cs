﻿using AutoMapper;
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
using WebSocket.Socket;

namespace WebSocket.Services
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
                                AGangAvatarId = _context.GangMember.Where(l=>l.UserId==req.SenderUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.AvatarId).FirstOrDefault(),
                                AGangId = _context.GangMember.Where(l=>l.UserId==req.SenderUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                AUsername = req.SenderUserName,
                                AGangName = _context.GangMember.Where(l=>l.UserId==req.SenderUserId&& l.IsActive)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                AUserId = req.SenderUserId,
                                ADead = req.AttackerDeadSpyCount,
                                TDead = req.DefenserDeadSpyCount,
                                TWounded = req.DefenserSpyCount,
                                AWounded = req.AttackerSpyCount,
                                ProcessDate = req.ArrivedDate,
                                TCoord = DbService.GetUserCoordinate(req.TargetUserId).Result.Data,
                                TUsername = req.TargetUserName,
                                TGangAvatarId = _context.GangMember.Where(l=>l.UserId==req.TargetUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.AvatarId).FirstOrDefault(),
                                TGangId = _context.GangMember.Where(l=>l.UserId==req.TargetUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                TGangName = _context.GangMember.Where(l=>l.UserId==req.TargetUserId&& l.IsActive)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                TUserId = req.TargetUserId,
                                Id = req.Id.ToString(),
                                AUserAvatar = req.SenderAvatarId,
                                TUserAvatar = req.TargetAvatarId
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
                                 AGangAvatarId = _context.GangMember.Where(l=>l.UserId==req.SenderUserId&& l.IsActive)
                                     .Select(l=>l.MemberType.Gang.AvatarId).FirstOrDefault(),
                                 AGangId = _context.GangMember.Where(l=>l.UserId==req.SenderUserId&& l.IsActive)
                                     .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                 AUsername = req.SenderUserName,
                                 AGangName = _context.GangMember.Where(l=>l.UserId==req.SenderUserId&& l.IsActive)
                                     .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                 AUserId = req.SenderUserId,
                                 ADead = req.AttackerDeadSpyCount,
                                 TDead = req.DefenserDeadSpyCount,
                                 TWounded = req.DefenserSpyCount,
                                 AWounded = req.AttackerSpyCount,
                                 ProcessDate = req.ArrivedDate,
                                 TCoord = DbService.GetUserCoordinate(req.TargetUserId).Result.Data,
                                 TUsername = req.TargetUserName,
                                 TGangAvatarId = _context.GangMember.Where(l=>l.UserId==req.TargetUserId&& l.IsActive)
                                     .Select(l=>l.MemberType.Gang.AvatarId).FirstOrDefault(),
                                 TGangId = _context.GangMember.Where(l=>l.UserId==req.TargetUserId&& l.IsActive)
                                     .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                 TGangName = _context.GangMember.Where(l=>l.UserId==req.TargetUserId&& l.IsActive)
                                     .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                 TUserId = req.TargetUserId,
                                 Id = req.Id.ToString(),
                                 AUserAvatar = req.SenderAvatarId,
                                 TUserAvatar = req.TargetAvatarId
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
                                AGangAvatarId = _context.GangMember.Where(l=>l.UserId==req.SenderUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.AvatarId).FirstOrDefault(),
                                AGangId = _context.GangMember.Where(l=>l.UserId==req.SenderUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                AUsername = req.SenderUserName,
                                AGangName = _context.GangMember.Where(l=>l.UserId==req.SenderUserId&& l.IsActive)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                AUserId = req.SenderUserId,
                                ProcessDate = DateTimeOffset.UtcNow,
                                TCoord = DbService.GetUserCoordinate(req.TargetUserId).Result.Data,
                                TScrap = scoutedData.ScrapCount,
                                TTroop = scoutedData.TroopCount,
                                ADead = req.AttackerDeadSpyCount,
                                TDead = req.DefenserDeadSpyCount,
                                TWounded = req.DefenserSpyCount,
                                AWounded = req.AttackerSpyCount,
                                TWall = scoutedData.WallLevel,
                                TUsername = req.TargetUserName,
                                TUserId = req.TargetUserId,
                                TGangAvatarId = _context.GangMember.Where(l=>l.UserId==req.TargetUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.AvatarId).FirstOrDefault(),
                                TGangId = _context.GangMember.Where(l=>l.UserId==req.TargetUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                TGangName = _context.GangMember.Where(l=>l.UserId==req.TargetUserId&& l.IsActive)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                AUserAvatar = req.SenderAvatarId,
                                TUserAvatar = req.TargetAvatarId
                                
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
                                AGangAvatarId = _context.GangMember.Where(l=>l.UserId==req.SenderUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.AvatarId).FirstOrDefault(),
                                AGangId = _context.GangMember.Where(l=>l.UserId==req.SenderUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                AUsername = req.SenderUserName,
                                AGangName = _context.GangMember.Where(l=>l.UserId==req.SenderUserId&& l.IsActive)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                AUserId = req.SenderUserId,
                                ProcessDate = DateTimeOffset.UtcNow,
                                TCoord = DbService.GetUserCoordinate(req.TargetUserId).Result.Data,
                                TScrap = scoutedData.ScrapCount,
                                TTroop = scoutedData.TroopCount,
                                TWall = scoutedData.WallLevel,
                                TUsername = req.TargetUserName,
                                ADead = req.AttackerDeadSpyCount,
                                TDead = req.DefenserDeadSpyCount,
                                TWounded = req.DefenserSpyCount,
                                AWounded = req.AttackerSpyCount,
                                TUserId = req.TargetUserId,
                                TGangAvatarId = _context.GangMember.Where(l=>l.UserId==req.TargetUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.AvatarId).FirstOrDefault(),
                                TGangId = _context.GangMember.Where(l=>l.UserId==req.TargetUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                TGangName = _context.GangMember.Where(l=>l.UserId==req.TargetUserId&& l.IsActive)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                AUserAvatar = req.SenderAvatarId,
                                TUserAvatar = req.TargetAvatarId
                                
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
                                AGangAvatarId = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.AvatarId).FirstOrDefault(),
                                AGangId = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                AUsername = req.AttackerUsername,
                                AGangName = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId&& l.IsActive)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                AUserId = req.AttackerUserId,
                                AHeroId = req.AttackerHeroId,
                                AHeroName = req.AttackerHeroName,
                                ProcessDate = req.ArriveDate,
                                TCoord = DbService.GetUserCoordinate(req.DefenserUserId).Result.Data,
                                TUsername = req.DefenserUsername,
                                TGangAvatarId = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.AvatarId).FirstOrDefault(),
                                TGangId = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                TGangName = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId&& l.IsActive)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                TUserId = req.DefenserUserId,
                                Id = req.Id.ToString(),
                                AUserAvatar = req.AttackerAvatarId,
                                TUserAvatar = req.DefenserAvatarId,
                                ACombatPower = req.AttackerPower,
                                TCombatPower = req.DefenserPower
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
                                AGangAvatarId = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.AvatarId).FirstOrDefault(),
                                AGangId = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                AUsername = req.AttackerUsername,
                                AGangName = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId&& l.IsActive)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                AUserId = req.AttackerUserId,
                                AHeroId = req.AttackerHeroId,
                                AHeroName = req.AttackerHeroName,
                                ProcessDate = req.ArriveDate,
                                TCoord = DbService.GetUserCoordinate(req.DefenserUserId).Result.Data,
                                TUsername = req.DefenserUsername,
                                TGangAvatarId = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.AvatarId).FirstOrDefault(),
                                TGangId = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                TGangName = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId&& l.IsActive)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                TUserId = req.DefenserUserId,
                                Id = req.Id.ToString(),
                                AUserAvatar = req.AttackerAvatarId,
                                TUserAvatar = req.DefenserAvatarId,
                                ACombatPower = req.AttackerPower,
                                TCombatPower = req.DefenserPower,
                                ATroop = req.AttackerTroopCount,
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
                                AHeroId = req.AttackerHeroId,
                                AHeroName = req.AttackerHeroName,
                                ACoord = DbService.GetUserCoordinate(req.AttackerUserId).Result.Data,
                                ATroop = req.AttackerTroopCount,
                                AGangAvatarId = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.AvatarId).FirstOrDefault(),
                                AGangId = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                AUsername = req.AttackerUsername,
                                AGangName = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId&& l.IsActive)
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
                                TGangAvatarId = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.AvatarId).FirstOrDefault(),
                                TGangId = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                TGangName = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId&& l.IsActive)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                AUserAvatar = req.AttackerAvatarId,
                                TUserAvatar = req.DefenserAvatarId,
                                ACombatPower = req.AttackerPower,
                                TCombatPower = req.DefenserPower,
                                

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
                                AGangAvatarId = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.AvatarId).FirstOrDefault(),
                                AGangId = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                AUsername = req.AttackerUsername,
                                AGangName = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId&& l.IsActive)
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
                                TGangAvatarId = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.AvatarId).FirstOrDefault(),
                                TGangId = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                TGangName = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId&& l.IsActive)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                AUserAvatar = req.AttackerAvatarId,
                                TUserAvatar = req.DefenserAvatarId,
                                ACombatPower = req.AttackerPower,
                                TCombatPower = req.DefenserPower,
                                AHeroId = req.AttackerHeroId,
                                AHeroName = req.AttackerHeroName,
                                
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
                                AGangAvatarId = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.AvatarId).FirstOrDefault(),
                                AGangId = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                AUsername = req.AttackerUsername,
                                AGangName = _context.GangMember.Where(l=>l.UserId==req.AttackerUserId&& l.IsActive)
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
                                TGangAvatarId = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.AvatarId).FirstOrDefault(),
                                TGangId = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId&& l.IsActive)
                                    .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                                TGangName = _context.GangMember.Where(l=>l.UserId==req.DefenserUserId&& l.IsActive)
                                    .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                                AUserAvatar = req.AttackerAvatarId,
                                TUserAvatar = req.DefenserAvatarId,
                                ACombatPower = req.AttackerPower,
                                TCombatPower = req.DefenserPower,
                                AHeroId = req.AttackerHeroId,
                                AHeroName = req.AttackerHeroName
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
        
        
        
        
        public async Task<TDResponse> SendRallyNews(RallyDTO req)
        {
            TDResponse response = new TDResponse();
            try
            {

                using (var _context = new WebSocketContext())
                {
                    switch ((req.WinnerSide, req.IsActive))
                    { 
                        case (null,true):
                                
                                foreach (var part in req.RallyParts)
                                {
                                    var nws = new NewsDTO()
                                    {
                                        Title = $"Rally (not necessary)",
                                        Seen = false,
                                        Date = req.RallyStartDate??"",
                                        Detail = $"not necessary",
                                        IsActive = true,
                                        TypeId = (int)NewsType.Rally,
                                        ACoord = req.LeaderUserCoord,
                                        AGangAvatarId = req.LeaderGangAvatarId,
                                        AGangId = req.LeaderGangId,
                                        AUsername = req.LeaderUsername,
                                        AGangName = req.LeaderGangName,
                                        AUserId = req.LeaderUserId,
                                        ProcessDate = req.WarDate,
                                        TCoord = req.TargetUserCoord,
                                        TUsername = req.TargetUsername,
                                        TGangAvatarId = req.TargetGangAvatarId,
                                        TGangId = req.TargetGangId,
                                        TGangName = req.TargetGangName,
                                        TUserId = req.TargetUserId,
                                        TDead = req.TargetsDeadTroop,
                                        TPrisoner = 0,
                                        ADead = part.DeadTroop,
                                        APrisoner = part.PrisonerCount,
                                        AWounded = part.WoundedTroop,
                                        ATroop = part.TroopCount,
                                        TTroop = req.TargetsTroop,
                                        WarLoot = part.LootedScrap,
                                        TWounded = req.TargetsWoundedTroop,
                                        TWall = req.TargetWallLevel,
                                        TScrap = req.TargetScrap,
                                        VictorySide = req.WinnerSide,
                                    };
                                    Player.SendNewInteraction(part.UserId, nws);
                                    
                                }
                                var nwsDefenser = new NewsDTO()
                                    {
                                        Title = $"Rally (not necessary)",
                                        Seen = false,
                                        Date = DateTimeOffset.UtcNow.ToString(),
                                        Detail = $"not necessary",
                                        IsActive = true,
                                        TypeId = (int)NewsType.Rally,
                                        ACoord = req.LeaderUserCoord,
                                        AGangAvatarId = req.LeaderGangAvatarId,
                                        AGangId = req.LeaderGangId,
                                        AUsername = req.LeaderUsername,
                                        AGangName = req.LeaderGangName,
                                        AUserId = req.LeaderUserId,
                                        ProcessDate = req.WarDate,
                                        TCoord = req.TargetUserCoord,
                                        TUsername = req.TargetUsername,
                                        TGangAvatarId = req.TargetGangAvatarId,
                                        TGangId = req.TargetGangId,
                                        TGangName = req.TargetGangName,
                                        TUserId = req.TargetUserId,
                                    };
                                Player.SendNewInteraction(req.TargetUserId, nwsDefenser);
                                if (req.LeaderGangId!=null)
                                {
                                    var gangGuid = new Guid(req.LeaderGangId);
                                    var members=await _context.GangMember
                                        .Where(l => l.MemberType.GangId == gangGuid && l.IsActive &&
                                                    l.MemberType.IsActive && l.MemberType.Gang.IsActive)
                                        .Select(l => l.UserId).ToListAsync();
                                    members.ForEach(Player.SendNewRallyNotification);
                                }
                                
                                break;                        
                        case (not null,true):
                            foreach (var attackerNews in req.RallyParts.Select(part => new News()
                                     {
                                         Title = $"RALLY MISSION {(req.WinnerSide==(byte)AttackSideEnum.Attacker ? "SUCCEED" : "FAILED")}",
                                         Seen = false,
                                         Date = DateTimeOffset.UtcNow,
                                         Detail = $"Results of your attack",
                                         IsActive = true,
                                         TypeId = (int)NewsType.Rally,
                                         ACoord = req.LeaderUserCoord,
                                         AGangAvatarId = req.LeaderGangAvatarId,
                                         AGangId = req.LeaderGangId,
                                         AUsername = req.LeaderUsername,
                                         AGangName = req.LeaderGangName,
                                         AUserId = req.LeaderUserId,
                                         ProcessDate = req.WarDate?.ToDateTimeOffsetUtc(),
                                         TCoord = req.TargetUserCoord,
                                         TUsername = req.TargetUsername,
                                         TGangAvatarId = req.TargetGangAvatarId,
                                         TGangId = req.TargetGangId,
                                         TGangName = req.TargetGangName,
                                         TUserId = req.TargetUserId,
                                         TDead = req.TargetsDeadTroop,
                                         TPrisoner = 0,
                                         ADead = part.DeadTroop,
                                         APrisoner = part.PrisonerCount,
                                         AWounded = part.WoundedTroop,
                                         ATroop = part.TroopCount,
                                         TTroop = req.TargetsTroop,
                                         WarLoot = part.LootedScrap,
                                         TWounded = req.TargetsWoundedTroop,
                                         TWall = req.TargetWallLevel,
                                         TScrap = req.TargetScrap,
                                         UserId = part.UserId,
                                         VictorySide = req.WinnerSide,
                                     }))
                            {
                                _context.Add(attackerNews);
                                await _context.SaveChangesAsync();
                                if (attackerNews.UserId!=null)
                                {
                                    Player.SendNewsRefreshNeeded(attackerNews.UserId.Value);
                                }
                            }
                            
                            var defenserNews = new News()
                            {
                                Title = $"RALLY DEFENSE {(req.WinnerSide==(byte)AttackSideEnum.Defenser ? "SUCCEED" : "FAILED")}",
                                Seen = false,
                                Date = DateTimeOffset.UtcNow,
                                Detail = $"Results of your attack",
                                IsActive = true,
                                TypeId = (int)NewsType.Rally,
                                ACoord = req.LeaderUserCoord,
                                AGangAvatarId = req.LeaderGangAvatarId,
                                AGangId = req.LeaderGangId,
                                AUsername = req.LeaderUsername,
                                AGangName = req.LeaderGangName,
                                AUserId = req.LeaderUserId,
                                ProcessDate = req.WarDate?.ToDateTimeOffsetUtc(),
                                TCoord = req.TargetUserCoord,
                                TUsername = req.TargetUsername,
                                TGangAvatarId = req.TargetGangAvatarId,
                                TGangId = req.TargetGangId,
                                TGangName = req.TargetGangName,
                                TUserId = req.TargetUserId,
                                TDead = req.TargetsDeadTroop,
                                TPrisoner = 0,
                                ADead = req.ATotalDeadTroop,
                                APrisoner = req.PrisonerCount,
                                AWounded = req.ATotalWoundedTroop,
                                ATroop = req.ATotalTroop,
                                TTroop = req.TargetsTroop,
                                WarLoot = req.LootedScrap,
                                TWounded = req.TargetsWoundedTroop,
                                TWall = req.TargetWallLevel,
                                TScrap = req.TargetScrap,
                                UserId = req.TargetUserId,
                                VictorySide = req.WinnerSide,
                            };
                            _context.Add(defenserNews);
                            await _context.SaveChangesAsync();
                            if (defenserNews.UserId!=null)
                            {
                                Player.SendNewsRefreshNeeded(defenserNews.UserId.Value);
                            }
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
        
        public async Task<TDResponse> SendSupportNews(SupportUnitDTO req)
        {
            TDResponse response = new TDResponse();
            try
            {

                using (var _context = new WebSocketContext())
                {
                    switch (((SupportUnitState)req.State, req.IsActive))
                    { 
                        case (SupportUnitState.Pending,true):
                                
                                    var nws = new NewsDTO()
                                    {
                                        Title = $"Reinforce (not necessary)",
                                        Seen = false,
                                        Date = DateTimeOffset.UtcNow.ToString(),
                                        Detail = $"not necessary",
                                        IsActive = true,
                                        TypeId = (int)NewsType.Reinforcement,
                                        ACoord = req.ClientCoord,
                                        AGangAvatarId = null,
                                        AGangId = null,
                                        AUsername = req.ClientUsername ,
                                        AGangName = null,
                                        AUserId = req.ClientUserId,
                                        ProcessDate = req.ArrivedDate,
                                        TCoord = req.HostCoord,
                                        TUsername = req.HostUsername,
                                        TGangAvatarId = null,
                                        TGangId = null,
                                        TGangName = null,
                                        TUserId = req.HostUserId,
                                        TDead = null,
                                        TPrisoner = 0,
                                        ADead = null,
                                        TUserAvatar = req.HostAvatarId,
                                        AUserAvatar = req.ClientAvatarId,
                                        AHeroId = req.HeroId,
                                        AHeroName = req.HeroName
                                    };
                                    Player.SendNewInteraction(req.ClientUserId, nws);
                                    Player.SendNewInteraction(req.HostUserId, nws);
                                
                                break;                        
                        case (SupportUnitState.Returning,true):
                            var nwsR = new NewsDTO()
                            {
                                Title = $"Reinforce (not necessary)",
                                Seen = false,
                                Date = DateTimeOffset.UtcNow.ToString(),
                                Detail = $"not necessary",
                                IsActive = true,
                                TypeId = (int)NewsType.Reinforcement,
                                ACoord = req.ClientCoord,
                                AGangAvatarId = null,
                                AGangId = null,
                                AUsername = req.ClientUsername ,
                                AGangName = null,
                                AUserId = req.ClientUserId,
                                ProcessDate = req.ComeBackDate,
                                TCoord = req.HostCoord,
                                TUsername = req.HostUsername,
                                TGangAvatarId = null,
                                TGangId = null,
                                TGangName = null,
                                TUserId = req.HostUserId,
                                TDead = null,
                                TPrisoner = 0,
                                ADead = null,
                                TUserAvatar = req.HostAvatarId,
                                AUserAvatar = req.ClientAvatarId,
                                AHeroId = req.HeroId,
                                AHeroName = req.HeroName
                            };
                            Player.SendNewInteraction(req.ClientUserId, nwsR);
                            Player.SendNewInteraction(req.HostUserId, nwsR);
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
        
        public async Task<TDResponse> SendRallyNeedRefresh(RallyDTO req)
        {
            TDResponse response = new TDResponse();
            try
            {
                req.RallyParts.ForEach(l=> Player.SendRallyNeedRefresh(l.UserId));
                
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
