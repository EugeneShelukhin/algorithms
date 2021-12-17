using System.Collections.Generic;

namespace GameOfLife
{
    public class Universe
    {
        private readonly Cell[,] _universe;
        public Universe(int width, int height)
        {
            Width = width;
            Height = height;
            _universe = new Cell[width, height];
            Init();
        }
        public Cell this[int x, int y]
        {
            get
            {
                if (x < 0 || y < 0 || x >= Width || y >= Height)
                {
                    return null;
                }
                return _universe[x, y];
            }
        }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public void Move()
        {
            foreach (var cell in _universe)
            {
                cell.CalculateNext();
            }
            foreach (var cell in _universe)
            {
                cell.Apply();
            }
        }

        private void Init()
        {
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    _universe[x, y] = new Cell(x, y);
                }
            }
            foreach (var cell in _universe) { cell.Neighbours = GetNeighbours(cell.X, cell.Y); };
        }

        private IEnumerable<Cell> GetNeighbours(int _x, int _y)
        {
            var neighbours = new List<Cell>();

            for (var x = _x - 1; x <= _x + 1; x++)
            {
                for (var y = _y - 1; y <= _y + 1; y++)
                {
                    if (!(x == _x && y == _y) && this[x, y] != null)
                    {
                        neighbours.Add(_universe[x, y]);
                    }
                }
            }
            return neighbours;
        }
    }
}
