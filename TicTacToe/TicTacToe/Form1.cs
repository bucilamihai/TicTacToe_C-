using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Button[,] b = new Button[4,4];
        TextBox Xscore = new TextBox();
        TextBox Oscore = new TextBox();
        TextBox GameNo = new TextBox();
        int pas = 0, round = 0;
        int Xwin = 0, Owin=0;
        
        private void ColorWin(int i,int j)
        {
            b[i, j].BackColor = Color.Green;
        }
        private void CheckWin(ref char p)
        {
            /// line check
            for(int i=0;i<3;i++)
            {
                if (b[i, 0].Text == "X" && b[i, 1].Text == "X" && b[i, 2].Text == "X")
                {
                    ColorWin(i, 0);
                    ColorWin(i, 1);
                    ColorWin(i, 2);
                    p = 'X';
                }
                if (b[i, 0].Text == "O" && b[i, 1].Text == "O" && b[i, 2].Text == "O")
                {
                    ColorWin(i, 0);
                    ColorWin(i, 1);
                    ColorWin(i, 2);
                    p = 'O';
                }
                    
            }
            /// column check
            for(int j=0;j<3;j++)
            {
                if (b[0, j].Text == "X" && b[1, j].Text == "X" && b[2, j].Text == "X")
                {
                    ColorWin(0, j);
                    ColorWin(1, j);
                    ColorWin(2, j);
                    p = 'X';
                }
                if (b[0, j].Text == "O" && b[1, j].Text == "O" && b[2, j].Text == "O")
                {
                    ColorWin(0, j);
                    ColorWin(1, j);
                    ColorWin(2, j);
                    p = 'O';
                }
            }
            /// first diagonal check
            if (b[0, 0].Text == "X" && b[1, 1].Text == "X" && b[2, 2].Text == "X")
            {
                ColorWin(0, 0);
                ColorWin(1, 1);
                ColorWin(2, 2);
                p = 'X';
            }
            if (b[0, 0].Text == "O" && b[1, 1].Text == "O" && b[2, 2].Text == "O")
            {
                ColorWin(0, 0);
                ColorWin(1, 1);
                ColorWin(2, 2);
                p = 'O';
            }
            /// seconde diagonal check
            if (b[0, 2].Text == "X" && b[1, 1].Text == "X" && b[2, 0].Text == "X")
            {
                ColorWin(0, 2);
                ColorWin(1, 1);
                ColorWin(2, 0);
                p = 'X';
            }
            if (b[0, 2].Text == "O" && b[1, 1].Text == "O" && b[2, 0].Text == "O")
            {
                ColorWin(0, 2);
                ColorWin(1, 1);
                ColorWin(2, 0);
                p = 'O';
            }
        }
        private void Clear_Table()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    b[i, j].Text = "";
                    b[i, j].BackColor = Color.Transparent;
                }       
        }
        private void Update_Score()
        {
            Xscore.Text = "X: " + Xwin;
            Xscore.Font = new Font(Xscore.Font.FontFamily, 10);
            Xscore.Location = new Point(400, 75);
            Xscore.ReadOnly = true;
            this.Controls.Add(Xscore);
            Oscore.Text = "O: " + Owin;
            Oscore.Font = new Font(Oscore.Font.FontFamily, 10);
            Oscore.Location = new Point(600, 75);
            Oscore.ReadOnly = true;
            this.Controls.Add(Oscore);
            GameNo.Text = "Game #" + (round + 1);
            GameNo.Font = new Font(GameNo.Font.FontFamily, 10);
            GameNo.Location = new Point(500, 25);
            GameNo.ReadOnly = true;
            this.Controls.Add(GameNo);
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button aux = (Button)sender;
            char p = ' ';
            if(aux.Text == "")
            {
                if(round % 2 == 0)
                { 
                    if (pas % 2 == 0)
                        aux.Text = "X";
                    else
                        aux.Text = "O";
                }
                else
                {
                    if (pas % 2 == 0)
                        aux.Text = "O";
                    else
                        aux.Text = "X";
                }
                pas++;
            }
            CheckWin(ref p);
            if (p == 'X')
            {
                Xwin++;
                round++;
                pas = 0;
                MessageBox.Show("X wins!");
                Clear_Table();
                Update_Score();
            }
            if (p == 'O')
            {
                Owin++;
                round++;
                pas = 0;
                MessageBox.Show("O wins!");
                Clear_Table();
                Update_Score();
            }
            if(pas==9)
            {
                round++;
                pas = 0;
                MessageBox.Show("It's a draw!");
                Clear_Table();
                Update_Score();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Update_Score();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    b[i, j] = new Button();
                    b[i, j].Text = "";
                    b[i, j].Width = 100;
                    b[i, j].Height = 100;
                    b[i, j].Location = new Point(i * 110, j * 110);
                    b[i, j].Font = new Font(Font.FontFamily, 28);
                    b[i, j].Click += new EventHandler(Button_Click);
                    this.Controls.Add(b[i, j]);
                }
        }
    }
}
