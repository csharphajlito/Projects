using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._14_Sudoku
{
    public class Program
    {
        public static void Draw(Sudoku su)
        {
            Console.Clear();
            int index = 1;

            Console.Write("|");

            foreach (var field in su.GetEnumerator())
            {
                if (su.actualPosition == index)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(field.Value);
                    Console.ResetColor();
                }
                else
                    Console.Write(field.Value);
                if (index % 9 == 0 && index != 0)
                {
                    Console.Write("|\r\n");
                }

                if (index % 27 == 0)
                    Console.Write("-------------\r\n");

                if (index % 3 == 0 && index != 81)
                    Console.Write("|");

                ++index;
            }
        }

        static void Main(string[] args)
        {
            Sudoku sudoku = new Sudoku();
            sudoku.getSolution();

            Console.ReadKey();
        }
    }
}
