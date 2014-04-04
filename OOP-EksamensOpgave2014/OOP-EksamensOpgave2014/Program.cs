using System;

namespace OOP_EksamensOpgave2014
{
    class Program
    {
        static void Main()
        {
            var bil = new Privatbil(Bændstof.Benzin, 2013) { Registreringsnummer = "aa12345", Navn = "Volvo", Km = 9001, KmPrL = 14};
            Console.WriteLine(bil.ToString());
            Console.WriteLine(bil.Registreringsnummer);
            Console.WriteLine(bil.Kørekorttype);
            Console.ReadLine();

            // TODO "hardcodet" demonstration af funktionaliteten
        }
    }
}
