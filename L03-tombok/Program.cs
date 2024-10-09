namespace L03_tombok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. feladat
            // lapok színei egy tömbben
            string[] szinek = { "Kör", "Káró", "Treff", "Pik" };

            // lapok magasságai egy tömbben
            // itt a számok (pl.: 2, 3) szövegként vannak (string tömb)
            // ezért kell az " " közéjük

            string[] magasságok = { "2", "3", "4", "5",
                "6", "7", "8", "9", "10",
                "Jumbó", "Dáma", "Király", "Ász"};

            // üres tömböt hozunk létre
            // meg kell mondani, hogy 52 eleme lesz
            // de, hogy azok mik??? még nem tudjuk...
            string[] kartyak = new string[52];

            // éppen melyik lapot generáljuk
            // azért 0, mert a tömböket 0-tól indexeljük
            // a kartyak[0] lesz az első lap
            int lapszam = 0;


            // végig megyünk a színeken
            for (int i = 0; i < szinek.Length; i++)
            {
                // és a magasságokon is
                for (int j = 0; j < magasságok.Length; j++)
                {
                    // beállítjuk megfelelő lapot (szövegét)
                    // és meg is növeljük a lapszam értékét
                    kartyak[lapszam++] = szinek[i] + " " + magasságok[j];
                }
            }

            // Ellenőrzés
            // végig megyünk a kártyákon
            foreach (string item in kartyak)
            {
                // kiírjuk az egyes elemeket + tab
                Console.Write(item + "\t");
            }

            // 2. feladat
            // Fisher-Yates keverés
            // az algoritmust lásd a feladat.pdf-ben
            // megnéztük órán közösen, ugyanis az algoritmusokat vizsgára kell tudni

            // 0-tól indexeljük a tömböket, az algoritmus 1-től indexel
            // így az i most 0
            // (n-1)-ig kell menni, ahol n: a tömb mérete
            // de le kell vonni belőle 1-et, mert 0-tól indexelünk
            for (int i = 0; i < kartyak.Length - 1; i++)
            {
                Random rndx = new Random();
                // j-be véletlenszám
                int j = rndx.Next(i, kartyak.Length);

                // csere
                string temp = kartyak[j];
                kartyak[j] = kartyak[i];
                kartyak[i] = temp;
                // egyszerűbb csere:
                // (kartyak[i], kartyak[j]) = (kartyak[j], kartyak[i]);

            }

            // Ellenőrzés
            Console.Clear();
            foreach (string item in kartyak)
            {
                Console.Write(item + "\t");
            }

            // 3. feladat
            Console.Clear();
            // beolvassuk, hogy hány szót szeretnénk majd eltárolni
            Console.Write("Kérek egy számot: ");
            int N = int.Parse(Console.ReadLine());

            // létrehozzuk a szavak tömböt -> kell hozzá a mérete
            string[] szavak = new string[N];

            // beolvassuk a szavakat
            for (int i = 0; i < szavak.Length; i++)
            {
                Console.Write($"Kérem az {i + 1}. szót: ");
                szavak[i] = Console.ReadLine();
            }

            Console.Write("Kérek egy szót: ");
            string be = Console.ReadLine();


            // hanyadik indexen van
            // -1 mindig azt jelenti a tömbben, hogy nincs benne
            // így feltételezem, hogy kezdetben nincs benne a szó
            int holVan = -1;

            // index, amivel a szavak[] -on fogok lépkedni
            int ind = 0;

            // amíg a holVan azt mutatja, hogy nincs benne és
            // az index még nem ért a végére
            while (holVan == -1 && ind < szavak.Length)
            {
                // ha az index-edik szó a keresett szó, akkor
                // beállítom az index értékét
                if (szavak[ind] == be) holVan = ind;
                ind++;
            }

            // benne van a szó
            if (ind > -1) Console.WriteLine($"Benne van a szótárban a szó!\nMéghozzá az {ind}. helyen!");
            else Console.WriteLine("Nincs benne a szó!");

            // 4. feladat

            // létrehozok egy listát
            // string típusú elemeket fog tárolni
            // de nem kell megadni, hogy mennyit fog tárolni
            List<string> szoLista = new List<string>();

            // a do-while feltételéhez kell
            // kezdetbeli string "" értékkel
            string beSzo = "";

            do
            {
                Console.Write("Kérek egy szót: ");
                beSzo = Console.ReadLine();

                // ha nem STOP-ot írt be -> hozzáadom
                if (beSzo != "STOP") szoLista.Add(beSzo);
            }
            // addig ismétlen a fentit, amíg nem a STOP-ot írta be
            while (beSzo != "STOP");

            Console.Write("A keresett szó: ");
            string bekertSzo = Console.ReadLine();

            // melyik indexen van a szó a listában
            int szoIndex = szoLista.IndexOf(bekertSzo);

            // -1 jelzi itt is, ha nincs benne
            if (szoIndex > -1)
                Console.WriteLine($"A szó benne van a listában az {szoIndex} indexen.");
            else
                Console.WriteLine("A szó nincs benne a listában.");

            // 5. feladat

            // listák az adatok tárolásához
            List<string> nevek = new List<string>();
            List<int> eletkorok = new List<int>();
            List<bool> tapasztalat = new List<bool>();

            // do-while feltételéhez a változó
            string beNev;

            do
            {
                Console.Write("Kérek egy nevet: ");
                beNev = Console.ReadLine();
                // ha nem üreset adott meg -> el kell tárolni
                if (beNev != "")
                {
                    nevek.Add(beNev);
                    Console.Write("Kérek egy kort: ");
                    int beKor = int.Parse(Console.ReadLine());
                    eletkorok.Add(beKor);
                    Console.Write("Van tapasztalata (T/F): ");
                    string beTapasztalat = Console.ReadLine();

                    // lehetne bool.Parse("...")-al is!
                    if (beTapasztalat == "T" || beTapasztalat == "t") tapasztalat.Add(true);
                    else tapasztalat.Add(false);
                }
            }
            // addig amíg a név nem üres
            while (beNev != "");

            // átlagéletkor = össz / darabszám

            // összéletkor kezdetben 0
            int osszEletkor = 0;

            // végigmegyünk az életkor listán
            foreach (int item in eletkorok)
            {
                // az aktuális életkort hozzáadjuk az eddigi összhöz
                osszEletkor += item;
            }
            // átlagéletkor segédváltozó
            int atlagEletkor = 0;

            // ha nem üres az életkorok listánk
            // azaz adtunk meg legalább egy embert, akkor lehet számolni
            if (eletkorok.Count() > 0) atlagEletkor = osszEletkor / eletkorok.Count();

            Console.WriteLine($"Az átlagéletkor: {atlagEletkor}");

            // segédváltozók a prog. tapasztalat nélküliekhez
            int osszEletkorProgNelkul = 0;
            int dbProgNelkul = 0;

            // for ciklussal megyünk végig a listákon
            // az i indexek kötik össze az egyes embereket
            // foreach-el itt nem tudod megcsinálni
            for (int i = 0; i < nevek.Count; i++)
            {
                // ha a tapasztalat false
                if (!tapasztalat[i])
                {
                    // életkorhoz hozzáad, db-ot növel
                    osszEletkorProgNelkul += eletkorok[i];
                    dbProgNelkul++;
                }
            }

            // átlagéletkor segédváltozó
            int atlagEletKorProgNelkul = 0;
            // ha volt legalább egy ilyen személy -> számol
            if (dbProgNelkul > 0) atlagEletKorProgNelkul = osszEletkorProgNelkul / dbProgNelkul;

            Console.WriteLine($"A Prog Tapasztalat nélküli átlagéletkor: {atlagEletKorProgNelkul}");

            // legidősebb prog tapasztalatú személy

            // ha van egyáltalán személy (akit lehet majd vizsgálni)
            if (eletkorok.Count() > 0)
            {
                // kezdetben a legidősebb legyen a 0. indexű
                int legidosebbIndex = 0;

                // 0. indexet nem kell nézni, mert azt mondtuk előbb, hogy ő a legidősebb
                for (int i = 1; i < nevek.Count; i++)
                {
                    // ha van tapasztalata
                    if (tapasztalat[i])
                    {
                        // idősebb, mint az eddigi legidősebb,
                        // akkor mentsük el az indexét
                        if (eletkorok[i] > eletkorok[legidosebbIndex]) legidosebbIndex = i;
                    }
                }

                Console.WriteLine($"A legidősebb {nevek[legidosebbIndex]}, kora: {eletkorok[legidosebbIndex]}.");
            }

            // 6. feladat
            // N és M értéke
            int NN = 3;
            int M = 4;
            // tömb létrehozása -> 0 minden értéke
            int[,] tömb = new int[NN, M];

            Random rnd = new Random();
            // tömb feltöltése véletlen számokkal
            // GetLength(0) -> 0. dimenzió hossza
            for (int i = 0; i < tömb.GetLength(0); i++)
            {
                for (int j = 0; j < tömb.GetLength(1); j++)
                {
                    tömb[i, j] = rnd.Next(0, 10);
                }
            }

            // megjelenítés
            for (int i = 0; i < tömb.GetLength(0); i++)
            {
                for (int j = 0; j < tömb.GetLength(1); j++)
                {
                    Console.Write($"{tömb[i, j]} ");
                }
                Console.WriteLine();
            }

            // transzponált mátrix előállítása

            int[,] mtx = new int[M, NN];
            for (int i = 0; i < tömb.GetLength(0); i++)
            {
                for (int j = 0; j < tömb.GetLength(1); j++)
                {
                    // az oszlop, sor -t felcseréljük sor, oszlop-ra
                    mtx[j, i] = tömb[i, j];
                }
            }

            // transzponált mátrix megjelenítése
            for (int i = 0; i < mtx.GetLength(0); i++)
            {
                for (int j = 0; j < mtx.GetLength(1); j++)
                {
                    Console.Write($"{mtx[i, j]} ");
                }
                Console.WriteLine();
            }

            // 8. feladat
            Console.Write("N=? ");
            int szamN = int.Parse(Console.ReadLine());
            // lista
            List<int> szamok = new List<int>();
            // hozzáadjuk a beolvasott számot
            szamok.Add(szamN);

            // utolsó szám
            int K = szamok.Last();

            do
            {
                // ha páros -> felét hozzáadjuk
                if (K % 2 == 0) szamok.Add(K / 2);

                // ptlannál ezt adjuk hozzá
                else szamok.Add(3 * K + 1);

                // utolsó elem frissítése
                K = szamok.Last();

            } while (K != 1);

            // 9. feladat
            // a jó megoldás
            int[] x = { 1, 2, 3, 4, 5, 6, 7, 8 };

            // a tömb feléig kell menni
            for (int i = 0; i < x.Length / 2; i++)
            {
                int tmp = x[i];
                x[i] = x[x.Length - i - 1];
                // itt is kell - 1
                x[x.Length - i - 1] = tmp;
            }
            ;
        }
    }
}
