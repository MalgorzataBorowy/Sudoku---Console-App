using System;
using System.Collections.Generic;

namespace SudokuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SudokuGames games = new SudokuGames();
            string path = @"C:\Users\skobr\Desktop\sudokus.txt";
            games.generateNSudokus(4, path);

            //games.readFromFile(path);
        }
    }
}
