using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L09_TheConsoleSlayer
{
    internal class Player
    {
        // mező
        Position pos;
        ConsoleSprite sprite;

        // tulajdonság
        public Position Pos { get => pos; set => pos = value; }
        public ConsoleSprite Sprite { get => sprite; }

        // ctor
        public Player(int x, int y)
        {
            // játékos új pos. létrehozása
            this.pos = new Position(x, y);

            // játékos kinézete
            this.sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.DarkGreen, 'O');

        }
    }
}
