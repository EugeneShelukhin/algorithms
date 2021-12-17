
using System;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        public static void Main(string[] args)
        {
            int xLength = 25;
            int yLength = 25;
            var universe = new Cell[xLength, yLength];
            universe.Init();

            universe[1, 0].IsAlive = true;
            universe[2, 1].IsAlive = true;
            universe[0, 2].IsAlive = true;
            universe[1, 2].IsAlive = true;
            universe[2, 2].IsAlive = true;

            var (_, initialCursorTop) = Console.GetCursorPosition();
            universe.Print();

            for (var i = 0; i < 1000; i++)
            {
                universe.Move();
                universe.Print(initialCursorTop);

                Console.WriteLine("step=" + i);
                Thread.Sleep(25);
            }

        }
    }
}