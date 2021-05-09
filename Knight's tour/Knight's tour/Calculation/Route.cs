using System.Collections.Generic;


namespace Knight_s_tour
{
    public class Route : IRoute
    {
        private List<int> route = new List<int>(64);

        public List<int> GetPath
        {
            get { return route; }
            set { route = value; }
        }

        public int this[int index]
        {
            get { return route[index]; }
            set { route[index] = value; }
        }

        public void Add(int num)
        {
            route.Add(num);
        }
    }
}
