using System.Collections.Generic;

namespace Knight_s_tour
{
    public class FiveRowAndSixColumn : Initializer
    {
        public override int ColumnCount { get { return 6; } }
        public override int RowCount { get { return 5; } }

        public override List<Field> initializeChessTableComponent()
        {
            List<Field> component = new List<Field>(30);
            List<int> num = new List<int>  // 5 sor 6 oszlop
            {
                0, 1, 2, 3, 4, 5,
                8, 9, 10, 11, 12, 13,
                16, 17, 18, 19, 20, 21,
                24, 25, 26, 27, 28, 29,
                32, 33, 34, 35, 36, 37
            };

            for (int i = 0; i < 30; ++i)
                component.Add(new Field(num[i]));

            return component;
        }
    }
}
