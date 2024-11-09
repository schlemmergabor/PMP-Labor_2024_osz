using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L09_TheConsoleSlayer
{
    internal class Position
    {
        // mezők
        int x, y;

        // tulajdonságok
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        // ctor
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // statikus két Pos.-t összeadó
        public static Position Add(Position p_1, Position p_2)
        {
            // vissza ad egy új Position példányt
            // X, Y értékek összeadásával
            return new Position(p_1.X + p_2.X, p_1.Y + p_2.Y);
        }

        // kés Pos. távolságát számolja ki
        public static double Distance(Position p_1, Position p_2)
        {
            // képlet: https://hu.wikipedia.org/wiki/T%C3%A1vols%C3%A1g#Geometria
            return Math.Sqrt( // négyzetgyök
                Math.Pow(p_2.X - p_1.X, 2) // power -> hatványozás
                +
                Math.Pow(p_2.Y - p_1.Y, 2)
                );
        }
    }
}
