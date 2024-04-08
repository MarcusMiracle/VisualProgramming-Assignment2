/**
 * Name: Miracle Marcus
 * Course Title: Visual Programming
 * Course Code: COMP-213
 * Student ID: U231N0171
 * Date: 8th April, 2024
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_2
{

    public partial class Form1 : Form
    {
        int[,] matrix = new int[3, 3];
        int[,] matrixWin = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
        int[,] matrixWin1 = new int[3, 3] { { 1, 2, 3 }, { 8, 0, 4 }, { 7, 6, 5 } };
        int MoveNum = 0;


        public void NewGame()
        {
            int[] numbers = new int[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            bool count = true;
            Random random = new Random();
            int randomNumber;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    count = true;
                    do
                    {
                        randomNumber = random.Next(0, 9);
                        if (numbers[randomNumber] != 9)
                        {
                            matrix[i, j] = numbers[randomNumber];
                            numbers[randomNumber] = 9;
                            count = false;
                        }
                    } while (count);
                }

            }
        }//function to make move 0 filde
        public char DisplayTransform(int x)
        {
            switch (x)
            {
                case 0: return ' ';
                case 1: return '1';
                case 2: return '2';
                case 3: return '3';
                case 4: return '4';
                case 5: return '5';
                case 6: return '6';
                case 7: return '7';
                case 8: return '8';
            }
            return ' ';
        }//transform nubers into string
        public void Display()
        {
            button1.Text = DisplayTransform(matrix[0, 0]).ToString();
            button2.Text = DisplayTransform(matrix[0, 1]).ToString();
            button3.Text = DisplayTransform(matrix[0, 2]).ToString();
            button4.Text = DisplayTransform(matrix[1, 0]).ToString();
            button5.Text = DisplayTransform(matrix[1, 1]).ToString();
            button6.Text = DisplayTransform(matrix[1, 2]).ToString();
            button7.Text = DisplayTransform(matrix[2, 0]).ToString();
            button8.Text = DisplayTransform(matrix[2, 1]).ToString();
            button9.Text = DisplayTransform(matrix[2, 2]).ToString();
        }//function to transform matrix

        public Form1()
        {
            InitializeComponent();
            MoveNo.Text = "Move #" + " " + MoveNum.ToString();
        }

        public bool Solved()
        {
            // First win method
            int counter = 0;
            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 3; j++)
                {
                    if (matrix[i, j] == matrixWin[i, j])
                    {
                        counter++;
                    }
                }
            }
            if (counter == 9)
            {
                return true;
            }

            // Second win method
            counter = 0;
            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 3; j++)
                {
                    if (matrix[i, j] == matrixWin1[i, j])
                    {
                        counter++;
                    }

                }
            }
            if (counter == 9)
            {
                return true;
            }
            return false;
        } //check if you won or not yet

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveNum = 0;
            MoveNo.Text = "Move #" + " " + MoveNum.ToString();
            NewGame();
            Display();
            panel1.Enabled = true;
        }

        private void otherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                this.BackColor = colorDialog1.Color;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Programmer: Miracle Marcus");
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Blue;
        }

        private void beginnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beginnerToolStripMenuItem.Checked = true;
            advancedToolStripMenuItem.Checked = false;
        }

        private void advancedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beginnerToolStripMenuItem.Checked = false;
            advancedToolStripMenuItem.Checked = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (matrix[0, 1] == 0)
            {
                matrix[0, 1] = matrix[0, 0];
                matrix[0, 0] = 0;
                MoveNum++;
            }
            if (matrix[1, 0] == 0)
            {
                matrix[1, 0] = matrix[0, 0];
                matrix[0, 0] = 0;
                MoveNum++;
            }
            Display();
            MoveNo.Text = "Move #" + " " + MoveNum.ToString();
            if (Solved())
            {
                MessageBox.Show("Congratulations - You Win");
                NewGame();
                Display();
            }
        }//simular functions to moove numbers

        private void button2_Click(object sender, EventArgs e)
        {

            if (matrix[0, 0] == 0)
            {
                matrix[0, 0] = matrix[0, 1];
                matrix[0, 1] = 0;
                MoveNum++;
            }
            if (matrix[0, 2] == 0)
            {
                matrix[0, 2] = matrix[0, 1];
                matrix[0, 1] = 0;
                MoveNum++;
            }
            if (matrix[1, 1] == 0)
            {
                matrix[1, 1] = matrix[0, 1];
                matrix[0, 1] = 0;
                MoveNum++;
            }
            Display();
            MoveNo.Text = "Move #" + " " + MoveNum.ToString();
            if (Solved())
            {
                MessageBox.Show("Congratulations - You Win");
                NewGame();
                Display();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (matrix[0, 1] == 0)
            {
                matrix[0, 1] = matrix[0, 2];
                matrix[0, 2] = 0;
                MoveNum++;
            }
            if (matrix[1, 2] == 0)
            {
                matrix[1, 2] = matrix[0, 2];
                matrix[0, 2] = 0;
                MoveNum++;
            }
            Display();
            MoveNo.Text = "Move #" + " " + MoveNum.ToString();
            if (Solved())
            {
                MessageBox.Show("Congratulations - You Win");
                NewGame();
                Display();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {


            if (matrix[0, 0] == 0)
            {
                matrix[0, 0] = matrix[1, 0];
                matrix[1, 0] = 0;
                MoveNum++;
            }
            if (matrix[2, 0] == 0)
            {
                matrix[2, 0] = matrix[1, 0];
                matrix[1, 0] = 0;
                MoveNum++;
            }
            if (matrix[1, 1] == 0)
            {
                matrix[1, 1] = matrix[1, 0];
                matrix[1, 0] = 0;
                MoveNum++;
            }
            Display();
            MoveNo.Text = "Move #" + " " + MoveNum.ToString();
            if (Solved())
            {
                MessageBox.Show("Congratulations - You Win");
                NewGame();
                Display();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (matrix[0, 1] == 0)
            {
                matrix[0, 1] = matrix[1, 1];
                matrix[1, 1] = 0;
                MoveNum++;
            }
            if (matrix[1, 2] == 0)
            {
                matrix[1, 2] = matrix[1, 1];
                matrix[1, 1] = 0;
                MoveNum++;
            }

            if (matrix[2, 1] == 0)
            {
                matrix[2, 1] = matrix[1, 1];
                matrix[1, 1] = 0;
                MoveNum++;
            }

            if (matrix[1, 0] == 0)
            {
                matrix[1, 0] = matrix[1, 1];
                matrix[1, 1] = 0;
                MoveNum++;
            }
            Display();
            MoveNo.Text = "Move #" + " " + MoveNum.ToString();
            if (Solved())
            {
                MessageBox.Show("Congratulations - You Win");
                NewGame();
                Display();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (matrix[0, 2] == 0)
            {
                matrix[0, 2] = matrix[1, 2];
                matrix[1, 2] = 0;
                MoveNum++;
            }
            if (matrix[1, 1] == 0)
            {
                matrix[1, 1] = matrix[1, 2];
                matrix[1, 2] = 0;
                MoveNum++;
            }
            if (matrix[2, 2] == 0)
            {
                matrix[2, 2] = matrix[1, 2];
                matrix[1, 2] = 0;
                MoveNum++;
            }
            Display();
            MoveNo.Text = "Move #" + " " + MoveNum.ToString();
            if (Solved())
            {
                MessageBox.Show("Congratulations - You Win");
                NewGame();
                Display();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (matrix[1, 0] == 0)
            {
                matrix[1, 0] = matrix[2, 0];
                matrix[2, 0] = 0;
                MoveNum++;
            }

            if (matrix[2, 1] == 0)
            {
                matrix[2, 1] = matrix[2, 0];
                matrix[2, 0] = 0;
                MoveNum++;
            }
            Display();
            MoveNo.Text = "Move #" + " " + MoveNum.ToString();
            if (Solved())
            {
                MessageBox.Show("Congratulations - You Win");
                NewGame();
                Display();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (matrix[1, 1] == 0)
            {
                matrix[1, 1] = matrix[2, 1];
                matrix[2, 1] = 0;
                MoveNum++;
            }
            if (matrix[2, 2] == 0)
            {
                matrix[2, 2] = matrix[2, 1];
                matrix[2, 1] = 0;
                MoveNum++;
            }
            if (matrix[2, 0] == 0)
            {
                matrix[2, 0] = matrix[2, 1];
                matrix[2, 1] = 0;
                MoveNum++;
            }
            Display();
            MoveNo.Text = "Move #" + " " + MoveNum.ToString();
            if (Solved())
            {
                MessageBox.Show("Congratulations - You Win");
                NewGame();
                Display();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (matrix[1, 2] == 0)
            {
                matrix[1, 2] = matrix[2, 2];
                matrix[2, 2] = 0;
                MoveNum++;
            }
            if (matrix[2, 1] == 0)
            {
                matrix[2, 1] = matrix[2, 2];
                matrix[2, 2] = 0;
                MoveNum++;
            }
            Display();
            MoveNo.Text = "Move #" + " " + MoveNum.ToString();
            if (Solved())
            {
                MessageBox.Show("Congratulations - You Win");
                NewGame();
                Display();
            }
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            MoveNum = 0;
            MoveNo.Text = "Move #" + " " + MoveNum.ToString();
            NewGame();
            Display();
            panel1.Enabled = true;
        }
    }
}
