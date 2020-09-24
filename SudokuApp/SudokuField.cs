using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    struct SudokuField
    {
        public int Value { get; set; }
        public bool Status { get; set; } //if the value can be changed

        public SudokuField(int value, bool status)
        {
            Status = status;
            Value = value;
        }
    }
}
