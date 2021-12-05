using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLogic
{
    public class BingoBoard
    {
        private BoardCell[,] board;
        private int size;

        public BingoBoard(int size)
        {
            this.size = size;
            board = new BoardCell[5,5];
        }

        public bool Won { get; private set; }

        public void InsertValueAtPosition(int cell, int row, int value)
        {
            board[cell, row] = new BoardCell(value);
        }

        public void Mark(int number)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (board[i,j].Value == number)
                    {
                        board[i, j].Mark();
                        int markedInRow = 0;
                        int markedInCol = 0;
                        for (int k = 0; k < size; k++)
                        {
                            if (board[i,k]!= null && board[i, k].Marked)
                            {
                                markedInCol++;
                            }
                        }
                        for (int l = 0; l < size; l++)
                        {
                            if (board[l, j] != null && board[l, j].Marked)
                            {
                                markedInRow++;
                            }
                        }

                        if (markedInCol == size || markedInRow == size)
                        {
                            Won = true;
                        }
                    }
                }
            }
        }

        public int SumOfAllUnmarked()
        {
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    sum += board[i, j].Marked ? 0 : board[i, j].Value;
                }
            }

            return sum;
        }
    }
}
