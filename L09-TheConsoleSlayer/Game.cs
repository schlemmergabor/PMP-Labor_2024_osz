using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L09_TheConsoleSlayer
{
    internal class Game
    {
        // mezők
        Player player;
        bool futE;

        // Property, tulajdonságok
        public bool Exited { get => futE; set => futE = value; }

        // ctor
        public Game()
        {
            // új játékos a 0,0 helyen
            this.player = new Player(0, 0);
        }

        private void RenderSingleSprite(Position pos, ConsoleSprite cs)
        {
            //  ha a pos a játéktéren belül van
            if (pos.X < Console.WindowWidth && pos.Y < Console.WindowHeight &&
                pos.X >= 0 && pos.Y >= 0)
            {
                // jó helyen, színnel, megjelenítés
                Console.SetCursorPosition(pos.X, pos.Y);
                Console.BackgroundColor = cs.Background;
                Console.ForegroundColor = cs.Foreground;
                Console.WriteLine(cs.Glyph);
            }
        }

        private void RenderGame()
        {
            // kurzor láthatóság kikapcsolása
            Console.CursorVisible = false;

            // színek alapállapotra állítása
            // fekete háttér, fehér betűszín
            Console.ResetColor();
            Console.Clear();

            // jatekos kiirasa / kirajzolása
            RenderSingleSprite(this.player.Pos, this.player.Sprite);
        }

        private void UserAction()
        {
            // történt billentyű lenyomás
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressed = Console.ReadKey(true);

                // többirányú/többágú elágazás
                switch (pressed.Key)
                {
                    case ConsoleKey.Escape:
                        this.Exited = true;
                        break;

                    case ConsoleKey.LeftArrow:
                        this.player.Pos = Position.Add(this.player.Pos, new Position(-1, 0));
                        break;
                    case ConsoleKey.RightArrow:
                        this.player.Pos = Position.Add(this.player.Pos, new Position(1, 0));
                        break;
                    case ConsoleKey.UpArrow:
                        this.player.Pos = Position.Add(this.player.Pos, new Position(0, -1));
                        break;
                    case ConsoleKey.DownArrow:
                        this.player.Pos = Position.Add(this.player.Pos, new Position(0, 1));
                        break;
                }
            }

        }

        public void Run()
        {
            // amíg megy a játék
            while (!this.Exited)
            {
                // játék "kirajzolása"
                RenderGame();
                
                // gombnyomás lekezelése
                UserAction();

                // vár 25 msec-et
                Thread.Sleep(25);
            }
        }
    }
}
