using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceX
{
    class Goodguy : Spaceship
    {
        public Goodguy(int x, int y, int health, int firePower, string fireName, Bitmap bitmap, int speed, int fireSpeed) 
            : base(x, y, health, firePower, fireName, bitmap, speed, fireSpeed)
        {
        }

        // dvizenje po x i y oska, granicite se width i heigth
        public void move(int x, int y, int width, int heigth)
        {
            if(x + X + 40 < width && x + X > 0)
                this.X += x;
            if(y + Y + 110 < heigth && y + Y > 0)
                this.Y += y;
        }
        
        public Ray Fire()
        {
            var start = new Point(X-3, Y - 15);
            Ray ray = new Ray(start, FirePower, fireName, -fireSpeed);
            return ray;
        }

        // ednostavna proverka dali se sudiraat so kreiranje na dva pravoalognika
        // i koristenje na gotovata funkcija implementirana vo klasata Rectangle
        public void isColiding(Asteroid s)
        {
            if (!s.valid)
                return;
            Rectangle r1 = new Rectangle(s.X, s.Y, s.width,  s.height);
            Rectangle r2 = new Rectangle(X, Y, bitmap.Width, bitmap.Height);
            if (r1.IntersectsWith(r2))
            {
                Health = 0;
                alive = false;
                s.valid = false;
            }
        }

        public override void isHit(Ray ray)
        {
            int x1 = ray.p1.X;
            int x2 = ray.p1.X + ray.width;

            int x3 = X;
            int x4 = X + bitmap.Width;

            //x oska (proverka daali se naogaat paralelno eden so drug)
            if (x1 > x3 && x1 < x4 || x2 > x3 && x2 < x4)
            {
                //y oska (proverka za penetracija na raketata)
                int y = ray.p1.Y + ray.height;
                if(y > Y && y < Y + bitmap.Height)
                {
                    ray.valid = false;
                    Health -= ray.damage;
                    alive = Health > 0;
                }
            }
        }
    }
}
