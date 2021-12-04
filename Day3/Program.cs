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
            int codeLength = input[0].Length;

            //part1

            int[] binaryValuesPerPosition = new int[codeLength];
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

            //part2

            var oxygenGeneratorCodeList = input.ToList();
            var co2ScrubberCodeList = input.ToList();
            
            for (int i = 0; i < codeLength; i++)
            {
                oxygenGeneratorCodeList = FindCodesForBitPosition(oxygenGeneratorCodeList, i, GreaterOrEqualThan);
                co2ScrubberCodeList = FindCodesForBitPosition(co2ScrubberCodeList, i, LessThan);
            }

            int oxygenGenerator = Convert.ToInt32(String.Join("", oxygenGeneratorCodeList[0]), 2);
            int co2Scrubber = Convert.ToInt32(String.Join("", co2ScrubberCodeList[0]), 2);

            Console.WriteLine($"Life support rating is: {oxygenGenerator * co2Scrubber}");
            Console.ReadKey();
        }

        private static List<string> FindCodesForBitPosition(List<string> inputPositions, int bitPosition, Func<int,double,bool> comparisonStrategy)
        {
            if (inputPositions.Count == 1) return inputPositions;

            var newCodeList = inputPositions.Where(code => code[bitPosition] == '1').ToList();

            return comparisonStrategy(newCodeList.Count, inputPositions.Count / (double)2) ?
                newCodeList :
                inputPositions.Except(newCodeList).ToList();
        }

        private static bool LessThan(int first, double second)
        {
            return first < second;
        }

        private static bool GreaterOrEqualThan(int first, double second)
        {
            return first >= second;
        }
    }
}
