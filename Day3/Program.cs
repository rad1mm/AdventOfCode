using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
using Shared.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = InputReader.Read("C:\\Users\\radovan.susuk\\Documents\\AdventOfCode\\Day3\\input\\input.txt");

            //part1
            int[] binaryValuesPerPosition = new int[input[0].Length];
            foreach (var binaryCode in input)
            {
                for (int j = 0; j < binaryCode.Length; j++)
                {
                    binaryValuesPerPosition[j] += binaryCode[j].ToString().ChangeType<int>();
                }
            }

            var gammaArray = binaryValuesPerPosition.Select(p => p < input.Length / 2 ? "0" : "1").ToArray();
            int gamma = Convert.ToInt32(String.Join("",gammaArray ), 2);
            int epsilon = Convert.ToInt32(String.Join("", gammaArray.Select(p => p == "0" ? "1" : "0").ToArray()), 2);

            Console.WriteLine($"Power consumption is: {gamma * epsilon}");
            Console.ReadKey();
        }
    }
}
