using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// This allows me to use windows media player
using WMPLib;

namespace Minesweeper_Devansh_Johnathan_Jason
{
    
    public partial class StartPageForm : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        MainForm f1;

        // I have initialized these variables so that I can use them in MainForm.
        public int cellsize = 0;
        public int gridsize = 0;
        public int TotalMines = 0;

        public StartPageForm()
        {
            InitializeComponent();
            // I have specified the music that I plan to play
            player.URL = "StartGameMusic.mp3";            

        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            try
            {
                // If no difficulty level is selected by the user then start with intermediate difficulty
                if (gridsize == 0)
                {
                    cellsize = 40;
                    gridsize = 16;
                    TotalMines = 40;
                }
                f1 = new MainForm(this);
                player.controls.pause();
                f1.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Error: Please try starting the game again! ");
            }
            
        }


        private void Form2StartPage_Load(object sender, EventArgs e)
        {
            // It plays the music when the form loads
            player.controls.play();
        }

        private void btnUserManual_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please refer to the user manual");
        }

        private void btnBeginner_Click(object sender, EventArgs e)
        {
            try
            {
                // If the user clicks on beginner then these are the settings
                cellsize = 80;
                gridsize = 8;
                TotalMines = 10;
            }
            catch 
            {
                MessageBox.Show("Error: Please try selecting the difficulty again! ");
            }

        }


        private void btnExpert_Click(object sender, EventArgs e)
        {
            try
            {
                // If the user clicks on expert then these are the settings
                cellsize = 26;
                gridsize = 24;
                TotalMines = 80;
            }
            catch
            {
                MessageBox.Show("Error: Please try selecting the difficulty again! ");
            }
        }

        private void btnIntermediate_Click(object sender, EventArgs e)
        {
            try
            {
                // If the user clicks on intermediate then these are the settings
                cellsize = 40;
                gridsize = 16;
                TotalMines = 40;
            }
            catch
            {
                MessageBox.Show("Error: Please try selecting the difficulty again! ");
            }
        }
    }
}
