using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
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
        // ha játékosok száma == 5 -> true, másik esetben false
        public bool IsFull { get => this.NumberOfPlayers == 5;  }

        // ctor
        public Team()
        {
            // itt hozzuk létre a tömböt !!! FONTOS !!!
            this.players = new Player[5];

            // kezdetben 0 játékosunk van
            this.NumberOfPlayers = 0;
        }

        // metódusok
        // eldönti, hogy a parameter szerepel-e már a csapatban
        // lásd Eldöntés programozási tétel
        // https://users.nik.uni-obuda.hu/sergyan/Programozas1Jegyzet.pdf
        // 25. oldal

        public bool IsIncluded(Player pl)
        {
            // tömb indexelés 0-tól indul, jegyzetben 1-től
            // ezért le kell egyet vonni belőle!
            int i = 1 - 1; // 0

            // tömb mérete -> indexelés miatt - 1 !!!
            int n = this.players.Length - 1;

            // ciklus amíg ...
            while ((i <= n) && !(this.players[i] == pl))
                i++;

            bool van = i <= n;
            
            // vissza van változó értéke
            return van;
        }

        // eldönti, hogy a parameter pozíciója szabad-e
        public bool IsAvailable(Player pl)
        {
            // csapatban a szabad poziciók kezdőszáma
            // 1 kapus, 1 csatár, 2 szélső, 1 védő
            // Enumban is ilyen sorrendben vannak
            // enum -> ból int
            // Goalkeeper, Forward, Winger, Defender
            //      0         1       2        3
            int[] nums = new int[] { 1, 1, 2, 1 };

            // végig nézzük az összes játékost
            for (int i = 0; i < this.NumberOfPlayers; i++)
            {
                // az adott játékos posztját számmá alakítjuk
                // kapus=0, csatár=1, szélső=2, védő=3
                int pos = (int)this.players[i].Pos;

                // ezzek indexeljük a tömböt
                // maradék szabad helyekből 1-t levonunk
                nums[pos]--;
            }

            // itt a nums tömbben az van benne, hogy menni
            // szabad hely van az egyes pozikon

            // ha a player paraméret Pos -án még van hely...
            if (nums[(int)pl.Pos] > 0) return true;
            else return false;
        }

        //  játékos hozzáadása a csapathoz
        public void Include(Player pl)
        {
            // ha nincs tele a csapat
            // ha nincs még benne
            // ha szabad a posztja
            if (!this.IsFull && !IsIncluded(pl) && IsAvailable(pl))

                // hozzáadjuk a tömbhöz
                // megnöveljük a játékosok számát!
                this.players[this.NumberOfPlayers++] = pl;
        }
    }
}
