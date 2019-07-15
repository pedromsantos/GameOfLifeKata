namespace GameOfLife
{
    public class Position
    {
        private readonly int _x;
        private readonly int _y;

        public Position(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public Position Left()
        {
            return new Position(_x - 1, _y);
        }
        
        public Position Right()
        {
            return new Position(_x + 1, _y);
        }
        
        public Position Above()
        {
            return new Position(_x, _y - 1);
        }
        
        public Position Bellow()
        {
            return new Position(_x, _y + 1);
        }

        public Position AboveLeft()
        {
            return new Position(_x - 1, _y - 1);
        }
        
        public Position AboveRight()
        {
            return new Position(_x + 1, _y - 1);
        }
        
        public Position BellowLeft()
        {
            return new Position(_x - 1, _y + 1);
        }
        
        public Position BellowRight()
        {
            return new Position(_x + 1, _y + 1);
        }

        private bool Equals(Position other)
        {
            return _x == other._x && _y == other._y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Position) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_x * 397) ^ _y;
            }
        }

        public static bool operator ==(Position left, Position right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !Equals(left, right);
        }
    }
}