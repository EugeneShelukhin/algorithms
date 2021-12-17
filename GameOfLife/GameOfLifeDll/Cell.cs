using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Cell
    {
        public Cell(int x, int y, bool isAlive = false)
        {
            X = x;
            Y = y;
            IsAlive = isAlive;
        }
        private bool isAliveNext;
        public bool IsAlive { get; set; }
        public int X { get; }
        public int Y { get; }

        public IEnumerable<Cell> Neighbours { private get; set; }
        public void CalculateNext()//TODO detetct changes, reflect on changes only
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
            return Neighbours.Count(x => x?.IsAlive == true);
        }
    }
}