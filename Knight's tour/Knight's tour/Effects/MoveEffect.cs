using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Knight_s_tour
{
   
    public class MoveEffect
    {
        public int Interval { get; set; }
        public PictureBox Knight { get; private set; }
        private EffectCalculator effectcalculator = new EffectCalculator();

        public MoveEffect()
        {
            Interval = 450;
        }
        
        public void moveKnight(Panel pnl, Initializer board, PictureBox knight, List<int> path)
        {
            Knight = knight;

            int fieldWidth = pnl.Width / board.ColumnCount; //egy saktábla kocka szélleség
            int fieldHeight = pnl.Height / board.RowCount;//egy sakktábla kocka magasság

            List<Point> directionPoints = new List<Point>(board.ColumnCount * board.RowCount);
            int[] directionCoordinates;

            int x;
            int y;

            for (int i = 0; i < path.Count; ++i)
            {
                directionCoordinates = effectcalculator.getRowAndColumnIndex(path[i]);

                //sor beállítás
                x = effectcalculator.getPositionInPixels(fieldHeight, directionCoordinates[0]);
                //oszlop beállítás
                y = effectcalculator.getPositionInPixels(fieldWidth, directionCoordinates[1]);

                directionPoints.Add(new Point(y, x));
            }

            FakeTimer fTimer = new FakeTimer(Interval,directionPoints);
            fTimer.start(knight);
        }
    }
}
