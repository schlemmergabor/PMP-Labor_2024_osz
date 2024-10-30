using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L07_tulajdonsagok
{
    // enum, felsorolás típus
    // a járatok státusza csak ilyen lehet
    enum Status
    {
        Scheduled, Delayed, Canceled
    }
    internal class Flight
    {
        //  mezők
        string jaratszam;
        string celallomas;
        DateTime indulas;
        int keses;
        Status allapot;

        // property-k a mezőkhöz 
        // csak lekérdezhető, így csak a get része marad meg
        // ha a set-et private láthatóságra tetted, az is jó!
        public string Jaratszam { get => jaratszam;  }
        public string Celallomas { get => celallomas;  }
        public DateTime Indulas { get => indulas;  }
        public int Keses { get => keses;  }
        internal Status Allapot { get => allapot;  }

        // egyik ctor
        public Flight(string jaratszam, string celallomas, DateTime indulas, int keses)
        {
            this.jaratszam = jaratszam;
            this.celallomas = celallomas;
            this.indulas = indulas;
            this.keses = keses;
            // van késés érték amit beállítottunk, így
            this.allapot = Status.Delayed;
        }

        // másik ctor
        // nem úgy készítettem, hogy újra leírtam a kód belsejét (kód duplikáció)
        // hanem meghívtam a másik ctor-t a paraméterekkel
        // ezt látod a : this() esetében
        public Flight(string jaratszam, string celallomas, DateTime indulas) :
            this (jaratszam, celallomas, indulas, 0)
        {
            // állapotot még be kell állítani külön
            this.allapot = Status.Scheduled;
        }

        // Metódus
        // beállítja a késés
        public void Delay(int mennyivel)
        {
            // hozzáadjuk az eddigiekhez, azért, mert
            // ha eddig is volt késése és tovább késik
            // akkor is lehessen megoldani a kóddal.
            this.keses += mennyivel;
        }

        // járat törlése -> állapot beállításával
        public void Cancel()
        {
            // mezőt közvetlenül beállítom
            this.allapot = Status.Canceled;
        }

        // a megadott állapotra állítja a mezőt
        private void UpdateStatus(Status all)
        {
            this.allapot = all;
        }
        
        // késéstől függően beállítjuk a státuszát
        public void UpdateStatus()
        {
            // nem a mezőt hívom meg, hanem a privát metódust
            // a megfelelő paraméterrel
            if (this.keses == 0) this.UpdateStatus(Status.Scheduled);
            else this.UpdateStatus(Status.Delayed);
        }

        // még egy tulajdonság
        // visszaadja a szöveget
        public string AllData {
            get
            {
                // temp stringbe fogom összerakakni a szöveget
                // mindenképp így kezdődik
                string temp = $"Flight {this.jaratszam} is ";

                // státusztól függően folytatódik
                // EstimatedDeparture() metódust meghívom, annak a ToString() értéke kerül ide
                if (this.Allapot == Status.Scheduled) temp += $"on time. (STD {EstimatedDeparture()})";
                if (this.Allapot == Status.Canceled) temp += "cancelled.";
                if (this.Allapot == Status.Delayed) temp += $"delayed by {this.keses} minutes. (ETD {EstimatedDeparture()})";

                // az elkészült temp string-et adja majd vissza a prop.
                return temp;
            }
        }

        // még egy Metódus
        // késéssel növelt indulást számol
        private DateTime EstimatedDeparture()
        {
            // DateTime típus az indulás
            // hozzáadjuk a késés perceit
            // és azt adja vissza a metódus
            return this.indulas.AddMinutes(this.keses);
        }
    }
}