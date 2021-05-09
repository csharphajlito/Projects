using System.Collections.Generic;


namespace Knight_s_tour
{
    public abstract class Initializer
    {
        public abstract List<Field> initializeChessTableComponent();
        public abstract int ColumnCount { get; }
        public abstract int RowCount { get; }
    }
}
