using System;
using System.Collections.Generic;

namespace Knight_s_tour
{
    public class Step
    {
        private Pair[] pairs;
        public Step()
        {
            Random rnd = new Random();
            int randomQueNumber;

            List<int> x = new List<int> { 2, 1, -1, -2, -2, -1, 1, 2 },
                         y = new List<int> { 1, 2, 2, 1, -1, -2, -2, -1 };

            pairs = new Pair[8];

            for (int i = 0; i < 8; ++i)
            {
                randomQueNumber = rnd.Next(x.Count);
                pairs[i] = new Pair(x[randomQueNumber], y[randomQueNumber]);

                x.RemoveAt(randomQueNumber);
                y.RemoveAt(randomQueNumber);
            }
        }

        public IEnumerable<Pair> GetEnumerator()
        {
            foreach (Pair p in pairs)
                yield return p;
        }

        public Pair this[int i]
        {
            get
            {
                return pairs[i];
            }
        }

        public class Pair
        {
            public int x { get; }
            public int y { get; }

            public Pair(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
