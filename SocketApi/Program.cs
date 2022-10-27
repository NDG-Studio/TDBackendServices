using Microsoft.VisualBasic;
using Riptide;
using Riptide.Transports;
using Riptide.Utils;

namespace SocketApi
{
    public class Program
    {
        public static Server server { get; set; }
        private static ushort _port;
        private static ushort maxClientCount;
        private static bool isRunning = false;
        public static void Main(string[] args)
        {
            Console.Title = "Game Server";
            RiptideLogger.Initialize(Console.WriteLine, true);
            isRunning = true;


            new Thread(new ThreadStart(Update)).Start();


            Console.WriteLine("Press enter to stop the server at any time.");
            Console.ReadLine();

            isRunning = false;

            Console.ReadLine();

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

            while (isRunning)
            {
                server.Update();
                
                Thread.Sleep(10);
            }

            server.Stop();
        }

        private static void PlayerLeft(object? sender, ServerDisconnectedEventArgs e)
        {
            Console.WriteLine(e.ToString());
            Player.list.Remove(e.Client.Id);
        }

    }
}