using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH02
{
    // 3. feladat
    internal class Dataset
    {
        // tároljuk mondjuk listában
        List<User> users = new List<User>();

        // ctor
        public Dataset(string fileName)
        {
            // beolvassuk a fájl minden sorát
            string[] sorok = File.ReadAllLines(fileName);

            // 0. sort kihagyjuk (fejléc miatt)
            for (int i = 1; i < sorok.Length; i++)
            {
                // új User példány az aktuális sor-ból
                User uj = new User(sorok[i]);

                // hozzáadjuk a listához
                users.Add(uj);
            }
        }

        // Tulajdonság
        public int FelhasznalokSzama { get => this.users.Count; }

        // Metódusok()

        public double AverageMonthlyRevenue(SubscriptionType type)
        {
            // darabszámuk 0
            int dB = 0;

            // kezdőösszeg 0
            int sum = 0;

            // végig megyünk az összes felhasználón
            for (int i = 0; i < users.Count; i++)
            {
                // ha egyezik az előfizetés típusa
                if (users[i].ElofizetesTipusa == type)
                {
                    // darabot növelünk
                    dB++;
                    // összeghez adjuk a díjat
                    sum += users[i].ElofizetesDija;
                }
            }

            
            return (double)sum / dB;
        }

        // legalább a megadott számú nap telt el az utolsó díjfizetése óta
        public User[] CollectNonPayers(int nap)
        {
            // legyűjtöm listába
            List<User> ujLista = new List<User>();

            // az eddigi lista minden elemén végigmegyek
            foreach (User item in users)
            {
                // ha az item-nek legutolsó fizetése
                if (item.DaysSinceLastPayment() >= nap)
                    // hozzáadom az új listához
                    ujLista.Add(item);
            }

            // listából tömböt csinálok és azt adom vissza
            return ujLista.ToArray();
        }

        // a legidősebb felhasználó adataival (karakterlánc) tér vissza
        public string MaximalAgeData()
        {
            // maximumkiválasztás programozás tétel

            // kezdetben a 0. a legnagyobb
            int maxIndex = 0;

            // 1-től végignézzük a lista elemeit
            for (int i = 1; i < users.Count; i++)
            {
                // ha az i. életkor nagyobb, mint az eddigi
                if (users[i].EletKor > users[maxIndex].EletKor) maxIndex = i;
            }

            // visszatérünk a maxIndex-edik textjével
            return users[maxIndex].DataAsText();
        }
        public string DistributionOfDeviceType(DeviceType eszkozTipus)
        {
            // összes ilyen eszköz megszámlálása
            // kezdetben 0 ilyen eszköz van
            int sum = 0;

            // országok enum maximum értéke
            int orszagokSzama = Enum.GetValues(typeof(CountryName)).Length;

            // országoknak készítek egy tömböt
            // ebbe fogom számolni, hogy az adott eszközből hány darab van
            // tehát a tömb kezdő értéke végig 0 legyen
            // mivel az országok enumja-t 1-től indexeltük, ezért a 0-t kihagyom,
            // így ezért kell a 89. sorban a +1
            int[] eszkozOrszagonkent = new int[orszagokSzama + 1];

            // lista bejárása
            for (int i = 0; i < users.Count; i++)
            {
                // ha egyezik 
                if (users[i].EszkozTipusa == eszkozTipus)
                {
                    // megnövelem az eddigi eszközök számát
                    sum++;

                    // frissítem az országhoz tartozó értéket
                    // enum-ból int-et csinálok
                    int index = (int)users[i].Orszaga;

                    // megnövelem az értékét
                    eszkozOrszagonkent[index]++;
                }
            }

            // a visszadós string kezdete
            string temp = $"-- Distribution of {eszkozTipus} --\n";

            // végigmegyünk az országokon
            // 0. indexű (enum)-ú ország nincs, ezért 1-től megyünk
            for (int i = 1; i < eszkozOrszagonkent.Length; i++)
            {
                // i. ország százalék számítása
                double ertek = (double)eszkozOrszagonkent[i] / sum * 100;
                // 2 tizedesjegyre kerekítés
                double szazalek = Math.Round(ertek, 2);

                // szöveg hozzáfűzése
                temp += ((CountryName)i).ToString() + ":  ";

                // százalék hozzáfűzése
                temp += szazalek + "%\n";

            }

            return temp;
        }

    }
}
