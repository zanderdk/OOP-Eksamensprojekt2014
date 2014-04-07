using System;

namespace OOP_EksamensOpgave2014
{
    class Privatperson : IKøber, ISælger
    {
        public readonly int CPRnummer;

        public Privatperson(int cpRnummer)
        {
            CPRnummer = cpRnummer;
            _saldo = 0;
        }

        private decimal _saldo;
        public decimal Saldo
        {
            get { return _saldo; }
            set
            {
                if (value >= 0)
                {
                    _saldo = value;
                    return;
                }
                throw new ArgumentOutOfRangeException("value");
            }
        }

        public int Postnummer { get; set; }


        public void ModtagNotifikationOmBud(object sender, Auktion.AuktionArgs args)
        {
            Console.WriteLine("Person med CPR " + CPRnummer + "har modtager et bud på auktion #" + args.Auktionsnummer + " på " + args.Bud + "kr");
        }
    }
}
