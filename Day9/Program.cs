using Shared.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using Shared;
using DomainLogic;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var input = InputReader.Read("C:\\Users\\radovan.susuk\\Documents\\AdventOfCode\\Day9\\input\\input.txt");
            ////part 1
            int[,] floorInt = new int[input.Length, input[0].Length];
            //part 2
            FloorCell[,] floor = new FloorCell[input.Length, input[0].Length];

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    //part1
                    floorInt[i, j] = input[i][j].ChangeType<string>().ChangeType<int>();
                    //part2
                    floor[i, j] = new FloorCell { Value = floorInt[i, j] };
                }
            }

            //part1
            int sum = 0;
            //part2
            List<int> basins = new List<int>();

            for (int i = 0; i < floorInt.GetLength(0); i++)
            {
                for (int j = 0; j < floorInt.GetLength(1); j++)
                {
                    if (IsLowestLocalHeight(floorInt, i, j))
                    {
                        //part1
                        sum += floorInt[i, j] + 1;
                        //part2
                        basins.Add(GetBasinSize(floor, i, j));
                    }
                }
            }

            basins = basins.OrderByDescending(p=>p).ToList();

            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Basins surface multiplied: {basins[0]*basins[1]*basins[2]}");
            Console.ReadKey();
        }

        public static int GetBasinSize(FloorCell[,] input, int row, int column)
        {
            int val = input[row, column].Value;
            int basinSize = 1;
            input[row, column].Visited = true;

            if (column + 1 < input.GetLength(1))
            {
                if (input[row, column + 1].Value >= input[row,column].Value &&
                    !input[row, column + 1].Visited &&
                    input[row, column + 1].Value != 9)
                {
                    basinSize += GetBasinSize(input, row, column + 1);
                }
            }

            if (row + 1 < input.GetLength(0))
            {
                if (input[row+1, column].Value >= input[row, column].Value &&
                    !input[row + 1, column].Visited &&
                    input[row + 1, column].Value != 9)
                {
                    basinSize += GetBasinSize(input, row+1, column);
                }
            }

            if (column - 1 >= 0)
            {
                if (input[row, column - 1].Value >= input[row, column].Value &&
                    !input[row, column - 1].Visited &&
                    input[row, column - 1].Value != 9)
                {
                    basinSize += GetBasinSize(input, row, column - 1);
                }
            }

            if (row - 1 >= 0)
            {
                if (input[row - 1, column].Value >= input[row, column].Value &&
                    !input[row - 1, column].Visited &&
                    input[row - 1, column].Value != 9)
                {
                    basinSize += GetBasinSize(input, row-1, column);
                }
            }

            return basinSize;
        }

        public static bool IsLowestLocalHeight(int[,] input, int row, int column)
        {
            var localValues = new List<int>();

            if (column + 1 < input.GetLength(1))
            {
                localValues.Add(input[row,column + 1]);
            }

            if (row + 1 < input.GetLength(0))
            {
                localValues.Add(input[row + 1, column]);
            }

            if (column - 1 >= 0)
            {
                localValues.Add(input[ row,column - 1 ]);
            }

            if (row-1 >= 0)
            {
                localValues.Add(input[row - 1,column]);
            }

            return localValues.Count(p => p <= input[row, column]) == 0;
        }
    }
}
