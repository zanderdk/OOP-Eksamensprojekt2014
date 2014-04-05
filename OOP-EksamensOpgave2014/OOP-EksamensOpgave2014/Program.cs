using System;

namespace OOP_EksamensOpgave2014
{
    class Program
    {
        static void Main()
        {
            var bil = new Privatbil(Brændstof.Benzin, 2013, 2) { Registreringsnummer = "aa12345", Navn = "Volvo", Km = 9001, KmPrL = 14};
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

            Console.ReadLine();

            // TODO "hardcodet" demonstration af funktionaliteten
        }
    }
}
