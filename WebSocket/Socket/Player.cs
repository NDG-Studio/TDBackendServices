
using Newtonsoft.Json;
using PlayerBaseApi.Services;
using Riptide;
using SharedLibrary.Models;
using System.Net.Security;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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

        #endregion



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

        public static void SendNewsRefreshNeeded(long userId)
        {
            Message message = Message.Create(MessageSendMode.Reliable, MessageEndpointId.RefreshNews);
            ServerProgram.server.Send(message, ServerProgram.server.Clients.First(l => l.Id == list[userId].Id));
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
            if (user != null && !list.TryGetValue(user.Id, out c))
            {

                ServerProgram.server.Accept(pendingConnection);
                Create(pendingConnection.Id, user.Id, user.Username, token, info);
            }
            else
            {
                ServerProgram.server.Reject(pendingConnection);
            }
        }

    }
}
