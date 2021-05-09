namespace Knight_s_tour
{
    public class CalculatorIndexes : ICalculatorIndexes
    {
        public int ActualPosition { get; set; }
        public int ActualRow { get; set; }
        public int ActualColumn { get; set; }
        public int TempTargetIndex { get; set; }
    }
}
