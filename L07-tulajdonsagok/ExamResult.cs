using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L07_tulajdonsagok
{
    enum Jegy
    {
        Elégtelen, // =0
        Elégséges, // =1
        Közepes, // =2
        Jó, // =3
        Jeles // =4
    }
    internal class ExamResult
    {
        // mező
        string neptunKod;
        int pontszam;

        // Property-k
        public string NeptunKod
        {
            get => neptunKod;
            set { if (value.Length == 6) this.neptunKod = value; }
        }
        public int Pontszam
        {
            get => pontszam;
            set { if (value >= 0 && value <= 100) this.pontszam = value; }
        }

        // paraméteres ctor
        public ExamResult(string neptunKod, int pontszam)
        {
            NeptunKod = neptunKod;
            Pontszam = pontszam;
        }
        
        // paraméter nélküli ctor
        public ExamResult()
        {
            // neptunkódot generálok
            this.NeptunKod = NeptunGeneralas();
            Random rnd = new Random();
            // véletlen pontszám 1...100 közé
            this.pontszam = rnd.Next(101);
        }

        // csináltam egy privát metódust, hogy
        // neptun kódot generálhassak
        private string NeptunGeneralas()
        {
            string temp = String.Empty;
            Random rnd = new Random();
            // első karakter mindenképp betű legyen
            temp += ((char)rnd.Next('A', 'Z' + 1)).ToString();

            for (int i = 0; i < 5; i++)
            {
                // fej vagy írás?
                if (rnd.Next(2) == 0)
                    // egyik esetében betűt generálok
                    temp += ((char)rnd.Next('A', 'Z' + 1)).ToString();
                // másik esetében számot
                else temp += (rnd.Next(0, 10)).ToString();
            }

            return temp;
        }

        // Propery, hogy sikeres-e a ZH
        public bool Passed
        {
            get
            {
                if (this.Pontszam >= 50) return true; return false;
            }
        }

        // ph -> Ponthatárok (:))
        public Jegy Grade(int[] ph)
        {
            // kezdetben a 0. indexű szintre tesszük a pontunkat
            int szint = 0;

            // végig nézzük az összes indexel a szinteket
            for (int i = 0; i < ph.Length; i++)
            {
                // ha a pontszámunk legalább akkora, mint
                // a ponthatár alsó értéke, akkor
                // az új szint az i. lesz
                if (Pontszam >= ph[i]) szint = i;
            }

            // itt a szint változó indexeli a pontHatárok tömböt
            // azaz, hogy melyik indexű "szinten" van pontunk

            // Jegy típussá castolunk a (Jegy)-el
            // a számból Jegy lesz, enum-nál találod, hogy melyik számból
            // melyik enumot fogja visszaadni
            return (Jegy)szint;
        }
    }
}
