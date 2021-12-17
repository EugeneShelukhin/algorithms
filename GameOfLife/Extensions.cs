using System;

namespace GameOfLife
{
    public static class Extensions
    {

        public static Cell ElementAtOrDefault(this Cell[,] universe, int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return null;
            }


            if (x > universe.GetMaxX() || y > universe.GetMaxY())
            {
                return null;
            }
            return universe[x, y];

        }

        public static void Move(this Cell[,] universe)
        {
            foreach (var c in universe)
            {
                c.MoveNext();
            }
            foreach (var c in universe)
            {
                c.Apply();
            }
        }

        public static void Print(this Cell[,] universe, int? cursorTop = null)
        {
            if (cursorTop != null)
            {
                Console.SetCursorPosition(0, cursorTop.Value);
            }
            for (var y = 0; y <= universe.GetMaxY(); y++)
            {
                var line = "";
                for (var x = 0; x <= universe.GetMaxX(); x++)
                {
                    var val = universe[x, y].IsAlive ? '\u25A0' : ' ';
                    line += (val + " ");
                }
                Console.WriteLine(line);
            }
        }

        public static void Init(this Cell[,] universe)
        {
            for (var x = 0; x <= universe.GetMaxX(); x++)
            {
                for (var y = 0; y <= universe.GetMaxY(); y++)
                {
                    universe[x, y] = new Cell(universe, x, y);
                }
            }
        }

        public static int GetMaxX(this Cell[,] universe)
        {
            //suppose length > 0
            return universe.GetLength(0) - 1;
        }

        public static int GetMaxY(this Cell[,] universe)
        {
            return universe.GetLength(1) - 1;
        }
    }
}