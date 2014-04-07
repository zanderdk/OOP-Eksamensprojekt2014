using System;

namespace OOP_EksamensOpgave2014
{
    class Program
    {
        static void Main()
        {
            var bil = new Privatbil("aa12345" ,"Volvo" ,Brændstof.Benzin, 5.3 ,2013, 4) { Km = 9001, KmPrL = 21};

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
            var auto = new Autocamper("aa12343", "dfgsdfg" , Brændstof.Benzin, 6.0 , 2007 , Varmesystem.Oliefyr, 2, 4) {KmPrL = 18.5,};
            Console.WriteLine(auto.Energiklasse);
            auto.Varmesystem = Varmesystem.Strøm;
            Console.WriteLine(auto.Energiklasse);

            Console.ReadLine();
            // TODO "hardcodet" demonstration af funktionaliteten
        }
    }
}
