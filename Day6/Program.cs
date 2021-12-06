using Shared.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using DomainLogic;
using Shared;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = InputReader.Read("C:\\Users\\radovan.susuk\\Documents\\AdventOfCode\\Day6\\input\\input.txt")[0].Split(',').ChangeArrayType<int>();
            //part1
            var schoolOfFish = new List<Fish>();

            foreach (var noOfDaysLeftUntilSpawning in input)
            {
                var newFish = new Fish(noOfDaysLeftUntilSpawning, schoolOfFish);
            }

            for (int i = 0; i < 80; i++)
            {
                var currentFish = schoolOfFish.ToArray();
                foreach (var fish in currentFish)
                {
                    fish.LiveADay();
                }
            }

            Console.WriteLine($"Number of fish: {schoolOfFish.Count}");
            Console.ReadKey();

            //part2

            var countsByTimer = new long[9];

            foreach (var fishTimer in input)
            {
                countsByTimer[fishTimer] += 1;
            }

            for (int i = 0; i < 256; i++)
            {
                var newCounter = new long[9];
                for (int j = 0; j < 9; j++)
                {
                    if (j + 1 > 8)
                    {
                        newCounter[j] = countsByTimer[0];
                        continue;
                    }

                    if (j == 6)
                    {
                        newCounter[j] = countsByTimer[j + 1] + countsByTimer[0];
                        continue;
                    }

                    newCounter[j] = countsByTimer[j + 1];
                }

                countsByTimer = newCounter;
            }

            Console.WriteLine($"Number of fish: {countsByTimer.Sum()}");
            Console.ReadKey();
        }
    }
}
