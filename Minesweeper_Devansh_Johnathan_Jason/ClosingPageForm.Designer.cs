namespace Minesweeper_Devansh_Johnathan_Jason
{
    partial class ClosingPageForm
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
            this.lblYouLose = new System.Windows.Forms.Label();
            this.btnStartANewGame = new System.Windows.Forms.Button();
            this.lblFinalTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblYouLose
            // 
            this.lblYouLose.AutoSize = true;
            this.lblYouLose.BackColor = System.Drawing.Color.Transparent;
            this.lblYouLose.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYouLose.Location = new System.Drawing.Point(180, 50);
            this.lblYouLose.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblYouLose.Name = "lblYouLose";
            this.lblYouLose.Size = new System.Drawing.Size(351, 90);
            this.lblYouLose.TabIndex = 0;
            this.lblYouLose.Text = "You Lose";
            // 
            // btnStartANewGame
            // 
            this.btnStartANewGame.BackColor = System.Drawing.Color.Transparent;
            this.btnStartANewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartANewGame.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartANewGame.Location = new System.Drawing.Point(223, 281);
            this.btnStartANewGame.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartANewGame.Name = "btnStartANewGame";
            this.btnStartANewGame.Size = new System.Drawing.Size(187, 34);
            this.btnStartANewGame.TabIndex = 6;
            this.btnStartANewGame.Text = "Start A New Game";
            this.btnStartANewGame.UseVisualStyleBackColor = false;
            this.btnStartANewGame.Click += new System.EventHandler(this.StartANewGame_Click);
            // 
            // lblFinalTime
            // 
            this.lblFinalTime.AutoSize = true;
            this.lblFinalTime.BackColor = System.Drawing.Color.Transparent;
            this.lblFinalTime.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalTime.Location = new System.Drawing.Point(293, 160);
            this.lblFinalTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFinalTime.Name = "lblFinalTime";
            this.lblFinalTime.Size = new System.Drawing.Size(117, 49);
            this.lblFinalTime.TabIndex = 7;
            this.lblFinalTime.Text = "Time";
            // 
            // ClosingPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Minesweeper_Devansh_Johnathan_Jason.Properties.Resources.WhatsApp_Image_2024_06_08_at_8_421;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.lblFinalTime);
            this.Controls.Add(this.btnStartANewGame);
            this.Controls.Add(this.lblYouLose);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ClosingPageForm";
            this.Text = "You Lose";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingPage_FormClosing);
            this.Load += new System.EventHandler(this.ClosingPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblYouLose;
        private System.Windows.Forms.Button btnStartANewGame;
        private System.Windows.Forms.Label lblFinalTime;
    }
}