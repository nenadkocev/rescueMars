using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spaceX
{
    public partial class Form1 : Form
    {
        public enum Level { Easy, Medium, Hard };
        Game game;
        bool up, down, left, right, fire;
        long elapsedTime;
        Timer timer, multipleKeysDown, credits;
        Level level;

        Graphics canvas;
        int marsX, marsY;
        Bitmap mars;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.BackgroundImage = Properties.Resources.spiral_galaxy_star_background;
            canvas = this.CreateGraphics();
            marsX = (this.Width - 800) / 3;
            marsY = -800;
            mars = Properties.Resources.mars;

            Intro intro = new Intro();
            intro.ShowDialog();
            level = intro.getLevel();

            game = new Game(this.Width, this.Height, level);
            elapsedTime = 0;

            timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 50;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            multipleKeysDown = new Timer();
            multipleKeysDown.Enabled = true;
            multipleKeysDown.Interval = 31;
            multipleKeysDown.Tick += new EventHandler(multipleKeysDown_Tick);
            multipleKeysDown.Start();

        }

        public void gameOver()
        {
            timer.Stop();
            multipleKeysDown.Stop();
            lblHp.Text = "DEAD";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            var result = MessageBox.Show("Дали сакате нова игра?", "Game Over", buttons);
            if (result == DialogResult.No)
                this.Close();
            else
            {
                newGame();
            }
        }

        public void newGame()
        {
            marsY = -800;
            elapsedTime = 0;
            game = new Game(this.Width, this.Height, level);
            up = down = left = right = fire = false;
            timer.Start();
            multipleKeysDown.Start();
        }

        public void win()
        {

            game.badGuys.RemoveAll(a => true);
            game.rocks.RemoveAll(a => true);
            game.goodRays.RemoveAll(a => true);
            game.goodRays.RemoveAll(a => true);
            Invalidate();
            timer.Stop();
            multipleKeysDown.Stop();

            credits = new Timer();
            credits.Enabled = true;
            credits.Tick += new EventHandler(Credits_Tick);
            credits.Interval = 50;
            credits.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e.Graphics);
        }

        public void timer_Tick(object sender, EventArgs args)
        {
            ustekolku.Value = (int)(elapsedTime/6);
            if (!game.goodGuy.alive)
            {
                gameOver();
            }
            if(elapsedTime == 600)
            {
                win();
            }
            if (elapsedTime % 50 == 0)
            {
                game.addBadGuy();
                game.addAsteroid();
            }
            if (elapsedTime % 4 == 0)
            {
                game.rotateRocks();
                game.fireBadGuys();
            }
            lblHp.Text = String.Format("HP: {0}", game.goodGuy.Health);
            
            elapsedTime += 1;
            game.moveObjects();
            game.moveBadGuys();
            Invalidate();
        }

        public void multipleKeysDown_Tick(object sender, EventArgs args)
        {
            if(down)
                game.moveGoodGuy(0, 15);
            else if(up)
                game.moveGoodGuy(0, -15);
            if(left)
                game.moveGoodGuy(-15, 0);
            else if(right)
                game.moveGoodGuy(15, 0);
            if(fire && elapsedTime % 2 == 0)
                game.Fire();
            Invalidate();
        }



        public void Credits_Tick(object sender, EventArgs args)
        {
            if(marsY + mars.Height >= game.goodGuy.Y)
            {
                credits.Stop();
                var result = MessageBox.Show("Одлично, стигнавте до Марс. Дали сакате нова игра?","u win", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    newGame();
                }
                else
                {
                    this.Close();
                }
            }

            canvas.DrawImageUnscaled(mars, marsX, marsY);
            marsY += 5;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    up = false;
                    break;
                case Keys.Down:
                    down = false;
                    break;
                case Keys.Left:
                    left = false;
                    break;
                case Keys.Right:
                    right = false;
                    break;
                case Keys.ControlKey:
                    fire = false;
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    up = true;
                    break;
                case Keys.Down:
                    down = true;
                    break;
                case Keys.Left:
                    left = true;
                    break;
                case Keys.Right:
                    right = true;
                    break;
                case Keys.ControlKey:
                    fire = true;
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
