using Shared.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    class Program
    {
        private const char bracketA1 = '(';
        private const char bracketA2 = ')';
        private const char bracketB1 = '[';
        private const char bracketB2 = ']';
        private const char bracketC1 = '<';
        private const char bracketC2 = '>';
        private const char bracketD1 = '{';
        private const char bracketD2 = '}';

        static void Main(string[] args)
        {
            
            var input = InputReader.Read("C:\\Users\\radovan.susuk\\Documents\\AdventOfCode\\Day10\\input\\input.txt");
            //part1
            int[] invalidBracketsCount = new int[4];
            bool stop = true;
            List<string> incompleteLines = new List<string>();
            for (var i = 0; i < input.Length; i++)
            {
                var line = input[i];
                if (!stop)
                {
                    incompleteLines.Add(input[i-1]);
                }

                Stack<char> stack = new Stack<char>();
                stop = false;
                for (var index = 0; index < line.Length; index++)
                {
                    if (line[index] == bracketA1 ||
                        line[index] == bracketB1 ||
                        line[index] == bracketC1 ||
                        line[index] == bracketD1)
                    {
                        stack.Push(line[index]);
                    }
                    else if (stack.Count > 0)
                    {
                        switch (line[index])
                        {
                            case bracketA2:
                            {
                                if (stack.Pop() != bracketA1)
                                {
                                    invalidBracketsCount[0]++;
                                    stop = true;
                                }

                                break;
                            }
                            case bracketB2:
                            {
                                if (stack.Pop() != bracketB1)
                                {
                                    invalidBracketsCount[1]++;
                                    stop = true;
                                }

                                break;
                            }
                            case bracketC2:
                            {
                                if (stack.Pop() != bracketC1)
                                {
                                    invalidBracketsCount[3]++;
                                    stop = true;
                                }

                                break;
                            }
                            case bracketD2:
                            {
                                if (stack.Pop() != bracketD1)
                                {
                                    invalidBracketsCount[2]++;
                                    stop = true;
                                }

                                break;
                            }
                        }

                        if (stop)
                        {
                            break;
                        }
                    }
                }
            }

            if (!stop)
            {
                incompleteLines.Add(input.Last());
            }

            //part2
            List<string> missingCharsLines = new List<string>();

            foreach (var incompleteLine in incompleteLines)
            {
                Stack<char> stack = new Stack<char>();
                for (int index = 0; index < incompleteLine.Length; index++)
                {
                    if (incompleteLine[index] == bracketA1 ||
                        incompleteLine[index] == bracketB1 ||
                        incompleteLine[index] == bracketC1 ||
                        incompleteLine[index] == bracketD1)
                    {
                        stack.Push(incompleteLine[index]);
                    }
                    else if (incompleteLine[index] == bracketA2 ||
                             incompleteLine[index] == bracketB2 ||
                             incompleteLine[index] == bracketC2 ||
                             incompleteLine[index] == bracketD2)
                    {
                        stack.Pop();
                    }
                }

                string missingcharLine = "";
                while (stack.Count > 0)
                {
                    char c = stack.Pop();
                    switch (c)
                    {
                        case bracketA1:
                        {
                            missingcharLine = missingcharLine + bracketA2;
                            break;
                        }
                        case bracketB1:
                        {
                            missingcharLine = missingcharLine + bracketB2;
                            break;
                        }
                        case bracketC1:
                        {
                            missingcharLine = missingcharLine + bracketC2;
                            break;
                        }
                        case bracketD1:
                        {
                            missingcharLine = missingcharLine + bracketD2;
                            break;
                        }
                    }
                }
                missingCharsLines.Add(missingcharLine);
            }

            List<long> points = new List<long>();

            foreach (string missingCharsLine in missingCharsLines)
            {
                long pointsForline = 0;
                foreach (char c in missingCharsLine)
                {
                    pointsForline = pointsForline * 5;
                    pointsForline += GetPointForChar(c);
                }
                points.Add(pointsForline);
            }

            points = points.OrderBy(i=>i).ToList();


            Console.WriteLine($"Sum: {invalidBracketsCount[0]*3 + invalidBracketsCount[1]*57+invalidBracketsCount[3]*25137+invalidBracketsCount[2]*1197}");
            Console.WriteLine($"Middle score: {points[points.Count/2]}");
            Console.ReadKey();

        }

        private static int GetPointForChar(char c)
        {
            switch (c)
            {
                case bracketA2:
                    return 1;
                case bracketB2:
                    return 2;
                case bracketC2:
                    return 4;
                case bracketD2:
                    return 3;
            }

            return 0;
        }
    }
}
