using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    class Sudoku
    {
        private const int size = 9;
        private int[,] matrix;

        public Sudoku()
        {
            matrix = new int[size, size];
        }

        private int generateRandom()
        {
            Random rnd = new Random();
            return rnd.Next(1,10);
        }

        private bool checkSquare(int value, int k, int r)
        {
            for(int i=k; i<k+3; i++)
            {
                for(int j=r; j<r+3; j++)
                {
                    if (matrix[i, j] == value)
                        return false;
                }
            }
            return true;
        }

        private bool checkRow(int value, int r)
        {
            for (int i = 0; i < size; i++)
            {
                if (matrix[r, i] == value)
                    return false;               
            }
            return true;
        }
        private bool checkColumn(int value, int k)
        {
            for (int i = 0; i < size; i++)
            {
                if (matrix[i, k] == value)
                    return false;
            }
            return true;
        }

        private bool fillSquare(int k, int r)
        {        
            for (int i = k-1; i<k+2; i++)
            {                
                for(int j=r-1; j<r+2; j++)
                {
                    List<int> table = new List<int>();
                    int rnd = generateRandom();
                    while( !( checkSquare(rnd,k-1,r-1) && (checkRow(rnd,i)) && checkColumn(rnd,j) ) )
                    {
                        rnd = generateRandom();
                        if(!table.Contains(rnd))
                        {
                            table.Add(rnd);
                        }
                        if (table.Count >= 9)
                            return false;
                    }
                    matrix[i, j] = rnd;
                }
            }
            return true;
        }

        private void fillWithZeros()
        {
            for(int i=0;i<size;i++)
            {
                for (int j = 0; j < size; j++)
                    matrix[i, j] = 0;
            }
        }

        private void generateDiagonal()
        {
            fillSquare(1, 1);
            fillSquare(4, 4);
            fillSquare(7, 7);
        }
        private bool generateNonDiagonal()
        {
            int cos = 0;
            generateDiagonal();
            for(int i=1; i<size; i+=3)
            {
                for(int j=1; j<size; j+=3)
                {
                    if (i != j)
                    {
                        bool flag = fillSquare(i, j);
                        if (!flag)
                        {
                            return false;
                        }
                        cos++;
                        if (cos == 6) //ile kwadratów jest wypełnionych (6 to wszystkie)
                            return true;
                    }  
                }
            }
            return true;
        }

        public bool generateSudoku()
        {
            bool flag = generateNonDiagonal();
            while(!flag)
            {
                fillWithZeros();
                flag = generateNonDiagonal();
                //printSudoku();
            }
            return flag;
        }

        public void SetMatrix(int[,] matrix)
        {
            if(matrix.GetLength(0)==size && matrix.GetLength(1)==size)
                this.matrix = matrix;
        }

        public void printSudoku()
        {

            for(int i=0; i<size+1; i++)
            {
                if((i+3)%3==0)
                {
                    for (int n = 0; n < 25; n++)
                        Console.Write("--  ");
                    Console.Write("\n\n");
                }  
                if (i<size)
                {
                    for(int j=0; j<size; j++)
                    {
                        if ((j+3) % 3 == 0)
                            Console.Write("|\t");
                        Console.Write($"{matrix[i,j]}\t");
                    }
                    Console.WriteLine("|\n");
                }                  
            }
        }

        public void saveToFile(string path)
        {
            string[] lines = new string[size+1];
            lines[0] = string.Empty;
            for (int i = 0; i < size; i++)
            {
                for(int j=0; j<size; j++)
                {
                    lines[i+1] += $"{matrix[i,j]} ";
                }                
            }

            System.IO.File.AppendAllLines(path, lines);
        }

    }
}
