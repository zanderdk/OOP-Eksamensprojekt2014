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

        public decimal Kredit { get; set; } //TODO hvad gør vi hvis man ændre kredit og er i undeskud?s
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
