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
                        if (sudokuPuzzle[i, j].Status)  // if value of the field can be changed, chnage the color
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{sudokuPuzzle[i, j].Value}\t");
                        Console.ForegroundColor = ConsoleColor.White;
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

        private bool checkSquare(int value, int r, int k)
        {
            // Calculating coordinates of first element of a square
            int a = r / 3;
            int b = k / 3;
            a = a * 3;
            b = b * 3;

            for (int i = a; i < a+3; i++)
            {
                for (int j = b; j < b+3; j++)
                {
                    if (!(a+i%3 == r && b+j%3 == k))    //Checking if field coordinates are the same as input coordinates
                    {
                        if(sudokuPuzzle[i ,j].Value == value)   //Checking if the field's value is equal to input value
                        {
                            return false;
                        }
                    }                        
                }
            }
            return true;
        }

        private bool checkRow(int value, int r, int k)
        {
            for (int i = 0; i < size; i++)
            {
                if (i != k && sudokuPuzzle[r, i].Value == value)
                    return false;
            }
            return true;
        }
        private bool checkColumn(int value, int r, int k)
        {
            for (int i = 0; i < size; i++)
            {
                if (i != r && sudokuPuzzle[i, k].Value == value)
                    return false;
            }
            return true;
        }

        public bool checkPuzzle()
        {
            for(int i=0;i<size;i++)
            {
                for (int j=0;j<size;j++)
                {
                    if (sudokuPuzzle[i,j].Value==0)
                        return false;
                    if (!(checkSquare(sudokuPuzzle[i, j].Value, i, j) && checkRow(sudokuPuzzle[i, j].Value, i, j) && 
                        checkColumn(sudokuPuzzle[i, j].Value, i, j)))
                        return false;
                }
            }
            return true;
        }

        public void solvePuzzle()
        {

        }
    }
}
