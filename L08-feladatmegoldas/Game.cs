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
            // Field létrehozása
            f = new Field(jatekterMerete);

            // bölények tömbjének létrehozása
            bfs = new Buffalo[bolenyekSzama];
            
            // egyes bölények létrehozása a tömbbe -> ctor
            for (int i = 0; i < bfs.Length; i++)
            {
                bfs[i] = new Buffalo();
            }
        }

        // Property - véget ért a játék
        public bool IsOver
        {
            get
            {
                // a bölény célbe ért
                foreach (Buffalo item in bfs)
                {
                    if (item.X == f.TargetX && item.Y == f.TargetY) return true;
                }


                // a bölények mind meghaltak
                bool vanElo = false;
                foreach (Buffalo item in bfs)
                {
                    if (item.Aktiv) vanElo = true;
                }

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

            // bölények megjelenítése
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
                // ha az X,Y-on van az item
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
            while (!IsOver)
            {
                // kirajzol
                VisualizeElements();
                // lövés
                Shoot();
            }

            // végéhez még egyszer kirajzolom
            VisualizeElements();
        }
    }
}
