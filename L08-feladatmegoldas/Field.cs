using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L08_feladatmegoldas
{
    internal class Field
    {
        // játéktér mérete
        int m;

        // ctor
        public Field(int m)
        {
            this.m = m;
        }

        // Tulajdonságok -> 0,0-tól indulunk
        // játéktér jobb alsó sarkát adja vissza
        public int TargetX
        {
            get { return this.m - 1; }
        }

        public int TargetY
        {
            get { return this.m - 1; }
        }

        // Léphet-e a bölény X, Y-ra?
        public bool AllowedPosition(int X, int Y)
        {
            // léphet, ha még a játéktéren belül van
            return X <= TargetX && Y <= TargetY;
        }

        // játéktér kirajzolása
        public void Show()
        {
            // ablak 0,0 pozijába
            Console.SetCursorPosition(0, 0);

            // első sor
            for (int i = 0; i < this.m; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            // "köztes" sorok
            for (int i = 1; i < this.m - 1; i++)
            {
                Console.Write("|");

                // szóközök -> "letisztítja" a pályát
                for (int j = 1; j < this.m - 1; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }

            // utolsó sor
            for (int i = 0; i < this.m; i++)
            {
                Console.Write("-");
            }
        }
    }
}
