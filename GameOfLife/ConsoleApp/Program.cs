using GameOfLife;
using System;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int xLength = 25;
            int yLength = 25;
            int steps = 1000;
            var universe = new Universe(xLength, yLength);

            universe[1, 0].IsAlive = true;
            universe[2, 1].IsAlive = true;
            universe[0, 2].IsAlive = true;
            universe[1, 2].IsAlive = true;
            universe[2, 2].IsAlive = true;

            var (_, initialCursorTop) = Console.GetCursorPosition();
            UniverseConsolePrinter.Print(universe, initialCursorTop);

            for (var i = 0; i < steps; i++)
            {
                universe.Move();
                UniverseConsolePrinter.Print(universe, initialCursorTop);

                Console.WriteLine("step=" + i);
                Thread.Sleep(25);
            }
        }
    }
}
