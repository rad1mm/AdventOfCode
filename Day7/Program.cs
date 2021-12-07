using Shared.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = InputReader.Read("C:\\Users\\radovan.susuk\\Documents\\AdventOfCode\\Day7\\input\\input.txt")[0].Split(',').ChangeArrayType<int>();
            int minPositionDistance = Int32.MaxValue;

            for (int i = input.Min(); i <= input.Max(); i++)
            {
                //int cumulativeDistanceToPosition = input.Select(position => Math.Abs(position - i)).Sum(); part1
                int cumulativeDistanceToPosition = input.Select(position => Math.Abs(position - i)).Select(nPlaces => (int)(nPlaces / (double)2 * (nPlaces + 1))).Sum(); // part2

                if (cumulativeDistanceToPosition < minPositionDistance)
                {
                    minPositionDistance = cumulativeDistanceToPosition;
                }
            }

            Console.WriteLine($"Fuel spent: {minPositionDistance}");
            Console.ReadKey();
        }
    }
}
