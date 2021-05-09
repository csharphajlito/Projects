using System.Collections.Generic;

namespace Knight_s_tour
{
    public interface IBacktrackLogger
    {
        event BacktrackHandler Backtrack;
        Dictionary<List<int>, List<int>> BacktracksContainer { get; }
        void invokeBacktrack(Calculator calculator, StepBackEventArgs e);
    }

    public interface ICalculatorIndexes
    {
        int ActualPosition { get; set; }
        int ActualRow { get; set; }
        int ActualColumn { get; set; }
        int TempTargetIndex { get; set; }
    }

    public interface IRoute
    {
        int this[int index] { get; set; }
        List<int> GetPath { get; set; }
        void Add(int num);
    }

    public interface IStepService
    {
        int getTargetIndex(int x, int y);
        bool isInRange(int[] currentFieldIndexes, int tempTargetIndex);
        bool isInPath(int tempTargetIndex, List<int> path);
        bool isLogged(IBacktrackLogger _logger, int tempTargetIndex, List<int> path);
    }

    public interface IValidStepCalculator
    {
        bool haveValidStep(ICalculatorIndexes _indexes, int[] currentFieldIndexes, List<int> path,
            IBacktrackLogger _logger, IStepService _service, out List<int> validSteps);
    }
}
