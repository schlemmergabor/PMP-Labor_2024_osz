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

            // megfelelő Pos-ba viszem a kurzort
            Console.SetCursorPosition(doomGuy.Pos.X, doomGuy.Pos.Y);

            // kiírom a karaktert
            Console.WriteLine(doomGuy.Sprite.Glyph);

            // Game tesztelése
            // új Game példány létrehozása
            Game game = new Game();

            // GameItem tesztelése lista feltöltésével
            //GameItem[] gi = new GameItem[]
            //{
            //    new GameItem(3, 3, ItemType.Door),
            //    new GameItem(4, 4, ItemType.Medikit),
            //    new GameItem(5, 5, ItemType.ToxicWaste),
            //    new GameItem(6, 6, ItemType.Wall)
            //};
            GameItem[] gi = new GameItem[]
{
    // Külső falak (12x12 méretű négyzet)
    new GameItem(2, 0, ItemType.Wall), new GameItem(3, 0, ItemType.Wall),
    new GameItem(4, 0, ItemType.Wall), new GameItem(5, 0, ItemType.Wall), new GameItem(6, 0, ItemType.Wall), new GameItem(7, 0, ItemType.Wall),
    new GameItem(8, 0, ItemType.Wall), new GameItem(9, 0, ItemType.Wall), new GameItem(10, 0, ItemType.Wall), new GameItem(11, 0, ItemType.Wall),

    new GameItem(0, 1, ItemType.Wall), new GameItem(11, 1, ItemType.Wall),
    new GameItem(0, 2, ItemType.Wall), new GameItem(11, 2, ItemType.Wall),
    new GameItem(0, 3, ItemType.Wall), new GameItem(11, 3, ItemType.Wall),
    new GameItem(0, 4, ItemType.Wall), new GameItem(11, 4, ItemType.Wall),
    new GameItem(0, 5, ItemType.Wall), new GameItem(11, 5, ItemType.Wall),
    new GameItem(0, 6, ItemType.Wall), new GameItem(11, 6, ItemType.Wall),
    new GameItem(0, 7, ItemType.Wall), new GameItem(11, 7, ItemType.Wall),
    new GameItem(0, 8, ItemType.Wall), new GameItem(11, 8, ItemType.Wall),
    new GameItem(0, 9, ItemType.Wall), new GameItem(11, 9, ItemType.Wall),
    new GameItem(0, 10, ItemType.Wall), new GameItem(11, 10, ItemType.Wall),

    new GameItem(0, 11, ItemType.Wall), new GameItem(1, 11, ItemType.Wall), new GameItem(2, 11, ItemType.Wall), new GameItem(3, 11, ItemType.Wall),
    new GameItem(4, 11, ItemType.Wall), new GameItem(5, 11, ItemType.Wall), new GameItem(6, 11, ItemType.Wall), new GameItem(7, 11, ItemType.Wall),
    new GameItem(8, 11, ItemType.Wall), new GameItem(9, 11, ItemType.Wall), new GameItem(10, 11, ItemType.Wall), new GameItem(11, 11, ItemType.Wall),

    // Labirintus belső falai
    new GameItem(2, 2, ItemType.Wall), new GameItem(2, 3, ItemType.Wall), new GameItem(2, 4, ItemType.Wall),
    new GameItem(3, 4, ItemType.Wall), new GameItem(4, 4, ItemType.Wall), new GameItem(5, 4, ItemType.Wall),
    new GameItem(5, 5, ItemType.Wall), new GameItem(5, 6, ItemType.Wall), new GameItem(6, 6, ItemType.Wall),
    new GameItem(7, 5, ItemType.Wall), new GameItem(8, 4, ItemType.Wall), new GameItem(9, 4, ItemType.Wall),
    
    // Ajtók
    new GameItem(3, 3, ItemType.Door),
    new GameItem(7, 3, ItemType.Door),
    new GameItem(5, 9, ItemType.Door),

    // Egyéb tárgyak
    new GameItem(1, 10, ItemType.Medikit),
    new GameItem(4, 1, ItemType.ToxicWaste),
    new GameItem(10, 10, ItemType.Medikit)
};



            // listába beletesszük a GameItem-eket
            for (int i = 0; i < gi.Length; i++)
            {
                game.Items.Add(gi[i]);
            }
           
            // játék indítása
            game.Run();
        }
    }
}
