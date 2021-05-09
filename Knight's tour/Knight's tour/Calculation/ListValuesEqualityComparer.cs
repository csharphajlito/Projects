using System.Collections.Generic;
using System.Linq;

namespace Knight_s_tour
{
    class ListValuesEqualityComparer : IEqualityComparer<List<int>>
    {
        public bool Equals(List<int> x, List<int> y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;

            return comparerLists(x, y);
        }

        public int GetHashCode(List<int> list)
        {
            int hCode = 0;

            for (int i = 0; i < list.Count - 1; ++i)
                hCode += list[i] ^ list[i + 1];

            return hCode;
        }

        private bool comparerLists(List<int> x, List<int> y)
        {
            if (x.Count != y.Count)
                return false;

            bool isEqual = true;

            for (int i = 0; i < x.Count(); ++i)
            {
                if (x[i] != y[i])
                    return false;
            }

            return isEqual;
        }
    }
}
