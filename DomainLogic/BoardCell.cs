using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLogic
{
    public class BoardCell
    {
        public BoardCell(int value)
        {
            Value = value;
        }
        public int Value { get; private set; }
        public bool Marked { get; private set; }

        public void Mark() => Marked = true;
    }
}
