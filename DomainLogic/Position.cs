using System;

namespace DomainLogic
{
    public class Position
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
    }
}