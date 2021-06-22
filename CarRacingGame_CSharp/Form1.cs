using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacingGame_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            labelGameOver.Visible = false;
        }

        int gameSpeed = 0;
        Random r = new Random();
        int x, y;
        int coins = 0;

        #region Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            moveLine(gameSpeed);
            moveEnemy(gameSpeed);
            moveCoin(gameSpeed);
            gameOver();
            collectCoin();
        }
        #endregion

        #region Move Line
        void moveLine(int speed)
        {
            if(pictureBox1.Top >= 500)
            {
                pictureBox1.Top = 0;
            }
            else
            {
                pictureBox1.Top += speed;
            }

            if (pictureBox2.Top >= 500)
            {
                pictureBox2.Top = 0;
            }
            else
            {
                pictureBox2.Top += speed;
            }

            if (pictureBox3.Top >= 500)
            {
                pictureBox3.Top = 0;
            }
            else
            {
                pictureBox3.Top += speed;
            }

            if (pictureBox4.Top >= 500)
            {
                pictureBox4.Top = 0;
            }
            else
            {
                pictureBox4.Top += speed;
            }
        }
        #endregion

        #region Move Enemy
        void moveEnemy(int speed)
        {
            if (pictureBoxEnemy1.Top >= 500)
            {
                x = r.Next(0, 190);
                y = 0;
                pictureBoxEnemy1.Location = new Point(x, y);
            }
            else
            {
                pictureBoxEnemy1.Top += speed;
            }

            if (pictureBoxEnemy2.Top >= 500)
            {
                x = r.Next(95, 285);
                y = 0;
                pictureBoxEnemy2.Location = new Point(x, y);
            }
            else
            {
                pictureBoxEnemy2.Top += speed;
            }

            if (pictureBoxEnemy3.Top >= 500)
            {
                x = r.Next(190, 370);
                y = 0;
                pictureBoxEnemy3.Location = new Point(x, y);
            }
            else
            {
                pictureBoxEnemy3.Top += speed;
            }
        }
        #endregion

        #region Car Movement
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                if(pictureBoxCar.Left > 0)
                {
                    pictureBoxCar.Left -= 8;
                }
            }
            if(e.KeyCode == Keys.Right)
            {
                if(pictureBoxCar.Right < 380)
                {
                    pictureBoxCar.Left += 8;
                }
            }

            if(e.KeyCode == Keys.Up)
            {
                if(gameSpeed < 21)
                {
                    gameSpeed++;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (gameSpeed > 0)
                {
                    gameSpeed--;
                }
            }
        }
        #endregion

        #region Game Over
        void gameOver()
        {
            if (pictureBoxCar.Bounds.IntersectsWith(pictureBoxEnemy1.Bounds))
            {
                timer1.Enabled = false;
                labelGameOver.Visible = true;
            }
            if (pictureBoxCar.Bounds.IntersectsWith(pictureBoxEnemy2.Bounds))
            {
                timer1.Enabled = false;
                labelGameOver.Visible = true;
            }
            if (pictureBoxCar.Bounds.IntersectsWith(pictureBoxEnemy3.Bounds))
            {
                timer1.Enabled = false;
                labelGameOver.Visible = true;
            }
        }
        #endregion

        #region Move Coin
        void moveCoin(int speed)
        {
            if (pictureBoxCoin1.Top >= 500)
            {
                x = r.Next(0, 190);
                y = 0;
                pictureBoxCoin1.Location = new Point(x, y);
            }
            else
            {
                pictureBoxCoin1.Top += speed;
            }

            if (pictureBoxCoin2.Top >= 500)
            {
                x = r.Next(0, 190);
                y = 0;
                pictureBoxCoin2.Location = new Point(x, y);
            }
            else
            {
                pictureBoxCoin2.Top += speed;
            }

            if (pictureBoxCoin3.Top >= 500)
            {
                x = r.Next(190, 370);
                y = 0;
                pictureBoxCoin3.Location = new Point(x, y);
            }
            else
            {
                pictureBoxCoin3.Top += speed;
            }

            if (pictureBoxCoin4.Top >= 500)
            {
                x = r.Next(190, 370);
                y = 0;
                pictureBoxCoin4.Location = new Point(x, y);
            }
            else
            {
                pictureBoxCoin4.Top += speed;
            }
        }
        #endregion

        #region Coin Collected
        void collectCoin()
        {
            if (pictureBoxCar.Bounds.IntersectsWith(pictureBoxCoin1.Bounds))
            {
                coins++;
                x = r.Next(0, 190);
                y = 0;
                pictureBoxCoin1.Location = new Point(x, y);
                labelCoins.Text = $"Coins = {coins}";
            }
            if (pictureBoxCar.Bounds.IntersectsWith(pictureBoxCoin2.Bounds))
            {
                coins++;
                x = r.Next(0, 190);
                y = 0;
                pictureBoxCoin2.Location = new Point(x, y);
                labelCoins.Text = $"Coins = {coins}";
            }
            if (pictureBoxCar.Bounds.IntersectsWith(pictureBoxCoin3.Bounds))
            {
                coins++;
                x = r.Next(190, 370);
                y = 0;
                pictureBoxCoin3.Location = new Point(x, y);
                labelCoins.Text = $"Coins = {coins}";
            }
            if (pictureBoxCar.Bounds.IntersectsWith(pictureBoxCoin4.Bounds))
            {
                coins++;
                x = r.Next(190, 370);
                y = 0;
                pictureBoxCoin4.Location = new Point(x, y);
                labelCoins.Text = $"Coins = {coins}";
            }
        }
        #endregion
    }
}
