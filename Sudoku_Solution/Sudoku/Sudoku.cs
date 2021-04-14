using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Sudoku
{
    public delegate void SolvingHandler(Sudoku sender, SudokuEventargs e);
    public class Sudoku
    {
        public event SolvingHandler Solve;
        private SolvingHandler so;

        public int[] indexes;
        public List<Field> fields; 
        private Random rnd;
        public int actualPosition;
        public int numberOfBacktracks;
        public BacktrackLogger logger;
        
        public Sudoku()
        {
            #region initialize
            fields = new List<Field>();
            numberOfBacktracks = 0;

            for (int i=0; i < 81; ++i)
            {
                indexes = Changer.actualPositionToIndexes(i);
                fields.Add(new Field(indexes[0], indexes[1], indexes[2]));
            }

            logger = new BacktrackLogger();
            rnd = new Random();

            fields[0].Value = rnd.Next(1, 10);
            actualPosition = 1;

            so += decideDirection;
            so += stepForward;
            so += stepBack;
            so += setActualPosition;
            Solve += so;
            #endregion
        }

        public IEnumerable<Field> GetEnumerator()
        {
            foreach (Field f in fields)
                yield return f;
        }

        private List<int> getTakedNumber()
        {
            indexes = Changer.actualPositionToIndexes(actualPosition);  

            return (from f in fields
                    where (f.ColumnIndex == indexes[1] ||
                    f.RowIndex == indexes[0] ||
                    f.BlockIndex == indexes[2]) &&
                    f.Value != 0                        
                    select f.Value).Distinct().ToList();
        }

        private int generateRightNumber(SudokuEventargs e)
        {
            int rightNumber; 

            do
            {
                rightNumber = rnd.Next(1, 10);
            } while (e.WrongNumbers.Contains(rightNumber));

            return rightNumber;
        }

        public void solving()
        {
            Solve?.Invoke(this, new SudokuEventargs(getTakedNumber(),actualPosition)); 
        }

        private void checkWrongNumbers(Sudoku su,SudokuEventargs e)
        {
            List<int> key = new List<int>(selectFieldValues(su));

            if (su.fields[actualPosition - 1].WrongWay != null 
                && su.fields[actualPosition - 1].WrongWay.ContainsKey(key))
            {
                List<int> num = su.fields[actualPosition - 1].WrongWay[key];
                e.WrongNumbers.AddRange(num);
            }
        }  
        
        public void getSolution()
        {
            int threadSleepValue = 50;
            Stopwatch sW = new Stopwatch();
            sW.Start();

            do
            {
                solving();
                Program.Draw(this);
                Thread.Sleep(threadSleepValue);
            } while (actualPosition!=81);

            sW.Stop();
            Console.WriteLine("\r\n~"+sW.ElapsedMilliseconds/1000+" sec needed to solve.");
            int withoutDelay = Convert.ToInt32(sW.ElapsedMilliseconds) - (numberOfBacktracks * 2 - 1 + 81) * threadSleepValue;
            Console.WriteLine("whithout delay: "+withoutDelay/1000+" sec.");
            Console.WriteLine("{0} backtracks.",numberOfBacktracks);
        }

        private void decideDirection(Sudoku sender, SudokuEventargs e)
        {
            checkWrongNumbers(sender, e);

            bool isBacktrack = e.WrongNumbers.Count == 9;

            e.isBacktrack = isBacktrack;
        }

        private void stepForward(Sudoku sender, SudokuEventargs e)
        {
            if (!e.isBacktrack)
            {
                sender.fields[actualPosition].Value = generateRightNumber(e);
            }
        }

        private void stepBack(Sudoku sender, SudokuEventargs e)
        {
            if (e.isBacktrack)
            {
                e.FieldValues = selectFieldValues(sender);
                sender.logger.InvokeBacktrack(sender, e);
                ++numberOfBacktracks;
            }

        }

        private void setActualPosition(Sudoku sender,SudokuEventargs e)
        {
            if (e.isBacktrack)
                --sender.actualPosition;
            else
                ++sender.actualPosition;
        }

        private List<int> selectFieldValues(Sudoku su)
        {
            List<int> selectedValues= su.fields.Select(field=>field.Value).ToList();
            do
            {
                selectedValues.RemoveAt(selectedValues.IndexOf(0));
            } while (selectedValues.Contains(0));

            return selectedValues;
        }
    } 
}
