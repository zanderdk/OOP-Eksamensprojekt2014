using System;

namespace OOP_EksamensOpgave2014
{
    class Privatperson : Køber, Sælger
    {
        public readonly int CPRnummer;

        public Privatperson(int cpRnummer)
        {
            CPRnummer = cpRnummer;
        }

        public decimal Saldo
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public int PostNummer
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public void ModtagNotifikationOmBud(object sender, Auktion.AuktionArgs args)
        {
            Console.WriteLine("Person med CPR " + CPRnummer + "har modtager et bud på auktion #" + args.Auktionsnummer + " på " + args.Bud + "kr");
        }
    }
}
