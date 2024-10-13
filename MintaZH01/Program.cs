namespace MintaZH01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. feladat

            // beolvastam a fájlt soronként
            string[] beMufajok = File.ReadAllLines(@"..\..\..\genre.txt");

            // beolvasott értékek feldolgozása

            // üres lista -> ebbe fogjuk tárolni
            List<string> mufajok = new List<string>();

            // feldaraboljuk
            string[] darabok = beMufajok[0].Split(", ");

            // bele is kell tenni -> listába
            for (int i = 0; i < darabok.Length; i++)
            {
                mufajok.Add(darabok[i]);
            }

            // 2. feladat

            // beolvasom a fájl minden sorát
            string[] beAdat = File.ReadAllLines(@"..\..\..\games_dataset.csv");

            // adatfeldolgozás

            // üres listák, amibe majd a játékok adatai kerülnek
            List<string> jatekCime = new List<string>();
            List<string> jatekMufaja = new List<string>();
            List<string> jatekKiadoja = new List<string>();
            List<DateTime> jatekRelDate = new List<DateTime>();
            List<DateTime> jatekOrigDate = new List<DateTime>();

            // 0. index -> első sor -> "fejléc"
            // 1. indextől -> játék adatok
            for (int i = 1; i < beAdat.Length; i++)
            {
                string[] jatekDarab = beAdat[i].Split(";");

                // hozzáadjuk a megfelelő listákhoz
                jatekCime.Add(jatekDarab[0]);

                // -1 a genre 0. indexelése miatt
                int index = int.Parse(jatekDarab[1]) - 1;

                jatekMufaja.Add(mufajok[index]);

                jatekKiadoja.Add(jatekDarab[2]);

                // DateTime.Parse, mint a double.Parse...
                jatekRelDate.Add(DateTime.Parse(jatekDarab[3]));
                jatekOrigDate.Add(DateTime.Parse(jatekDarab[4]));
            }

            // 3. feladat
            Console.Write("Kérem a kiadó nevét: ");
            string kiadoNeve = Console.ReadLine();

            // megszámlálás programozási tétel

            // kezdetben 0. darab ilyen játék van
            int db = 0;

            // végignézem a kiadók listáját
            for (int i = 0; i < jatekKiadoja.Count; i++)
            {
                // ha az aktuális (i) kiadó megegyezik
                // darabszám megnövelése 1-el
                if (jatekKiadoja[i] == kiadoNeve) db++;
            }

            Console.WriteLine($"A kiadóhoz tartozó játékok száma: {db}");

            // 4. feladat

            // végigjárjuk a listákat
            for (int i = 0; i < jatekCime.Count; i++)
            {
                // ha megegyezik a két évszám
                // DateTime-nak van .Year (.Month, .Day, stb) Property-je
                if (jatekOrigDate[i].Year == jatekRelDate[i].Year)
                {
                    Console.WriteLine($"{jatekCime[i]} , {jatekMufaja[i]}, {jatekRelDate[i].Year}");
                }
            }

            // 5. feladat

            // végigjárom a műfajokat tartalmazó listát
            for (int i = 0; i < mufajok.Count; i++)
            {
                // kezdetben 0. db játék van
                int mDb = 0;

                // végig nézzük a játékok műfaj listáját
                for (int j = 0; j < jatekMufaja.Count; j++)
                {
                    // a vizsgált műfaj és az aktuális
                    // játék műfaja megegyezik -> db++
                    if (mufajok[i] == jatekMufaja[j]) mDb++;
                }
                // kiírom az eredményt
                Console.WriteLine($"{mufajok[i]} - {mDb} db");
            }
        }
    }
}
