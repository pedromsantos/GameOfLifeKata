using System.Collections.Generic;
using System.Linq;
using Optional;

namespace GameOfLife
{
    public class Neighbours
    {
        private readonly IList<Option<Cell>> _cells;

        public Neighbours()
        {
            _cells = new List<Option<Cell>>();
        }

        public int CountAlive()
        {
            return _cells.Count(
                oc => oc.Match(
                    c => c is LiveCell,
                    () => false));
        }

        public Neighbours Add(Option<Cell> cell)
        {
            _cells.Add(cell);
            return this;
        }
    }
}