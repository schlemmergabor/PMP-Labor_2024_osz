namespace L06_OOPalapok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // a feladatok megoldásához szükséges osztályok
            // külön .cs fájlokban találhatóak
            // 1. feladathoz a Book osztály a Book.cs-ben
            // és így tovább...

            // 1. feladat
            // az osztály-t lásd a Book.cs -ben
            // létrehozom a példányt b -néven -> lefut a konstruktor
            Book b = new Book("The Hobbit - or There and Back Again", "J.R.R. Tolkien", 1937, 312);
            // b objektumnak meghívható már az AllData() metódusa. Az szöveget ad vissza
            // az meg megy a cw paraméterébe. Ugye milyen egyszerű? :))
            Console.WriteLine(b.AllData());

            // 3. feladat
            // lásd Runner osztály Runner.cs
            // két runner osztálybeli példány
            Runner r1 = new Runner("Alma", 2, 4);
            Runner r2 = new Runner("Körte", 5, 3);

            // cél poziciója
            int cel = 30;

            // kezdeti start kirajzolása
            r1.Show();
            r2.Show();

            // 3 mp várás, 3, 2, 1, rajt!
            System.Threading.Thread.Sleep(3000);

            // amíg mindkettő a cél előtt van...
            while (r2.GetDistance() < cel && r1.GetDistance() < cel)
            {
                // Console törlés
                Console.Clear();
                // távolság frissítés 1 mp-vel
                r1.RefreshDistance(1);
                r2.RefreshDistance(1);
                // kirajzolás
                r1.Show();
                r2.Show();
                // 1 mp várás
                System.Threading.Thread.Sleep(1000);
            }

            // 4. feladat
            // Caesar-rejtjelezés lásd EA 4. diasor
            // lásd Caesar osztály, Caesar.cs fájl

            // példány létrehozása
            Caesar kodolo = new Caesar(3);
            string eredeti = "Hello World! Hello ÓE!";

            // eredeti-t kódoljuk
            string kodolt = kodolo.Encode(eredeti);

            // kódolt-at dekódoljuk
            string deKodolt = kodolo.Decode(kodolt);

            // ellenőrzés
            Console.WriteLine($"Eredeti szöveg: {eredeti}");
            Console.WriteLine($"Rejtjelezett szöveg: {kodolt}");
            Console.WriteLine($"Visszafejtett szöveg: {deKodolt}");

        }
    }
}
