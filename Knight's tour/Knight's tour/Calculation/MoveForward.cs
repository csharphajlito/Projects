using System;

namespace Knight_s_tour
{
    public delegate void StepForwardHandler(Calculator calculator, ForwardEventArgs e);
    public class MoveForward
    {
        public event StepForwardHandler StepForward;
        private Random rnd;

        public MoveForward()
        {
            rnd = new Random();
            StepForward += move;
        }

        public void invokeStepForward(Calculator calculator, ForwardEventArgs e)
        {
            StepForward?.Invoke(calculator, e);
        }

        private void move(Calculator calculator, ForwardEventArgs e)
        {
            calculator.getIndexes.ActualPosition = e.ValidSteps[rnd.Next(e.ValidSteps.Count)];
            calculator.getRoute.GetPath.Add(calculator.getIndexes.ActualPosition);

            calculator.getIndexes.ActualRow = calculator.getIndexes.ActualPosition / 8;
            calculator.getIndexes.ActualColumn = calculator.getIndexes.ActualPosition % 8;
        }
    }
}
