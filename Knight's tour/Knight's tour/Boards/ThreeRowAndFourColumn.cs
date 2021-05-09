using System.Collections.Generic;

namespace Knight_s_tour
{
    public class ThreeRowAndFourColumn : Initializer
    {
        public override int ColumnCount { get { return 4; } }
        public override int RowCount { get { return 3; } }

        public override List<Field> initializeChessTableComponent()
        {
            List<Field> component = new List<Field>(12);
            List<int> num = new List<int> //3 sor 4 sozlop
            {
                0, 1, 2, 3,
                8, 9, 10, 11,
                16, 17, 18, 19
            };

            for (int i = 0; i < 12; ++i)
                component.Add(new Field(num[i]));

            return component;
        }
    }
}
