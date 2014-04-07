using System;

namespace OOP_EksamensOpgave2014
{
    public class Firma : IKøber, ISælger
    {
        public readonly int CVRnummer;

        public Firma(int CVRnummer)
        {
            this.CVRnummer = CVRnummer;
        }

        private decimal _kredit;

        public decimal Kredit
        {
            get { return _kredit; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                if (Saldo < -value )
                {
                    throw new ArgumentException("Kan ikke hæve kredit til over det der skyldes");
                }

                _kredit = value;
            }
        }
        
        private decimal _saldo;
        public decimal Saldo
        {
            get { return _saldo; }
            set
            {
                if (value >= -Kredit)
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
            Console.WriteLine("Firma med CVR " + CVRnummer + "har modtager et bud på auktion #" + args.Auktionsnummer + " på " + args.Bud + "kr");
        }
    }
}
