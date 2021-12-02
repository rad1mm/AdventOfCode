using System;
using DomainLogic;
using Shared;
using Shared.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = InputReader.Read("C:\\Users\\radovan.susuk\\Documents\\AdventOfCode\\Day2\\input\\input.txt");
            var submarine = new Submarine();

            foreach (var line in input)
            {
                var lineValues = line.Split(' ');
                var newMove = new MoveParameters(lineValues[0].ChangeType<Direction>(), lineValues[1].ChangeType<int>());
                submarine.Move(newMove);
            }

            Console.WriteLine($"Input array length: {input.Length}");
            Console.WriteLine($"Submarine position: {submarine.Position}");
            Console.WriteLine($"Result: {submarine.Position.Horizontal * submarine.Position.Vertical}");
            Console.ReadKey();
        }
    }
}
