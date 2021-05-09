using System.Collections.Generic;

namespace Knight_s_tour
{
    public class EightAndEight : Initializer
    {
        public override int ColumnCount { get { return 8; } }
        public override int RowCount { get { return 8; } }

        public override List<Field> initializeChessTableComponent()
        {
            //8 sor 8 oszlop
            List<Field> component = new List<Field>(64);

            for (int i = 0; i < 64; ++i)
                component.Add(new Field(i));

            return component;
        }
    }
}
