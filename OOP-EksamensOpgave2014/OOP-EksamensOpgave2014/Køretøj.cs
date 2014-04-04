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

        abstract public bool Trækkrog {get; set;} //TODO

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

                if (Årgang < 2010) //TODO: refactor
                {
                    if (Brændstof == Brændstof.Diesel)
                    {
                        if (brændstofsforbrug >= 23)
                        {
                            return Energiklasse.A;
                        }
                        else if (brændstofsforbrug >= 18)
                        {
                            return Energiklasse.B;
                        }
                        else if (brændstofsforbrug >= 13)
                        {
                            return Energiklasse.C;
                        }
                        else
                        {
                            return Energiklasse.D;
                        }
                    }
                    else
                    {
                        if (brændstofsforbrug >= 18)
                        {
                            return Energiklasse.A;
                        }
                        else if (brændstofsforbrug >= 14)
                        {
                            return Energiklasse.B;
                        }
                        else if (brændstofsforbrug >= 10)
                        {
                            return Energiklasse.C;
                        }
                        else
                        {
                            return Energiklasse.D;
                        }
                    }
                }
                else
                {
                    if (Brændstof == Brændstof.Diesel)
                    {
                        if (brændstofsforbrug >= 25)
                        {
                            return Energiklasse.A;
                        }
                        else if (brændstofsforbrug >= 20)
                        {
                            return Energiklasse.B;
                        }
                        else if (brændstofsforbrug >= 15)
                        {
                            return Energiklasse.C;
                        }
                        else
                        {
                            return Energiklasse.D;
                        }
                    }
                    else
                    {
                        if (brændstofsforbrug >= 20)
                        {
                            return Energiklasse.A;
                        }
                        else if (brændstofsforbrug >= 16)
                        {
                            return Energiklasse.B;
                        }
                        else if (brændstofsforbrug >= 12)
                        {
                            return Energiklasse.C;
                        }
                        else
                        {
                            return Energiklasse.D;
                        }
                    }
                }
            }
        }

        public override string ToString() // TODO giv en sigende beskrivelse af køretøjet
        {
            return string.Format("Navn: {0}\nKilometer kørt: {1}\nKilometer Pr Liter: {2}\nEnergiklasse: {3}",Navn,Km,KmPrL,Energiklasse);
        }
        
    }
}
