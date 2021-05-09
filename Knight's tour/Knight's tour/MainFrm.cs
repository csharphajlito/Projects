using System.Windows.Forms;
using MetroFramework.Forms;
using Knight_s_tour.Properties;
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Knight_s_tour
{
    public delegate void ButtonDelegate();
    public partial class MainFrm : MetroForm
    {
        private Calculator calculator;
        private List<int> path;
        private MoveEffect moveEffect = new MoveEffect();
        private Initializer board = new FiveAndFive();
        private List<PictureBox> xList = new List<PictureBox>(64);
        private Stopwatch stopwatch = new Stopwatch();

        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            pctrBxKnight.Visible = false;
            bttnStart.Enabled = false;

            cmbBxBoard.DataSource = new List<string> { "5x5", "5x6", "3x4", "8x8" };
            cmbBxDesign.DataSource = new List<string> { "Extra Budget", "Low Budget" };

            //álátszó legyen a kép
            pctrBxBoard.Parent = pnlBoard;
            pctrBxKnight.Parent = pctrBxBoard;
            pctrBxKnight.BackColor = Color.Transparent;
            pctrBxBoard.BackColor = Color.Transparent;
        }

        private async void bttnStart_Click(object sender, EventArgs e)
        {
            //eddigi x-eket töröljük
            xList.ForEach(xPicture => pctrBxBoard.Controls.Remove(xPicture));

            //figurát oda teszem az első helyre és alá teszem az x-et, hogy ott már volt
            pctrBxKnight.Location = new Point(0,0);
            PictureBox xFirst = new PictureBox
            {
                Location = pctrBxKnight.Location,
                Image = Resources.x,
                Width = 100,
                Height = 100,
                BackColor = Color.Transparent,
                Parent = pctrBxBoard
            };
            xList.Add(xFirst);
            pctrBxBoard.Controls.Add(xFirst);

            //kinézet
            setDesign();
            setBoard();

            //elérés tiltása
            cmbBxBoard.Enabled = cmbBxDesign.Enabled = bttnStart.Enabled = false;

            //számolás és stopwacth, timer indítása
            stopwatch.Start();
            tmr.Start();
            board = getBoard();
            calculator = new Calculator(board.initializeChessTableComponent(), 0);
            tmr.Start();
                //gui-nak elérhetőnek kell maradnia
                Task solution = new Task(()=> calculator.solve());
                solution.Start();
                await solution;
            //óra leállítás
            stopwatch.Stop();
            stopwatch.Reset();
            tmr.Stop();
            calculator.Iterations = 0;
            //eredmény megjegyzése
            path = calculator.getRoute.GetPath;

            //megjelenítés
            pctrBxKnight.Visible = true;
            moveEffect.moveKnight(pnlBoard, board, pctrBxKnight, path);

            //elérés engedélyezése
            setEnabledPopertyTrue();
        }

        private void pctrBxKnight_Move(object sender, EventArgs e)
        {
            PictureBox x = new PictureBox
            {
                Location = pctrBxKnight.Location,
                Image = Resources.x,
                Width = 100,
                Height = 100,
                BackColor = Color.Transparent,
                Parent = pctrBxBoard
            };
            xList.Add(x);
            pctrBxBoard.Controls.Add(x);
        }

        private void setBoard()
        {
            switch (cmbBxBoard.SelectedItem)
            {
                case "5x5":
                    Width = 800;
                    Height = 600;

                    pctrBxBoard.Image = cmbBxDesign.SelectedItem == "Low Budget" ? Resources._5x5Low : Resources._5x5;
                    pctrBxBoard.Width = Resources._5x5Low.Width;
                    pctrBxBoard.Height = Resources._5x5Low.Height;
                    pctrBxBoard.Location = new Point(0, 0);

                    pnlBoard.Width = Resources._5x5Low.Width;
                    pnlBoard.Height = Resources._5x5Low.Height;
                    break;

                case "5x6":
                    Width = 875;
                    Height = 600;

                    pctrBxBoard.Image = cmbBxDesign.SelectedItem == "Low Budget" ? Resources._5x6Low : Resources._5x6;
                    pctrBxBoard.Width = Resources._5x6Low.Width;
                    pctrBxBoard.Height = Resources._5x6Low.Height;
                    pctrBxBoard.Location = new Point(0, 0);

                    pnlBoard.Width = Resources._5x6Low.Width;
                    pnlBoard.Height = Resources._5x6Low.Height;
                    break;

                case "8x8":
                    Width = 1125;
                    Height = 900;

                    pctrBxBoard.Image = cmbBxDesign.SelectedItem == "Low Budget" ? Resources._8x8Low : Resources._8x8;
                    pctrBxBoard.Width = Resources._8x8Low.Width;
                    pctrBxBoard.Height = Resources._8x8Low.Height;
                    pctrBxBoard.Location = new Point(0, 0);

                    pnlBoard.Width = Resources._8x8Low.Width;
                    pnlBoard.Height = Resources._8x8Low.Height;

                    CenterToScreen();
                    break;

                case "3x4":
                    Width = 750;
                    Height = 400;

                    pctrBxBoard.Image = cmbBxDesign.SelectedItem == "Low Budget" ? Resources._3x4Low : Resources._3x4;
                    pnlBoard.Width = Resources._3x4Low.Width;
                    pnlBoard.Height = Resources._3x4Low.Height;

                    pctrBxBoard.Width = Resources._3x4Low.Width;
                    pctrBxBoard.Height = Resources._3x4Low.Height;
                    pctrBxBoard.Location = new Point(0, 0);
                    break;
            }
        }

        private Initializer getBoard()
        {
            switch (cmbBxBoard.SelectedItem)
            {
                case "5x5":
                    return new FiveAndFive();

                case "5x6":
                    return new FiveRowAndSixColumn();

                case "8x8":
                    return new EightAndEight();

                case "3x4":
                    return new ThreeRowAndFourColumn();

                default: return new FiveAndFive();
            }
        }

        private void setDesign()
        {
            switch (cmbBxDesign.SelectedItem)
            {
                case "Low Budget":
                    pctrBxKnight.Image = Resources.kLow;
                    pctrBxKnight.Width = 100;
                    pctrBxKnight.Height = 100;
                    pctrBxKnight.Location = new Point(0,0);
                    break;

                case "Extra Budget":
                    pctrBxKnight.Image = Resources.k;
                    pctrBxKnight.Width = 100;
                    pctrBxKnight.Height = 100;
                    pctrBxKnight.Location = new Point(0, 0);
                    break;
            }
        }

        private void bttnLoad_Click(object sender, EventArgs e)
        {
            pctrBxKnight.BringToFront();

            bttnStart.Enabled = true;
            bttnLoad.Visible = false;
            lblCount.Visible = true;

            pnlBoard.Visible = true;
            pctrBxBoard.Visible = true;
            pctrBxKnight.Visible = true;
            lblInformation.Visible = true;
            lblTime.Visible = true;
            lblElapsedTime.Visible = true;

            setDesign();
            setBoard();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            int second = Convert.ToInt32((stopwatch.ElapsedMilliseconds / 1000) % 60);
            int minute = Convert.ToInt32((stopwatch.ElapsedMilliseconds / 1000) / 60);

            lblCount.Text = Convert.ToString(calculator.Iterations);
            lblElapsedTime.Text = Convert.ToString(minute + ":" + second);
        }

        private async void setEnabledPopertyTrue()
        {
            Task enableStartButton = new Task(() => Thread.Sleep(moveEffect.Interval * board.ColumnCount * board.RowCount));
            enableStartButton.Start();
            await enableStartButton;

            cmbBxBoard.Enabled = cmbBxDesign.Enabled = bttnStart.Enabled = true;
        }
    }
}
