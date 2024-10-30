using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L07_tulajdonsagok
{
    internal class Mole
    {
        // feladat nem írta, hogy külön mező kell neki
        // (nézd meg a 2. Flight-os feladatot ott írja)
        // így simán egy auto implemented propertyvel oldottam meg
        // ami public get, private set-el rendelkezik
        public int X { get; private set; }
        public int Y { get; private set; }
        
        // paraméter nélküli ctor
        public Mole()
        {
            this.X = 0;
            this.Y = 0;
        }

        // feljön és megmutatja magát
        public void TurnUp()
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("M");
        }

        // elbújik és a, b közötti helyen feltűnik
        public void Hide(int a, int b)
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(" ");
            Random rnd = new Random();
            this.X = rnd.Next(a, b);
            this.Y = rnd.Next(a, b);
        }
    }
}
