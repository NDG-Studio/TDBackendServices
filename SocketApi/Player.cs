using Riptide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketApi
{
    public class Player
    {
        public static Dictionary<ushort, Player> list = new Dictionary<ushort, Player>();

        public ushort Id { get; private set; }
        public string Username { get; private set; }
        public string UniqueId { get; private set; }

        public static void Create(ushort id,string userId, string username)
        {
            Player player = new Player();
            player.Username = (String.IsNullOrEmpty(username) ? $"Guest {id}" : username);
            player.UniqueId = userId;
            player.Id = 1;
            list.Add(id, player);
        }

        [MessageHandler((ushort)ClientToServerId.handshake)]
        private static void handshake(ushort fromClientId, Message message)
        {
            Create(fromClientId, message.GetString(), message.GetString());
        }



    }
}
