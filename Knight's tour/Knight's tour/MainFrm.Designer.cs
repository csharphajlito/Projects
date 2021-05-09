
namespace Knight_s_tour
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblElapsedTime = new MetroFramework.Controls.MetroLabel();
            this.lblTime = new MetroFramework.Controls.MetroLabel();
            this.bttnLoad = new MetroFramework.Controls.MetroButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInformation = new MetroFramework.Controls.MetroLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBxDesign = new MetroFramework.Controls.MetroComboBox();
            this.lblCount = new MetroFramework.Controls.MetroLabel();
            this.cmbBxBoard = new MetroFramework.Controls.MetroComboBox();
            this.bttnStart = new MetroFramework.Controls.MetroButton();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.pctrBxKnight = new System.Windows.Forms.PictureBox();
            this.pctrBxBoard = new System.Windows.Forms.PictureBox();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.pnlRight.SuspendLayout();
            this.pnlBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrBxKnight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrBxBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.lblElapsedTime);
            this.pnlRight.Controls.Add(this.lblTime);
            this.pnlRight.Controls.Add(this.bttnLoad);
            this.pnlRight.Controls.Add(this.label2);
            this.pnlRight.Controls.Add(this.lblInformation);
            this.pnlRight.Controls.Add(this.label1);
            this.pnlRight.Controls.Add(this.cmbBxDesign);
            this.pnlRight.Controls.Add(this.lblCount);
            this.pnlRight.Controls.Add(this.cmbBxBoard);
            this.pnlRight.Controls.Add(this.bttnStart);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(16, 60);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(200, 288);
            this.pnlRight.TabIndex = 0;
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.AutoSize = true;
            this.lblElapsedTime.Location = new System.Drawing.Point(50, 233);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(121, 19);
            this.lblElapsedTime.TabIndex = 10;
            this.lblElapsedTime.Text = "Waiting For Start....";
            this.lblElapsedTime.Visible = false;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(29, 211);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(41, 19);
            this.lblTime.TabIndex = 9;
            this.lblTime.Text = "Time:";
            this.lblTime.Visible = false;
            // 
            // bttnLoad
            // 
            this.bttnLoad.Location = new System.Drawing.Point(26, 226);
            this.bttnLoad.Name = "bttnLoad";
            this.bttnLoad.Size = new System.Drawing.Size(155, 48);
            this.bttnLoad.TabIndex = 5;
            this.bttnLoad.Text = "Load";
            this.bttnLoad.UseSelectable = true;
            this.bttnLoad.Click += new System.EventHandler(this.bttnLoad_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Choose Design";
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Location = new System.Drawing.Point(29, 255);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(65, 19);
            this.lblInformation.TabIndex = 7;
            this.lblInformation.Text = "Iterations:";
            this.lblInformation.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose Board";
            // 
            // cmbBxDesign
            // 
            this.cmbBxDesign.FormattingEnabled = true;
            this.cmbBxDesign.ItemHeight = 23;
            this.cmbBxDesign.Location = new System.Drawing.Point(26, 166);
            this.cmbBxDesign.Name = "cmbBxDesign";
            this.cmbBxDesign.Size = new System.Drawing.Size(155, 29);
            this.cmbBxDesign.TabIndex = 2;
            this.cmbBxDesign.UseSelectable = true;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(50, 277);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(121, 19);
            this.lblCount.TabIndex = 6;
            this.lblCount.Text = "Waiting For Start....";
            this.lblCount.Visible = false;
            // 
            // cmbBxBoard
            // 
            this.cmbBxBoard.FormattingEnabled = true;
            this.cmbBxBoard.ItemHeight = 23;
            this.cmbBxBoard.Location = new System.Drawing.Point(26, 103);
            this.cmbBxBoard.Name = "cmbBxBoard";
            this.cmbBxBoard.Size = new System.Drawing.Size(155, 29);
            this.cmbBxBoard.TabIndex = 1;
            this.cmbBxBoard.UseSelectable = true;
            // 
            // bttnStart
            // 
            this.bttnStart.Location = new System.Drawing.Point(26, 3);
            this.bttnStart.Name = "bttnStart";
            this.bttnStart.Size = new System.Drawing.Size(155, 48);
            this.bttnStart.TabIndex = 0;
            this.bttnStart.Text = "Start";
            this.bttnStart.UseSelectable = true;
            this.bttnStart.Click += new System.EventHandler(this.bttnStart_Click);
            // 
            // pnlBoard
            // 
            this.pnlBoard.Controls.Add(this.pctrBxKnight);
            this.pnlBoard.Controls.Add(this.pctrBxBoard);
            this.pnlBoard.Location = new System.Drawing.Point(13, 63);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(127, 368);
            this.pnlBoard.TabIndex = 7;
            this.pnlBoard.Visible = false;
            // 
            // pctrBxKnight
            // 
            this.pctrBxKnight.Location = new System.Drawing.Point(3, 100);
            this.pctrBxKnight.Name = "pctrBxKnight";
            this.pctrBxKnight.Size = new System.Drawing.Size(100, 83);
            this.pctrBxKnight.TabIndex = 2;
            this.pctrBxKnight.TabStop = false;
            this.pctrBxKnight.Move += new System.EventHandler(this.pctrBxKnight_Move);
            // 
            // pctrBxBoard
            // 
            this.pctrBxBoard.Location = new System.Drawing.Point(10, 147);
            this.pctrBxBoard.Name = "pctrBxBoard";
            this.pctrBxBoard.Size = new System.Drawing.Size(100, 50);
            this.pctrBxBoard.TabIndex = 1;
            this.pctrBxBoard.TabStop = false;
            // 
            // tmr
            // 
            this.tmr.Interval = 1;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // MainFrm
            // 
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(236, 368);
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.pnlRight);
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.Resizable = false;
            this.Text = "Knight\'s tour";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlBoard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctrBxKnight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrBxBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroComboBox cmbBxDesign;
        private MetroFramework.Controls.MetroComboBox cmbBxBoard;
        private MetroFramework.Controls.MetroButton bttnStart;
        private MetroFramework.Controls.MetroButton bttnLoad;
        private MetroFramework.Controls.MetroLabel lblCount;
        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Timer tmr;
        private MetroFramework.Controls.MetroLabel lblInformation;
        private MetroFramework.Controls.MetroLabel lblElapsedTime;
        private MetroFramework.Controls.MetroLabel lblTime;
        private System.Windows.Forms.PictureBox pctrBxBoard;
        private System.Windows.Forms.PictureBox pctrBxKnight;
    }
}

