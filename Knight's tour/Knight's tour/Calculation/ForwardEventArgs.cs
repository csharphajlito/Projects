using System.Collections.Generic;

namespace Knight_s_tour
{
    public class ForwardEventArgs
    {
        public List<int> ValidSteps { get; }

        public ForwardEventArgs(List<int> validSteps)
        {
            ValidSteps = validSteps;
        }
    }
}
