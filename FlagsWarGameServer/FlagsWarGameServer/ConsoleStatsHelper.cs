using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FlagsWarGameServer
{
    static class ConsoleStatsHelper
    {
        public static void PrintPlantedFlags(List<int[]> list, int player)
        {
            Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId +
                " prints planted flags of " + player + ". player" + ": ");
            foreach (int[] point in list)
            {
                Console.WriteLine(point[0] + " " + point[1]);
            }
        }

        public static void PrintBombs(List<int[]> bombs)
        {
            for (int i = 0; i < bombs.Count; i++)
            {
                Console.WriteLine("{0}. bomb is located at {1},{2}", (i + 1), bombs[i][0], bombs[i][1]);
            }
        }

        public static void PrintSelectedLocation(int player, byte[] data, int recv)
        {
            Console.WriteLine("{0}. player searched the location: " +
                Encoding.ASCII.GetString(data, 0, recv), player);
        }
    }
}
