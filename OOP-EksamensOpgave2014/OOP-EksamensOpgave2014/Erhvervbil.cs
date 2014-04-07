using System;

namespace OOP_EksamensOpgave2014
{
    // Personbil til erhverv
    public class Erhvervbil : Personbil
    {
        public bool Sikkerhedsbøjle;

        public double Lasteevne;

        public Erhvervbil(String registreringsnummer, string navn, Brændstof brændstof, double motorStørelse, int årgang, int sæder, bool trækkrog)
            : base(registreringsnummer, navn , brændstof, motorStørelse, årgang, sæder)
        {
            if (trækkrog)
            {
                _trækkrog = true;
            }
            else
            {
                throw new ArgumentException("Personbiler til erhverv skal være udstyret med en trækkrog");
            }
            
        }

        public override Kørekorttype Kørekorttype
        {
            get
            {
                if (Lasteevne > 750)
                {
                    return Kørekorttype.BE;
                }
                return Kørekorttype.B;
            }
        }

        public override int AntalSæder
        {
            get { return _antalSæder; }
            set
            {
                if (value != 2)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                _antalSæder = value;
            }
        }

        public override bool Trækkrog
        {
            get { return _trækkrog; }
            set 
            {
                if (value)
                {
                    _trækkrog = true;
                }
                else
                {
                    throw new ArgumentException("Personbiler til erhverv skal være udstyret med en trækkrog");
                }
            }
        }
    }
}
