using System;
using System.Collections.Generic;

namespace SudokuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<SudokuGame> sudokus = new List<SudokuGame>();
            string path = @"C:\Users\skobr\Desktop\sudokus.txt";
            while(sudokus.Count<5)

            {
                SudokuGame game = new SudokuGame();                
                game.generateSudoku();
                game.printSudoku();
                game.saveToFile(path);
                sudokus.Add(game);
            }
        }
    }
}
