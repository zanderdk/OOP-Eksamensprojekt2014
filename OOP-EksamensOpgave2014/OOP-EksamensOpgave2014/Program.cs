using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_EksamensOpgave2014
{
    class Program
    {
        static void Main(string[] args)
        {
            var bil = new Privatbil() { Registreringsnummer = "aa12345" };
            Console.WriteLine(bil.Registreringsnummer);
            Console.WriteLine(bil.Kørekorttype);
            Console.ReadLine();

        }
    }
}
