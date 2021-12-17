using GameOfLife;
using System;

namespace ConsoleApp
{
    internal class UniverseConsolePrinter
    {
        internal static void Print(Universe universe, int? cursorTop = null)
        {
            if (cursorTop != null)
            {
                Console.SetCursorPosition(0, cursorTop.Value);
            }

            for (var y = 0; y < universe.Height; y++)
            {
                var line = "";
                for (var x = 0; x < universe.Width; x++)
                {
                    var val = universe[x, y].IsAlive ? '\u25A0' : ' ';
                    line += (val + " ");
                }
                Console.WriteLine(line);
            }
        }
    }
}
