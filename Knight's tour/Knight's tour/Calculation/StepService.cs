using System.Collections.Generic;
using System.Linq;

namespace Knight_s_tour
{
    public class StepService : IStepService
    {
        private IValidStepCalculator _validStepCalculator;

        public StepService(IValidStepCalculator validStepCalculator = null)
        {
            _validStepCalculator = validStepCalculator ?? new ValidStepCalculator();
        }

        public int getTargetIndex(int x, int y)
        {
            if (x >= 0 && x < 8 &&
                y >= 0 && y < 8)
                return (x * 8 + y);

            return -1;
        }

        public bool isInRange(int[] currentFieldIndexes, int tempTargetIndex)
        {
            return currentFieldIndexes.Contains(tempTargetIndex);
        }

        public bool isInPath(int tempTargetIndex, List<int> path)
        {
            return path.Contains(tempTargetIndex);
        }

        public bool isLogged(IBacktrackLogger _logger, int tempTargetIndex, List<int> path)
        {
            return _logger.BacktracksContainer.ContainsKey(path) &&
                _logger.BacktracksContainer[path].Contains(tempTargetIndex);
        }

        public void steping(ICalculatorIndexes _indexes, int[] currentFieldIndexes, List<int> path,
            IBacktrackLogger _logger, MoveForward move, Calculator calculator)
        {
            List<int> validSteps = new List<int>();

            if (_validStepCalculator.haveValidStep(_indexes, currentFieldIndexes, path, _logger, this, out validSteps))
                move.invokeStepForward(calculator, new ForwardEventArgs(validSteps));
            else
                _logger.invokeBacktrack(calculator, new StepBackEventArgs(path));
        }
    }
}
