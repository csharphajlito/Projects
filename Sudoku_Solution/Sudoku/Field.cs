using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Field
    {
        public int RowIndex { get; }
        public int ColumnIndex { get; }
        public int BlockIndex { get; }
        public int Value { get; set; }
        public Dictionary<List<int>,List<int>> WrongWay { get; set; }

        public Field(int rIndex,int cIndex,int bIndex)
        {
            RowIndex = rIndex;
            ColumnIndex = cIndex;
            BlockIndex = bIndex;

            WrongWay = null;
            Value = 0;
        }
    }
}
