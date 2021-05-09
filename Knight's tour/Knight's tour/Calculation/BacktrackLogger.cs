using System.Collections.Generic;

namespace Knight_s_tour
{
    public delegate void BacktrackHandler(Calculator calculator, StepBackEventArgs e);
    public delegate void RefreshIndexesHandler(Calculator calculator, StepBackEventArgs e);

    public class BacktrackLogger : IBacktrackLogger
    {
        private Dictionary<List<int>, List<int>> backtracksContainer;
        public Dictionary<List<int>, List<int>> BacktracksContainer { get => backtracksContainer; }

        public event BacktrackHandler Backtrack;
        private event RefreshIndexesHandler RefreshIndexes;

        public BacktrackLogger()
        {
            backtracksContainer = new Dictionary<List<int>, List<int>>(new ListValuesEqualityComparer());
            Backtrack += Logging;
            RefreshIndexes += setMembersAfterBacktracking;
        }

        public void invokeBacktrack(Calculator calculator, StepBackEventArgs e)
        {
            Backtrack?.Invoke(calculator, e);
        }

        private void Logging(Calculator calculator, StepBackEventArgs e)
        {
            List<int> key = getKey(e.Path);
            List<int> value = getValue(e);

            if (BacktracksContainer.ContainsKey(key))
                BacktracksContainer[key].AddRange(value);
            else
                BacktracksContainer.Add(key, value);


            RefreshIndexes?.Invoke(calculator, e);
        }

        private List<int> getKey(List<int> path)
        {
            List<int> key = new List<int>(path);
            key.RemoveAt(key.Count - 1);

            return key;
        }

        private List<int> getValue(StepBackEventArgs e)
        {
            List<int> value = new List<int>();
            value.Add(e.ActualPosition);

            return value;
        }

        private void setMembersAfterBacktracking(Calculator calculator, StepBackEventArgs e)
        {
            List<int> key = getKey(e.Path);
            int actualPosition = key[key.Count - 1];

            calculator.getRoute.GetPath = key;
            calculator.getIndexes.ActualPosition = actualPosition;
            calculator.getIndexes.ActualRow = actualPosition / 8;
            calculator.getIndexes.ActualColumn = actualPosition% 8;
        }
    }
}
