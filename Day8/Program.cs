using Shared.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            int zero = 6;
            int one = 2;
            int two = 5;
            int three = 5;
            int four = 4;
            int five = 5;
            int six = 6;
            int seven = 3;
            int eight = 7;
            int nine = 6;
            int[] knownDigitNumbers = new[] { one, four, seven, eight };

            var input = InputReader.Read("C:\\Users\\radovan.susuk\\Documents\\AdventOfCode\\Day8\\input\\input.txt");
            //part1
            //int noOfKnownDigitsNumbers = 0;
            //foreach (var text in input)
            //{
            //    var outputPart = text.Split('|')[1].Split(' ').Select(s => s.Trim()).ToArray();
            //    foreach (var stringNumber in outputPart)
            //    {
            //        if (knownDigitNumbers.Contains(stringNumber.Length))
            //        {
            //            noOfKnownDigitsNumbers++;
            //        }
            //    }
            //}

            //Console.WriteLine($"Known numbers count: {noOfKnownDigitsNumbers}");
            //Console.ReadKey();

            //part2
            char[] parts = new char[7];
            int sumOfAll = 0;
            foreach (var text in input)
            {
                string inputPart = text.Split('|')[0];
                string knownParts = "";
                foreach (char letter in "abcdefg")
                {
                    var letterCount = inputPart.Count(c => c == letter);
                    switch (letterCount)
                    {
                        case 9:
                            parts[5] = letter;
                            knownParts += letter;
                            break;
                        case 4:
                            parts[4] = letter;
                            knownParts += letter;
                            break;
                        case 6:
                            parts[1] = letter;
                            knownParts += letter;
                            break;
                    }
                }

                var oneParts = inputPart.Split(' ').Select(t => t.Trim()).Where(s=>s.Length == one).ToArray()[0];
                parts[2] = oneParts[0] == parts[5] ? oneParts[1] : oneParts[0];
                knownParts += parts[2];
                var sevenParts = inputPart.Split(' ').Select(t => t.Trim()).Where(s => s.Length == seven).ToArray()[0];
                parts[0] = sevenParts.Except(oneParts).First();
                knownParts += parts[0];
                var sixPartParts = inputPart.Split(' ').Select(t => t.Trim()).Where(s => s.Length == zero).ToArray();
                var unknownLetters = "abcdefg".Except(knownParts).ToArray();
                int firstUnknownLetterCount = 0;
                foreach (string sixPartPart in sixPartParts)
                {
                    if (sixPartPart.Contains(unknownLetters[0]))
                    {
                        firstUnknownLetterCount++;
                    }
                }

                parts[3] = firstUnknownLetterCount == 2 ? unknownLetters[0] : unknownLetters[1];
                parts[6] = firstUnknownLetterCount == 2 ? unknownLetters[1] : unknownLetters[0];


                string zeroCode = parts[0].ToString() + parts[1] + parts[2] + parts[4] + parts[5] + parts[6];
                string oneCode = parts[2].ToString() + parts[5];
                string twoCode = parts[0].ToString() + parts[2] + parts[3] + parts[4] +parts[6];
                string threeCode = parts[0].ToString() + parts[2] + parts[3] + parts[5] + parts[6];
                string fourCode = parts[1].ToString() + parts[2] + parts[3] + parts[5];
                string fiveCode = parts[0].ToString() + parts[1] + parts[3] + parts[5] + parts[6];
                string sixCode = parts[0].ToString() + parts[1] + parts[3] + parts[4] + parts[5] + parts[6];
                string sevenCode = parts[0].ToString() + parts[2] + parts[5];
                string eightCode = parts[0].ToString() + parts[1] + parts[2] + parts[3] + parts[4] + parts[5] + parts[6];
                string nineCode = parts[0].ToString() + parts[1] + parts[2] + parts[3] + parts[5] + parts[6];

                string[] numbers = new[]
                {
                    zeroCode, oneCode, twoCode, threeCode, fourCode, fiveCode, sixCode, sevenCode, eightCode, nineCode
                };

                int[] outputNumbers = new int[4];
                var outputPart = text.Split('|')[1].Trim().Split(' ').Select(s => s.Trim()).ToArray();
                for (int i = 0; i < 4; i++)
                {
                    var aSet = new HashSet<char>(outputPart[i]);
                    for (int j = 0; j < numbers.Length; j++)
                    {
                        var bSet = new HashSet<char>(numbers[j]);
                        if (aSet.SetEquals(bSet))
                        {
                            outputNumbers[i] = j;
                            break;
                        }
                    }
                }

                int finalOutputNumber = 1000 * outputNumbers[0] + 100 * outputNumbers[1] + 10 * outputNumbers[2] +
                                        outputNumbers[3];
                sumOfAll += finalOutputNumber;

            }

            Console.WriteLine($"Sum: {sumOfAll}");
            Console.ReadKey();
        }
    }
}
