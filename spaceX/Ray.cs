using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace spaceX
{
    class Ray
    {
        public Point p1 { get; set; }
        public bool valid { get; set; }
        public int damage { get; set; }
        public string name { get; set; }
        public int Speed { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public Ray(Point pt1, int damage, string bitmap, int speed)
        {
            valid = true;
            p1 = pt1;
            this.damage = damage;
            this.name = bitmap;
            Speed = speed;
        }

        public void Draw(Graphics g)
        {
            // slikata za sekoj zrak ili raketa se cuva vo resursite i se zema spored imeto na atributot
            Bitmap bm = (Bitmap)Properties.Resources.ResourceManager.GetObject(name);
            g.DrawImageUnscaled(bm, p1);
            width = bm.Width;
            height = bm.Height;
            bm.Dispose();
        }

        public void Move()
        {
            p1 = new Point(p1.X, p1.Y + Speed);
        }

    }
}
