using System.Collections.Generic;

namespace Knight_s_tour
{
    public class ValidStepCalculator : IValidStepCalculator
    {

        public bool haveValidStep(ICalculatorIndexes _indexes, int[] currentFieldIndexes, List<int> path,
            IBacktrackLogger _logger, IStepService _service, out List<int> validSteps)
        {
            #region spimplification
            int tempTargetIndex;
            int actualRowIndex = _indexes.ActualRow;
            int actualColumnIndex = _indexes.ActualColumn;
            Step steps = new Step();
            #endregion

            validSteps = new List<int>(8);

            foreach (var step in steps.GetEnumerator())
            {
                tempTargetIndex = _service.getTargetIndex(actualRowIndex + step.x, actualColumnIndex + step.y);
                if (_service.isInRange(currentFieldIndexes, tempTargetIndex) && !_service.isLogged(_logger, tempTargetIndex, path) &&
                    !_service.isInPath(tempTargetIndex, path))
                {
                    validSteps.Add(tempTargetIndex);
                }
            }

            return validSteps.Count != 0;
        }
    }
}
