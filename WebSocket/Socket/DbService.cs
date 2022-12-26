using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Riptide;
using SharedLibrary.Models;
using SharedLibrary.Helpers;
using SharedLibrary.Models.Loot;
using System.Net.Http.Headers;
using System.Text;
using WebSocket.Entities;
using WebSocket.Enums;
using WebSocket.Helpers;
using WebSocket.Models;
namespace WebSocket.Socket
{
    public class DbService
    {
        public static async Task SetUserActivity(Player player, DateTimeOffset LastConnection, bool IsConnectedNow)
        {
            try
            {
                using (var _context = new WebSocketContext())
                {
                    var q = await _context.UserActivity.Where(l => l.UserId == player.UniqueId).FirstOrDefaultAsync();
                    if (q != null)
                    {
                        q.LastConnection = LastConnection;
                        q.IsConnectedNow = IsConnectedNow;
                    }
                    else
                    {
                        await _context.AddAsync(new UserActivity()
                        {
                            UserId = player.UniqueId,
                            LastConnection = LastConnection,
                            IsConnectedNow = IsConnectedNow,
                            LastNewsCheck = new DateTimeOffset(1997, 4, 10, 10, 10, 0, TimeSpan.FromHours(0))
                        });
                    }
                    await _context.SaveChangesAsync();
                }
                if (IsConnectedNow)
                {
                    SendSomethingInStart(player);
                }
            }
            catch (Exception e)
            {

            }

        }

        private static async Task SendSomethingInStart(Player player)
        {
            try
            {
                using (var _context = new WebSocketContext())
                {
                    var userActivity = await _context.UserActivity.Where(l => l.UserId == player.UniqueId).FirstOrDefaultAsync();
                    await RefreshLootRuns(_context, player, userActivity);
                    await SendNews(_context, player.UniqueId, userActivity,null);
                    await SendChatRooms(_context, player, userActivity);
                    await SendActiveInteractions(_context, player);
                    await SendGangApplications(_context, player);
                }
            }
            catch (Exception e)
            {

            }
        }
        
        public static async Task SendGangApplications(WebSocketContext? _context, Player player)
        {
            try
            {
                var g = _context;
                if (_context == null)
                {
                    _context = new WebSocketContext();
                }

                var gangMember = await _context.GangMember
                    .Where(l => l.UserId == player.UniqueId && l.IsActive && l.MemberType.IsActive &&
                                l.MemberType.Gang.IsActive)
                    .FirstOrDefaultAsync();
                if (gangMember!=null && gangMember.MemberType.CanAcceptMember )
                {
                    var gangAppCount = await _context.GangApplication
                        .Where(l => l.GangId == gangMember.MemberType.GangId).CountAsync();
                    Player.SendGangApplicationCount(player.UniqueId,gangAppCount);
                }
                if (g == null)
                {
                    _context.Dispose();
                }
            }
            catch (Exception e)
            {

            }
        }


        public static async Task SendNews(WebSocketContext? _context, long userId, UserActivity? userActivity,string? lastMessageDate)
        {
            try
            {
                var g = _context;
                if (_context == null)
                {
                    _context = new WebSocketContext();
                }
                if (userActivity == null)
                {
                    userActivity = await _context.UserActivity.Where(l => l.UserId == userId).FirstOrDefaultAsync();
                }
                var importantNews = await _context.News.Where(l => l.IsActive && l.Date > userActivity.LastNewsCheck && l.UserId == null).OrderByDescending(l => l.Date).ThenBy(l => l.Title).ToListAsync();
                foreach (var item in importantNews)
                {
                    _context.News.Add(new News()
                    {
                        IsActive = true,
                        Title = item.Title,
                        Detail = item.Detail,
                        Date = item.Date,
                        Seen = false,
                        TypeId = item.TypeId,
                        UserId = userId

                    });
                }
                await _context.SaveChangesAsync();
                var lastDate=lastMessageDate.ToDateTimeOffsetUtc();
                var newsQuery = await _context.News
                    .Where(l => l.UserId == userId && l.IsActive &&(lastDate==null ? true:l.Date>lastDate))
                    .OrderByDescending(l => l.Date).Take(10)
                    .Select(l => new NewsDTO()
                    {
                        Id = l.Id.ToString(),
                        Title = l.Title,
                        Detail = l.Detail,
                        TypeId = l.TypeId,
                        GainedResources = l.GainedResources,
                        ADead = l.ADead,
                        ACoord = l.ACoord,
                        AHeroId = l.AHeroId,
                        AHeroName = l.AHeroName,
                        TCoord = l.TCoord,
                        APrisoner = l.APrisoner,
                        ATroop = l.ATroop,
                        AUsername = l.AUsername,
                        AWounded = l.AWounded,
                        ProcessDate = l.ProcessDate.ToString(),
                        TDead = l.TDead,
                        TPrisoner = l.TPrisoner,
                        TScrap = l.TScrap,
                        TTroop = l.TTroop,
                        TUsername = l.TUsername,
                        TWall = l.TWall,
                        TWounded = l.TWounded,
                        VictorySide = l.VictorySide,
                        WarLoot = l.WarLoot,
                        AGangId = l.AGangId,
                        AGangName = l.AGangName,
                        AUserId = l.AUserId,
                        TGangId = l.TGangId,
                        TGangName = l.TGangName,
                        TUserId = l.TUserId,
                        Date = l.Date.ToString(),
                        IsCollected = l.IsCollected,
                        Seen = l.Seen,
                        IsActive = l.IsActive,
                        TUserAvatar = l.TUserAvatar,
                        ACombatPower = l.ACombatPower,
                        AUserAvatar = l.AUserAvatar,
                        TCombatPower = l.TCombatPower,
                        AGangAvatarId = l.AGangAvatarId,
                        TGangAvatarId = l.TGangAvatarId
                    })
                    .ToListAsync();
                userActivity.LastNewsCheck = DateTimeOffset.UtcNow;
                await _context.SaveChangesAsync();
                Player.SendNewNews(userId, newsQuery);
                if (newsQuery.Any(l=>l.Seen==false))
                {
                    Player.SendNewsRefreshNeeded(userId);
                }
                if (g == null)
                {
                    _context.Dispose();
                }
            }
            catch (Exception e)
            {

            }
        }
        public static async Task SendActiveInteractions(WebSocketContext? _context, Player player)
        {
            try
            {
                var g = _context;
                if (_context == null)
                {
                    _context = new WebSocketContext();
                }

                var allInteractions = GetActiveInteractions(player.UniqueId,player.GetToken(),player.GetInfo()).Result;
                
                
                await _context.SaveChangesAsync();
                foreach (var scout in allInteractions.ActiveScoutList)
                {
                    if (scout.ComeBackDate ==null)
                    {
                        continue;
                    }

                    Player.SendNewInteraction(player.UniqueId,new NewsDTO()
                    {
                        Title = $"SCOUT (not necessary)",
                        Seen = false,
                        Date = scout.ComeBackDate,
                        Detail = $"not necessary",
                        IsActive = true,
                        TypeId = (int)NewsType.Scout,
                        ACoord = DbService.GetUserCoordinate(scout.SenderUserId).Result.Data,
                        AGangId = _context.GangMember.Where(l=>l.UserId==scout.SenderUserId && l.IsActive)
                            .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                        AUsername = scout.SenderUserName,
                        AGangName = _context.GangMember.Where(l=>l.UserId==scout.SenderUserId &&l.IsActive)
                            .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                        AUserId = scout.SenderUserId,
                        ProcessDate = scout.ArrivedDate,
                        TCoord = DbService.GetUserCoordinate(scout.TargetUserId).Result.Data,
                        TUsername = scout.TargetUserName,
                        TGangId = _context.GangMember.Where(l=>l.UserId==scout.TargetUserId && l.IsActive)
                            .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                        TGangName = _context.GangMember.Where(l=>l.UserId==scout.TargetUserId&& l.IsActive)
                            .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                        TUserId = scout.TargetUserId,
                        Id = scout.Id.ToString()
                    });

                }
                
                foreach (var attack in allInteractions.ActiveAttackList)
                {
                    if (attack.ComeBackDate ==null)
                    {
                        continue;
                    }

                    Player.SendNewInteraction(player.UniqueId,new NewsDTO()
                    {
                        Title = $"ATTACK (not necessary)",
                        Seen = false,
                        Date = attack.ComeBackDate,
                        Detail = $"not necessary",
                        IsActive = true,
                        TypeId = (int)NewsType.Attack,
                        ACoord = DbService.GetUserCoordinate(attack.AttackerUserId).Result.Data,
                        AGangId = _context.GangMember.Where(l=>l.UserId==attack.AttackerUserId&& l.IsActive)
                            .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                        AUsername = attack.AttackerUsername,
                        AGangName = _context.GangMember.Where(l=>l.UserId==attack.AttackerUserId&& l.IsActive)
                            .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                        AUserId = attack.AttackerUserId,
                        AHeroId = attack.AttackerHeroId,
                        AHeroName = attack.AttackerHeroName,
                        ATroop = attack.AttackerTroopCount,
                        ProcessDate = attack.ArriveDate,
                        TCoord = DbService.GetUserCoordinate(attack.DefenserUserId).Result.Data,
                        TUsername = attack.DefenserUsername,
                        TGangId = _context.GangMember.Where(l=>l.UserId==attack.DefenserUserId&& l.IsActive)
                            .Select(l=>l.MemberType.Gang.Id).FirstOrDefault().ToString(),
                        TGangName = _context.GangMember.Where(l=>l.UserId==attack.DefenserUserId&& l.IsActive)
                            .Select(l=>$"[{l.MemberType.Gang.ShortName}]{l.MemberType.Gang.Name}").FirstOrDefault(),
                        TUserId = attack.DefenserUserId,
                        Id = attack.Id.ToString(),
                    });

                }
                if (g == null)
                {
                    _context.Dispose();
                }
            }
            catch (Exception e)
            {

            }
        }
        public static async Task RefreshLootRuns(WebSocketContext? _context, Player player, UserActivity? userActivity, bool sendNews = false)
        {
            try
            {
                var g = _context;
                if (_context == null)
                {
                    _context = new WebSocketContext();
                }
                if (userActivity == null)
                {
                    userActivity = await _context.UserActivity.Where(l => l.UserId == player.UniqueId).FirstOrDefaultAsync();
                }

                var res = await GetActiveLootRuns(player.UniqueId, player.GetToken(), player.GetInfo());




                foreach (var item in res.GainedLootRuns)
                {
                    await _context.News.AddAsync(new News()
                    {
                        Date = item.EndDate.ToDateTimeOffsetUtc() ?? DateTimeOffset.UtcNow,
                        Title = "LOOT RUN SUCCEED",
                        Detail = "Congrats your loot run done!",
                        IsActive = true,
                        GainedResources = item.ToString(),
                        IsCollected = false,
                        UserId = player.UniqueId,
                        Seen = false,
                        TypeId = (int)NewsType.LootRun
                    });
                }

                await _context.SaveChangesAsync();

                Message lootMessage = Message.Create(MessageSendMode.Reliable, MessageEndpointId.ActiveLootRuns);
                lootMessage.AddModel(res.ActiveLootRuns);
                ServerProgram.server.Send(lootMessage, ServerProgram.server.Clients.First(l => l.Id == player.Id));
                if (sendNews && res.GainedLootRuns!=null && res.GainedLootRuns.Count>0)
                {
                    Player.SendNewsRefreshNeeded(player.UniqueId);
                }

                if (g == null)
                {
                    _context.Dispose();
                }
            }
            catch (Exception e)
            {

            }
        }

        public static async Task SendChatRooms(WebSocketContext? _context, Player player, UserActivity? userActivity)
        {
            try
            {
                var g = _context;
                if (_context == null)
                {
                    _context = new WebSocketContext();
                }
                if (userActivity == null)
                {
                    userActivity = await _context.UserActivity.Where(l => l.UserId == player.UniqueId).FirstOrDefaultAsync();
                }

                #region Username Changing

                var allmemberitys = await _context.ChatRoomMember.Where(l => l.UserId == player.UniqueId).ToListAsync();
                foreach (var m in allmemberitys)
                {
                    m.Username = player.Username;
                }

                await _context.SaveChangesAsync();
                #endregion

                var globalChat = await _context.ChatRoom.Where(l => l.ChatRoomTypeId == (int)ChatRoomTypeEnum.GlobalChat && l.IsActive).FirstOrDefaultAsync();
                var serverChat = await _context.ChatRoom.Where(l => l.ChatRoomTypeId == (int)ChatRoomTypeEnum.ServerChat && l.IsActive).FirstOrDefaultAsync();
                var raceChatId = await _context.ChatRoom.Where(l => (player.IsApe ? (l.ChatRoomTypeId == (int)ChatRoomTypeEnum.ApeChat) : (l.ChatRoomTypeId == (int)ChatRoomTypeEnum.HumanChat)) && l.IsActive).FirstOrDefaultAsync();
                var gangId = await _context.GangMember.Include(l => l.MemberType).ThenInclude(l => l.Gang).Where(l => l.UserId == player.UniqueId && l.MemberType.IsActive && l.MemberType.Gang.IsActive&& l.IsActive)
                    .Select(l => l.MemberType.GangId.ToString()).FirstOrDefaultAsync();
                if (gangId != null)
                {
                    var gangChatRoomId = await _context.ChatRoom.Where(l => l.ChatRoomTypeId == (int)ChatRoomTypeEnum.GangChat && l.Name == gangId).Select(l => l.Id).FirstOrDefaultAsync();
                    if (gangChatRoomId != null)
                    {
                        Player.SendGangChatId(player.UniqueId, gangChatRoomId.ToString());
                    }

                }

                Player.SendGlobalChat(player.UniqueId, globalChat?.Id.ToString() ?? "--");
                Player.SendServerChatId(player.UniqueId, serverChat?.Id.ToString() ?? "--");
                Player.SendRaceChatId(player.UniqueId, raceChatId!.Id.ToString());
                var dmRooms = await _context.ChatRoomMember
                    .Include(l => l.ChatRoom)
                    .Where(l => l.ChatRoom.ChatRoomTypeId == (int)ChatRoomTypeEnum.Dm && l.UserId == player.UniqueId && l.IsActive)
                    .Select(l => new ChatRoomDTO()
                    {
                        OtherPlayerId = _context.ChatRoomMember.Where(c => c.ChatRoomId == l.ChatRoomId && c.UserId != l.UserId).Select(z => z.UserId).FirstOrDefault(),
                        ChatRoomTypeId = l.ChatRoom.ChatRoomTypeId,
                        LastChangeDate = l.ChatRoom.LastChangeDate.ToString(),
                        Name = l.ChatRoom.Name,
                        Id = l.ChatRoom.Id.ToString()
                    })
                    .Distinct()
                    .ToListAsync();

                Player.SendDmRooms(player.UniqueId, dmRooms.Where(l => l.OtherPlayerId != player.UniqueId && l.OtherPlayerId != null).ToList());

                if (g == null)
                {
                    _context.Dispose();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static async Task CreateDm(Player player, long recieverUserId, string recieverUserName, int extentionTypeId, string text, string extention)
        {
            using (var _context = new WebSocketContext())
            {
                var chatRoom = new ChatRoom()
                {
                    CreatedDate = DateTimeOffset.UtcNow,
                    IsActive = true,
                    ChatRoomTypeId = (int)ChatRoomTypeEnum.Dm,
                    LastChangeDate = DateTimeOffset.UtcNow,
                    Name = $"{player.Username}*.-.*{recieverUserName}"
                };
                await _context.AddAsync(chatRoom);
                await _context.SaveChangesAsync();
                var chatRoomMember = new ChatRoomMember()
                {
                    IsActive = true,
                    UserId = recieverUserId,
                    ChatRoomId = chatRoom.Id,
                    JoinedRoomDate = DateTimeOffset.UtcNow,
                    Username = recieverUserName,
                    LastSeen = DateTimeOffset.UtcNow,

                };
                var senderMember = new ChatRoomMember()
                {
                    IsActive = true,
                    UserId = player.UniqueId,
                    ChatRoomId = chatRoom.Id,
                    JoinedRoomDate = DateTimeOffset.UtcNow,
                    Username = player.Username,
                    LastSeen = DateTimeOffset.UtcNow

                };
                await _context.AddAsync(chatRoomMember);
                await _context.AddAsync(senderMember);
                await _context.SaveChangesAsync();

                var chatMessage = new ChatMessage()
                {
                    SendedDate = DateTimeOffset.UtcNow,
                    ChatRoomMemberId = senderMember.Id,
                    ExtentionTypeId = extentionTypeId,
                    Extention = extention,
                    Text = text
                };
                await _context.AddAsync(chatMessage);
                await _context.SaveChangesAsync();
                var newChatRoomDto = new ChatRoomDTO()
                {
                    OtherPlayerId = recieverUserId,
                    ChatRoomTypeId = (int)ChatRoomTypeEnum.Dm,
                    LastChangeDate = DateTimeOffset.UtcNow.ToString(),
                    Name = chatRoom.Name,
                    Id = chatRoom.Id.ToString(),
                };

                Player.SendInitialRoom(player.UniqueId, newChatRoomDto);
                Player.SendInitialRoom(recieverUserId, newChatRoomDto);
            }
        }
        public static async Task SendChatMessage(Player player, string chatId, int extentionTypeId, string text, string extention)
        {
            using (var _context = new WebSocketContext())
            {

                var chatGuid = new Guid(chatId);
                var isGlobal = false;
                if (await _context.ChatRoom.Where(l => l.Id == chatGuid &&
                (l.ChatRoomTypeId == (int)ChatRoomTypeEnum.GlobalChat
                || l.ChatRoomTypeId == (int)ChatRoomTypeEnum.ServerChat
                || (l.ChatRoomTypeId == (int)ChatRoomTypeEnum.ApeChat && player.IsApe)
                || (l.ChatRoomTypeId == (int)ChatRoomTypeEnum.HumanChat && !player.IsApe)
                )).AnyAsync())//TODO: ozel chat kontrolleri yapılacak
                {
                    isGlobal = true;
                }
                var chatRoomMember = await _context.ChatRoomMember.Include(l => l.ChatRoom).Where(l => l.ChatRoomId == chatGuid && l.UserId == player.UniqueId && l.IsActive && l.ChatRoom.IsActive)
                    .FirstOrDefaultAsync();
                if (chatRoomMember == null && isGlobal)
                {
                    await _context.AddAsync(new ChatRoomMember()
                    {
                        ChatRoomId = chatGuid,
                        IsActive = true,
                        JoinedRoomDate = DateTimeOffset.UtcNow,
                        LastSeen = DateTimeOffset.UtcNow,
                        UserId = player.UniqueId,
                        Username = player.Username
                    });
                    await _context.SaveChangesAsync();
                    chatRoomMember = await _context.ChatRoomMember.Include(l => l.ChatRoom).Where(l => l.ChatRoomId == chatGuid && l.UserId == player.UniqueId && l.IsActive && l.ChatRoom.IsActive)
                    .FirstOrDefaultAsync();
                }
                if (chatRoomMember == null)
                {
                    Console.WriteLine("chatroommember_null");
                    return;
                }
                var chatMessage = new ChatMessage()
                {
                    SendedDate = DateTimeOffset.UtcNow,
                    ChatRoomMemberId = chatRoomMember.Id,
                    ExtentionTypeId = extentionTypeId,
                    Extention = extention,
                    Text = text
                };
                await _context.AddAsync(chatMessage);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {

                    var c = e;
                }

                Player.RoomRefreshNeeded(chatRoomMember.ChatRoomId.ToString());
            }
        }
        
         public static async Task SeenReport(string reportId)
        {
            using (var _context = new WebSocketContext())
            {

                var reportGuid = new Guid(reportId);
                var news = await _context.News
                    .Where(l => l.Id == reportGuid)
                    .FirstOrDefaultAsync();
                if (news!=null)
                {
                    news.Seen = true;
                }
                
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {

                    var c = e;
                }

            }
        }

        public static async Task GetChatMessagesFromLastMessageDate(Player player, string chatId, string? lastMessageDate)
        {
            using (var _context = new WebSocketContext())
            {

                var chatGuid = new Guid(chatId);
                var canSeeMessage = await _context.ChatRoomMember
                    .Include(l => l.ChatRoom)
                    .Where(l => l.ChatRoomId == chatGuid && l.UserId == player.UniqueId && l.IsActive && l.ChatRoom.IsActive).AnyAsync();
                if (await _context.ChatRoom.Where(l => l.Id == chatGuid && (l.ChatRoomTypeId == (int)ChatRoomTypeEnum.GlobalChat || l.ChatRoomTypeId == (int)ChatRoomTypeEnum.ServerChat)).AnyAsync())//TODO: ozel chat kontrolleri yapılacak
                {
                    canSeeMessage = true;
                }
                if (!canSeeMessage)
                {
                    return;
                }


                DateTimeOffset? date = lastMessageDate?.ToDateTimeOffsetUtc();
                var chatMessages = await _context.ChatMessage.Include(l => l.ChatRoomMember).ThenInclude(l => l.ChatRoom)
                    .Where(l => l.ChatRoomMember.ChatRoomId == chatGuid && (date == null ? true : l.SendedDate > date)).OrderByDescending(l => l.SendedDate).Take(25).OrderBy(l => l.SendedDate)
                    .Select(l => new ChatMessageDTO()
                    {
                        Id = l.Id.ToString(),
                        Extention = l.Extention,
                        ExtentionTypeId = l.ExtentionTypeId,
                        SendedDate = l.SendedDate.ToString(),
                        SenderUserId = l.ChatRoomMember.UserId,
                        SenderIsActive = l.ChatRoomMember.IsActive,
                        SenderUsername = l.ChatRoomMember.Username,
                        Text = l.Text
                    })
                    .ToListAsync();
                for (int i = 0; i < (chatMessages.Count / 5) + 1; i++)
                {
                    var chatMessagesList = chatMessages.Skip(i * 5).Take(5).ToList();
                    var m = Message.Create(MessageSendMode.Reliable, MessageEndpointId.GetChatMessagesFromLastMessageDate);
                    m.AddInt(i == (chatMessages.Count / 5) ? 2 : i == 0 ? 0 : 1);
                    m.AddString(chatId);
                    m.AddModel(chatMessagesList);
                    ServerProgram.server.Send(m, player.Id);
                    Thread.Sleep(10);
                }

            }
        }
        public static async Task GetChatMessagesFromFirstMessageDate(Player player, string chatId, string? firstMessageDate)
        {
            using (var _context = new WebSocketContext())
            {

                var chatGuid = new Guid(chatId);
                var canSeeMessage = await _context.ChatRoomMember
                    .Include(l => l.ChatRoom)
                    .Where(l => l.ChatRoomId == chatGuid && l.UserId == player.UniqueId && l.IsActive && l.ChatRoom.IsActive).AnyAsync();
                if (await _context.ChatRoom.Where(l => l.Id == chatGuid && l.ChatRoomTypeId == (int)ChatRoomTypeEnum.GlobalChat).AnyAsync())//TODO: ozel chat kontrolleri yapılacak
                {
                    canSeeMessage = true;
                }
                if (!canSeeMessage)
                {
                    return;
                }


                DateTimeOffset? date = firstMessageDate?.ToDateTimeOffsetUtc();
                var chatMessages = await _context.ChatMessage.Include(l => l.ChatRoomMember).ThenInclude(l => l.ChatRoom)
                    .Where(l => l.ChatRoomMember.ChatRoomId == chatGuid && (date == null ? true : l.SendedDate < date)).OrderBy(l => l.SendedDate).Take(25).OrderByDescending(l => l.SendedDate)
                    .Select(l => new ChatMessageDTO()
                    {
                        Id = l.Id.ToString(),
                        Extention = l.Extention,
                        ExtentionTypeId = l.ExtentionTypeId,
                        SendedDate = l.SendedDate.ToString(),
                        SenderUserId = l.ChatRoomMember.UserId,
                        SenderIsActive = l.ChatRoomMember.IsActive,
                        SenderUsername = l.ChatRoomMember.Username,
                        Text = l.Text
                    })
                    .ToListAsync();
                for (int i = 0; i < (chatMessages.Count / 5) + 1; i++)
                {
                    var chatMessagesList = chatMessages.Skip(i * 5).Take(5).ToList().OrderBy(l => l.SendedDate).ToList();
                    var m = Message.Create(MessageSendMode.Reliable, MessageEndpointId.GetChatMessagesFromFirstMessageDate);
                    m.AddInt(i == (chatMessages.Count / 5) ? 2 : i == 0 ? 0 : 1);
                    m.AddString(chatId);
                    m.AddModel(chatMessagesList);
                    ServerProgram.server.Send(m, player.Id);
                    Thread.Sleep(10);
                }

            }
        }




        private static async Task<LootRunResponse?> GetActiveLootRuns(long userId, string token, InfoDto info)
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
        
        private static async Task<InteractionsDTO?> GetActiveInteractions(long userId, string token, InfoDto info)
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) =>
                    { return true; }; //TODO: Prodda silinmeli

            using (HttpClient client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", token);

                var response = client.PostAsync(new Uri(Player.PlayerBaseUrl + "/api/PlayerBase/GetActiveInteractionsForSocket"),
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
                    var res = JsonConvert.DeserializeObject<TDResponse<InteractionsDTO>>(content)?.Data;
                    return res;
                }
                return null;
            }
        }

        public static async Task<TDResponse> SpendGangCreateMoney(string token, InfoDto info)
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) =>
                    { return true; }; //TODO: Prodda silinmeli

            using (HttpClient client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", token);

                var response = client.PostAsync(new Uri(Player.PlayerBaseUrl + "/api/PlayerBase/SpendGangCreateMoney"),
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
                    var res = JsonConvert.DeserializeObject<TDResponse>(content);
                    return res;
                }
                return null;
            }
        }
        
        public static async Task<TDResponse> SendLootGifts(PlayerBaseInfoDTO pb)
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) =>
                { return true; }; //TODO: Prodda silinmeli

            using (HttpClient client = new HttpClient(handler))
            {

                var response = client.PostAsync(new Uri(Player.PlayerBaseUrl + "/api/PlayerBase/UpdateOrCreatePlayerBaseInfo"),
                    new StringContent(JsonConvert.SerializeObject(
                        new BaseRequest<PlayerBaseInfoDTO>()
                        {
                            Data = pb,
                            Info = new InfoDto()
                            {
                                DeviceId = "_socket_",
                                OsVersion = "_socket_",
                                AppVersion = "_socket_",
                                DeviceModel = "_socket_",
                                DeviceType = "_socket_",
                                UserId = 0,
                                Ip = "_socket_"
                            }
                        }
                    ), Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var res = JsonConvert.DeserializeObject<TDResponse>(content);
                    return res;
                }
                return null;
            }
        }
        
        public static async Task<TDResponse<string>> GetUserCoordinate(long id)
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) =>
                { return true; }; //TODO: Prodda silinmeli

            using (HttpClient client = new HttpClient(handler))
            {

                var response = client.PostAsync(new Uri(Player.MapApiUrl + "/api/Map/GetUserCoordinate"),
                    new StringContent(JsonConvert.SerializeObject(
                        new BaseRequest<long>()
                        {
                            Data = id,
                            Info = new InfoDto()
                            {
                                DeviceId = "_socket_",
                                OsVersion = "_socket_",
                                AppVersion = "_socket_",
                                DeviceModel = "_socket_",
                                DeviceType = "_socket_",
                                UserId = 0,
                                Ip = "_socket_"
                            }
                        }
                    ), Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var res = JsonConvert.DeserializeObject<TDResponse<string>>(content);
                    return res;
                }
                return null;
            }
        }


    }
}
