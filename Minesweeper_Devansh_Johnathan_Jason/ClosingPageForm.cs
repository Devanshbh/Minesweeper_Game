using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper_Devansh_Johnathan_Jason
{
    public partial class ClosingPageForm : Form
    {
        public int TimeLapsed = 0;
        public bool StartPageFlag = false;
        public ClosingPageForm()
        {
            InitializeComponent();
            // I am storing the variable FinalTime that I made in form 1, in a variable called FinalTimeForm2
           
            
        }


        private void StartANewGame_Click(object sender, EventArgs e)
        {
            StartPageFlag= true;
            this.Close();
        }

        private void ClosingPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void ClosingPage_Load(object sender, EventArgs e)
        {
            lblFinalTime.Text = Convert.ToString(TimeLapsed) + "s";
        }
    }
}
