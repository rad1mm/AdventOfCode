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
            int[] binaryValuesPerPosition = new int[input[0].Length];
            foreach (var binaryCode in input)
            {
                for (int j = 0; j < binaryCode.Length; j++)
                {
                    binaryValuesPerPosition[j] += binaryCode[j].ToString().ChangeType<int>();
                }
            }

            double halfCount = input.Length / 2;
            var gammaArray = binaryValuesPerPosition.Select(p => p < halfCount ? "0" : "1").ToArray();
            var epsylonArray = gammaArray.Select(p => p == "0" ? "1" : "0").ToArray();
            string binaryGamma = String.Join("", gammaArray);
            string binaryEpsylon = String.Join("", epsylonArray);
            int gamma = Convert.ToInt32(binaryGamma, 2);
            int epsylon = Convert.ToInt32(binaryEpsylon, 2);

            Console.WriteLine($"Power consumption is: {gamma*epsylon}");
            Console.ReadKey();

        }
    }
}
