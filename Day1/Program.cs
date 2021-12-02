using Shared.IO;
using System;
using Shared;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = InputReader.Read("C:\\Users\\radovan.susuk\\Documents\\AdventOfCode\\Day1\\input\\input.txt");
            int biggerNumbers = 0;

            for (int i = 1; i < input.Length; i++)
            {
                biggerNumbers = input[i - 1].ChangeType<int>() < input[i].ChangeType<int>() ? biggerNumbers + 1 : biggerNumbers;
            }

            Console.WriteLine($"Input array length: {input.Length}");
            Console.WriteLine($"Bigger consecutive numbers count: {biggerNumbers}");
            Console.ReadKey();
        }
    }
}
