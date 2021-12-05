using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLogic;
using Shared;
using Shared.IO;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumbers = InputReader.Read("C:\\Users\\radovan.susuk\\Documents\\AdventOfCode\\Day4\\input\\inputNumbers.txt")[0].Split(',').ChangeArrayType<int>();
            var inputGroup = InputReader.Read("C:\\Users\\radovan.susuk\\Documents\\AdventOfCode\\Day4\\input\\inputGroups.txt");
            var separators = new[] { " ", "  " };
            var bingoBoards = new List<BingoBoard>();
            var newBoard = new BingoBoard(inputGroup[0].Split(separators, StringSplitOptions.RemoveEmptyEntries).Length);
            int xCorr = 0;
            for (int i = 0; i < inputGroup.Length; i++)
            {
                if (String.IsNullOrEmpty(inputGroup[i]))
                {
                    bingoBoards.Add(newBoard);
                    newBoard = new BingoBoard(inputGroup[0].Split(separators, StringSplitOptions.RemoveEmptyEntries).Length);
                    xCorr = 0;
                    continue;
                }

                var splitStrings = inputGroup[i].Split(separators,StringSplitOptions.RemoveEmptyEntries);
                var numbersArray = splitStrings.ChangeArrayType<int>();

                for (int j = 0; j < numbersArray.Length; j++)
                {
                    newBoard.InsertValueAtPosition(xCorr, j, numbersArray[j]);
                }

                xCorr++;
            }

            bingoBoards.Add(newBoard);

            //part1

            //int unmarkedCount = 0;
            //int lastAddedNumber = 0;
            //BingoBoard actualBoard = null;

            //foreach (int bingoNumber in inputNumbers)
            //{
            //    foreach (var board in bingoBoards)
            //    {
            //        actualBoard = board;
            //        actualBoard.Mark(bingoNumber);
            //        if (actualBoard.Won)
            //        {
            //            lastAddedNumber = bingoNumber;
            //            break;
            //        }
            //    }

            //    if (actualBoard != null && actualBoard.Won)
            //    {
            //        break;
            //    }
            //}

            //part2

            int unmarkedCount = 0;
            int lastAddedNumber = -1;
            BingoBoard actualBoard = null;
            int boardsWon = 0;
            foreach (int bingoNumber in inputNumbers)
            {
                foreach (var board in bingoBoards)
                {
                    actualBoard = board;
                    bool wonBeforeMarked = actualBoard.Won;
                    actualBoard.Mark(bingoNumber);
                    if (!wonBeforeMarked && actualBoard.Won)
                    {
                        boardsWon++;
                    }
                    if (actualBoard.Won && boardsWon == bingoBoards.Count)
                    {
                        lastAddedNumber = bingoNumber;
                        break;
                    }
                }

                if (lastAddedNumber >= 0)
                {
                    break;
                }
            }

            if (actualBoard != null)
            {
                unmarkedCount = actualBoard.SumOfAllUnmarked();
            }
            
            Console.WriteLine($"Final bingo score is is: {unmarkedCount * lastAddedNumber}");
            Console.ReadKey();
        }
    }
}
