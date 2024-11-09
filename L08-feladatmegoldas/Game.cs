using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L08_feladatmegoldas
{
    internal class Game
    {
        // mezők
        Field f;
        
        // bölényeket tároló tömb
        Buffalo[] bfs;

        // ctor
        public Game(int jatekterMerete, int bolenyekSzama)
        {
            // Field létrehozása -> játéktér
            f = new Field(jatekterMerete);

            // bölények tömbjének létrehozása
            bfs = new Buffalo[bolenyekSzama];
            
            // egyes bölények létrehozása a tömbbe -> ctor
            for (int i = 0; i < bfs.Length; i++)
            {
                bfs[i] = new Buffalo();
            }
        }

        // Property - véget ért-e már a játék?
        public bool IsOver
        {
            get
            {
                // ha egy bölény célbe ért
                foreach (Buffalo item in bfs)
                {
                    // ha megtaláltuk az első célba ért bölényt
                    // akkor máris return true -> nem kell a többit végig nézni
                    // ekkor a foreach ciklusból azonnal "visszalép"
                    if (item.X == f.TargetX && item.Y == f.TargetY) return true;
                }

                // vége a játéknak a másik esetben is, azaz,
                // ha a bölények mind meghaltak

                // kezdetben azt mondjuk nincs élő bölény
                bool vanElo = false;

                // végig nézzük az összes bölényt
                foreach (Buffalo item in bfs)
                {
                    // ha találtunk élőt -> akkor van legalább egy élő
                    if (item.Aktiv) vanElo = true;
                }

                // vanélő negálása
                // ha volt élő, akkor vanElo = true, tehát false-t ad vissza
                // ha nem volt élő, akkor vanElo = false, tehát true-t ad vissza
                return !vanElo;
            }
        }

        // játék megjelenítése
        public void VisualizeElements()
        {
            // képernyő törlése
            Console.Clear();

            // játéktér megjelenítése
            f.Show();

            // bölények tömbjének bejárása
            foreach (Buffalo item in bfs)
            {
                // megjelenítés
                item.Show();

                // mozgatás
                item.Move(f);
            }
        }

        // lövés
        private void Shoot()
        {
            // alul jelenjen meg a lövés "panel"
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("---------------------------");
            Console.Write("X=? ");
            int X = int.Parse(Console.ReadLine());

            Console.Write("Y=? ");
            int Y = int.Parse(Console.ReadLine());


            // lövés...
            foreach (Buffalo item in bfs)
            {
                // ha az X,Y-on van az item (bölény)
                if (item.X == X && item.Y == Y)
                {
                    // deaktiválás -> eltaláltam
                    item.Deactivate();
                }
            }

        }
        public void Run()
        {
            // amíg nincs vége a játéknak
            while (!this.IsOver)
            {
                // kirajzol
                VisualizeElements();
                // lövés
                Shoot();
            }

            // eldöntjük, hogy ki nyert

            // van-e élő bölény még?
            bool vanElo = false;
            foreach (Buffalo item in bfs)
            {
                // ha találtunk élőt -> akkor van élő
                if (item.Aktiv) vanElo = true;
            }

            // ha van még élő -> akkor az célba ért
            if (vanElo) Console.WriteLine("A bölények nyertek!");
            else Console.WriteLine("A játékos nyert!");
           

        }
    }
}
