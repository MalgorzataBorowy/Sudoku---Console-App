using System;

namespace SudokuApp
{
    class Program
    {
        static void Main(string[] args)
        {

            SudokuGame game1 = new SudokuGame();
            game1.generateSudoku();
            game1.printSudoku();
        }
    }
}
