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
using static System.Net.Mime.MediaTypeNames;
using System.Numerics;

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
                    await SendNews(_context, player.UniqueId, userActivity);
                    await SendChatRooms(_context, player, userActivity);
                }
            }
            catch (Exception e)
            {

            }
        }


        public static async Task SendNews(WebSocketContext? _context, long userId, UserActivity? userActivity)
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
                var newsQuery = await _context.News.Where(l => l.UserId == userId && l.IsActive).OrderByDescending(l => l.Date).Take(10)
                    .Select(l => new NewsDTO()
                    {
                        Casualities = l.Casualities,
                        Date = l.Date.ToString(),
                        Detail = l.Detail,
                        GainedResources = l.GainedResources,
                        LostResource = l.LostResource,
                        Prisoners = l.Prisoners,
                        Seen = l.Seen,
                        TypeId = l.TypeId,
                        Title = l.Title,
                        Wounded = l.Wounded,
                        Id = l.Id.ToString()
                    })
                    .ToListAsync();
                userActivity.LastNewsCheck = DateTimeOffset.Now;
                await _context.SaveChangesAsync();
                Player.SendNewNews(userId, newsQuery);
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
                        Title = "Loot Run Succeed",
                        Detail = "Congrats your loot run done!",
                        IsActive = true,
                        GainedResources = item.ToString(),
                        UserId = player.UniqueId,
                        Seen = false,
                        TypeId = (int)NewsType.LootRun
                    });
                }

                await _context.SaveChangesAsync();

                Message lootMessage = Message.Create(MessageSendMode.Reliable, MessageEndpointId.ActiveLootRuns);
                lootMessage.AddModel(res.ActiveLootRuns);
                ServerProgram.server.Send(lootMessage, ServerProgram.server.Clients.First(l => l.Id == player.Id));
                if (sendNews)
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

                var globalChat = await _context.ChatRoom.Where(l => l.ChatRoomTypeId == (int)ChatRoomTypeEnum.GlobalChat && l.IsActive).FirstOrDefaultAsync();
                var serverChat = await _context.ChatRoom.Where(l => l.ChatRoomTypeId == (int)ChatRoomTypeEnum.ServerChat && l.IsActive).FirstOrDefaultAsync();
                var raceChatId = await _context.ChatRoom.Where(l => (player.IsApe ? (l.ChatRoomTypeId == (int)ChatRoomTypeEnum.ApeChat) : (l.ChatRoomTypeId == (int)ChatRoomTypeEnum.HumanChat)) && l.IsActive).FirstOrDefaultAsync();
                var gangId = await _context.GangMember.Include(l => l.MemberType).ThenInclude(l => l.Gang).Where(l => l.UserId == player.UniqueId && l.MemberType.IsActive && l.MemberType.Gang.IsActive)
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


    }
}
