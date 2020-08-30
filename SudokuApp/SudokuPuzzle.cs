using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    class SudokuPuzzle : Sudoku
    {
        private SudokuField[,] sudokuPuzzle;

        public SudokuPuzzle()
        {
            sudokuPuzzle = new SudokuField[size, size];
        }

        public void generateGame(int blanks)
        {
            this.generateSudoku();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    sudokuPuzzle[i, j] = new SudokuField(matrix[i, j], false);
                }
            }

            while (blanks > 0)
            {
                int i = generateRandom() - 1;
                int j = generateRandom() - 1;
                if (sudokuPuzzle[i, j].Value != 0)
                {
                    sudokuPuzzle[i, j].Value = 0;
                    sudokuPuzzle[i, j].Status = true;
                    blanks--;
                }
            }
            printSudoku();
        }

        public override void printSudoku()
        {
            for (int i = 0; i < size + 1; i++)
            {
                if ((i + 3) % 3 == 0)
                {
                    for (int n = 0; n < 25; n++)
                        Console.Write("--  ");
                    Console.Write("\n\n");
                }
                if (i < size)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if ((j + 3) % 3 == 0)
                            Console.Write("|\t");
                        Console.Write($"{sudokuPuzzle[i, j].Value}\t");
                    }
                    Console.WriteLine("|\n");
                }
            }
        }

        public void makeGuess(int x, int y, int value)
        {
            if (sudokuPuzzle[x, y].Status)
                sudokuPuzzle[x, y].Value = value;
            printSudoku();
        }
    }
}
