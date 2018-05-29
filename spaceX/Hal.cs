using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceX
{
    //Hal is the bad guy
    class Hal : Spaceship
    {

        public Hal(int x, int y, int health, int firePower, string fireName, Bitmap bitmap, int speed, int fireSpeed)
            :base(x, y, health, firePower, fireName, bitmap, speed, fireSpeed){}

        //  se dvizi prema protivnickiot brod
        //  y e krajnata linija kon koja moze da odi napred
        public void Move(int x, int y)
        {
            var n = Math.Abs(x - X);
            var nspeed = n > speed ? speed : n;
            if (x > X)
                X += nspeed;
            else
                X -= nspeed;
            if (Y < y)
                Y += speed;
        }


        //puka samo dokolku se naoga vo paralela so protivnickiot brod
        public Ray Fire(int x1, int x2)
        {
            var middle = X + bitmap.Width / 2;
            if(middle >= x1 && middle <= x2)
            {
                var start = new Point(X, Y - 15);
                Ray ray = new Ray(start, FirePower, fireName, fireSpeed);
                return ray;
            }

            return null;
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
                int y = ray.p1.Y;
                if (Y < y && y < Y + bitmap.Height - bitmap.Height/4)
                {
                    ray.valid = false;
                    Health -= ray.damage;
                    alive = Health > 0;
                }
            }
        }
    }
}
