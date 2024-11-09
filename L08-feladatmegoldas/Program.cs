namespace L08_feladatmegoldas
{
    internal class Program
    {
        // Random játékosok generálása
        static Player[] RandomPlayers(int a)
        {
            // tömb méretének lefoglalása
            Player[] players = new Player[a];

            Random rnd = new Random();

            // tömb feltöltése
            for (int i = 0; i < players.Length; i++)
            {
                // véletlenszerű játékosnév - 3 betűs
                string nev = "P-" + (char)rnd.Next((int)'A', (int)'Z'+1) + (char)rnd.Next((int)'A', (int)'Z'+1); ;

                // Pozi enum-ba
                Position pos = (Position)rnd.Next(0, 4);

                // tömb elemre létrehozás -> itt hívjuk meg a ctor-t
                players[i] = new Player(nev, pos);
            }

            // elkészült tömb visszaadása
            return players;
        }
        
        // Játékosok kiválasztása és csapatba rendelése
        static void ElsoFeladat()
        {
            Team csapat = new Team();
            Player[] valaszthatok = RandomPlayers(15);
            while (!csapat.IsFull)
            {
                Console.WriteLine("Választható játékosok:\n");
                for (int i = 0; i < valaszthatok.Length; i++)
                {
                    Console.WriteLine($"{i} -> {valaszthatok[i]}");
                }
                Console.Write("\nMelyiket adjuk a csapathoz?");
                int index = int.Parse(Console.ReadLine());
                csapat.Include(valaszthatok[index]);
            }
        }
        static void MasodikFeladat()
        {
            Console.Write("N=? ");
            int N = int.Parse(Console.ReadLine());

            Console.Write("M=? ");
            int M = int.Parse(Console.ReadLine());

            Game g = new Game(M, N);
            g.Run();

        }
        static void Main(string[] args)
        {
            // teszteléshez használt kód
            Player p1 = new Player("király kapus", Position.Goalkeeper);
            Player p2 = new Player("király csatár", Position.Forward);

            Team ftc = new Team();

            bool a = ftc.IsIncluded(p1);
            ftc.Include(p1);
            bool b = ftc.IsIncluded(p1);
            ;
            ftc.Include(p2);
            ;

            // Első Feladat (futsal csapatos)
            ElsoFeladat();

            // Második Feladat (bölényes)
            MasodikFeladat();
        }
    }
}
