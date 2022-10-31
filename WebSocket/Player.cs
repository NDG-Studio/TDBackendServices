
using Newtonsoft.Json;
using Riptide;
using SharedLibrary.Models;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace WebSocket
{
    public class Player
    {
        public static Dictionary<ushort, Player> list = new Dictionary<ushort, Player>();

        public ushort Id { get; private set; }
        public string Username { get; private set; }
        public long UniqueId { get; private set; }
        private string Token { get; set; }

        public static void Create(ushort id, long userId, string username, string token)
        {
            Player player = new Player();
            player.Username = username;
            player.UniqueId = userId;
            player.Id = id;
            player.Token = token;
            list.Add(id, player);
        }

        [MessageHandler((ushort)ClientToServerId.handshake)]
        private static void handshake(ushort fromClientId, Message message)
        {
            var token = message.GetString();
            var user = checkuser(token);//token bilgisi kontrol ediliyor. token bozuksa veya kullanıcı zaten aktifse girişi engellenir.
            if (user != null && !Player.list.Where(l => l.Value.UniqueId == user.Id).Any())
            {
                Create(fromClientId, user.Id, user.Username, token);
            }
            else
            {
                ServerProgram.server.DisconnectClient(fromClientId);
            }

        }


        private static UserDto? checkuser(string token)
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
            (
              HttpRequestMessage message,
              X509Certificate2 cert,
              X509Chain chain,
              SslPolicyErrors errors
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

                var response = client.PostAsync(new Uri(Constants.Identity + "/api/user/checkToken"),
                    new StringContent(JsonConvert.SerializeObject(
                        (new BaseRequest<string>()
                        {
                            Data = token,
                            Info = new InfoDto()
                            {
                                DeviceId = "socket",
                                AppVersion = "dsad",
                                DeviceModel = "dsadsa",
                                Ip = "123ds1a2d1a3s",
                                UserId = 12,
                                DeviceType = "dsadsa",
                                OsVersion = "1"
                            }
                        })
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

        public static void KickPlayerByUniqueId(long id)
        {
            var clientId = Player.list.Values.Where(l => l.UniqueId == id).Select(l => l.Id).FirstOrDefault();
            ServerProgram.server.DisconnectClient(clientId);

        }

        public static void ConnectionAttemptHandler(Connection pendingConnection, Message connectMessage)
        {
            var token = connectMessage.GetString();
            var user = checkuser(token);//token bilgisi kontrol ediliyor. token bozuksa veya kullanıcı zaten aktifse girişi engellenir.
            if (user != null && !Player.list.Where(l => l.Value.UniqueId == user.Id).Any())
            {

                Create(pendingConnection.Id, user.Id, user.Username, token);
                ServerProgram.server.Accept(pendingConnection);
            }
            else
            {
                ServerProgram.server.Reject(pendingConnection);
            }
        }

    }
}
