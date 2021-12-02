using System;

namespace DomainLogic
{
    public class Position : IEquatable<Position>
    {
        private int vertical = 0;
        
        public int Horizontal { get; set; } = 0;

        public int Vertical
        {
            get => vertical;
            set
            {
                if (value < 0)
                {
                    throw new ApplicationException("Submarines can't fly you fool!");
                }

                vertical = value;
            }
        }

        public int Aim { get; set; } = 0;

        public override string ToString()
        {
            return $"Horizontal position: {Horizontal},   Vertical Position: {Vertical},   Aim: {Aim}";
        }

        public bool Equals(Position other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return vertical == other.vertical && Horizontal == other.Horizontal && Aim == other.Aim;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Position) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = vertical;
                hashCode = (hashCode * 397) ^ Horizontal;
                hashCode = (hashCode * 397) ^ Aim;
                return hashCode;
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