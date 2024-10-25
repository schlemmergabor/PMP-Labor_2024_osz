using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L06_OOPalapok
{
    internal class Runner
    {
        // belső értékek, tagváltozók, mezők
        // nem írunk láthatóságot default -> private
        string nev;
        int sorSzam;
        int sebesseg; // m/s
        int tav; // m

        // ctor -> 3 paraméterrel
        public Runner(string név, int sorSzám, int sebesség)
        {
            this.nev = név;
            this.sorSzam = sorSzám;
            this.sebesseg = sebesség;
            this.tav = 0; // kezdőérték állítása itt
            // vagy a 16. sorban is lehetett volna, ha
            // int tav=0; -t írsz
        }

        // Metódusok
        // távolság frissítése
        // public, mert kívülről kell majd tudni meghívni
        // void, mert a hívás-nak nincs visszatérési értéke
        // nincs számítás eredmény, amit visszakapunk
        // int mp, mert egy int típusú paramétert kaphat,
        // értéke a kódban mp néven lesz felhasználva
        public void RefreshDistance(int mp)
        {
            // eltelt mp * sebesség-el növeljük meg a távolságot
            this.tav += mp * this.sebesseg;
        }

        // kirajzolás
        // public, mert kívülről (másik osztályból / másik .cs-ből)
        // fogjuk majd meghívni
        // void, mert nincs érték, amit visszaad (nincs mit kiszámolni...)
        // () -> paraméter nélküli, mert a kirajzolás nem függ attól,
        // hogy (1), (2), stb-vel hívod majd meg
        // hanem csak a belső értékétől (mezők!!!) függ!
        public void Show()
        {
            // belső mezőket (this) felhasználva pozit beállítjuk
            Console.SetCursorPosition(this.tav, this.sorSzam);
            // név első betűje ki
            Console.Write(this.nev[0]);

        }

        // táv lekérése Metódus
        // azért van szükség erre, mert a this.tav private láthatóságú
        // azaz nem tudjuk az értékét lekérdezni
        // de ez a metódus ezt megoldja, mert visszaadja az értéket
        // public, mert másik osztályból szeretnénk hívni
        // int, mert int típusú értéket ad vissza (return kell !!!)
        // (), mert nem lesz paramétere
        // return után kerül, hogy mit adjon vissza

        public int GetDistance()
        {
            return this.tav;
        }
    }
}
