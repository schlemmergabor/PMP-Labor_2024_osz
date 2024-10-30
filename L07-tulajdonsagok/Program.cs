using System.Runtime.CompilerServices;

namespace L07_tulajdonsagok
{
    internal class Program
    {
        // az első feladathoz tartozó kódot itt találod
        // ez egy metódus, amit megtudunk majd hívni
        // Program class-ban static metódusok vannak
        // amiket példányosítás nélkül tudunk meghívni a Main-ben...
        static void ElsoFeladat()
        {
            // példányosítás
            // paraméter nélküli ctor hívása
            Mole m = new Mole();

            // rögtön elrejtem, mert így
            // véletlenszerű helyre fog kerülni
            m.Hide(0, 10);

            // tipp beolvasása
            Console.SetCursorPosition(0, 15);
            Console.Write("X= ");
            int tippX = int.Parse(Console.ReadLine());
            Console.Write("Y= ");
            int tippY = int.Parse(Console.ReadLine());

            // nem találtuk el -> megy a játék
            while (tippX != m.X && tippY != m.Y)
            {
                // megmutatja, hogy hol volt
                m.TurnUp();

                // újabb tipp bekérése
                Console.SetCursorPosition(0, 15);
                Console.Write("X= ");
                tippX = int.Parse(Console.ReadLine());
                Console.Write("Y= ");
                tippY = int.Parse(Console.ReadLine());
                
                // elrejtőzés
                m.Hide(0, 10);

                // várunk 1 mp-et
                Thread.Sleep(1000);
            }
            // ide akkor kerül a vezérlés, ha már eltaláltuk
            // megmutatjuk, hogy tényleg ott volt!
            m.TurnUp();
            Console.WriteLine("Eltaláltad. G A M E   O V E R");
        }

        // itt találod a második feladat kódját
        static void MasodikFeladat()
        {
            // GroundControl példány
            GroundControl g = new GroundControl();

            // repülők
            Flight f1 = new Flight("LH1337", "London", DateTime.Now);
            Flight f2 = new Flight("W62221", "New York", DateTime.Now, 10);
            Flight f3 = new Flight("FR3586", "Berlin", DateTime.Now, 30);

            // hozzáadjuk a repülőket
            g.AddFlight(f1);
            g.AddFlight(f2);
            g.AddFlight(f3);

            // megjelenítjük az adatokat
            g.DisplayFlightData();
        }
        static void HarmadikFeladat()
        {
            Console.Write("N=? ");
            int N = int.Parse(Console.ReadLine());

            // tömb létrehozása, ekkor még az indexek üresek
            ExamResult[] eredmények = new ExamResult[N];

            // tömb feltöltése -> indexek példányosítása
            for (int i = 0; i < eredmények.Length; i++)
            {
                eredmények[i] = new ExamResult();
            }

            // ponthatár teszteléshez
            int[] ph = { 0, 50, 62, 74, 86 };
            
            // sum psz
            int sum = 0;

            // max psz
            int maxPsz = 0;
            // max psz neptunkodja
            string maxNK = "";
            ;
            // sikeres dolgozatok
            foreach (ExamResult item in eredmények)
            {
                if (item.Passed) Console.WriteLine($"{item.NeptunKod} - {item.Pontszam}");
                sum += item.Pontszam;
                if (item.Pontszam > maxPsz)
                {
                    maxPsz = item.Pontszam;
                    maxNK = item.NeptunKod;
                }
            }
            Console.WriteLine($"\nÁtlagos pontszám: {(double)sum / eredmények.Length}");
            Console.WriteLine($"Max pontszámos neptunkód: {maxNK}");
        }
        static void Main(string[] args)
        {
            // meghívjuk az első feladat metódusát
            // a részletes kódot megtalálod feljebb (9. sortól)
            // ElsoFeladat();

            // Repülős feladat metódusának meghívása
            // a kódrészletet lásd 53. sortól
            MasodikFeladat();

            // ZH eredményes feladat
            // kódrészletet lásd 72. sortól
            HarmadikFeladat();
        }

       
    }
}
