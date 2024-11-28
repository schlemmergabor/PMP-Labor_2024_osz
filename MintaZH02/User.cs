using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH02
{
    // 2. feladat
    internal class User
    {
        // privát (ha nem írod ki a láthatóságot az lesz) mezők
        int azonositoSzam;
        SubscriptionType elofizetesTipusa;
        int elofizetesDija;
        DateTime csatlakozasDT;
        DateTime legutobbiDT;
        CountryName orszaga;
        int eletKor;
        DeviceType eszkozTipusa;

        // csak lekérdezhető tulajdonságok
        public int AzonositoSzam { get => azonositoSzam;  }
        public int ElofizetesDija { get => elofizetesDija; }
        public DateTime CsatlakozasDT { get => csatlakozasDT;  }
        public DateTime LegutobbiDT { get => legutobbiDT;  }
        public int EletKor { get => eletKor;  }
        internal SubscriptionType ElofizetesTipusa { get => elofizetesTipusa;  }
        internal CountryName Orszaga { get => orszaga;  }
        internal DeviceType EszkozTipusa { get => eszkozTipusa;  }

        // konstruktor
        // string-et szöveget kap
        // 1528,Standard,12,2022-09-10,2023-07-07,UnitedKingdom,45,SmartTV
        public User(string sor)
        {
            // feldaraboljuk , -nél
            string[] sorDB = sor.Split(',');

            // mezők értékadása -> megfelelő típusra figyelni kell!
            this.azonositoSzam = int.Parse(sorDB[0]);
            this.elofizetesTipusa = (SubscriptionType)Enum.Parse(typeof(SubscriptionType), sorDB[1]);
            this.elofizetesDija = int.Parse(sorDB[2]);
            this.csatlakozasDT = DateTime.Parse(sorDB[3]);
            this.legutobbiDT = DateTime.Parse(sorDB[4]);
            this.orszaga = (CountryName)Enum.Parse(typeof(CountryName), sorDB[5]);
            this.eletKor = int.Parse(sorDB[6]);
            this.eszkozTipusa = (DeviceType)Enum.Parse(typeof(DeviceType), sorDB[7]);
        }

        // metódusok

        public int SubscriptionInDays()
        {
            // futtatáskori "időérték"
            DateTime ma = DateTime.Now;

            // előfizető csatlakozási "időértéke"
            // this.csatlakozasDT

            // ma -ból kivonjuk a csatlakozási értéket
            // ennek eredményi TimeSpan lesz
            // -> ebből nekünk napok (Days) kell
            // aminek az eredménye egész szám (int) lesz

            int napok = ma.Subtract(this.csatlakozasDT).Days;
            
            return napok;
        }

        public int DaysSinceLastPayment()
        {
            // ugyaúgy kell, mint a fenti SubscriptionInDays metódusnál
            // csak ma.Subtract(this.LegutobbiDT) kell

            // másik ötlet
            // kivonjuk a két DateTime-ot egymásból
            // ennek eredménye TimeSpan típus, annak a nap része kell

            return (DateTime.Now - this.legutobbiDT).Days;
        }

        public string DataAsText()
        {
            return $"User ID: {this.azonositoSzam} " +
                $"({this.orszaga}, " +
                $"{this.elofizetesTipusa}, " +
                $"{this.eszkozTipusa}). " +
                $"Subscription: {this.SubscriptionInDays()} days, " +
                $"last payment: {this.DaysSinceLastPayment()} days.";
        }

    }
}
