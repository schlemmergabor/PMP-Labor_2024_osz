using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace L08_feladatmegoldas
{
    internal class Team
    {
        // adattagok, mezők
        Player[] players;

        // property
        public int NumberOfPlayers { get; set; }
        public bool IsFull { get; set; }

        // metódusok
        // eldönti, hogy a parameter szerepel-e már a csapatban
        public bool IsIncluded(Player pl)
        {

            return true;
        }

        // eldönti, hogy a parameter pozíciója szabad-e
        public bool IsAvailable(Player pl)
        {

            return true;
        }

        //  játékos hozzáadása a csapathoz
        public void Include(Player pl)
        {

        }
    }
}
