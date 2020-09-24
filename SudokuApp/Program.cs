using System;
using System.Collections.Generic;

namespace SudokuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SudokuPuzzle puzzle = new SudokuPuzzle();
            puzzle.generateGame(5);
            bool solved = puzzle.solvePuzzle();
            puzzle.printSudoku();

            /*bool unsolved = true;

            while(unsolved)
            { 
                Console.WriteLine("Make a guess: Enter row number: ");
                int x = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter column number: ");
                int y = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter value: ");
                int value = Int32.Parse(Console.ReadLine());

                puzzle.makeGuess(x, y, value);
                puzzle.printSudoku();
                unsolved = !puzzle.checkPuzzle();
            }
            if (!unsolved)
            {
                Console.WriteLine("Puzzle solved");
            }*/
        }
    }
}
