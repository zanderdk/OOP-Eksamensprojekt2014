using System;
using System.Text.RegularExpressions;

namespace OOP_EksamensOpgave2014
{
    public abstract class Køretøj
    {
        protected Køretøj(Brændstof brændstof, int årgang)
        {
            Brændstof = brændstof;
            Årgang = årgang;
        }

        public readonly Brændstof Brændstof;
        public readonly int Årgang;

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

        private static bool ErGyldigtRegistreringsnummer(string value)
        {
            string mønster = @"^[a-zæøåA-ZÆØÅ]{2}\d{5}$";
            return Regex.Match(value, mønster).Success;
        }
        
        private decimal _nyPris;
        public decimal NyPris
        {
            get { return _nyPris; }
            set {
                _nyPris = value < 0 ? 0 : value;
            }
        }

        protected bool _trækkrog;
        public virtual bool Trækkrog
        {
            get { return _trækkrog; }
            set { _trækkrog = value; }
        }
        
        public abstract Kørekorttype Kørekorttype { get; }

        private double _motorstørrelse;
        protected abstract double MaxMotorstørrelse { get; }
        protected abstract double MinMotorstørrelse { get; }
        public double Motorstørrelse
        {
            get { return _motorstørrelse; }
            set
            {
                if (MinMotorstørrelse <= value && value <= MaxMotorstørrelse)
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
