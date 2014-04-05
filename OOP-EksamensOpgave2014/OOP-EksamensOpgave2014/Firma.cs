using System;

namespace OOP_EksamensOpgave2014
{
    public class Firma : Køber, Sælger
    {
        public readonly int CVRnummer;

        public Firma(int cvRnummer)
        {
            CVRnummer = cvRnummer;
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
            Console.WriteLine("Firma med CVR " + CVRnummer + "har modtager et bud på auktion #" + args.Auktionsnummer + " på " + args.Bud + "kr");
        }
    }
}
