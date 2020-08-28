using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    class SudokuGames
    {
        private List<Sudoku> games;

        public SudokuGames()
        {
            games = new List<Sudoku>();
        }

        public void readFromFile(string path)
        {
            string text = System.IO.File.ReadAllText(path, Encoding.UTF8);
            text = text.Replace(" ", string.Empty).Replace("\r",string.Empty).Replace("\n", string.Empty);
            int count = 0;
            for(int a=0;a<text.Length/81;a++)
            {
                games.Add(new Sudoku());
                int[,] matrix = new int[9,9];
                for(int i=0; i<9; i++)
                {
                    for (int j = 0; j < 9; j++)
                        matrix[i, j] = Int32.Parse(text[count++].ToString());
                }
                games[a].SetMatrix(matrix);
                games[a].printSudoku();
            }            
        }

    }
}
