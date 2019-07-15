using System.Collections.Generic;
using System.Linq;
using Optional.Collections;

namespace GameOfLife
{
    public class Universe
    {
        private readonly IDictionary<Position, Cell> _seed;

        public Universe(IDictionary<Position, Cell> seed)
        {
            _seed = seed;
        }

        public Universe Tick()
        {
            var newSeed = new Dictionary<Position, Cell>();

            foreach (var (position, cell) in _seed)
            {
                newSeed[position] = cell.Tick(NeighboursTo(position));
            }
            
            return new Universe(newSeed);
        }

        private Neighbours NeighboursTo(Position position)
        {
            return new Neighbours()
                .Add(_seed.GetValueOrNone(position.Above()))
                .Add(_seed.GetValueOrNone(position.Bellow()))
                .Add(_seed.GetValueOrNone(position.Left()))
                .Add(_seed.GetValueOrNone(position.Right()))
                .Add(_seed.GetValueOrNone(position.AboveLeft()))
                .Add(_seed.GetValueOrNone(position.AboveRight()))
                .Add(_seed.GetValueOrNone(position.BellowLeft()))
                .Add(_seed.GetValueOrNone(position.BellowRight()));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() 
                   && _seed.Count() == ((Universe)obj)._seed.Count 
                   && !_seed.Except(((Universe)obj)._seed).Any();
        }

        public override int GetHashCode()
        {
            return (_seed != null ? _seed.GetHashCode() : 0);
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