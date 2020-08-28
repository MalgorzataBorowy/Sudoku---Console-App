using System;
using System.Collections.Generic;

namespace SudokuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*List<Sudoku> sudokus = new List<Sudoku>();
            string path = @"C:\Users\skobr\Desktop\sudokus.txt";
            while(sudokus.Count<1)

            {
                Sudoku game = new Sudoku();                
                game.generateSudoku();
                game.printSudoku();
                game.saveToFile(path);
                sudokus.Add(game);
            }*/
            string path = @"C:\Users\skobr\Desktop\sudokus.txt";
            SudokuGames games = new SudokuGames();
            games.readFromFile(path);
        }
    }
}
