using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L09_TheConsoleSlayer
{
    enum ItemType { Ammo, BFGCell, Door, LevelExit, Medikit, ToxicWaste, Wall }
    internal class GameItem
    {
        // mezők
        Position pos;
        ConsoleSprite sprite;
        ItemType type;
        double fill;
        bool available;

        // property-k
        public Position Position { get => pos; }
        public ConsoleSprite Sprite { get => sprite; }
        public ItemType Type { get => type; }
        public double FillingRatio { get => fill; }
        public bool Available { get => available; }

        private void SetInitialProperties()
        {
            switch (this.type)
            {
                case ItemType.Ammo:
                    this.fill = 0.0;
                    this.sprite = new ConsoleSprite(ConsoleColor.Red, ConsoleColor.Yellow, 'A');
                    break;

                case ItemType.BFGCell:
                    this.fill = 0.0;
                    this.sprite = new ConsoleSprite(ConsoleColor.Green, ConsoleColor.White, 'B');
                    break;

                case ItemType.Door:
                    this.fill = 1.0;
                    this.sprite = new ConsoleSprite(ConsoleColor.Gray, ConsoleColor.Yellow, '/');
                    break;

                case ItemType.LevelExit:
                    this.fill = 1.0;
                    this.sprite = new ConsoleSprite(ConsoleColor.Cyan, ConsoleColor.Black, 'E');
                    break;

                case ItemType.Medikit:
                    this.fill = 0.0;
                    this.sprite = new ConsoleSprite(ConsoleColor.Gray, ConsoleColor.Red, '+');
                    break;
                case ItemType.ToxicWaste:
                    this.fill = 0.0;
                    this.sprite = new ConsoleSprite(ConsoleColor.DarkGreen, ConsoleColor.Yellow, ':');
                    break;
                case ItemType.Wall:
                    this.fill = 1.0;
                    this.sprite = new ConsoleSprite(ConsoleColor.DarkGray, ConsoleColor.DarkGray, ' ');
                    break;

            }
        }

        // ctor
        public GameItem(int x, int y, ItemType tipus)
        {
            this.available = true;
            this.pos = new Position(x, y);
            this.type = tipus;
            this.SetInitialProperties();
        }

        public void Interact()
        {
            switch (this.type)
            {
                case ItemType.Ammo:
                case ItemType.BFGCell:
                case ItemType.Medikit:
                    this.available = false;
                    break;

                case ItemType.Door:
                    if (this.fill == 1.0)
                    {
                        this.fill = 0.0;
                        this.sprite = new ConsoleSprite(ConsoleColor.DarkGray, ConsoleColor.DarkYellow, '/');
                    }
                    else
                    {
                        this.fill = 1.0;
                        this.sprite = new ConsoleSprite(ConsoleColor.Gray, ConsoleColor.Yellow, '/');
                    }
                    break;
            }
        }
    }
}