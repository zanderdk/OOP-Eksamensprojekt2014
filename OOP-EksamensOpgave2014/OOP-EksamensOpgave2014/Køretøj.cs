using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_EksamensOpgave2014
{
    abstract public class Køretøj
    {
        private string navn;
        // TODO
        public string Navn
        {
            get { return navn; }
            set { navn = value; }
        }

        private decimal km;
        // TODO
        public decimal Km
        {
            get { return km; }
            set { km = value; }
        }

        private string registreringsnummer;
        // TODO
        public string Registreringsnummer
        {
            get { return registreringsnummer; }
            set { registreringsnummer = value; }
        }

        public readonly int Årgang;

        private decimal nyPris;
        // TODO
        public decimal NyPris
        {
            get { return nyPris; }
            set { nyPris = value; }
        }

        abstract public bool Trækkrog {get; set;}

        public virtual Kørekorttype Kørekorttype {get; set;} //TODO

        abstract public double Motorstørrelse {get; set;}

        public double KmPrL;

        public readonly Brændstof Brændstof;

        public virtual int Energiklasse { get; set; } //TODO

        public override string ToString() // TODO
        {
            return base.ToString();
        }
        
    }
}
