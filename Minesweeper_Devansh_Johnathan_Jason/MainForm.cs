using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
// Allows me to use windows media player
using WMPLib;

namespace Minesweeper_Devansh_Johnathan_Jason
{

    public partial class MainForm : Form
    {
        public int GridSize;
        public int CellSize;
        public int TotalMines;
        // I have added this so that a sound is played when I click on a tile
        WindowsMediaPlayer playertile = new WindowsMediaPlayer();
        // Declared two arrays for mines and titles.
        // I have declared them to null because there values will change based on the level of difficulty the user chooses
        int[,] MineArray = null;
        int[,] CoverArray = null;
        // Random number generator method
        Random rndGenerator = new Random();
        // Game over checker
        bool GameOver = false;
        // boolean to reveal the bombs after the user loses
        bool BombRevealed = false;
        // Timer
        int Timer = 0;
        // This variable stores the final time
        public static int FinalTime;
        int FlagCount = 0; // Counts the number of flags
        ClosingPageForm myCloseForm;

        public MainForm(StartPageForm spf)
        {
            InitializeComponent();
            GridSize = spf.gridsize;
            CellSize = spf.cellsize;
            FlagCount=TotalMines = spf.TotalMines;

            MineArray = new int[GridSize, GridSize];
            CoverArray = new int[GridSize, GridSize];

            
            StartNewGame();

        }
      
        // This method will initialize all the elements of the MineArray to 0 and all the elements of CoverArray to -1 using a double loop.
        public void InitializeArrays()
        {
            // The first loop is for moving through the rows
            // The second loop is for moving through the columns
            // Initialized each mine to zero to show that there is no mine present at that spot
            // Initialized each tile to zero
            for (int iRow = 0; iRow < GridSize; iRow++)
            {
                for (int iColum = 0; iColum < GridSize; iColum++)
                {
                    MineArray[iRow, iColum] = 0;
                    CoverArray[iRow, iColum] = -1;
                }
            }
        }
        public void PlantMines()
        {
            // This method uses random number generator 1 to place 40 mines randomly in the MineArray.
            // Use a loop to countdown the number of planted mines and make sure that all mines are planted in unique locations.

            // Initialized a variable to keep a counter of the number of mines I have added
            int iMineCounter = 0;
            // Initialized a variable to store the x and y coordinates of the mine
            int iRowCoordinate = 0;
            int iColumnCoordinate = 0;
            // Used a while loop to keep a count of the number of mines that I have added and to keep adding the mines
            while (iMineCounter < TotalMines)
            {
                // I have used a random number generator to generate random number for the x and y coordinates of the location of the mine
                iRowCoordinate = rndGenerator.Next(0, GridSize);
                iColumnCoordinate = rndGenerator.Next(0, GridSize);
                // If statement to check if a mine already exists and to add -1 if the mine exists
                // Also the iMineCounter is increased by 1 if there is a mine
                if (MineArray[iRowCoordinate, iColumnCoordinate] == 0)
                {
                    MineArray[iRowCoordinate, iColumnCoordinate] = -1;
                    iMineCounter++;
                }
            }
        }
        public void MineCounter()
        {
            // Defined iMineCounter to keep the count of the number of adjacent mines
            int iMineCounter = 0;
            for (int iRowMineArray = 0; iRowMineArray < GridSize; iRowMineArray++)
            {
                for (int iColumMineArray = 0; iColumMineArray < GridSize; iColumMineArray++)
                {
                    if (MineArray[iRowMineArray, iColumMineArray] != -1) // if it is not a mine
                    {
                        iMineCounter = 0;
                        // It finds adjacent mines around the four corner cells
                        if (iRowMineArray == 0 && iColumMineArray == 0)
                        {
                            if (MineArray[iRowMineArray, iColumMineArray + 1] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray + 1, iColumMineArray] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray + 1, iColumMineArray + 1] == -1)
                            {
                                iMineCounter++;
                            }
                        }
                        // Corner
                        else if (iRowMineArray == 0 && iColumMineArray == GridSize-1)
                        {
                            if (MineArray[iRowMineArray, iColumMineArray - 1] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray + 1, iColumMineArray - 1] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray + 1, iColumMineArray] == -1)
                            {
                                iMineCounter++;
                            }
                        }
                        // Corner
                        else if (iRowMineArray == GridSize - 1 && iColumMineArray == GridSize - 1)
                        {
                            if (MineArray[iRowMineArray, iColumMineArray - 1] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray - 1, iColumMineArray - 1] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray - 1, iColumMineArray] == -1)
                            {
                                iMineCounter++;
                            }
                        }
                        // Corner
                        else if (iRowMineArray == GridSize - 1 && iColumMineArray == 0)
                        {
                            if (MineArray[iRowMineArray, iColumMineArray + 1] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray - 1, iColumMineArray] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray - 1, iColumMineArray + 1] == -1)
                            {
                                iMineCounter++;
                            }
                        }
                        // It finds the number of adjacent mines around the cells which are at the four edges
                        else if (iRowMineArray == 0 && iColumMineArray >= 1 && iColumMineArray <= GridSize - 2)
                        {
                            if (MineArray[iRowMineArray + 1, iColumMineArray] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray + 1, iColumMineArray - 1] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray, iColumMineArray - 1] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray + 1, iColumMineArray + 1] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray, iColumMineArray + 1] == -1)
                            {
                                iMineCounter++;
                            }
                        }
                        // Edges
                        else if (iColumMineArray == GridSize - 1 && iRowMineArray >= 1 && iRowMineArray <= GridSize - 2)
                        {
                            if (MineArray[iRowMineArray + 1, iColumMineArray] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray + 1, iColumMineArray - 1] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray, iColumMineArray - 1] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray - 1, iColumMineArray - 1] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray - 1, iColumMineArray] == -1)
                            {
                                iMineCounter++;
                            }
                        }
                        // Edges
                        else if (iRowMineArray == GridSize - 1 && iColumMineArray >= 1 && iColumMineArray <= GridSize - 2)
                        {
                            if (MineArray[iRowMineArray - 1, iColumMineArray - 1] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray - 1, iColumMineArray] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray - 1, iColumMineArray + 1] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray, iColumMineArray + 1] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray, iColumMineArray - 1] == -1)
                            {
                                iMineCounter++;
                            }
                        }
                        // Edges
                        else if (iColumMineArray == 0 && iRowMineArray >= 1 && iRowMineArray <= GridSize - 2)
                        {
                            if (MineArray[iRowMineArray - 1, iColumMineArray] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray - 1, iColumMineArray + 1] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray, iColumMineArray + 1] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray + 1, iColumMineArray + 1] == -1)
                            {
                                iMineCounter++;
                            }
                            if (MineArray[iRowMineArray + 1, iColumMineArray] == -1)
                            {
                                iMineCounter++;
                            }
                        }
                        // The code below finds the number of mines around the cells in the middle which have 8 cells surrounding them
                        else
                        {
                            for (int iRow = iRowMineArray - 1; iRow <= iRowMineArray + 1; iRow++)
                            {
                                for (int iColumn = iColumMineArray - 1; iColumn <= iColumMineArray + 1; iColumn++)
                                {
                                    if (MineArray[iRow, iColumn] == -1)
                                    {
                                        iMineCounter++;
                                    }
                                }
                            }
                        }
                        // Stored the iMineCounter value in the MineArray in order to display the number later in the picturebox
                        MineArray[iRowMineArray, iColumMineArray] = iMineCounter;
                    }
                }

            }
        }
        private void pbBoard_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // I have made a pen and a few brushes in order to make bombs, titles, flags and to show adjacent mine numbers
            Pen myPen = new Pen(Color.Black, 2);
            SolidBrush my_RedBrush = new SolidBrush(Color.Red);
            SolidBrush myBlackBrush = new SolidBrush(Color.Black);
            // For the flag
            Pen myFlagPen = new Pen(Color.Red, 4);
            Font myFont = new Font("Arial", Convert.ToInt32(15 * CellSize/ 40));
            // For the bomb
            Brush bombBlackBrush = new SolidBrush(Color.Black);
            Pen bombPen = new Pen(Color.Black, 4);
            // Grid light green and dark green Brushes
            Brush gridBrushDark = new SolidBrush(Color.FromArgb(142, 222, 112));
            Brush gridBrushLight = new SolidBrush(Color.FromArgb(152, 242, 122));
            // Beige color light and dark brushes
            SolidBrush CellLightBeigeBrush = new SolidBrush(Color.FromArgb(212, 222, 142));
            SolidBrush CellDarkBeigeBrush = new SolidBrush(Color.FromArgb(222, 232, 152));
            // I have used a loop to go to each cell in the grid and alternate between light green and dark green
            for (int r = 0; r < GridSize; r++)
            {
                for (int c = 0; c < GridSize; c++)
                {
                    // Here, I am alternating between two colors will filling color in the titles
                    if ((r + c) % 2 == 0)
                    {
                        g.FillRectangle(gridBrushLight, c * CellSize, r * CellSize, CellSize, CellSize);
                    }
                    else
                    {
                        g.FillRectangle(gridBrushDark, c * CellSize, r * CellSize, CellSize, CellSize);
                    }
                    // If the cell is covered and flagged, I make a flag
                    if (CoverArray[r, c] == 1)
                    {

                        // First I draw a flag pole (small rectangle)
                        
                        g.FillRectangle(myBlackBrush, (c * CellSize) + ((15*CellSize/40)), (r * CellSize) + CellSize/4, 2, CellSize/2);

                        // Then I make a triangle
                        Point[] polygonPoint = new Point[3];

                        polygonPoint[0].X = (c * CellSize) + ((18* CellSize/40));
                        polygonPoint[0].Y = (r * CellSize) + ((15 * CellSize / 40) );
                        polygonPoint[1].X = (c * CellSize) + ((18 * CellSize / 40) );
                        polygonPoint[1].Y = (r * CellSize) + ((20 * CellSize / 40) );
                        polygonPoint[2].X = (c * CellSize) + ((25 * CellSize / 40) );
                        polygonPoint[2].Y = (r * CellSize) + ((20 * CellSize / 40) );

                        g.DrawPolygon(myFlagPen, polygonPoint);
                        g.FillPolygon(my_RedBrush, polygonPoint);


                    }
                    // If the cell has a bomb or a number then I show those
                    else if (CoverArray[r, c] == 0)  // revealed
                    {
                        // Here, I am alternating between two colors will filling color in the titles
                        if ((r + c) % 2 == 0)
                        {
                            g.FillRectangle(CellLightBeigeBrush, c * CellSize, r * CellSize, CellSize, CellSize);
                        }
                        else
                        {
                            g.FillRectangle(CellDarkBeigeBrush, c * CellSize, r * CellSize, CellSize  , CellSize);
                        }
                        // I am storing the number of adjacent mines in a variable called number
                        int number = MineArray[r, c];

                        // I start checking is the numbers to paint them on the cells
                        if (number == -1)  //bomb
                        {
                            g.FillEllipse(bombBlackBrush, (c * CellSize) + ((10 * CellSize / 40) ), (r * CellSize) + ((10 * CellSize / 40) ), CellSize/2, CellSize/2);
                            g.DrawLine(bombPen, (c * CellSize) + ((10 * CellSize / 40) ), (r * CellSize) + ((10 * CellSize / 40) ), (c * CellSize) + ((30 * CellSize / 40)), (r * CellSize) + ((30 * CellSize / 40) ));
                            g.DrawLine(bombPen, (c * CellSize) + ((10 * CellSize / 40) ), (r * CellSize) + ((30 * CellSize / 40) ), (c * CellSize) + ((30 * CellSize / 40) ), (r * CellSize) + ((10 * CellSize / 40) ));
                            BombRevealed = true;

                        }
                        else if (number == 1)
                        {
                            SolidBrush mynum1brush = new SolidBrush(Color.Blue);
                            g.DrawString(number.ToString(), myFont, mynum1brush, c * CellSize + ((10 * CellSize / 40) ), r * CellSize + ((10 * CellSize / 40) ));
                        }
                        else if (number == 2)
                        {
                            SolidBrush mynum2brush = new SolidBrush(Color.Green);
                            g.DrawString(number.ToString(), myFont, mynum2brush, c * CellSize + ((10 * CellSize / 40) ), r * CellSize + ((10 * CellSize / 40) ));
                        }
                        else if (number == 3)
                        {
                            SolidBrush mynum3brush = new SolidBrush(Color.Red);
                            g.DrawString(number.ToString(), myFont, mynum3brush, c * CellSize + ((10 * CellSize / 40) ), r * CellSize + ((10 * CellSize / 40) ));
                        }
                        else if (number == 4)
                        {
                            SolidBrush mynum4brush = new SolidBrush(Color.Purple);
                            g.DrawString(number.ToString(), myFont, mynum4brush, c * CellSize + ((10 * CellSize / 40) ), r * CellSize + ((10 * CellSize / 40) ));
                        }
                        else if (number == 5)
                        {
                            SolidBrush mynum5brush = new SolidBrush(Color.Yellow);
                            g.DrawString(number.ToString(), myFont, mynum5brush, c * CellSize + ((10 * CellSize / 40) ), r * CellSize + ((10 * CellSize / 40) ));
                        }
                        else if (number == 6)
                        {
                            SolidBrush mynum6brush = new SolidBrush(Color.Brown);
                            g.DrawString(number.ToString(), myFont, mynum6brush, c * CellSize + ((10 * CellSize / 40) ), r * CellSize + ((10 * CellSize / 40)));
                        }
                        else if (number == 7)
                        {
                            SolidBrush mynum7brush = new SolidBrush(Color.OrangeRed);
                            g.DrawString(number.ToString(), myFont, mynum7brush, c * CellSize + ((10 * CellSize / 40) ), r * CellSize + ((10 * CellSize / 40) ));
                        }
                        else if (number == 8)
                        {
                            SolidBrush mynum8brush = new SolidBrush(Color.Turquoise);
                            g.DrawString(number.ToString(), myFont, mynum8brush, c * CellSize + ((10 * CellSize / 40) ), r * CellSize + ((10 * CellSize / 40) ));
                        }

                    }

                }
            }
            // This code reveals all the bombs after the user has clicked on a bomb
            if (BombRevealed == true)
            {
                for (int rbomb = 0; rbomb < GridSize; rbomb++)
                {
                    for (int cbomb = 0; cbomb < GridSize; cbomb++)
                    {
                        if (MineArray[rbomb, cbomb] == -1)
                        {
                            // First I paint the cell either light or dark beige
                            if ((rbomb + cbomb) % 2 == 0)
                            {
                                g.FillRectangle(CellLightBeigeBrush, cbomb * CellSize, rbomb * CellSize, CellSize, CellSize);
                            }
                            else
                            {
                                g.FillRectangle(CellDarkBeigeBrush, cbomb * CellSize, rbomb * CellSize, CellSize, CellSize);
                            }
                            // Then I make the bomb in that cell
                            g.FillEllipse(bombBlackBrush, (cbomb * CellSize) + ((10 * CellSize / 40) ), (rbomb * CellSize) + ((10 * CellSize / 40)), CellSize/2, CellSize/2);
                            g.DrawLine(bombPen, (cbomb * CellSize) + ((10 * CellSize / 40)), (rbomb * CellSize) + ((10 * CellSize / 40) ), (cbomb * CellSize) + ((30 * CellSize / 40) ), (rbomb * CellSize) + ((30 * CellSize / 40)));
                            g.DrawLine(bombPen, (cbomb * CellSize) + ((10 * CellSize / 40)), (rbomb * CellSize) + ((30 * CellSize / 40)), (cbomb * CellSize) + ((30 * CellSize / 40)), (rbomb * CellSize) + ((10 * CellSize / 40) ));

                        }

                    }
                }
                // Stops the timer
                GameTimer.Stop();
                FinalTime = Timer;

                GameOver = true;
            }
        }
        public void RevealEmptyCells(int row, int column)
        {
            int r, c;
            if ((row < 0 || row > GridSize-1 || column < 0 || column > GridSize-1 || CoverArray[row, column] == 0))
            {
                return;
            }
            CoverArray[row, column] = 0;
            if (MineArray[row, column] > 0)
            {
                return;
            }
            // base case: if it reaches a mine or when it reaches the boundry            
            for (r = row - 1; r <= row + 1; r++)
            {
                for (c = column - 1; c <= column + 1; c++)
                {
                    if (r != row || c != column) // Skip the current cell
                    {
                        RevealEmptyCells(r, c);
                    }
                }
            }

        }

        public bool WinGame()
        {
           // GameTimer.Stop();
            
            int revealchecker = 0;
            for (int r = 0; r < GridSize; r++)
            {
                for (int c = 0; c < GridSize; c++)
                {
                    // Checks if the cell is uncovered and the cell does not have a mine
                    if ((CoverArray[r, c] == 0 && MineArray[r, c] != -1))
                    {
                        revealchecker += 1;
                    }
                }
            }
            if (revealchecker == (GridSize*GridSize)- TotalMines)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        
        public void TaskDelay(int seconds)   // This method helps me add a time delay. I need this after all the mines are shown.
        {
            var t = Task.Run(async delegate
            {
                await Task.Delay(seconds * 1000);
                return 42;
            });
            t.Wait();
        }

        public void ShowLosePage()
        {
            myCloseForm.TimeLapsed = Timer;
            myCloseForm.ShowDialog();
            if (myCloseForm.StartPageFlag == true)
            {
                StartNewGame();
                //Start a new Game Automatically
                this.Close();
            }
        }
        private void pbBoard_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int MouseX, MouseY;
                MouseX = e.X;
                MouseY = e.Y;
                // Row and column for the mouse click
                int row, column;
                if (GameOver == true) // If the game is over then a 'you lose' page is shown
                {
                    ShowLosePage();
                }
                else
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        // This line adds music
                        playertile.URL = "clicksoundtrim.mp3";
                        playertile.controls.play();

                        row = MouseY / CellSize;
                        column = MouseX / CellSize;
                        // Reveal the cell if it is covered and not flagged
                        if (CoverArray[row, column] == -1)
                        {
                            if (MineArray[row, column] == 0)
                            {
                                RevealEmptyCells(row, column);
                            }
                            else if (MineArray[row, column] == -1)
                            {
                                BombRevealed = true;
                                pbBoard.Invalidate();
                                // 2 second delay after all the mines are shown
                                TaskDelay(2);
                                // Switching the form after 
                                ShowLosePage();

                            }
                            else
                            {
                                CoverArray[row, column] = 0;  // Reveal the cell
                            }
                        }
                        if (WinGame() == true && GameOver == false)
                        {
                            // Stops the timer
                            GameTimer.Stop();
                            int iReply = (int)(MessageBox.Show("You won the game. Thank you for playing! Do you want to restart the game with the same level.", "You Won", MessageBoxButtons.YesNo));
                            if (iReply == 6) //yes
                            {
                                StartNewGame();
                            }
                            else
                            {
                                this.Close();
                            }
                        }
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        // This line adds music
                        playertile.URL = "clicksoundtrim.mp3";
                        playertile.controls.play();

                        row = MouseY / CellSize;
                        column = MouseX / CellSize;
                        // Toggle the flag status
                        if (CoverArray[row, column] == -1)
                        {
                            CoverArray[row, column] = 1;  // Place a flag
                            FlagCount--;
                        }
                        else if (CoverArray[row, column] == 1)
                        {
                            CoverArray[row, column] = -1;  // Remove the flag
                            FlagCount++;
                        }
                    }
                }
                txtFlagCounter.Text = Convert.ToString(FlagCount);
                pbBoard.Invalidate();

            }
            catch
            {
                MessageBox.Show("Error: Please try clicking again!");
            }


        }
        private void StartNewGame()
        {
            GameOver = false;
            BombRevealed = false;  // Removes all the bombs
            FlagCount = TotalMines;
            InitializeArrays();
            PlantMines();
            MineCounter();
            pbBoard.Invalidate(); // Refreshes the screen
            Timer = 0;
            GameTimer.Start();
            myCloseForm = new ClosingPageForm();
        }
        private void StartANewGame_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            Timer += 1;
            txtTimer.Text = Convert.ToString(Timer) + "s";
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            string MineArrayRow, CoverArrayRow;

            lbMineArray.Items.Clear();
            lbCoverArray.Items.Clear();
            for (int i = 0; i < GridSize; i++)
            {
                MineArrayRow = "";
                CoverArrayRow = "";

                for (int j = 0; j < GridSize; j++)
                {
                    if (MineArray[i, j] == -1)
                    {
                        MineArrayRow = MineArrayRow + " " + MineArray[i, j];
                    }
                    else
                    {
                        MineArrayRow = MineArrayRow + "  " + MineArray[i, j];
                    }

                    CoverArrayRow = CoverArrayRow + " " + CoverArray[i, j];
                }
                lbMineArray.Items.Add(MineArrayRow);
                lbCoverArray.Items.Add(CoverArrayRow);
                MineArrayRow = "";
                CoverArrayRow = "";

            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            for (int r = 0; r < GridSize; r++)
            {
                for (int c = 0; c < GridSize-1; c++)
                {
                    // Checks if the cell is uncovered and the cell does not have a mine
                    if ( MineArray[r, c] != -1)
                    {
                        CoverArray[r, c] = 0;
                    }
                }
            }
        }

        
    }
}
