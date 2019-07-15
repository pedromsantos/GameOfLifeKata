using System.Collections.Generic;
using System.Linq;
using Optional.Collections;

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
                .Add(_spots.GetValueOrNone(position.Above()))
                .Add(_spots.GetValueOrNone(position.Bellow()))
                .Add(_spots.GetValueOrNone(position.Left()))
                .Add(_spots.GetValueOrNone(position.Right()))
                .Add(_spots.GetValueOrNone(position.AboveLeft()))
                .Add(_spots.GetValueOrNone(position.AboveRight()))
                .Add(_spots.GetValueOrNone(position.BellowLeft()))
                .Add(_spots.GetValueOrNone(position.BellowRight()));
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