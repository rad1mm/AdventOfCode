using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLogic
{
    public class FloorCell : IComparable<FloorCell>
    {
        public int Value { get; set; }
        public bool Visited { get; set; }
        public int CompareTo(FloorCell other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
