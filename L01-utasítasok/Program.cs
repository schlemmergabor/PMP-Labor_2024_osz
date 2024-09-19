namespace L01_utasítasok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. feladat
            Console.WriteLine("Hello World!"); // kiírás
            Console.ReadLine(); // beolvasás

            // Console.WriteLine(); <- kiírás után új sor
            // Console.Write(); <- kiírás után nincs új sor

            ////////////////////////////////////////////////

            // 2. feladat
            
            // letörli a Console-t
            Console.Clear();

            // beállítja a Console magasságát
            Console.WindowHeight = 5;

            // beállítja a Console szélességét
            Console.WindowWidth = 30;

            // beállítja a Console háttérszínét - fehérre
            // enum-ok közül tudunk választani (felsorolás típus)
            Console.BackgroundColor = ConsoleColor.White;

            // beállítja a Console írószínét - feketére
            Console.ForegroundColor = ConsoleColor.Black;

            // A kurzort a 2, 3 poz-ba állítja (left, top)
            Console.SetCursorPosition(2, 3);

            // A kurzor láthatóságát állítja
            // default: true (látható) | false (nem látható)
            Console.CursorVisible = false;

            // visszaállítjuk a Console színeit, előző beállításait
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = true;
            Console.SetWindowSize(80, 25);

            // 3. feladat
            // kiírjuk a "tájékoztató" üzenetet
            Console.Write("Kérem a neved: ");
            // string (szöveg) típusú változót csinálunk nev néven
            // és beolvassuk amit beír a felhasználó
            string nev = Console.ReadLine();
            // kiírjuk a szöveget, figyelj a $ -re !!!
            Console.WriteLine($"Szia kedves {nev}!");

            // 4. feladat
            Console.Write("Születési éved: ");
            int szuletesiEv = int.Parse(Console.ReadLine());
            int kor = 2024 - szuletesiEv;
            // int kor = DateTime.Now.Year - szuletesiEv;
            // ez a fenti kód minden évben jól fog működni, mert
            // DateTime.Now.Year   -> ez a mostani évet jelenti

            Console.WriteLine("A felhasználó kora: {0}", kor);
            Console.WriteLine("A következő évben " + (kor + 1) + " éves leszel.");

            // 5. feladat
            // ennél a feladatnál emlékezz arra, hogy mi történt
            // ha rosszul írta be a felhasználó a tizedespontot
            Console.Write("Testmagasság [m]: ");
            double magassag = double.Parse(Console.ReadLine());

            Console.Write("Testtömeg [kg]: ");
            double tomeg = double.Parse(Console.ReadLine());

            // nézd át, hogyan lehet két int-et elosztani úgy, hogy
            // a tizedesjegyek is megmaradjanak
            double BMI = tomeg / (magassag * magassag);

            Console.WriteLine($"A BMI értéke: {BMI}");

            // 6. feladat
            Console.Write("Az időtartam másodpercben: ");
            int mp = int.Parse(Console.ReadLine());
            int kiP = mp / 60; // egész osztás int/int
            int kiMp = mp % 60; // maradékos osztás
            // .ToString() -> szöveggé alakítja a változó értékét
            // .ToString("00") -> két helyiértékesre alakítva veszi a számot
            Console.WriteLine($"Az időtartam formázva: {kiP}:{kiMp.ToString("00")}");

            // 7. feladat
            Console.Write("Jelszó1: ");
            string jelszoA = Console.ReadLine();
            Console.Write("Jelszó2: ");
            string jelszoB = Console.ReadLine();

            if (jelszoA.Equals(jelszoB)) // jelszoA == jelszoB
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine("Beléphet.");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("Belépés M E G T A G A D V A ! ! !");
            }

            // technikai szünet
            Console.ReadLine();
            Console.ResetColor();
            Console.Clear();

            // 9. feladat
            Console.Write("Add meg az első számot: ");
            int szamA = int.Parse(Console.ReadLine());
            Console.Write("Add meg a második számot: ");
            int szamB = int.Parse(Console.ReadLine());
            Console.Write("Add meg a műveletet: ");
            string muv = Console.ReadLine();

            int eredmeny = 0;

            if (muv == "+") eredmeny = szamA + szamB;
            if (muv == "-") eredmeny = szamA - szamB;
            if (muv == "/") eredmeny = szamA / szamB;
            if (muv == "*") eredmeny = szamA * szamB;

            Console.WriteLine($"{szamA} {muv} {szamB} = {eredmeny}");

            // szürkével jelzett feladatok -> önálló gyakorlásra
            // sárgával jelzett feladatok -> advanced feladatok :)
        }
    }
}
