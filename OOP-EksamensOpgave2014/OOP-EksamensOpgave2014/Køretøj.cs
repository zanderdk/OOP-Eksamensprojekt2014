using System;

namespace OOP_EksamensOpgave2014
{
    abstract public class Køretøj
    {
        protected Køretøj(Brændstof brændstof, int årgang)
        {
            Brændstof = brændstof;
            Årgang = årgang;
        }

        private string _navn;
        public string Navn
        {
            get { return _navn; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _navn = value;
            }
        }

        private decimal _km;
        public decimal Km
        {
            get { return _km; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                _km = value;
            }
        }

        private string _registreringsnummer;
        public string Registreringsnummer
        {
            get
            {
                return string.Format("**{0}**", _registreringsnummer.Substring(2, 3)) ;
            }
            set
            {
                if (ErGyldigtRegistreringsnummer(value))
                {
                    _registreringsnummer = value;
                }
                else
                {
                    throw new RegistreringnummerException("Registreringsnummeret er ikke gyldigt");
                }
                
            }
        }

        //TODO: skal opdateres så den er bedre
        private static bool ErGyldigtRegistreringsnummer(string value)
        {
            if (value.Length != 7)
            {
                return false;
            }
            int buf;
            return int.TryParse(value.Substring(2, 5), out buf);
        }

        public readonly int Årgang;

        private decimal _nyPris;
        public decimal NyPris
        {
            get { return _nyPris; }
            set
            {
                if (value < 0)
	            {
		            _nyPris = 0;
	            }
                else
                {
                    _nyPris = value;   
                }
            }
        }

        abstract public bool Trækkrog { get; set; } //TODO personbiler til erhverv være udstyret med en trækkrog

        public abstract Kørekorttype Kørekorttype { get; }

        private double _motorstørrelse;
        protected abstract double MaxMotorstørrelse { get; }
        protected abstract double MinMotorstørrelse { get; }
        public double Motorstørrelse
        {
            get { return _motorstørrelse; }
            set
            {
                if (MaxMotorstørrelse < value && value < MaxMotorstørrelse)
                {
                    _motorstørrelse = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }

        public double KmPrL;

        public readonly Brændstof Brændstof;

        public Energiklasse Energiklasse
        {
            get
            {
                double brændstofsforbrug = KmPrL;

                if (this is Autocamper) // TODO flyt til metode
                {
                    Varmesystem varm = ((Autocamper) this).Varmesystem;

                    switch (varm)
	                {
                        case Varmesystem.Gas:
                            brændstofsforbrug *= 0.9;
                            break;
                        case Varmesystem.Strøm:
                            brændstofsforbrug *= 0.8;
                            break;
                        case Varmesystem.Oliefyr:
                            brændstofsforbrug *= 0.7;
                            break;
	                }
                }

                if (Årgang < 2010)
                {
                    if (Brændstof == Brændstof.Diesel)
                    {
                        return Energimærke(brændstofsforbrug, 13, 18, 23);
                    }
                    return Energimærke(brændstofsforbrug, 10, 14, 18);
                }
                if (Brændstof == Brændstof.Diesel)
                {
                    return Energimærke(brændstofsforbrug, 15, 20, 25);
                }
                return Energimærke(brændstofsforbrug, 12, 16, 20);
            }
        }

        private static Energiklasse Energimærke(double brændstofsforbrug, int min, int mid, int max)
        {
            if (brændstofsforbrug >= max)
                return Energiklasse.A;
            if (brændstofsforbrug >= mid)
                return Energiklasse.B;
            if (brændstofsforbrug >= min)
                return Energiklasse.C;
            return Energiklasse.D;
        }

        public override string ToString() // TODO giv en sigende beskrivelse af køretøjet
        {
            return string.Format("Navn: {0}\nKilometer kørt: {1}\nKilometer Pr Liter: {2}\nEnergiklasse: {3}",Navn,Km,KmPrL,Energiklasse);
        }
        
    }
}
