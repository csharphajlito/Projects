namespace Knight_s_tour
{
    public class Field
    {
        public int Index { get; }
        public int RowIndex { get; } 
        public int ColumnIndex { get; } 

        public Field(int index)
        {
            Index = index;

            RowIndex = Index / 8;
            ColumnIndex = Index % 8;
        }
    }
}
