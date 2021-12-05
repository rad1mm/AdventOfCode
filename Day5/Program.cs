using DomainLogic;
using Shared.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = InputReader.Read("C:\\Users\\radovan.susuk\\Documents\\AdventOfCode\\Day5\\input\\input.txt");
            var lines = new List<Line>();
            var separators = new[] { "->" };

            int minX = Int32.MaxValue;
            int minY = Int32.MaxValue;
            int maxX = Int32.MinValue;
            int maxY = Int32.MinValue;

            foreach (var inputLine in input)
            {
                var numbers = string.Join(",",inputLine.Split(separators, StringSplitOptions.RemoveEmptyEntries));
                var numberParts = numbers.Split(',').Select(s=> s.Trim()).ToArray().ChangeArrayType<int>();
                int x1 = numberParts[0];
                int y1 = numberParts[1];
                int x2 = numberParts[2];
                int y2 = numberParts[3];

                lines.Add(new Line(x1, y1, x2, y2));

                minX = x1 < minX ? x1 : minX;
                minX = x2 < minX ? x2 : minX;
                minY = y1 < minY ? y1 : minY;
                minY = y2 < minY ? y2 : minY;
                maxX = x1 > maxX ? x1 : maxX;
                maxX = x2 > maxX ? x2 : maxX;
                maxY = y1 > maxY ? y1 : maxY;
                maxY = y2 > maxY ? y2 : maxY;
            }

            int dimensionX = maxX - minX + 1;
            int dimensionY = maxY - minY + 1;
            int[,] diagram = new int[dimensionX,dimensionY];

            foreach (var point in lines.SelectMany(line => line.PointsCovered))
            {
                diagram[point.X - minX, point.Y - minY]++;
            }

            int overlappingPoints = 0;

            for (int i = 0; i < dimensionX; i++)
            {
                for (int j = 0; j < dimensionY; j++)
                {
                    if (diagram[i,j] > 1)
                    {
                        overlappingPoints++;
                    }
                }
            }

            Console.WriteLine($"Overlapping points: {overlappingPoints}");
            Console.ReadKey();

        }
    }
}
