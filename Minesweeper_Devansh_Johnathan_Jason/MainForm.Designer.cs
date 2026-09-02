namespace Minesweeper_Devansh_Johnathan_Jason
{
    partial class MainForm
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
            this.lbMineArray = new System.Windows.Forms.ListBox();
            this.lbCoverArray = new System.Windows.Forms.ListBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.StartANewGame = new System.Windows.Forms.Button();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.txtTimer = new System.Windows.Forms.TextBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblFlagCounter = new System.Windows.Forms.Label();
            this.txtFlagCounter = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pbBoard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMineArray
            // 
            this.lbMineArray.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMineArray.FormattingEnabled = true;
            this.lbMineArray.ItemHeight = 16;
            this.lbMineArray.Location = new System.Drawing.Point(835, 21);
            this.lbMineArray.Name = "lbMineArray";
            this.lbMineArray.Size = new System.Drawing.Size(320, 308);
            this.lbMineArray.TabIndex = 1;
            // 
            // lbCoverArray
            // 
            this.lbCoverArray.FormattingEnabled = true;
            this.lbCoverArray.Location = new System.Drawing.Point(835, 360);
            this.lbCoverArray.Name = "lbCoverArray";
            this.lbCoverArray.Size = new System.Drawing.Size(330, 290);
            this.lbCoverArray.TabIndex = 2;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(852, 331);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // StartANewGame
            // 
            this.StartANewGame.Location = new System.Drawing.Point(674, 21);
            this.StartANewGame.Name = "StartANewGame";
            this.StartANewGame.Size = new System.Drawing.Size(118, 42);
            this.StartANewGame.TabIndex = 5;
            this.StartANewGame.Text = "Restart Game";
            this.StartANewGame.UseVisualStyleBackColor = true;
            this.StartANewGame.Click += new System.EventHandler(this.StartANewGame_Click);
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 1000;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // txtTimer
            // 
            this.txtTimer.BackColor = System.Drawing.SystemColors.Control;
            this.txtTimer.Location = new System.Drawing.Point(674, 186);
            this.txtTimer.Name = "txtTimer";
            this.txtTimer.Size = new System.Drawing.Size(100, 20);
            this.txtTimer.TabIndex = 6;
            this.txtTimer.TabStop = false;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.BackColor = System.Drawing.SystemColors.Control;
            this.lblTimer.Location = new System.Drawing.Point(671, 150);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(39, 15);
            this.lblTimer.TabIndex = 7;
            this.lblTimer.Text = "Timer";
            // 
            // lblFlagCounter
            // 
            this.lblFlagCounter.AutoSize = true;
            this.lblFlagCounter.Location = new System.Drawing.Point(671, 241);
            this.lblFlagCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFlagCounter.Name = "lblFlagCounter";
            this.lblFlagCounter.Size = new System.Drawing.Size(77, 15);
            this.lblFlagCounter.TabIndex = 9;
            this.lblFlagCounter.Text = "Flag Counter";
            // 
            // txtFlagCounter
            // 
            this.txtFlagCounter.Location = new System.Drawing.Point(674, 278);
            this.txtFlagCounter.Margin = new System.Windows.Forms.Padding(4);
            this.txtFlagCounter.Name = "txtFlagCounter";
            this.txtFlagCounter.ReadOnly = true;
            this.txtFlagCounter.Size = new System.Drawing.Size(152, 20);
            this.txtFlagCounter.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(674, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbBoard
            // 
            this.pbBoard.Location = new System.Drawing.Point(12, 12);
            this.pbBoard.Name = "pbBoard";
            this.pbBoard.Size = new System.Drawing.Size(640, 640);
            this.pbBoard.TabIndex = 0;
            this.pbBoard.TabStop = false;
            this.pbBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pbBoard_Paint);
            this.pbBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbBoard_MouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1174, 670);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblFlagCounter);
            this.Controls.Add(this.txtFlagCounter);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.txtTimer);
            this.Controls.Add(this.StartANewGame);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lbCoverArray);
            this.Controls.Add(this.lbMineArray);
            this.Controls.Add(this.pbBoard);
            this.Name = "MainForm";
            this.Text = "MineSweeper";
            ((System.ComponentModel.ISupportInitialize)(this.pbBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBoard;
        private System.Windows.Forms.ListBox lbMineArray;
        private System.Windows.Forms.ListBox lbCoverArray;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button StartANewGame;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.TextBox txtTimer;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblFlagCounter;
        private System.Windows.Forms.TextBox txtFlagCounter;
        private System.Windows.Forms.Button button1;
    }
}

