using System.Transactions;

namespace L09_TheConsoleSlayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Position tesztelése

            Position p1 = new Position(3, 3);
            Position p2 = new Position(1, 2);
            
            // összeg 
            // mivel az Add metódus statikus így az osztályhoz
            // kötődik, nem pedig a példányhoz -> !!!
            Position összeg = Position.Add(p1, p2);

            // távolság -> 2.236068
            double tav = Position.Distance(p1, p2);
            ;

            // ConsoleSprite tesztelése

            // CS példány létrehozása
            ConsoleSprite cs = new ConsoleSprite(ConsoleColor.Green, ConsoleColor.DarkRed, 'X');

            // előtte beállítom a példány segítségével
            // az előtér és a háttér színeke
            Console.BackgroundColor = cs.Background;
            Console.ForegroundColor = cs.Foreground;

            // kiírom a karaktert
            Console.WriteLine(cs.Glyph);

            // Player tesztelése a fentihez hasonlóan
            Player doomGuy = new Player(3, 3);

            // beállítom a példány segítségével
            // az előtér és a háttér színeke
            Console.BackgroundColor = doomGuy.Sprite.Background;
            Console.ForegroundColor = doomGuy.Sprite.Foreground;

            // megfelelő Pos-ba viszek a kurzort
            Console.SetCursorPosition(doomGuy.Pos.X, doomGuy.Pos.Y);

            // kiírom a karaktert
            Console.WriteLine(doomGuy.Sprite.Glyph);

            // Game tesztelése
            // új Game példány létrehozása
            Game game = new Game();

            // játék indítása
            game.Run();

        }
    }
}
