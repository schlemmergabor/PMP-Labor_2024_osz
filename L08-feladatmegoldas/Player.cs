using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L08_feladatmegoldas
{
    enum Position
    {
        Goalkeeper, Forward, Winger, Defender
    }
    internal class Player
    {
        // adattagok, mezők, belső változók
        string name;
        Position pos;

        // ctor
        public Player(string name, Position pos)
        {
            this.name = name;
            this.pos = pos;
        }

        // ToString() felüldefiniálása
        public override string? ToString()
        {
            return $"{this.name} - {this.pos}";
        }

    }
}
