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

        // játékelemekkel bővítés
        // tesztelés miatt public a get
        public List<GameItem> Items { get; private set; }

        // Property, tulajdonságok
        public bool Exited { get => futE; set => futE = value; }

        // ctor
        public Game()
        {
            // új játékos a 0,0 helyen
            this.player = new Player(0, 0);

            // új üres gameitem lista
            this.Items = new List<GameItem>();
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

            // Items lista bejárása és minden elem kirajzolása
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Available)
                    RenderSingleSprite(Items[i].Position, Items[i].Sprite); ;
            }

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
                    // tesztelés miatt interact működik-e
                    case ConsoleKey.D:
                        for (int i = 0; i < Items.Count; i++)
                        {
                            Items[i].Interact();
                        }
                        break;
                    case ConsoleKey.Escape:
                        this.Exited = true;
                        break;

                    case ConsoleKey.LeftArrow:
                        Move(this.player, Position.Add(this.player.Pos, new Position(-1, 0)));
                        // this.player.Pos = Position.Add(this.player.Pos, new Position(-1, 0));
                        break;
                    case ConsoleKey.RightArrow:
                        Move(this.player, Position.Add(this.player.Pos, new Position(1, 0)));

                        // this.player.Pos = Position.Add(this.player.Pos, new Position(1, 0));
                        break;
                    case ConsoleKey.UpArrow:
                        Move(this.player, Position.Add(this.player.Pos, new Position(0, -1)));

                        // this.player.Pos = Position.Add(this.player.Pos, new Position(0, -1));
                        break;
                    case ConsoleKey.DownArrow:
                        Move(this.player, Position.Add(this.player.Pos, new Position(0, 1)));

                        // this.player.Pos = Position.Add(this.player.Pos, new Position(0, 1));
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

        // törli a nem elérhető elemeket
        private void CleanUpGameItems()
        {
            List<GameItem> ujLista = new List<GameItem>();
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Available) ujLista.Add(Items[i]);
            }

            this.Items = ujLista;
        }

        // ütközésvizsgálathoz
        private List<GameItem> GetGameItemsWithinDistance(Position pos, double ertek)
        {
            List<GameItem> lista = new List<GameItem>();
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (Position.Distance(pos, this.Items[i].Position) <= ertek)
                {
                    lista.Add(Items[i]);
                }
            }
            return lista;
        }

        private double GetTotalFillingRatio(Position pos)
        {
            List<GameItem> lista = GetGameItemsWithinDistance(pos, 0);
            double kitTenyezo = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                kitTenyezo += lista[i].FillingRatio;
            }
            return kitTenyezo;
        }

        private void Move(Player pl, Position vel)
        {
            double ertek = GetTotalFillingRatio(vel);
            if (ertek < 1) pl.Pos = vel;
        }
    }
}
