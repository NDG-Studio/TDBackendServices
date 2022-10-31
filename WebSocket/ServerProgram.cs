using Microsoft.AspNetCore.Hosting.Server;
using Riptide;
using Riptide.Utils;
using System.Text.Json;

namespace WebSocket
{
    public class ServerProgram
    {
        public static Server server { get; set; }
        private static bool isRunning = false;
        public static void Start()
        {
            Console.Title = "Game Server";
            RiptideLogger.Initialize(Console.WriteLine, true);
            isRunning = true;


            new Thread(new ThreadStart(Update)).Start();


            //Console.WriteLine("Commands:");
            //Console.WriteLine("'clients' : return client count and list");
            //Console.WriteLine("'stop' : stop server");
            //Console.WriteLine("'kick' : kick user with unique id like 'kick 4'");
            //while (isRunning)
            //{
            //    try
            //    {
            //        var line = Console.ReadLine();
            //        switch (line.ToLower().Split()[0])
            //        {
            //            case "clients":
            //            case "ls":
            //                Console.WriteLine($"Client Count : {server.ClientCount}");
            //                Console.WriteLine($"PlayerList : {JsonSerializer.Serialize(Player.list.Values)}");
            //                break;
            //            case "stop":
            //                isRunning = false;
            //                break;
            //            case "kick":
            //                Player.KickPlayerByUniqueId(Convert.ToInt64(line.ToLower().Split()[1]));
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //    catch (Exception e)
            //    {

            //        Console.WriteLine(e.Message);
            //    }
            //}


        }

        public static List<string> DoCommand(string line)
        {
            List<string> response =new List<string>();
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
                        break;
                    case "kick":
                        Player.KickPlayerByUniqueId(Convert.ToInt64(line.ToLower().Split()[1]));
                        break;
                    default:
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
            server.Start(7777, 10000);
            server.ClientDisconnected += PlayerLeft;
            server.HandleConnection = Player.ConnectionAttemptHandler;

            while (isRunning)
            {
                server.Update();

                Thread.Sleep(10);
            }

            server.Stop();
        }

        private static void PlayerLeft(object? sender, ServerDisconnectedEventArgs e)
        {
            Player.list.Remove(e.Client.Id);
        }


    }
}
