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
            var inputs = InputReader.Read("C:\\Users\\radovan.susuk\\Documents\\AdventOfCode\\Day1\\input\\input.txt")
                .ChangeArrayType<int>();

            int biggerNumbers = 0;

            for (int i = 1; i < inputs.Length; i++)
            {
                biggerNumbers = inputs[i - 1] < inputs[i] ? biggerNumbers + 1 : biggerNumbers;
            }

            Console.WriteLine($"Input array length: {inputs.Length}");
            Console.WriteLine();
            Console.WriteLine("Part 1:");
            Console.WriteLine($"Bigger consecutive numbers count: {biggerNumbers}");
            Console.WriteLine();
            
            int biggerSums = 0;
            for (int i = 2; i < inputs.Length-1; i++)
            {
                var firstSum = inputs[i-2] + inputs[i-1] + inputs[i];
                var secondSum = inputs[i-1] + inputs[i] + inputs[i + 1];
                biggerSums = firstSum < secondSum ? biggerSums+1 : biggerSums;
            }

            Console.WriteLine("Part 2:");
            Console.WriteLine($"Bigger consecutive sums of sliding windows count: {biggerSums}");
            Console.ReadKey();
        }
    }
}
