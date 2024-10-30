using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L07_tulajdonsagok
{
    internal class GroundControl
    {
        // mezők
        // tároljuk majd az időpontot
        DateTime aktualisIdopont;
        // repülők "gyűjteménye" -> lista
        // lehetne tömb is, de akkor majd a hozzáadásnál
        // kell trükközni
        List<Flight> flights = new List<Flight>();
        
        // ctor, paraméter nélkül
        // beállítjuk az aktuális időt
        public GroundControl()
        {
            this.aktualisIdopont = DateTime.Now;
        }

        // Metódusok
        // hozzáadjuk a repülőt
        public void AddFlight(Flight flight)
        {
            flights.Add(flight);
        }

        // a nem törölt járatok átlagos késési idejét kiszámítjuk
        private int AverageDelay()
        {
            int db = 0;
            int sumKeses = 0;

            for (int i = 0; i < flights.Count; i++)
            {
                if (flights[i].Allapot != Status.Canceled)
                {
                    db++;
                    sumKeses += flights[i].Keses;
                }
            }
            // 0-al nem osztunk -> ha mindegyik Cancelled
            // így szépen ezt megoldjuk
            if (db == 0) return 0;
            // nem kell else, mert csak akkor kerülhet ide
            // a vezérlés, ha nem teljesült a felette levő if
            return sumKeses / db;
        }

        // Repülők adatait megjeleníti
        public void DisplayFlightData()
        {   
            // végigmegyünk a gyűjteményen
            // lista -> .Count
            // tömb -> .Length
            for (int i = 0; i < flights.Count; i++)
            {
                // adott repcsi Property-jét lekérjük és cw
                Console.WriteLine(flights[i].AllData);
            }
            Console.WriteLine($"Average delay is {AverageDelay()} minutes.");
        }

    }
}
