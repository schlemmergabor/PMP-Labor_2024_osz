using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L06_OOPalapok
{
    internal class Book
    {
        // mezők, tagváltozók, adattagok
        // ha nem írom ki a változó neve elé, akkor mind private láthatóságú
        // azaz csak a Book osztályból érhető el
        // "csak itt tudod elérni, másik .cs fájlban nem!"
        string szerző;
        string cím;
        int kiadásÉve;
        // itt kiírtam a láthatóságot, hogy láss erre is példát
        // private -ot elhagyhattam volna...
        private int oldalSzám;

        // konstruktor 4 paraméterrel
        // ctor
        // a Program.cs-ben majd úgy hozzuk létre, hogy
        // Book könyv1 = new Book(cím, szerző, kiadásÉve, oldalSzám)
        // és ezen sornál fog ez lefutni
        // beállítjuk a kezdőértékeket, létrehozzuk az objektumot!
        public Book(string cím, string szerző, int kiadásÉve, int oldalSzám)
        {
            // this. jelentése: adott példány, objektum...
            this.szerző = szerző;
            this.cím = cím;
            this.kiadásÉve = kiadásÉve;
            this.oldalSzám = oldalSzám;
        }

        // metódus
        // Ennek most public láthatósága, azaz másik osztályból
        // másik .cs fájlból is megtudjuk majd hívni
        // string visszatérési érték
        // AllData néven
        // () paraméterekkel -> nincs paramétere
        public string AllData()
        {
            // visszatérési érték beállítása
            return $"{this.szerző}: {this.cím}, {this.kiadásÉve} ({this.oldalSzám} pages)";
        }

        // az AllData() metódust csak akkor tudjuk meghívni, ha létezik
        // a Book osztálybéli példány - azaz van Book objuktum
        // először tehát példányosítunk, létrehozunk -> ... = new Book(...)
        // majd erre a példányra tudjuk meghívni a metódust

        // példakód:
        // alább létrehozzuk a b nevű objektumot (meghívódik a konstruktor)
        // Book könyv = new Book("The Hobbit - or There and Back Again", "J.R.R. Tolkien", 1937, 312);
        // a könyv-nek elérhető már az AllData() metódusa.
        // Console.WriteLine(könyv.AllData());

    }
}
