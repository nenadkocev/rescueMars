using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceX
{
    class Explosion
    {
        // da se iscrtaat 5 krugovi vo razlicni nijansi, 
        // pocnuva od najmaliot do najgolemiot i nazad za da se dobie efekt na explozija
        // Radiusot se zgolemuva do nekoja maksimalna golemina, a potoa se namaluva do inicijalniot radius

        public int X { get; set; }
        public int Y { get; set; }
        public int i { get; set; }
        public bool increase { get; set; }
        public bool alive { get; set; }
        public int Radius { get; set; }
        public int initialRadius { get; set; }

        public static Color[] Colors =
        {
            Color.FromArgb(255, 252, 71),
            Color.FromArgb(255, 251, 36),
            Color.FromArgb(245, 241, 0),
            Color.FromArgb(250, 154, 0),
            Color.FromArgb(250, 50, 0),
            Color.FromArgb(250, 30, 0),
            Color.FromArgb(250, 10, 0)
        };
        public Explosion(int x, int y, int radius)
        {
            Radius = radius;
            X = x + 5 * radius;
            Y = y + 5 * radius;
            i = 0;
            alive = true;
            increase = true;
            initialRadius = radius;
        }

        public void Draw(Graphics g)
        {
            if (i < 0)
                return;
            using(Brush br = new SolidBrush(Colors[i]))
            {
                g.FillEllipse(br, X,Y, Radius * 2, Radius * 2);
            }
            // ako increase == true, zgolemi go radiusot i pomesti gi X i Y za centarot na krugovite si ostane ist
            if (increase)
            {
                i++;
                Radius += initialRadius;
                X -= initialRadius;
                Y -= initialRadius;
            }
            else
            {
                i--;
                Radius -= initialRadius;
                X += initialRadius;
                Y += initialRadius;
            }
            // vo ovoj slucaj zavrsuva eksplozijata, t.e koga se namaluva i go dostignuva pocetniot radius
            if (Radius == initialRadius && !increase)
                alive = false;
            if (Radius == 6 * initialRadius)
                increase = false;
        }
    }
}
