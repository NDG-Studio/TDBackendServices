﻿using Microsoft.EntityFrameworkCore;
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
                    await SendChatRooms(_context, player.UniqueId, userActivity);
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

        public static async Task SendChatRooms(WebSocketContext? _context, long userId, UserActivity? userActivity)
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

                var globalChat = await _context.ChatRoom.Where(l => l.ChatRoomTypeId == (int)ChatRoomTypeEnum.GlobalChat && l.IsActive).FirstOrDefaultAsync();
                var dmRooms = await _context.ChatMessage
                    .Include(l => l.ChatRoomMember).ThenInclude(l => l.ChatRoom)
                    .Where(l => l.ChatRoomMember.ChatRoom.ChatRoomTypeId == (int)ChatRoomTypeEnum.Dm && l.ChatRoomMember.UserId == userId && l.ChatRoomMember.IsActive)
                    .Select(l => l.ChatRoomMember.ChatRoom)
                    .Distinct()
                    .ToListAsync();

                Player.SendGlobalChat(userId, globalChat?.Id.ToString() ?? "--");
                Player.SendDmRooms(userId, dmRooms);

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

                Player.SendInitialRoom(recieverUserId, chatRoom.Id.ToString(), chatRoom.Name, chatRoom.LastChangeDate.ToString());
                Player.SendInitialRoom(player.UniqueId, chatRoom.Id.ToString(), chatRoom.Name, chatRoom.LastChangeDate.ToString());
            }
        }
        public static async Task SendChatMessage(Player player, string chatId, int extentionTypeId, string text, string extention)
        {
            using (var _context = new WebSocketContext())
            {
                if (true)//TODO: ozel chat kontrolleri yapılacak
                {

                }
                var chatGuid = new Guid(chatId);
                var chatRoom = await _context.ChatRoomMember.Include(l => l.ChatRoom).Where(l => l.ChatRoomId == chatGuid && l.UserId == player.UniqueId && l.IsActive && l.ChatRoom.IsActive)
                    .Select(l => l.ChatRoom)
                    .FirstOrDefaultAsync();
                if (chatRoom == null)
                {
                    return;
                }
                var chatMessage = new ChatMessage()
                {
                    SendedDate = DateTimeOffset.UtcNow,
                    ChatRoomMemberId = chatRoom.Id,
                    ExtentionTypeId = extentionTypeId,
                    Extention = extention,
                    Text = text
                };
                await _context.AddAsync(chatMessage);
                await _context.SaveChangesAsync();

                Player.RoomRefreshNeeded(chatRoom.Id.ToString());
            }
        }

        public static async Task GetChatMessagesFromLastMessageDate(Player player, string chatId, string? lastMessageDate)
        {
            using (var _context = new WebSocketContext())
            {
                if (true)//TODO: ozel chat kontrolleri yapılacak
                {

                }

                var chatGuid = new Guid(chatId);
                var canSeeMessage = await _context.ChatRoomMember
                    .Include(l => l.ChatRoom)
                    .Where(l => l.ChatRoomId == chatGuid && l.UserId == player.UniqueId && l.IsActive && l.ChatRoom.IsActive).AnyAsync();
                if (!canSeeMessage)
                {
                    return;
                }


                DateTimeOffset? date = lastMessageDate?.ToDateTimeOffsetUtc();
                var chatMessages = await _context.ChatMessage   //.Include(l => l.ChatRoomMember).ThenInclude(l => l.ChatRoom)
                    .Where(l => l.ChatRoomMember.ChatRoomId == chatGuid && (date == null ? true : l.SendedDate < date)).OrderByDescending(l => l.SendedDate)
                    .Select(l => l)
                    .ToListAsync();

                for (int i = 0; i < (chatMessages.Count / 5) + 1; i++)
                {
                    var chatRoomList = chatMessages.Skip(i * 5).Take(5).ToList();
                    var m = Message.Create(MessageSendMode.Reliable, MessageEndpointId.GetChatMessagesFromLastMessageDate);
                    m.AddModel(chatRoomList);
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
