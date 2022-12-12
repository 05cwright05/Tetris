using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tetris
{

    public partial class Form1 : Form
    {
        public Label[,] grid = new Label[8, 12];
        public Label[,] sGrid = new Label[4, 4];
        List<Label> Piece = new List<Label>();
        List<Label> sList = new List<Label>();
        List<Label> gList = new List<Label>();
        List<Label> PieceList = new List<Label>();
        List<Point> Pos = new List<Point>();
        List<int> yPos = new List<int>();
        int type;

        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            SpawnGrid();
            //PopulatePositionLists();
            type = 0;

            SpawnBlock2();
            tmrMove.Enabled = true;
        }
        private void PopulatePositionLists()
        {
            //Should add an ability to add an offset by like a plus i 
            Pos.Add(sGrid[0, 0].Location);
            Pos.Add(sGrid[0, 1].Location);
            Pos.Add(sGrid[0, 2].Location);
            Pos.Add(sGrid[0, 3].Location);

            Pos.Add(sGrid[1, 0].Location);
            Pos.Add(sGrid[1, 1].Location);
            Pos.Add(sGrid[1, 2].Location);
            Pos.Add(sGrid[1, 3].Location);

            Pos.Add(sGrid[2, 0].Location);
            Pos.Add(sGrid[2, 1].Location);
            Pos.Add(sGrid[2, 2].Location);
            Pos.Add(sGrid[2, 3].Location);

            Pos.Add(sGrid[3, 0].Location);
            Pos.Add(sGrid[3, 1].Location);
            Pos.Add(sGrid[3, 2].Location);
            Pos.Add(sGrid[3, 3].Location);
            tmrMove.Enabled = true;
            MessageBox.Show(Pos.Count().ToString());
        }

        private void SpawnBlock2()
        {
            //Piece piece1 = new Piece(1, 1, 3);

            //So we can create a list of lists and seperate each piece by block (which we should do so they can be cleared later)
            //or i can high light blocks, i have just been having trouble keeping track of where multiple pieces are and rotating(tho this is a possible solution)
            //or a single piece and maybe make a conglomeration at the bottom idk man.

            // spawn 3x3 to hold piece and put that grid in a list 
            //could use tags to know which blocks have a piece instead of rnning a seperate item


            // Do this 
            //Try adding tags to the current positions for easier rotation and then shift the whole grid down
            if (type == 0)
            {
                sGrid[1, 1].Tag = "1";
                sGrid[1, 2].Tag = "1";
                sGrid[2, 1].Tag = "1";
                sGrid[2, 2].Tag = "1";
            }
        }

        private void SpawnGrid()
        {
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    Label label = new Label();
                    label.AutoSize = false;
                    label.Location = new Point(5 + (45 * r), 5 + (45 * c));
                    label.BackColor = Color.Black;
                    label.Size = new Size(40, 40);
                    label.Text = r.ToString() + "," + c.ToString();
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.ForeColor = Color.White;
                    label.SendToBack();



                    Controls.Add(label);
                    grid[r, c] = label;
                    gList.Add(grid[r, c]);
                    if (c == 11)
                    {
                        grid[r, c].Tag = "1";
                        grid[r, c].BackColor = Color.Green;
                    }
                }
            }

            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    Label label = new Label();
                    label.AutoSize = false;
                    label.Location = new Point(5 + (45 * r), 5 + (45 * c));
                    label.BackColor = Color.Blue;
                    label.Size = new Size(40, 40);
                    label.Text = r.ToString() + "," + c.ToString();
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.ForeColor = Color.White;
                    label.BringToFront();
                    Controls.Add(label);
                    sGrid[r, c] = label;
                    sList.Add(sGrid[r, c]);
                }
            }
        }




        private void tmrMove_Tick(object sender, EventArgs e)
        {
            for (int s = 0; s < sList.Count; s++)
            {
                sList[s].Top++;

                if (sList[s].Tag == "1")
                {
                    sList[s].BackColor = Color.Red;
                }
                else
                {
                    sList[s].BackColor = Color.Blue;
                }
            }


            for (int g = 0; g < gList.Count; g++)
            {

                for (int i = 0; i < sList.Count; i++)
                {

                    if (sList[i].Bounds.IntersectsWith(gList[g].Bounds))
                    {
                        //considering making just lists of those with tags
                        //make sure it keeps tag when transferring
                        //maybe run the for loop backward?
                        if (gList[g].Tag == "1" && sList[i].Tag == "1")
                        {
                            try
                            {
                                gList[g - 9].Tag = "1";
                                gList[g - 9].BackColor = Color.Green;
                            }
                            catch
                            {

                            }

                        }
                    }
                }

            }
        }
    }
}
