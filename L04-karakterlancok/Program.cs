namespace L04_karakterlancok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. feladat
            Console.Write("Kérem a szöveget: ");

            // beolvassuk a szöveget
            string beSzoveg = Console.ReadLine();

            // segédváltozók, számláláshoz
            int numBetuk = 0;
            int numSzamok = 0;
            int numMgh = 0;

            string mghk = "aeuioáéíöőúűóü";

            // karakterenként végigmegyünk a beolvasott szövegen
            foreach (char karakter in beSzoveg)
            {
                // a karakter betű?
                if (char.IsLetter(karakter)) numBetuk++;

                // a karakter szám?
                if (char.IsDigit(karakter)) numSzamok++;

                // karakter Mgh?
                if (mghk.Contains(karakter)) numMgh++;
            }

            Console.WriteLine($"Betűk száma: {numBetuk}, számok száma: {numSzamok}, mghk száma: {numMgh}");


            // 2. feladat
            string szoveg = "Géza kék az ég.";

            // kisbetűssé alakítás
            string kisbetus = szoveg.ToLower();

            // Eltávolítjuk a szóközt, pontot, vesszőt
            string szokozNelkul = kisbetus.Replace(" ", "");
            szokozNelkul = szokozNelkul.Replace(".", "");
            szokozNelkul = szokozNelkul.Replace(",", "");

            // előállítjuk visszafelé a szöveget
            string visszaFele = "";

            // hátulról járjuk be a szöveg karakteit
            for (int i = szokozNelkul.Length-1; i >=0 ; i--)
            {
                // hozzáfűzzük az eddigi szöveghez a karaktert
                visszaFele += szokozNelkul[i];
            }

            if (visszaFele == szokozNelkul) Console.WriteLine("Palindrom");
            else Console.WriteLine("Nem palindrom");

            // 3. feladat
            Console.Write("Adja meg a rendszámot: ");
            string be = Console.ReadLine();

            // kitöröljük (lecseréljük) a space a - jeleket
            // és nagybetűssé is alakítjuk egyben
            be = be.Replace(" ", "").Replace("-", "").ToUpper();

            // összeállítjuk a kimeneti stringet
            // .ToString() - nélkül nem betűket kapsz és nem tudnád összefűzni
            string ki = be[0].ToString() + be[1].ToString() + " " + be[2].ToString() + be[3].ToString() + "-" + be[4].ToString() + be[5].ToString() + be[6].ToString();


            Console.WriteLine($"A rendszám sztenderd formátuma: {ki}");


            // 6. feladat
            // Véletlenszám generáló objektum
            Random rnd = new Random();

            // kezdő NK üres
            string neptunKod = "";

            // NK-amit keresünk
            string NK = "AA12BB";

            // számláló
            int db = 0;

            // addig generálunk, amíg nem a keresett NK-k kapjuk
            // db < 10 feltétel nem kell csak azért hagytam benne, hogy
            // ne álljon ebben a loopban a program órákig...
            while (NK != neptunKod && db < 10) // 
            {
                
                // első karakter betű, ami az ASCII kódtáblában 65-90 között van
                int rNum = rnd.Next((int)'A', (int)'Z');

                // kódot -> char-á alakítok
                char betu = (char)rNum;

                // első karakter a betu (char) string-e legyen
                // ha már második neptun-t generálom, akkor felülírom az első betűvel
                neptunKod = betu.ToString();

                // maradék 5 karakterre a következőt csinálom
                for (int i = 1; i < 6; i++)
                {
                    // betű vagy szám legyen?
                    int betuE = rnd.Next(0, 2);

                    // szám lesz
                    if (betuE == 0)
                    {
                        // ASCII kódtábla 0-9 közötti kódjából generálok
                        rNum = rnd.Next(48, 58); // 0-9
                    }
                    else
                    {
                        // ASCII kódtábla betűt tartalmazó részéből generálok
                        rNum = rnd.Next(65, 91);  // A - Z (lásd 95. kódsor)
                    }

                    // int -> char
                    char betu2 = (char)rNum;

                    // NK-hoz hozzáfűzés
                    neptunKod += betu2;

                }
                
                // neptunkód kiírása
                Console.WriteLine(neptunKod);

                db++;
            }

            // 8. feladat
            
            // forrás szöveged
            string s = "Vincent;Vega;Vince\nMarsellus;Wallace;Big Man\nWinston;Wolf;The Wolf";

            // \n-ek mentén felvájuk
            string[] sorok = s.Split('\n');

            // hány sorunk lesz?
            int sorSz = sorok.Length;

            // hány oszlopunk lesz
            // első sort vágjuk fel ;-k mentén és annak a hossza kell
            int oszlopSz = sorok[0].Split(";").Length;

            // eredmény kétdimenziós tömb
            string[,] result = new string[sorSz, oszlopSz];

            // eredmény melyik sorába írunk
            int j = 0;

            // soronként megyünk
            // lehet jobb lett volna egy for ciklus (segédváltozó miatt)
            foreach (string sor in sorok)
            {
                // sort felosztjuk cellákra ; -n mentén
                string[] cells = sor.Split(";");

                // felosztott cellákon végigmegyünk
                for (int i = 0; i < cells.Length; i++)
                {
                    // eredmény tömbbe beírjuk
                    result[j, i] = cells[i];
                }
                // következő sorra lépés az eredményben
                j++;
            }

            ;
        }
    }
}
