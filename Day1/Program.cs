using Shared.IO;
using System;
using System.Linq;
using Shared;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringInputs = InputReader.Read("C:\\Users\\radovan.susuk\\Documents\\AdventOfCode\\Day1\\input\\input.txt");
            int[] intInputs = stringInputs.Select(i => i.ChangeType<int>()).ToArray();

            int biggerNumbers = 0;

            for (int i = 1; i < intInputs.Length; i++)
            {
                biggerNumbers = intInputs[i - 1] < intInputs[i] ? biggerNumbers + 1 : biggerNumbers;
            }

            Console.WriteLine($"Input array length: {intInputs.Length}");
            Console.WriteLine();
            Console.WriteLine("Part 1:");
            Console.WriteLine($"Bigger consecutive numbers count: {biggerNumbers}");
            Console.WriteLine();
            
            int biggerSums = 0;
            for (int i = 2; i < intInputs.Length-1; i++)
            {
                var firstSum = intInputs[i-2] + intInputs[i-1] + intInputs[i];
                var secondSum = intInputs[i-1] + intInputs[i] + intInputs[i + 1];
                biggerSums = firstSum < secondSum ? biggerSums+1 : biggerSums;
            }

            Console.WriteLine("Part 2:");
            Console.WriteLine($"Bigger consecutive sums of sliding windows count: {biggerSums}");
            Console.ReadKey();
        }
    }
}
