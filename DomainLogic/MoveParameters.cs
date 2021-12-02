using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLogic
{
    public class MoveParameters
    {
        public Direction Direction { get; set; }

        public int Length { get; set; }

        public MoveParameters(Direction direction, int length)
        {
            Direction = direction;
            Length = length;
        }
    }
}
