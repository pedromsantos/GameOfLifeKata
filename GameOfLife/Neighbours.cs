using System.Collections.Generic;
using System.Linq;
using Optional;

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

        public Neighbours Add(Option<Cell> cell)
        {
            cell.Match(c => _cells.Add(c), () => { });
            return this;
        }
    }
}