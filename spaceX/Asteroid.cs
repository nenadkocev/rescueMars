using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace spaceX
{
    class Asteroid
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool valid { get; set; }
        public char Type { get; set; }
        public int numOfImage { get; set; }
        public int health { get; set; }
        public int Speed { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public Asteroid(int x, int y, char size, int speed)
        {
            valid = true;
            X = x;
            Y = y;
            Type = size;
            health = 300;
            numOfImage = 0;
            this.Speed = speed;
        }

        public void Move()
        {
            this.Y += Speed;
        }

        public void Rotate()
        {
            numOfImage++;
        }

        public void Draw(Graphics g)
        {
            // za sekoj asteroid se cuvaat 16 sliki i pri sekoe crtanje se zema druga za efekt na rotacija
            string img = String.Format("{0}{1}", Type, numOfImage % 16);
            ResourceManager rm = Properties.Resources.ResourceManager;
            Bitmap bitmap = (Bitmap)rm.GetObject(img);
            width = bitmap.Width;
            height = bitmap.Height;
            g.DrawImageUnscaled(bitmap, X, Y);
            bitmap.Dispose();
        }

        public void isHit(Ray ray)
        {
            // science
            if(ray.p1.X > X && ray.p1.X < X + width && ray.p1.Y < Y + (height * 0.8) && (ray.p1.Y + ray.height) > Y+height/4)
            {
                this.health -= ray.damage;
                ray.valid = false;
            }
            valid = health > 0;
        }

    }
}
