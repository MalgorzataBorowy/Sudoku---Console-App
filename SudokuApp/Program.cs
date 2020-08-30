using System;
using System.Collections.Generic;

namespace SudokuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SudokuPuzzle puzzle = new SudokuPuzzle();
            puzzle.generateGame(30);

            while(true)
            { 
                Console.WriteLine("Make a guess: Enter x: ");
                int x = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter y: ");
                int y = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter value: ");
                int value = Int32.Parse(Console.ReadLine());

                puzzle.makeGuess(x, y, value);
                puzzle.printSudoku();   
            }

            /*Sudoku sudoku = new Sudoku();
            sudoku.generateSudoku();
            sudoku.printSudoku();
            sudoku.fillWithBlanks(55);
            sudoku.printSudoku();*/


            //SudokuGames games = new SudokuGames();
            //string path = @"C:\Users\skobr\Desktop\sudokus.txt";
            //games.generateNSudokus(4, path);

            //games.readFromFile(path);
            //games.games[0].fillWithBlanks(50);
            //games.games[0].printSudoku();
        }
    }
}
