using System;
using System.Collections.Generic;

namespace DomainLogic
{
    public class Submarine
    {
        private Dictionary<Direction, Action<int>> directedMovesDictionary;
        public Submarine()
        {
            Position = new Position();
            InitActionDictionary();
        }

        public Position Position { get; private set; }

        public void Move(MoveParameters newMove)
        {
            if (!directedMovesDictionary.TryGetValue(newMove.Direction, out var directedMove))
            {
                throw new ArgumentException($"Invalid value {newMove.Direction}", nameof(newMove.Direction));
            }

            directedMove(newMove.Distance);
        }

        private void InitActionDictionary()
        {
            directedMovesDictionary = new Dictionary<Direction, Action<int>>()
            {
                [Direction.Down] = MoveDownwards,
                [Direction.Up] = MoveUpwards,
                [Direction.Forward] = MoveForward
            };
        }

        private void MoveUpwards(int distance)
        {
            Position.Aim -= distance;
        }

        private void MoveDownwards(int distance)
        {
            Position.Aim += distance;
        }

        private void MoveForward(int distance)
        {
            Position.Horizontal += distance;
            Position.Vertical += Position.Aim * distance;
        }
    }
}
