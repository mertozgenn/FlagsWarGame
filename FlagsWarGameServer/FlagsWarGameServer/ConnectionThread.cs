using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace FlagsWarGameServer
{
    class ConnectionThread
    {
        public TcpListener threadListener;
        NetworkStream ns;
        public byte[] data = new byte[1024];
        public int recv;
        public static int connections = 0;
        public static List<int[]> flags1 = new List<int[]>();
        public static List<int[]> flags2 = new List<int[]>();
        public static List<int[]> bombs;
        public static int player1Thread;
        public static int player2Thread;
        public static int turn = 1;
        public bool turnChanged = true;
        public static bool bombExploded = false;
        public void HandleConnection()
        {
            TcpClient client = threadListener.AcceptTcpClient(); // accept the player
            ns = client.GetStream();
            connections++;
            Console.WriteLine("New client accepted: {0} active connections",
            connections);
            if (connections == 1) // send other player is waiting to the client
            {
                SendToPlayer(Messages.Waiting, 0);
                player1Thread = Thread.CurrentThread.ManagedThreadId; // get first player's thread ID
            }
            while (connections == 1) // wait for other player
            {
                Thread.Sleep(1000);
            }

            if (Thread.CurrentThread.ManagedThreadId != player1Thread) // get second player's thread ID
            {
                player2Thread = Thread.CurrentThread.ManagedThreadId;
            }

            SendToPlayer(Messages.StartPlanting, 0); // send start planting flags to all players.

            GetPlantedFlags(player1Thread, flags1); // get planted flag coordinates.
            GetPlantedFlags(player2Thread, flags2);

            WaitOtherToPlant(flags1, player2Thread); // Wait for other player to plant their flags.
            WaitOtherToPlant(flags2, player1Thread);

            SetBombs(); // place bombs randamly on the map.

            ConsoleStatsHelper.PrintPlantedFlags(flags1, 1);
            ConsoleStatsHelper.PrintPlantedFlags(flags2, 2);

            // Players take turns to play until a player's flag is finished or a bomb exploded.
            while (!(flags1.Count == 0 || flags2.Count == 0) && !bombExploded)
            {
                if (turn == 1)
                {
                    HandleTurn(player1Thread, flags1, player2Thread, flags2); // first player's turn
                    if (recv != -1)
                    {
                        ConsoleStatsHelper.PrintSelectedLocation(1, data, recv);
                        if (HandleSearching(recv, flags2) == -1) // if first player explodes a bomb.
                        {
                            bombExploded = true;
                            break;
                        }
                        turn = 2;
                        turnChanged = true;
                    }
                    continue;
                }

                if (turn == 2)
                {
                    HandleTurn(player2Thread, flags2, player1Thread, flags1); // second player's turn
                    if (recv != -1)
                    {
                        ConsoleStatsHelper.PrintSelectedLocation(2, data, recv);
                        if (HandleSearching(recv, flags1) == -1) // if second player explodes a bomb.
                        {
                            bombExploded = true;
                            break;
                        }

                        turn = 1;
                        turnChanged = true;
                    }
                }
            }

            if (bombExploded)
                SendToPlayer("Bomb exploded", 0);

            Thread.Sleep(500);

            SendToPlayer(Messages.GameFinished + "," + flags2.Count
                        + "," + flags1.Count, player2Thread);
            SendToPlayer(Messages.GameFinished + "," + flags1.Count
                        + "," + flags2.Count, player1Thread);

            Thread.Sleep(500);

            CloseConnection(client);
            Console.ReadKey();
        }

        private void SendToPlayer(String message, int player) // send the message to the player(s)
        {
            if (player == 0 | player == Thread.CurrentThread.ManagedThreadId)
            {
                data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);
            }

        }

        private int ReceiveFromPlayer(int player) // receive the message from the given player
        {
            if (player == Thread.CurrentThread.ManagedThreadId)
            {
                data = new byte[1024];
                return ns.Read(data, 0, data.Length);
            }
            return -1;
        }

        private void GetPlantedFlags(int playerThreadId, List<int[]> flagList) // get planted flag coordinates of the given player
        {
            int recv;
            for (int i = 0; i < 5 && Thread.CurrentThread.ManagedThreadId == playerThreadId; i++)
            {
                recv = -1;
                while (recv == -1)
                    recv = ReceiveFromPlayer(playerThreadId);
                string[] location = Encoding.ASCII.GetString(data, 0, recv).Split(',').ToArray();
                int[] coordinates = new int[2];
                coordinates[0] = int.Parse(location[0]);
                coordinates[1] = int.Parse(location[1]);
                flagList.Add(coordinates);
            }
        }

        private void WaitOtherToPlant(List<int[]> notCompletedFlags, int completedThread) // wait other player to plant plags.
        {
            if (notCompletedFlags.Count != 5)
            {
                SendToPlayer(Messages.Waiting, completedThread);
            }

            while (notCompletedFlags.Count != 5 && Thread.CurrentThread.ManagedThreadId == completedThread)
            {
                Thread.Sleep(1000);
            }

        }

        private void SetBombs() // place bombs randomly on the map without conflicting a flag.
        {
            if (bombs == null)
            {
                bombs = new List<int[]>();
                int[] bombCoordinates;
                Random random = new Random();
                int x, y;
                for (int i = 0; i < 5; i++)
                {
                    bombCoordinates = new int[2];
                    do
                    {
                        x = random.Next(0, 870);
                        y = random.Next(0, 427);
                    } while (IsThereFlag(x, y));

                    bombCoordinates[0] = x;
                    bombCoordinates[1] = y;
                    bombs.Add(bombCoordinates);
                }
                ConsoleStatsHelper.PrintBombs(bombs);
            }
        }

        private bool IsThereFlag(int x, int y) // check for flags before locating the bomb.
        {
            for (int i = 0; i < 5; i++)
            {
                if (Math.Abs(flags1[i][0] - x) <= 10 &&
                Math.Abs(flags1[i][1] - y) <= 10 &&
                Math.Abs(flags2[i][0] - x) <= 10 &&
                Math.Abs(flags2[i][1] - y) <= 10)
                {
                    return true;
                }
            }
            return false;
        }

        private void HandleTurn(int playingPlayerThread, List<int[]> flagsOfPlaying, // handle playing player and waiting player
            int waitingPlayerThread, List<int[]> flagsOfWaiting)
        {
            SendToPlayer(Messages.SelectPoint + "," + flagsOfPlaying.Count
                        + "," + flagsOfWaiting.Count, playingPlayerThread);
            if (turnChanged)
            {
                SendToPlayer(Messages.OthersTurn + "," + flagsOfWaiting.Count
                + "," + flagsOfPlaying.Count, waitingPlayerThread);
                turnChanged = false;
            }
            if (Thread.CurrentThread.ManagedThreadId == waitingPlayerThread) Thread.Sleep(250);
            recv = ReceiveFromPlayer(playingPlayerThread);
        }

        private int HandleSearching(int recv, List<int[]> flagList) // Remove the flag on the given location if any.
        {
            String[] searchPoint = Encoding.ASCII.GetString(data, 0, recv).Split(',').ToArray();

            if (IsThereBomb(searchPoint)) return -1;

            for (int i = 0; i < flagList.Count; i++)
            {
                if (Math.Abs(flagList[i][0] - int.Parse(searchPoint[0])) <= 10 &&
                    Math.Abs(flagList[i][1] - int.Parse(searchPoint[1])) <= 10)
                {
                    flagList.RemoveAt(i);
                    break;
                }
            }
            return 0;
        }

        private bool IsThereBomb(String[] searchPoint) // check whether the search point is in the area of a bomb.
        {
            for (int i = 0; i < 5; i++)
            {
                if (Math.Abs(bombs[i][0] - int.Parse(searchPoint[0])) <= 10 &&
                    Math.Abs(bombs[i][1] - int.Parse(searchPoint[1])) <= 10)
                {
                    return true;
                }
            }
            return false;
        }

        private void CloseConnection(TcpClient client) // disconnect the client
        {
            ns.Close();
            client.Close();
            connections--;
            Console.WriteLine("Client disconnected: {0} active connections",
            connections);
        }
    }
}
