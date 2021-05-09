using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using Knight_s_tour.Properties;

namespace Knight_s_tour
{
    public delegate void knightControlMoveHandler(PictureBox knight, Point location);

    public class FakeTimer
    {
        public int Interval { get; set; }
        public List<Point> Points { get; set; }

        public FakeTimer(int interval, List<Point> points)
        {
            Interval = interval;
            Points = points;
        }

        public async void start(PictureBox knight)
        {
            Task waitTask;

            for (int i = 0; i < Points.Count; ++i)
            {
                moveKnight(knight, Points[i]);

                waitTask = new Task(() => Thread.Sleep(Interval));
                waitTask.Start();
                await waitTask;
                waitTask = null;
            }
        }

        private void moveKnight(PictureBox knight, Point location)
        {
            knightControlMoveHandler mover = new knightControlMoveHandler(move);
            knight.Invoke(mover,knight,location);
        }

        private void move(PictureBox knight, Point location)
        {
            knight.Location = location;
        }

    }
}
