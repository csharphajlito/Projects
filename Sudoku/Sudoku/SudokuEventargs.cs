using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._14_Sudoku
{
    public class SudokuEventargs :EventArgs
    {
        public bool isBacktrack { get; set; }
        public int ActualPosition { get; }
        public List<int> FieldValues { get; set; }
        public List<int> WrongNumbers { get; set; }

        public SudokuEventargs(List<int> wrongNumbers,int actualPosition)
        {
            WrongNumbers = wrongNumbers;
            ActualPosition = actualPosition;
            isBacktrack = false;
        }
    }
}
