using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Knight_s_tour
{
    public class EffectCalculator
    {
        public int[] getRowAndColumnIndex(int position)
        {
            int[] coordinates = new int[2];

            coordinates[0] = position / 8; //sor
            coordinates[1] = position % 8; //oszlop

            return coordinates;
        }

        public int getPositionInPixels(int coordinate,int fieldSize)
        {
            return coordinate * fieldSize;
        }
    }
}
