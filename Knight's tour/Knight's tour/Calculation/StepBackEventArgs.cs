using System;
using System.Collections.Generic;

namespace Knight_s_tour
{
    public class StepBackEventArgs : EventArgs
    {
        public List<int> Path { get; }
        public int ActualPosition { get { return Path[Path.Count - 1]; } }

        public StepBackEventArgs(List<int> path)
        {
            Path = path;
        }
    }
}
