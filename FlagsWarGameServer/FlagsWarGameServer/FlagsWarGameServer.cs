using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace FlagsWarGameServer
{
    class FlagsWarGameServer
    {
        private TcpListener client;
        public FlagsWarGameServer() // start thread for each player
        {
            int players = 0;
            client = new TcpListener(IPAddress.Any, 9050);
            client.Start();
            Console.WriteLine("Waiting for players...");
            while (players != 2)
            {
                while (!client.Pending())
                {
                    Thread.Sleep(1000);
                }
                players++;
                ConnectionThread newconnection = new ConnectionThread();
                newconnection.threadListener = this.client;
                Thread newthread = new Thread(new
                ThreadStart(newconnection.HandleConnection));
                newthread.Start();
            }
        }
        public static void Main()
        {
            FlagsWarGameServer server = new FlagsWarGameServer();
        }
    }
}
