using System.Collections.Generic;
using System.Linq;

namespace _02._14_Sudoku
{
    public delegate void BacktrackLogHandler(Sudoku sender,SudokuEventargs e);  
    
    public class BacktrackLogger
    {
        public event BacktrackLogHandler Backtrack;
       
        public BacktrackLogger()
        { 
            BacktrackLogHandler BH = Logging;
            BH += writeField;
            Backtrack += BH; 
        }

        private void Logging(Sudoku sender,SudokuEventargs e)
        {
            if(sender.fields[sender.actualPosition - 2].WrongWay == null)
                sender.fields[sender.actualPosition - 2].WrongWay = createDictonary(e);
            else
                if(sender.fields[sender.actualPosition - 2].WrongWay.ContainsKey(getDictonaryKey(e)))
                {
                    sender.fields[sender.actualPosition - 2].WrongWay[getDictonaryKey(e)].AddRange(getDictonaryValue(e));
                }
                else
                {
                    sender.fields[sender.actualPosition - 2].WrongWay.Add(getDictonaryKey(e),getDictonaryValue(e));
                }
        }
        private void writeField(Sudoku sender, SudokuEventargs e)
        {
            sender.fields[sender.actualPosition - 1].Value = 0;
        }
        public void InvokeBacktrack(Sudoku sender, SudokuEventargs e)
        {
            sender.logger.Backtrack.Invoke(sender, e);
        }

        private Dictionary<List<int>,List<int>> createDictonary(SudokuEventargs e)
        {
            var dict= new Dictionary<List<int>, List<int>>(new listValuesEqualityComparer());
            dict.Add(getDictonaryKey(e), getDictonaryValue(e));

            return dict;
        }

        private List<int> getDictonaryKey(SudokuEventargs e)
        {
            List<int> key = new List<int>();

            foreach (int num in e.FieldValues)
                key.Add(num);

            key.RemoveAt(key.Count() - 1);

            return key;
        }

        private List<int> getDictonaryValue(SudokuEventargs e)
        {
            List<int> values = new List<int>(); 
            int value = e.FieldValues[e.FieldValues.Count()-1];
            values.Add(value);
            return values;
        }
    }
}
