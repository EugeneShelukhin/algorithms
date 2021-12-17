namespace GameOfLife
{
    public class Cell
    {
        private readonly Cell[,] _universe;
        private readonly int _x;
        private readonly int _y;

        public Cell(Cell[,] universe, int x, int y, bool isAlive = false)
        {
            _universe = universe;
            _x = x;
            _y = y;
            IsAlive = isAlive;
        }
        public bool IsAlive { get; set; }
        private bool isAliveNext;
        public void MoveNext()
        {
            var neighbourCount = CountNeighbours();
            isAliveNext = IsAlive;
            if (neighbourCount == 3)
            {
                isAliveNext = true;
            }
            else if (neighbourCount != 2)
            {
                isAliveNext = false;
            }
        }
        public void Apply()
        {
            IsAlive = isAliveNext;
        }

        private int CountNeighbours()
        {
            var counter = 0;
            for (var x = _x - 1; x <= _x + 1; x++)
            {
                for (var y = _y - 1; y <= _y + 1; y++)
                {
                    if (!IsSelf(x, y) && _universe.ElementAtOrDefault(x, y)?.IsAlive == true)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        private bool IsSelf(int x, int y)
        {
            return x == _x && y == _y;
        }


    }
}