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
        int type;
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SpawnGrid();
            type = 1;
            //SpawnBlock1();
            //Rotate();
            EasierRotation();
            SpawnBlock();
        }
        private void SpawnBlock()
        {
            //Piece piece1 = new Piece(1, 1, 3);

            //So we can create a list of lists and seperate each piece by block (which we should do so they can be cleared later)
            //or i can high light blocks, i have just been having trouble keeping track of where multiple pieces are and rotating(tho this is a possible solution)
            //or a single piece and maybe make a conglomeration at the bottom idk man.
        }
        private void EasierRotation()
        {
            
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
                    label.Text = r.ToString() +"," + c.ToString();
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.ForeColor = Color.White;
                    Controls.Add(label);
                    grid[r, c] = label;
                }
            }
        }
        private void Rotate()
        {
            for (int i = 0; i < grid.Length; i++)
            {
                
            }
        }
        private void SpawnBlock()
        {
            for (int c=2; c <=5; c++)
            {
                for (int r = 0; r < 4; r ++)
                {
                    grid[c, r].BackColor = Color.SaddleBrown;
                }
            }

            if(type ==0)
            {
                grid[3, 1].BackColor = Color.Red;
                grid[3, 2].BackColor = Color.Red;
                grid[4, 1].BackColor = Color.Red;
                grid[4, 2].BackColor = Color.Red;
            }else if(type == 1)
            {
                grid[2, 1].BackColor = Color.Red;
                grid[3, 1].BackColor = Color.Red;
                grid[4, 1].BackColor = Color.Red;
                grid[4, 2].BackColor = Color.Red;
            }
        }
    }
}
