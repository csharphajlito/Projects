using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;

namespace Knight_s_tour
{
    public class Calculator
    {
        public int[] CurrentFieldIndexes { get; private set; }

        private IRoute _route;
        private ICalculatorIndexes _indexes;
        private IBacktrackLogger _logger;
        private StepService stepService;
        private MoveForward move;

        public int Iterations { get; set; }
        private int fieldsCount;

        public Calculator(List<Field> fields, int actualPosition,
            IRoute route = null, ICalculatorIndexes indexes = null, IBacktrackLogger logger = null)
        {
            CurrentFieldIndexes = fields.Select(f => f.Index).ToArray();
            _route = route ?? new Route();
            _indexes = indexes ?? new CalculatorIndexes();
            _logger = logger ?? new BacktrackLogger();

            _indexes.ActualPosition = actualPosition; //kezdő pozíció adott
            _route.Add(actualPosition);
            setActualRowAndColumn();

            stepService = new StepService();
            move = new MoveForward();

            Iterations = 0;
            fieldsCount = CurrentFieldIndexes.Length;
        }

        public void solve()
        {
            do
            {
                stepService.steping(_indexes, CurrentFieldIndexes, _route.GetPath, _logger, move, this);
                ++Iterations;
            } while (_route.GetPath.Count != fieldsCount);
        }

        private void setActualRowAndColumn()
        {
            _indexes.ActualRow = _indexes.ActualPosition / 8;
            _indexes.ActualColumn = _indexes.ActualPosition % 8;
        }

        public IBacktrackLogger getLogger { get { return _logger; } }
        public IRoute getRoute { get { return _route; } }
        public ICalculatorIndexes getIndexes { get { return _indexes; } }
        public MoveForward getMoveObject { get { return move; } }
    }
}
