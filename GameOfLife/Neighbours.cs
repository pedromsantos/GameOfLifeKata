using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Neighbours
    {
        private readonly IList<Cell> _cells;

        public Neighbours()
        {
            _cells = new List<Cell>();
        }

        public int CountAlive()
        {
            return _cells.Count(c => c is LiveCell);
        }

        public Neighbours Add(Cell cell)
        {
            if (cell == null)
            {
                return this;
            }
            
            _cells.Add(cell);
            
            return this;
        }
    }
}