using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace spaceX
{
    class Game
    {
        public Goodguy goodGuy { get; set; }
        public Random random;
        public int width { get; set; }
        public int heigth { get; set; }
        public List<Asteroid> rocks { get; set; }
        public List<Hal> badGuys { get; set; }
        public List<Ray> goodRays { get; set; }
        public List<Ray> badRays { get; set; }
        public List<Explosion> explosions { get; set; }

        // raketite se cuvaat vo dve listi za da se namali brojot na proverki
        // t.e da ne se proveruva raketa sto ja ispukal eden brod dali go pogodila istiot toj brod
        // bidejki takva situacija tuka ne e vozmozna

        // ResourceManager se koristi za pristapuvanje do nekoj resurs so string namesto so .
        public static ResourceManager rm = Properties.Resources.ResourceManager;
        public static char[] sizeOfAsteroids = { 's', 'm', 'l' };
        public static string[] namesOfBadGuys = { "normal", "bigger", "biggest" };
        public static string[] namesOfWeapons = { "slabo", "jako", "najjako" };
        public static int[] firePower = { 10, 20, 30 };
        public static int[] fireSpeed = { 35, 40, 45 };
        public static int[] speed = { 11, 9, 7 };
        public static int[] health = { 100, 150, 200 };

        public Game(int width, int heigth)
        {
            random = new Random();
            this.width = width;
            this.heigth = heigth;
            Bitmap bitmap = new Bitmap(Properties.Resources.G_10);
            goodGuy = new Goodguy(width / 2, heigth - 130, 150, 5, "laser_20", bitmap, 15, 30);

            explosions = new List<Explosion>();
            rocks = new List<Asteroid>();
            badGuys = new List<Hal>();
            goodRays = new List<Ray>();
            badRays = new List<Ray>();
        }

        public void Draw(Graphics g)
        {
            goodGuy.Draw(g);

            foreach (Ray ray in goodRays)
                ray.Draw(g);

            foreach (Ray ray in badRays)
                ray.Draw(g);

            foreach (Asteroid r in rocks)
                r.Draw(g);

            foreach (Hal hal in badGuys)
                hal.Draw(g);

            foreach (Explosion ex in explosions)
                ex.Draw(g);
        }

        public void moveObjects()
        {

            foreach (Ray ray in goodRays)
                ray.Move();

            foreach (Ray ray in badRays)
                ray.Move();

            foreach (Asteroid a in rocks)
                a.Move();


            checkCollisions();
            deleteInvalidObjects();
        }

        public void checkCollisions()
        {
            // proverka za kolizija pomegu asteroidite i nasiot brod,
            // zracite od listata na nashiot brod so site neprijatelski brodovi i obratno
            foreach (Asteroid r in rocks)
            {
                goodGuy.isColiding(r);
                foreach (Ray ray in badRays)
                    r.isHit(ray);
                foreach (Ray ray in goodRays)
                    r.isHit(ray);
            }
            foreach (Ray ray in badRays)
            {
                goodGuy.isHit(ray);
            }
            foreach (Hal hal in badGuys)
            {
                foreach (Ray ray in goodRays)
                {
                    hal.isHit(ray);
                }
            }

        }

        public void deleteInvalidObjects()
        {

            foreach (Ray r in goodRays)
            {
                if (r.p1.Y < 0 || r.p1.Y > heigth)
                    r.valid = false;
            }

            for (int j = goodRays.Count - 1; j >= 0; j--)
            {
                if (!goodRays[j].valid)
                {
                    goodRays.RemoveAt(j);
                }
            }

            foreach (Ray r in badRays)
            {
                if (r.p1.Y < 0 || r.p1.Y > heigth)
                    r.valid = false;
            }

            for (int j = badRays.Count - 1; j >= 0; j--)
            {
                if (!badRays[j].valid)
                {
                    badRays.RemoveAt(j);
                }
            }

            foreach (Asteroid a in rocks)
            {
                if (a.Y > this.heigth)
                    a.valid = false;
            }

            // Dodavanje na eksplozija na mestoto kade e unisten neprijatelskiot brod
            // Radiusot na eksplozijata zavisi od goleminata na brodot
            for (int i = badGuys.Count - 1; i >= 0; i--)
            {
                if (!badGuys[i].alive)
                {
                    Hal dead = badGuys[i];
                    int x = dead.X - dead.bitmap.Width / 2;
                    int y = dead.Y;
                    int r = dead.bitmap.Height / 12;
                    explosions.Add(new Explosion(x, y, r));
                    badGuys.RemoveAt(i);
                }
            }

            for (int j = rocks.Count - 1; j >= 0; j--)
            {
                if (!rocks[j].valid)
                    rocks.RemoveAt(j);
            }

            for (int j = explosions.Count - 1; j >= 0; j--)
            {
                if (!explosions[j].alive)
                    explosions.RemoveAt(j);
            }

        }


        public void rotateRocks()
        {
            foreach (Asteroid a in rocks)
                a.Rotate();
        }

        public void moveBadGuys()
        {
            foreach (Hal hal in badGuys)
                hal.Move(goodGuy.X, 20);
        }

        public void fireBadGuys()
        {
            int x = goodGuy.X;

            foreach (Hal hal in badGuys)
            {
                var ray = hal.Fire(x, x + goodGuy.bitmap.Width);
                if (ray != null)
                    badRays.Add(ray);
            }
        }

        public void moveGoodGuy(int x, int y)
        {
            goodGuy.move(x, y, width, heigth);
        }

        public void Fire()
        {
            var ray = goodGuy.Fire();
            goodRays.Add(ray);
        }

        public void addAsteroid()
        {
            int x = random.Next(50, width - 200);
            char size = sizeOfAsteroids[random.Next(0, 3)];
            int speed = random.Next(2, 6);
            rocks.Add(new Asteroid(x, -150, size, speed));
        }

        public void addBadGuy()
        {
            if(badGuys.Count < 4)
            {
                // postojat tri vida na neprijatelski brodovi, random se izbira nekoj od niv pri sekoe dodavanje
                int i = random.Next(3);
                string name = namesOfBadGuys[i];
                string weapon = namesOfWeapons[i];
                int power = firePower[i];
                int sp = speed[i];
                int ps = fireSpeed[i];
                int x = random.Next(50, width - 100);
                int h = health[i];

                Bitmap bm = (Bitmap)rm.GetObject(name);

                badGuys.Add(new Hal(x, -100,  h, power, weapon, bm, sp, ps));
            }
        }
    }
}
