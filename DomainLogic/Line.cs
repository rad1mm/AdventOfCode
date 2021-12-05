using System;
using System.Collections.Generic;
using System.Drawing;

namespace DomainLogic
{
    public class Line
    {
        private int x1;
        private int y1;
        private int x2;
        private int y2;

        public Line(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1; 
            this.x2 = x2;
            this.y2 = y2;

            PointsCovered = new List<Point>();
            int firstX = x1 <= x2 ? x1 : x2;
            int firstY = y1 <= y2 ? y1 : y2;
            int secondX = x1 > x2 ? x1 : x2;
            int secondY = y1 > y2 ? y1 : y2;
            
            //vertical or horizontal line
            if (x1 == x2 || y1 == y2)
            {
                InitializeHorizontalOrVerticalPoints(firstX, firstY, secondX, secondY);
            }//check if diagonal
            else if(Math.Abs(x1 - x2) == Math.Abs(y1-y2))
            {
                bool diagonalSecondary = x1 < x2 && y1 > y2 || x1 > x2 && y1 < y2;
                InitializeDiagonalPoints(diagonalSecondary, firstX, firstY, secondX, secondY);
            }
        }



        private void InitializeHorizontalOrVerticalPoints(int firstX,int firstY,int secondX, int secondY)
        {
            for (int i = firstX; i <= secondX; i++)
            {
                for (int j = firstY; j <= secondY; j++)
                {
                    PointsCovered.Add(new Point(i, j));
                }
            }
        }

        private void InitializeDiagonalPoints(bool secondaryDiagonal, int firstX, int firstY, int secondX, int secondY)
        {
            for (int i = firstX; i <= secondX; i++)
            {
                for (int j = firstY; j <= secondY; j++)
                {
                    if (secondaryDiagonal)
                    {
                        if (i - firstX + j - firstY == secondX - firstX)
                        {
                            PointsCovered.Add(new Point(i, j));
                        }
                    }
                    else
                    {
                        if (i - firstX == j - firstY)
                        {
                            PointsCovered.Add(new Point(i, j));
                        }
                    }
                }
            }
        }

        public List<Point> PointsCovered { get; private set; }
    }
}
