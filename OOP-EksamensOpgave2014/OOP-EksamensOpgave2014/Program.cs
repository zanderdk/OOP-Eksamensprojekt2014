using System;

namespace OOP_EksamensOpgave2014
{
    class Program
    {
        static void Main()
        {
            var bil = new Privatbil(Brændstof.Benzin, 2013) { Registreringsnummer = "aa12345", Navn = "Volvo", Km = 9001, KmPrL = 21};

            Console.WriteLine(bil.ToString());
            Console.WriteLine(bil.Registreringsnummer);
            Console.WriteLine(bil.Kørekorttype);

            var test1 = new Auktion(bil, new Firma(2), 2390);
            var test2 = new Auktion(bil, new Firma(23), 2390);
            var test3 = new Auktion(bil, new Firma(23), 2390);
            var test4 = new Auktion(bil, new Firma(23), 2390);
            Console.WriteLine(test1.Auktionsnummer);
            Console.WriteLine(test2.Auktionsnummer);
            Console.WriteLine(test3.Auktionsnummer);
            Console.WriteLine(test4.Auktionsnummer);

            /*Eksempel: En benzin-drevet autocamper fra 2007 der kører 18.5 km/l (klasse A) vil med
            oliefyr havne i klasse C (18.5 * 0.7 = 12.95), mens en strøm-udgave vil havne i klasse B
            (18.5 * 0.8 = 14.8)*/
            var auto = new Autocamper(Brændstof.Benzin, 2007, Varmesystem.Oliefyr) {KmPrL = 18.5,};
            Console.WriteLine(auto.Energiklasse);
            auto.Varmesystem = Varmesystem.Strøm;
            Console.WriteLine(auto.Energiklasse);

            Console.ReadLine();
            // TODO "hardcodet" demonstration af funktionaliteten
        }
    }
}
