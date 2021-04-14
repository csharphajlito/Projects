﻿using System.Collections.Generic;
using System.Linq;

namespace _02._14_Sudoku
{
    class listValuesEqualityComparer : IEqualityComparer<List<int>>
    {
        private bool isEqual;
        public bool Equals(List<int> x, List<int> y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;
            else if(comparerLists(x,y))
                return true;
            else
                return false;
        }

        public int GetHashCode(List<int> list)
        {
            int hCode = 0;

            for (int i = 0; i < list.Count - 1; ++i)
                hCode += list[i] ^ list[i + 1];

            return hCode;
        }

        private bool comparerLists( List<int> x, List<int> y)
        {
            if (x.Count != y.Count)
                return false;

            isEqual = true;

            for (int i = 0; i < x.Count(); ++i)
            {
                if (x[i] != y[i])
                    return false;
            }

            return isEqual;
        }
    }
}
