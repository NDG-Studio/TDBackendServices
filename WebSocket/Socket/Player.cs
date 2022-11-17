
using Newtonsoft.Json;
using PlayerBaseApi.Services;
using Riptide;
using SharedLibrary.Models;
using System.Net.Security;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;
using WebSocket.Entities;
using WebSocket.Enums;
using WebSocket.Helpers;
using WebSocket.Interfaces;
using WebSocket.Models;

namespace WebSocket.Socket
{
    public class Player
    {
        public static Dictionary<long, Player> list = new Dictionary<long, Player>();
        public static string IdentityUrl = "";
        public static string PlayerBaseUrl = "";
        public ushort Id { get; private set; }
        public string Username { get; private set; }
        public long UniqueId { get; private set; }
        private string Token { get; set; }
        public string GetToken() => Token;
        private InfoDto Info { get; set; }
        public InfoDto GetInfo() => Info;

        public static void Create(ushort id, long userId, string username, string token, InfoDto info)
        {
            Player player = new Player();
            player.Username = username;
            player.UniqueId = userId;
            player.Id = id;
            player.Token = token;
            player.Info = info;
            list.Add(userId, player);

            DbService.SetUserActivity(player, DateTimeOffset.Now, true);
        }


        #region MessageHandlers

        [Obsolete("deprecated")]
        [MessageHandler((ushort)MessageEndpointId.handshake)]
        private static void handshake(ushort fromClientId, Message message)
        {
            //var token = message.GetString();
            //var user = Checkuser(token);//token bilgisi kontrol ediliyor. token bozuksa veya kullanıcı zaten aktifse girişi engellenir.
            //if (user != null && !list.Where(l => l.Value.UniqueId == user.Id).Any())
            //{
            //    Create(fromClientId, user.Id, user.Username, token);
            //}
            //else
            //{
            //    ServerProgram.server.DisconnectClient(fromClientId);
            //}

        }

        public static void SetUrls()
        {
            IdentityUrl = Environment.GetEnvironmentVariable("Identity_Url") ?? "";
            PlayerBaseUrl = Environment.GetEnvironmentVariable("PlayerBase_Url") ?? "";
        }

        [MessageHandler((ushort)MessageEndpointId.RefreshNews)]
        private static void RefreshNews(ushort fromClientId, Message message)
        {
            var player = list.Values.FirstOrDefault(l => l.Id == fromClientId)?.UniqueId;
            if (player == null)
            {
                return;
            }
            DbService.SendNews(null, player.Value, null);

        }

        [MessageHandler((ushort)MessageEndpointId.RefreshActiveLoots)]
        private static void RefreshActiveLoots(ushort fromClientId, Message message)
        {
            var player = list.Values.FirstOrDefault(l => l.Id == fromClientId);
            if (player == null)
            {
                return;
            }
            DbService.RefreshLootRuns(null, player, null,true);

        }


        [MessageHandler((ushort)MessageEndpointId.CreateDm)]
        private static void CreateDm(ushort fromClientId, Message message)
        {
            var player = list.Values.FirstOrDefault(l => l.Id == fromClientId);
            if (player == null)
            {
                return;
            }
            var recieverUserId = message.GetLong();
            var recieverUserName = message.GetString();
            var extentionTypeId = message.GetInt();
            var text = message.GetString();
            var extention = message.GetString();
            DbService.CreateDm(player,recieverUserId,recieverUserName,extentionTypeId,text,extention);

        }


        [MessageHandler((ushort)MessageEndpointId.SendChatMessage)]
        private static void SendChatMessage(ushort fromClientId, Message message)
        {
            var player = list.Values.FirstOrDefault(l => l.Id == fromClientId);
            if (player == null)
            {
                return;
            }
            var chatId = message.GetString();
            var extentionTypeId = message.GetInt();
            var text = message.GetString();
            var extention = message.GetString();
            DbService.SendChatMessage(player,chatId,extentionTypeId,text,extention);

        }

        [MessageHandler((ushort)MessageEndpointId.GetChatMessagesFromLastMessageDate)]
        private static void GetChatMessagesFromLastMessageId(ushort fromClientId, Message message)
        {
            var player = list.Values.FirstOrDefault(l => l.Id == fromClientId);
            if (player == null)
            {
                return;
            }
            var chatId = message.GetString();
            var lastMessageDate = message.GetString();//default "--"
            DbService.GetChatMessagesFromLastMessageDate(player,chatId, lastMessageDate);

        }

        #endregion

        public static void SendInitialRoom(long userId,string ChatId,string Name, string LastChangeDate)
        {
            try
            {
                var m = Message.Create(MessageSendMode.Reliable, MessageEndpointId.InitialChatRoom);
                m.AddString(ChatId);
                m.AddString(Name);
                m.AddString(LastChangeDate);
                ServerProgram.server.Send(m, ServerProgram.server.Clients.First(l => l.Id == list[userId].Id));
            }
            catch (Exception e)
            {
                Console.WriteLine("hata:128", e);

            }
        }

        public static void RoomRefreshNeeded(string ChatId)
        {
            try
            {
                var m = Message.Create(MessageSendMode.Reliable, MessageEndpointId.RoomRefreshNeeded);
                m.AddString(ChatId);
                ServerProgram.server.SendToAll(m);
            }
            catch (Exception e)
            {
                Console.WriteLine("hata:128", e);

            }
        }

        public static void SendDmRooms(long userId,List<ChatRoom> chatRooms)
        {
            try
            {
                for (int i = 0; i < (chatRooms.Count / 5)+1; i++)
                {
                    var chatRoomList = chatRooms.Skip(i * 5).Take(5).Select(l=>new ChatRoomDTO()
                    {
                        Id=l.Id.ToString(),
                        ChatRoomTypeId=l.ChatRoomTypeId,
                        LastChangeDate=l.LastChangeDate.ToString(),
                        Name = l.Name
                    }).ToList();
                    var m = Message.Create(MessageSendMode.Reliable, MessageEndpointId.DmRooms);
                    m.AddBool(i==0);
                    m.AddModel(chatRoomList);
                    ServerProgram.server.Send(m, ServerProgram.server.Clients.First(l => l.Id == list[userId].Id));
                    Thread.Sleep(100);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("hata:149", e);
            }
        }

        public static void SendGlobalChat(long userId,string globalChatId)
        {
            try
            {
                    var m = Message.Create(MessageSendMode.Reliable, MessageEndpointId.GlobalChatRoom);
                    m.AddString(globalChatId);
                    ServerProgram.server.Send(m, ServerProgram.server.Clients.First(l => l.Id == list[userId].Id));
                    Thread.Sleep(100);

            }
            catch (Exception e)
            {
                Console.WriteLine("hata:149", e);
            }
        }

        private static UserDto? Checkuser(string token, InfoDto info)
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
            (
message,
cert,
chain,
errors
             ) =>
            { return true; }; //TODO: Prodda silinmeli

            using (HttpClient client = new HttpClient(handler))
            {
                //var request = new HttpRequestMessage
                //{
                //    Method = HttpMethod.Post,
                //    RequestUri = new Uri(_configuration["IdentityEndpoint"] + "/api/user/checkToken"),
                //    Content = new StringContent((new BaseRequest<string>() { Data = token, Info = info }).ToString()!, Encoding.UTF8, "application/json")

                //};

                var response = client.PostAsync(new Uri(IdentityUrl + "/api/user/checkToken"),
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
                    var user = JsonConvert.DeserializeObject<TDResponse<UserDto>>(content)?.Data;
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }


        public static void SendAllRawMessage(string message)
        {
            try
            {

                var m = Message.Create(MessageSendMode.Reliable, MessageEndpointId.rawMessage);
                m.AddString(message);
                ServerProgram.server.SendToAll(m);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public void SendRawMessage(string message)
        {
            try
            {

                var m = Message.Create(MessageSendMode.Reliable, MessageEndpointId.rawMessage);
                m.AddString(message);
                ServerProgram.server.Send(m, ServerProgram.server.Clients.First(l => l.Id == Id));
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public static void SendNewNews(long userId, List<NewsDTO> message)
        {
            try
            {

                var m = Message.Create(MessageSendMode.Reliable, MessageEndpointId.NewNews);
                m.AddModel(message);
                ServerProgram.server.Send(m, ServerProgram.server.Clients.First(l => l.Id == list[userId].Id));
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public static void SendAllNewsRefreshNeeded()
        {
            Message message = Message.Create(MessageSendMode.Reliable, MessageEndpointId.RefreshNews);
            ServerProgram.server.SendToAll(message);
        }

        public static bool SendNewsRefreshNeeded(long userId)
        {
            try
            {
                Message message = Message.Create(MessageSendMode.Reliable, MessageEndpointId.RefreshNews);
                ServerProgram.server.Send(message, ServerProgram.server.Clients.First(l => l.Id == list[userId].Id));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void KickPlayerByUniqueId(long id)
        {
            DbService.SetUserActivity(list[id], DateTimeOffset.Now, false);
            ServerProgram.server.DisconnectClient(list[id].Id);

        }

        public static void ConnectionAttemptHandler(Connection pendingConnection, Message connectMessage)
        {
            var token = connectMessage.GetString();
            var info = connectMessage.GetModel<InfoDto>();
            var user = Checkuser(token, info);//token bilgisi kontrol ediliyor. token bozuksa veya kullanıcı zaten aktifse girişi engellenir.
            var c = new Player();
            Connection conn = null;
            if (user == null || (list.TryGetValue(user.Id, out c) && ServerProgram.server.TryGetClient(list[user.Id].Id,out conn)))
            {
                ServerProgram.server.Reject(pendingConnection);
            }
            else
            {
                if (list.TryGetValue(user.Id,out c))
                {
                    list.Remove(user.Id);
                }
                ServerProgram.server.Accept(pendingConnection);
                Create(pendingConnection.Id, user.Id, user.Username, token, info);
            }
        }

    }
}
