using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using PlayerBaseApi.Services;
using Riptide;
using Riptide.Utils;
using System.Configuration;
using System.Text.Json;
using WebSocket.Enums;
using WebSocket.Interfaces;

namespace WebSocket.Socket
{
    public class ServerProgram
    {
        public static Server server { get; set; }
        private static bool isRunning = false;
        public static void Start()
        {
            RiptideLogger.Initialize(Console.WriteLine, true);
            
            Message.MaxPayloadSize = 30000;
            new Thread(new ThreadStart(Update)).Start();
            new Thread(new ThreadStart(ResfreshPlayerBase)).Start();
            
        }

        public static List<string> DoCommand(string line)
        {
            List<string> response = new List<string>();
            try
            {
                switch (line.ToLower().Split()[0])
                {
                    case "clients":
                    case "ls":
                        response.Add($"Client Count : {server.ClientCount}");
                        response.Add($"PlayerList : {JsonSerializer.Serialize(Player.list.Values)}");
                        break;
                    case "stop":
                        isRunning = false;
                        response.Add("Done");
                        break;
                    case "start":
                        isRunning = false;
                        Thread.Sleep(10);
                        Start();
                        response.Add("Done");
                        break;
                    case "kick":
                        Player.KickPlayerByUniqueId(Convert.ToInt64(line.ToLower().Split()[1]));
                        response.Add("Done");
                        break;
                    case "sayto":
                        Player.list.Values.Where(l => l.UniqueId == Convert.ToInt64(line.ToLower().Split()[1])).FirstOrDefault()?
                            .SendRawMessage(line.ToLower().Split()[2]);
                        response.Add("Done");
                        break;
                    case "sayall":
                        Player.SendAllRawMessage(line.ToLower().Split()[1]);
                        response.Add("Done");
                        break;
                    default:
                        response.Add($"No Command Exist :  {line.Split()[0]}");
                        break;
                }
            }
            catch (Exception e)
            {

                response.Add(e.Message);

            }
            return response;
        }

        private static void Update()
        {
            //Console.WriteLine($"Server started");
            server = new Server
            {
                TimeoutTime = ushort.MaxValue
            };
            Player.SetUrls();
            server.Start(7777, 10000);
            server.ClientDisconnected += PlayerLeft;
            server.HandleConnection = Player.ConnectionAttemptHandler;
            isRunning = true;
            while (isRunning)
            {
                server.Update();

                Thread.Sleep(10);
            }

            server.Stop();
        }

        private static void ResfreshPlayerBase()
        {

            while (isRunning)
            {
                Message message = Message.Create(MessageSendMode.Reliable, MessageEndpointId.RefreshPlayerBaseInfo);
                server.SendToAll(message);
                Thread.Sleep(300000);
            }
        }

        private static void PlayerLeft(object? sender, ServerDisconnectedEventArgs e)
        {
            Player.list.Remove(Player.list.Values.FirstOrDefault(l=>l.Id==e.Client.Id).UniqueId);
        }


    }
}
