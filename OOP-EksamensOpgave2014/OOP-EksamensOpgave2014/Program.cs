using System;

namespace OOP_EksamensOpgave2014
{
    class Program
    {
        static void Main()
        {
            var bil = new Privatbil { Registreringsnummer = "aa12345" };
            Console.WriteLine(bil.Registreringsnummer);
            Console.WriteLine(bil.Kørekorttype);
            Console.ReadLine();
            // TODO "hardcodet" demonstration af funktionaliteten
        }
    }
}
