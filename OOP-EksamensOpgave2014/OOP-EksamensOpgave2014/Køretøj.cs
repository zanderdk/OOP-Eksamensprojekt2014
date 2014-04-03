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
        public string Navn
        {
            get { return navn; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Kan ikke sætte et bil navn til null");
                }
                navn = value;
            }
        }

        private decimal km;
        public decimal Km
        {
            get { return km; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Et køretøj kan ikke havde køre minus km");
                }
                km = value;
            }
        }

        private string registreringsnummer;
        public string Registreringsnummer
        {
            get
            {
                return string.Format("**{0}**", registreringsnummer.Substring(2, 3)) ;
            }
            set
            {
                if (ErGyldigtRegistreringsnummer(value))
                {
                    registreringsnummer = value;
                }
                else
                {
                    throw new RegistreringnummerException("Registreringsnummeret er ikke gyldigt");
                }
                
            }
        }

        //TODO: skal opdateres så den er bedre
        private bool ErGyldigtRegistreringsnummer(string value)
        {
            if (value.Length != 7)
            {
                return false;
            }
            int buf;
            return int.TryParse(value.Substring(2, 5), out buf);
        }

        public readonly int Årgang; // TODO en construkter der sætter denne

        private decimal nyPris;
        public decimal NyPris
        {
            get { return nyPris; }
            set
            {
                if (value < 0)
	            {
		            nyPris = 0;
	            }
                else
                {
                    nyPris = value;   
                }
            }
        }

        abstract public bool Trækkrog {get; set;}

        public abstract Kørekorttype Kørekorttype { get; }

        abstract public double Motorstørrelse {get; set;}

        public double KmPrL;

        public readonly Brændstof Brændstof;

        public Energiklasse Energiklasse
        {
            get
            {
                double brændstofsforbrug = this.KmPrL;

                if (this is Autocamper) // TODO flyt til metode
                {
                    Varmesystem varm = (this as Autocamper).Varmesystem;

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
                        default:
                            break;
	                }
                }

                if (this.Årgang < 2010) //TODO: refactor
                {
                    if (this.Brændstof == Brændstof.Diesel)
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
                    if (this.Brændstof == Brændstof.Diesel)
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

        public override string ToString() // TODO
        {
            return base.ToString();
        }
        
    }
}
