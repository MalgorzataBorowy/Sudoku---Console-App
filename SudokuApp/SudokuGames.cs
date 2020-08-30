using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    class SudokuGames : Sudoku
    {
        public List<Sudoku> games;

        public SudokuGames()
        {
            games = new List<Sudoku>();
        }

        public void generateNSudokus(int n, string path)
        {
            int count = 0;
            while (count < n)
            {
                Sudoku game = new Sudoku();
                game.generateSudoku();
                game.printSudoku();
                game.saveToFile(path);
                games.Add(game);
                count++;
            }
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
                games[a].setMatrix(matrix);
                games[a].printSudoku();
            }            
        }

    }
}
