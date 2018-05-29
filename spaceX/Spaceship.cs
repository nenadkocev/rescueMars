using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceX
{
    abstract class Spaceship
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Health { get; set; }
        public int FirePower { get; set; }
        public bool alive { get; set; }
        public string fireName { get; set; }
        public Bitmap bitmap { get; set; }
        public int speed { get; set; }
        public int fireSpeed { get; set; }

        // zaednicki atributi za sekoj broj
        protected Spaceship(int x, int y, int health, int firePower, string fireName, Bitmap bitmap, int speed, int fireSpeed)
        {
            X = x;
            Y = y;
            Health = health;
            FirePower = firePower;
            this.fireName = fireName;
            this.bitmap = bitmap;
            this.speed = speed;
            this.fireSpeed = fireSpeed;
            alive = true;
        }

        public void Draw(Graphics g)
        {
            g.DrawImageUnscaled(bitmap, X - bitmap.Width / 2, Y);
        }

        public abstract void isHit(Ray ray);
    }
}
