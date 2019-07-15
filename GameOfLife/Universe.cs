using System.Collections.Generic;
using System.Linq;
using Optional;

namespace GameOfLife
{
    public class Universe
    {
        private readonly IDictionary<Position, Cell> _spots;

        public Universe(IDictionary<Position, Cell> spots)
        {
            _spots = spots;
        }

        public Universe Tick()
        {
            var spots = new Dictionary<Position, Cell>();

            foreach (var (position, cell) in _spots)
            {
                spots[position] = cell.Tick(NeighboursTo(position));
            }
            
            return new Universe(spots);
        }

        private Neighbours NeighboursTo(Position position)
        {
            return new Neighbours()
                .Add(_spots.ContainsKey(position.Above()) ? _spots[position.Above()].Some() : Option.None<Cell>())
                .Add(_spots.ContainsKey(position.Bellow()) ? _spots[position.Bellow()].Some() : Option.None<Cell>())
                .Add(_spots.ContainsKey(position.Left()) ? _spots[position.Left()].Some() : Option.None<Cell>())
                .Add(_spots.ContainsKey(position.Right()) ? _spots[position.Right()].Some() : Option.None<Cell>())
                .Add(_spots.ContainsKey(position.AboveLeft()) ? _spots[position.AboveLeft()].Some() : Option.None<Cell>())
                .Add(_spots.ContainsKey(position.AboveRight()) ? _spots[position.AboveRight()].Some() : Option.None<Cell>())
                .Add(_spots.ContainsKey(position.BellowLeft()) ? _spots[position.BellowLeft()].Some() : Option.None<Cell>())
                .Add(_spots.ContainsKey(position.BellowRight()) ? _spots[position.BellowRight()].Some() : Option.None<Cell>());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() 
                   && _spots.Count() == ((Universe)obj)._spots.Count 
                   && !_spots.Except(((Universe)obj)._spots).Any();
        }

        public override int GetHashCode()
        {
            return (_spots != null ? _spots.GetHashCode() : 0);
        }

        public static bool operator ==(Universe left, Universe right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Universe left, Universe right)
        {
            return !Equals(left, right);
        }
    }
}