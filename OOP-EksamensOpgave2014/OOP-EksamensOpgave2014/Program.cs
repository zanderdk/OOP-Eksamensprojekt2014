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
            Console.WriteLine("\n");

            try
            {
                bil.Motorstørrelse = 11;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("\nMotorstørrelse er for stor til personbil");
            }
            // men 11 er ikke for stor til en bus
            Køretøj bus = new Bus("df78645", "Opel", Brændstof.Diesel, 11, 2010){KmPrL = 8};

            Console.WriteLine("Udregning af forskellige energi klasser:");
            Console.WriteLine(bus.Energiklasse);
            Console.WriteLine(bil.Energiklasse);
            /*Eksempel: En benzin-drevet autocamper fra 2007 der kører 18.5 km/l (klasse A) vil med
            oliefyr havne i klasse C (18.5 * 0.7 = 12.95), mens en strøm-udgave vil havne i klasse B
            (18.5 * 0.8 = 14.8)*/
            var auto = new Autocamper("aa12343", "dfgsdfg" , Brændstof.Benzin, 6.0 , 2007 , Varmesystem.Oliefyr, 2, 4) {KmPrL = 18.5,};
            Console.WriteLine(auto.Energiklasse);
            auto.Varmesystem = Varmesystem.Strøm;
            Console.WriteLine(auto.Energiklasse);

            Console.ReadLine();
            
            // TODO "hardcodet" demonstration af funktionaliteten
        }
    }
}
