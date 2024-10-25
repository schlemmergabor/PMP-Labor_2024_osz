using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L06_OOPalapok
{
    internal class Caesar
    {
        // belső változó, kulcs (eltolás) értéke
        int kulcs;

        // konstruktor
        public Caesar(int kulcs)
        {
            this.kulcs = kulcs;
        }

        // Metódusok
        // üzenet átalakítása
        // private, tehát csak ebből az osztályból hívható meg
        // string a visszatérési értéke
        // két paramétere van egy string tipusu uzenet névvel
        // és egy int típusú kulcs névvel
        private string TransformMessage(string uzenet, int kulcs)
        {
            // algoritmus a jegyzetből
            int s = kulcs;
            // n változót nem használjuk fel a kódban - lásd lejjebb
            // int n = 'z' - 'a' + 1; 
            int idx0 = 'a';
            string result = String.Empty;
            foreach (char a in uzenet)
            {
                // % n van a jegyzetben, ami lekortlázotta a betűkészletet
                // az a-z -re, de mi ugye szeretnénk nagybetűket,
                // ékezetes karaktereket is kezelni, úgyhogy az kimarad! :)
                char c = (char)(idx0 + ((int)a - idx0 + s) );
                result += c;
            }
            return result;

        }

        // publikus kódolás Metódus
        // public, hogy kívülről hívható legyen
        // string a visszatérési értéke
        // csak string típusú uzenet nevű paramétert kap
        // a kulcsot a this tárolja!
        public string Encode(string uzenet)
        {
            // visszaadja a kiszámított értékét a másik metódusnak
            // kódolás a +kulcs miatt
            // a karakterek + irányba eltolva
            return TransformMessage(uzenet, this.kulcs);

        }

        // publikus dekódolás visszaalakítás Metódus
        // public, hogy kívülről hívható legyen
        // string a visszatérési értéke
        // csak string típusú uzenet nevű paramétert kap
        // -kulcs a paraméter, a visszaalakítás miatt
        public string Decode(string uzenet)
        {
            // dekódolás -kulcs miatt
            // a karaktereket visszatoljuk - irányba
            return TransformMessage(uzenet, -this.kulcs);
        }
    }
}
