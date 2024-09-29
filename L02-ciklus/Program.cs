namespace L02_ciklus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. feladat
            Console.Write("Kérem N értékét: ");
            int N = int.Parse(Console.ReadLine());

            // elöltesztelős ciklussal
            int i = 0;
            while (i <= N)
            {
                // kiírjuk i értékét és utána megnöveljük 1-el
                Console.WriteLine(i++);
            }

            // hátultesztelős ciklussal
            int j = 0;
            do
            {
                Console.WriteLine(j++);
            } while (j <= N);

            // számlálós (for) ciklussal
            for (int k = 0; k <= N; k++)
            {
                Console.WriteLine(k);
            }

            // Páros számok módosítása
            // pl úgy, hogy csak akkor írjuk ki,
            // ha tényleg páros szám
            // if (i % 2 == 0) Console.WriteLine(i);
            // a fenti sor megnézi, hogy i-t osztva 2-vel 0-e a maradék
            // igen akkor a szám páros és kiírjuk az i-t.

            // másik ötlet -> léptesd 2-vel a ciklusváltozót...

            // 2. feladat
            string taroltJelszo = "Guest";
            string beJelszo = ""; // kezdetben üres -> a ciklus feltétel miatt kell
            int probak = 0; // próbálkozások száma

            // amíg nem egyezik a két jelszó és még nem próbálkoztunk 3x
            while (beJelszo != taroltJelszo && probak < 3)
            {
                Console.Write("Kérem a jelszót: ");
                beJelszo = Console.ReadLine();
                // próbálkozások számát megnövelem
                probak++;
            }
            // if kell, hogy tudjuk miért ért véget a ciklus
            // ha jelszavak okék -> Go
            if (beJelszo == taroltJelszo) Console.WriteLine("Köszi. Beléphetsz!");
            else Console.WriteLine("3x hibás jelszót adtál meg, belépés megtagadva!");

            // 4. feladat
            Console.Write("Kérem a játékosok számát (N-t): ");
            // játékosok száma
            int jSz = int.Parse(Console.ReadLine());

            // aktuális (dobó) játékos
            int akt = 0;

            // random objektum a véletlenszámok generálásához
            // jegyzetben az rnd a generator...
            Random rnd = new Random();

            // mit dobott az aktuális játékos
            // direkt nem lehetséges értéket állítok
            // (ugye hat oldalú kockán 1-6-ig vannak a "pöttyök"
            int dobas = 0;

            // amíg nem dobtunk hatost
            while (dobas != 6)
            {
                // enter-re várunk
                Console.ReadLine();
                // következő játékos fog dobni
                akt++;

                //  ha nincs következő játékos akkor az 1 fog ismét dobni
                if (akt > jSz) akt = 1;

                // véletlenszám -> kocka dobás
                dobas = rnd.Next(1, 7);
                Console.WriteLine($"{akt} játékos dobása: {dobas}");
            }
            Console.WriteLine($"\nA {akt}. számú játékos dobott hatost Ő kezd!");


            // 6. feladat
            Console.Write("Kérem az N számot: ");
            int szam = int.Parse(Console.ReadLine());

            if (szam % 2 == 0) Console.WriteLine("A szám páros");
            else Console.WriteLine("A szám páratlan.");

            int osztokSzama = 0;
            for (int m = 2; m < szam; m++)
            {
                // ha osztja a szám, akkor van egy újabb osztónk!
                if (szam % m == 0) osztokSzama++;
            }
            if (osztokSzama == 0) Console.WriteLine("A szám prím szám.");
            else Console.WriteLine("A szám összetett szám.");

            // 7. feladat
            Console.Write("Kérek egy számot! N = ");
            int nSzam = int.Parse(Console.ReadLine());

            // faktoriális értékét ebbe fogom számítani
            // 1 az értéke, mert szorozni fogok
            int faktor = 1;

            Console.Write($"{nSzam}! = ");
            for (int cv = nSzam; cv > 0; cv--)
            {
                Console.Write($"{cv}");
                faktor *= cv;
                if (cv != 1) Console.Write("x");
                else Console.WriteLine($" = {faktor}");
            }

            // 9. feladat
            Console.Write("Kérem a másodperceket! ");
            int beMp = int.Parse(Console.ReadLine());

            // amíg nem 00 a másodperc
            while (beMp > -1)
            {
                // átváltás perc mpre
                int perc = beMp / 60;
                int mperc = beMp % 60;
                Console.WriteLine($"{perc}:{mperc.ToString("00")}");
                // hátralevő idő csökkentése 1-el
                beMp--;
                // várjunk 1000 msec-et -> 1 mp-et
                System.Threading.Thread.Sleep(1000);
            }
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.Beep();

            // 11. feladat
            Console.ResetColor();
            Console.Clear();
            // kezdőkredit
            int kredit = 100;

            // tét értéke
            int tet = 1;
            // ebbe tároljuk majd el a lenyomott gombot
            ConsoleKey gomb;
            // ciklust csinálunk
            do
            {
                // tájékoztató kiírása
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Kredit: {kredit}          ");
                Console.WriteLine($"Tét: {tet}");

                // gombnyomásra várunk
                gomb = Console.ReadKey().Key;

                // felfelé nyilat nyomtunk
                if (gomb == ConsoleKey.UpArrow)
                {
                    tet++;
                }
                // lefelé nyilat nyomtunk
                if (gomb == ConsoleKey.DownArrow)
                {
                    tet--;
                }


                // space gombot nyomtunk és van elég kredit -> játék
                if (gomb == ConsoleKey.Spacebar && kredit>=tet)
                {
                    // tétet levonjuk
                    kredit -= tet;
                    Random rnd = new Random();
                    // három véletlenszám
                    int A = rnd.Next(0, 10);
                    int B = rnd.Next(0, 10);
                    int C = rnd.Next(0, 10);

                    Console.WriteLine();
                    Console.WriteLine($"{A}\t{B}\t{C}");
                    // három egyforma
                    if (A == B && B == C) kredit += 50 * tet;
                    // ha nem egyf, de két egyforma van
                    else if (A == B || B == C || C == A) kredit += 10 * tet;
                }
                
            }
            // addig csináljuk amíg kredit van és nem ESC-t nyomtunk
            while (kredit > 0 && gomb != ConsoleKey.Escape);
        }
    }
}