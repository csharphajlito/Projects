using System.Collections.Generic;

namespace Knight_s_tour
{
    public class FiveAndFive : Initializer
    {
        public  override int ColumnCount { get { return 5; } }
        public override int RowCount { get { return 5; } }

        public override List<Field> initializeChessTableComponent()
        {
            List<Field> component = new List<Field>(25);
            List<int> num = new List<int> //5 sor 5 oszlop
            {
                0, 1, 2, 3, 4,
                8, 9, 10, 11, 12,
                16, 17, 18, 19, 20,
                24, 25, 26, 27, 28,
                32, 33, 34, 35, 36
            };

            for (int i = 0; i < 25; ++i)
                component.Add(new Field(num[i]));

            return component;
        }
    }
}
