using System;
using System.Collections.Generic;

namespace OOP_EksamensOpgave2014
{
    class Program
    {
        static void Main()
        {
            Køretøj bil;
            try
            {
                bil = new Privatbil("aa12345", null, Brændstof.Benzin, 5.3, 2013, 4) { Km = 9001, KmPrL = 21 };
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Navn må ikke være null");
            }
            bil = new Privatbil("aa12345", "Volvo", Brændstof.Benzin, 5.3, 2013, 4) { Km = 9001, KmPrL = 21 };

            Console.WriteLine("Prøver at sette NyPris til negativ");
            bil.NyPris = -12;
            Console.WriteLine("Billens værdi er nu: " + bil.NyPris);

            try
            {
                bil.Registreringsnummer = "A432";
            }
            catch (RegistreringnummerException)
            {
                Console.WriteLine("Har prøvet at sætte Registreringsnummer til noget ulovligt");
            }
            Console.WriteLine("\nUdskriv bil:");
            Console.WriteLine(bil);

            try
            {
                bil.Motorstørrelse = 11;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("\nMotorstørrelse er for stor til personbil");
            }
            // men 11 er ikke for stor til en bus
            Køretøj bus = new Bus("df78645", "Opel", Brændstof.Diesel, 11, 2010, 20, 0, 800){Km = 500000, KmPrL = 8, Trækkrog = true};

            Console.WriteLine("\nUdregning af forskellige energiklasser:");
            Console.WriteLine(bus.Energiklasse);
            Console.WriteLine(bil.Energiklasse);
            /*Eksempel: En benzin-drevet autocamper fra 2007 der kører 18.5 km/l (klasse A) vil med
            oliefyr havne i klasse C (18.5 * 0.7 = 12.95), mens en strøm-udgave vil havne i klasse B
            (18.5 * 0.8 = 14.8)*/
            var auto = new Autocamper("aa12343", "Mercedes" , Brændstof.Benzin, 6.0 , 2007 , Varmesystem.Oliefyr, 2, 4) {Km = 34800, KmPrL = 18.5,};
            Console.WriteLine(auto.Energiklasse);
            auto.Varmesystem = Varmesystem.Strøm;
            Console.WriteLine(auto.Energiklasse);

            Console.WriteLine("\nUdregning af forskellige Kørekorttyper:");
            Console.WriteLine(bus.Kørekorttype);
            Console.WriteLine(bil.Kørekorttype);
            Console.WriteLine(auto.Kørekorttype);

            Console.WriteLine("\n");
            // Laver auktionshus og folk til at sælge og købe
            Auktionshus carAway = new Auktionshus();
            Firma mærsk = new Firma(22756214){Postnummer = 1250, Saldo = 9000000000, Kredit = 0};
            Firma glCars = new Firma(23984723){Postnummer = 8850, Saldo = 15000, Kredit = 40000};
            Privatperson alice = new Privatperson(3101902222){Postnummer = 9000, Saldo = 0};
            Privatperson bob = new Privatperson(1403921111){Postnummer = 9000, Saldo = 200000};

            int mId = carAway.SætTilSalg(bus, mærsk, 50000);
            int aId = carAway.SætTilSalg(bil, alice, 10000);
            //aId = carAway.SætTilSalg(bil, alice, 70000); Hun kan ikke sælge den samme igen
            int gId = carAway.SætTilSalg(auto, glCars, 10000);

            carAway.ModtagBud(glCars, aId, 30000); //TODO tjek at man ikke kan byde over dig selv
            carAway.ModtagBud(bob, aId, 45000);
            carAway.ModtagBud(glCars, aId, 55000);
            carAway.ModtagBud(bob, aId, 80000);
            carAway.ModtagBud(mærsk, aId, 90000);
            carAway.ModtagBud(bob, aId, 95000);
            carAway.ModtagBud(mærsk, aId, 97000);
            carAway.ModtagBud(bob, aId, 100000);
            carAway.ModtagBud(glCars, aId, 105000);// Det har de ikke penge til

            Console.WriteLine("Før biler er solgt er alices saldo: " + alice.Saldo);
            Console.WriteLine("Før biler er solgt er bobs saldo: " + bob.Saldo);
            if (carAway.AccepterBud(alice, aId))
            {
                Console.WriteLine("Bilen er solgt!!");
                Console.WriteLine("Efter biler er solgt er alices saldo: " + alice.Saldo);
                Console.WriteLine("Efter biler er solgt er bobs saldo: " + bob.Saldo);
            }
            Console.WriteLine("\nVi kan nu genneløbe de solgte køretøjer:");
            foreach (Auktion auk in carAway.SolgteKøretøjer)
            {
                Console.WriteLine(auk.Køretøj);
            }

            // Mærsk skal havde ryddet ud i deres biler
            List<Køretøj> mærskLager = new List<Køretøj>
            {
                new Autocamper("sd87354", "Volvo", Brændstof.Benzin, 5.2, 1992, Varmesystem.Oliefyr, 5, 3){Toilet = true, Km = 400000, KmPrL = 19.3},
                new Autocamper("kj83645", "Ford", Brændstof.Benzin, 5.2, 1992, Varmesystem.Strøm, 5, 0){Toilet = false, Km = 200000, KmPrL = 17.3},
                new Autocamper("of91546", "VW", Brændstof.Diesel, 3.2, 2013, Varmesystem.Gas, 7, 7){Toilet = true, Km = 1000, KmPrL = 20.4},
                new Autocamper("le75635", "Audi", Brændstof.Diesel, 4.2, 1999, Varmesystem.Oliefyr, 3, 1){Toilet = true, Km = 165000, KmPrL = 19.3},
                new Bus("pw94673", "Scania", Brændstof.Diesel, 10.2, 2006, 49, 0, 2000){Km = 405966, KmPrL = 18},
                new Bus("ue84756", "Mercedes-Benz", Brændstof.Diesel, 12.3, 2010, 28, 28, 1500){Toilet = true, Km = 98273, KmPrL = 25},
                new Bus("ok57635", "Scania", Brændstof.Diesel, 11.2, 2006, 5, 0, 900){Km = 438500, KmPrL = 17},
                new Privatbil("ac23645", "Volvo", Brændstof.Benzin, 7, 2013, 5){Km = 45000, KmPrL = 30},
                new Privatbil("kj82734", "BMW", Brændstof.Benzin, 8, 2013, 5){Km = 105000, KmPrL = 20},
                new Erhvervbil("ok45857", "Renault", Brændstof.Diesel, 5, 2012, 2, true){Km = 33000, KmPrL = 20}
            };

            foreach (Køretøj item in mærskLager)
            {
                carAway.SætTilSalg(item, mærsk, 10000);
            }

            Console.WriteLine("\nVolvo til sagt:");
            foreach (Køretøj item in carAway.Søg("Volvo"))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nBusser og autocampere med mindst 5 pladser og et toilet:");
            foreach (Køretøj item in carAway.Pladser(5))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nStorekøretøjer der vejer mindre en 1000 kg:");
            foreach (Køretøj item in carAway.StortKørekort(1000))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nPersonbiler der har kørt mindre end 100kkm og minpris ikke er over 50k:");
            foreach (Køretøj item in carAway.PrivatBiler(100000, 50000))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nBiler til sagt i indre kbh. området:");
            foreach (Køretøj item in carAway.Nærliggende(1000, 999))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nGennemsnitlige energi-klasse tilsalg: " + carAway.GennemsnitligeEnergiKlasse());

            Console.ReadLine();
        }
    }
}
