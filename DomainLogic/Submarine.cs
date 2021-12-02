using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLogic
{
    public class Submarine
    {
        public Submarine()
        {
            Position = new Position();
        }

        public Position Position { get; private set; }

        public void Move(MoveParameters newMove)
        {
            switch (newMove.Direction)
            {
                case Direction.Up:
                {
                    MoveUpwards(newMove.Length);
                    break;
                }
                case Direction.Down:
                {
                    MoveDownwards(newMove.Length);
                    break;
                }
                case Direction.Forward:
                {
                    MoveForward(newMove.Length);
                    break;
                }
                default:
                    throw new ArgumentException($"Invalid value {newMove.Direction}", nameof(newMove.Direction));
            }
        }

        private void MoveUpwards(int length)
        {
            Position.Aim -= length;
        }

        private void MoveDownwards(int length)
        {
            Position.Aim += length;
        }

        private void MoveForward(int length)
        {
            Position.Horizontal += length;
            Position.Vertical += Position.Aim * length;
        }
    }
}
