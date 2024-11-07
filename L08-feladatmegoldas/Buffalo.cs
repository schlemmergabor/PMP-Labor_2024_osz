using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L08_feladatmegoldas
{
    internal class Buffalo
    {
        // mezők
        int x;
        int y;
        bool aktiv;


        // Property-k
        public int X { get => x; }
        public int Y { get => y; }


        // extra Property 
        // él-e még
        public bool Aktiv { get => aktiv; }


        // construktor
        // 0,0-ból indul, aktív
        public Buffalo()
        {
            this.x = 0;
            this.y = 0;
            this.aktiv = true;
        }

        // Mozog
        public void Move(Field f)
        {
            // ha még él a Buffalo
            if (this.aktiv)
            {
                // hova léphet ->  a három irány
                bool[] hova = new bool[3];

                // melyik irányba mehet -> true mehet, false -> nem mehet
                hova[0] = f.AllowedPosition(X + 1, Y);
                hova[1] = f.AllowedPosition(X, Y + 1);
                hova[2] = f.AllowedPosition(X + 1, Y + 1);


                // véletlenszám addig, amíg egy olyan irányt választunk
                // ami true, azaz ahova lehet lépni
                Random rnd = new Random();
                int szam;
                do
                {
                    szam = rnd.Next(0, 3);
                }
                while (!hova[szam]);

                // lépés megvalósítása -> új, x, y értékek
                if (szam == 0) x++;
                if (szam == 1) y++;
                if (szam == 2) { x++; y++; }
            }

        }

        // eltalálták a bölényt -> meghal
        public void Deactivate()
        {
            this.aktiv = false;
        }

        // bölény megjelenítése
        public void Show()
        {
            // x, y helyre ugrik a kurzor
            Console.SetCursorPosition(x, y);

            // ha aktív beállítunk egy zöld színt
            if (this.aktiv)
                Console.ForegroundColor = ConsoleColor.Green;
            
            // ha nem akkor piros szín-t
            else Console.ForegroundColor = ConsoleColor.Red;

            // bölény kiírása
            Console.WriteLine("B");

            // visszaállítom a fehér console színt
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
