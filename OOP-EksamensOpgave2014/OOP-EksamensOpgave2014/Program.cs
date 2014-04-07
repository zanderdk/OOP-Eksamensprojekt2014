using System;

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
            Køretøj bus = new Bus("df78645", "Opel", Brændstof.Diesel, 11, 2010){KmPrL = 8, Trækkrog = true};

            Console.WriteLine("\nUdregning af forskellige energiklasser:");
            Console.WriteLine(bus.Energiklasse);
            Console.WriteLine(bil.Energiklasse);
            /*Eksempel: En benzin-drevet autocamper fra 2007 der kører 18.5 km/l (klasse A) vil med
            oliefyr havne i klasse C (18.5 * 0.7 = 12.95), mens en strøm-udgave vil havne i klasse B
            (18.5 * 0.8 = 14.8)*/
            var auto = new Autocamper("aa12343", "dfgsdfg" , Brændstof.Benzin, 6.0 , 2007 , Varmesystem.Oliefyr, 2, 4) {KmPrL = 18.5,};
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
            Privatperson alice = new Privatperson(1101702222){Postnummer = 9000, Saldo = 0};
            Privatperson bob = new Privatperson(0101701111){Postnummer = 9000, Saldo = 200000};

            int mId = carAway.SætTilSalg(bus, mærsk, 50000);
            int aId = carAway.SætTilSalg(bil, alice, 70000);
            //aId = carAway.SætTilSalg(bil, alice, 70000); Det kan hun da ikke
            int gId = carAway.SætTilSalg(auto, glCars, 10000);

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
            

            Console.ReadLine();
            
            // TODO "hardcodet" demonstration af funktionaliteten
        }
    }
}
