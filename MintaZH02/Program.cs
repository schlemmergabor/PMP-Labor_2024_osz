namespace MintaZH02
{
    // 1. feladat -> felsorolt típusok -> enum-ok
    // azért tesszük ide, hogy az egész projektből (namespace) elérjük
    enum CountryName
    {
        Australia = 1, Brazil = 2, Canada = 3, France = 4, Germany = 5, Italy = 6, Mexico = 7,
        Spain = 8, UnitedKingdom = 9, UnitedStates = 10
    }
    enum SubscriptionType
    {
        Basic, Premium, Standard
    }

    enum DeviceType
    {
        Laptop, SmartTV, Smartphone, Tablet
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // 4. feladat
            // egyszerű menürendszer
            // a többi feladatot megtalálod a többi osztályban!

            // menu kezdeti értéke
            int menu = 0;

            // kezdeti dataset ami null
            Dataset ds = null;

            // amíg nem 5-t írtunk
            while (menu != 5)
            {
                // képernyő törlése
                Console.Clear();

                // menü kiíratása
                Console.Write($"1. Load data file\n2. Get average monthly revenue\n3. List non-paying users\n4. Show distribution of devices\n5. Exit\n\nYour choice: ");
                
                // választott menü frissítése
                menu = int.Parse(Console.ReadLine());

                

                switch(menu)
                {
                    case 1:
                        Console.Write("filename [netflix_data.csv]:  ");
                        string f = Console.ReadLine();
                        
                        // ha nem adott meg semmit -> entert nyomott
                        // akkor az alap fájlt dolgozza fel
                        if (f == "") f = @"..\..\..\netflix_data.csv";
                        ds = new Dataset(f);
                        
                        // ha sikerült feldolgozni...
                        if (ds != null) Console.WriteLine("File load complete.");
                        break;
                    case 2:
                        Console.Write("SubscriptionType [Basic, Premium, Standard]: ");
                        string be = Console.ReadLine();
                        
                        // ha nem írt be semmit, akkor Basic legyen
                        if (be == "") be = "Basic;";
                        
                        SubscriptionType type = (SubscriptionType)Enum.Parse(typeof(SubscriptionType), be);
                        
                        Console.WriteLine($"AverageMonthlyRevenue: {ds.AverageMonthlyRevenue(type)}");

                        break;
                    case 3:
                        Console.Write("Number (integer): ");
                        int nap = int.Parse(Console.ReadLine());

                        // ebbe az eredménytömmbe várjuk az objektumokat
                        User[] result = ds.CollectNonPayers(nap);

                        // végig megyünk az eredményeken
                        foreach (User item in result)
                        {
                            // mindegyikre meghívjuk a DataAsText metódust
                            Console.WriteLine(item.DataAsText());
                        }
                        break;
                    case 4:
                        Console.Write("DeviceType [Laptop, SmartTV, Smartphone, Tablet]: ");
                        string betype = Console.ReadLine();
                        if (betype == "") betype = "Laptop";
                        DeviceType device = (DeviceType)Enum.Parse(typeof(DeviceType), betype);
                        Console.WriteLine(ds.DistributionOfDeviceType(device));
                        break;
                    case 5:
                        Console.WriteLine("EXIT. Please wait...");
                        break;
                    default:
                        Console.WriteLine("Sorry, that's not a valid option. Please choose a number from 1 to 5.");
                        break;
                }
                if (menu!= 5)
                {
                    // Várjunk billentyű nyomásra
                    Console.WriteLine("\n\nPress any key to continue...");
                    Console.ReadLine();
                }
               
            }

        }
    }
}
