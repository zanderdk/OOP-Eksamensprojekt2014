using System;

namespace OOP_EksamensOpgave2014
{
    // Personbil til privat brug
    public class Privatbil : Personbil
    {
        public bool IsofixBeslag;

        public Privatbil(String registreringsnummer, string navn, Brændstof brændstof, double motorStørelse, int årgang, int sæder)
            : base(registreringsnummer, navn, brændstof, motorStørelse, årgang, sæder)
        {
        }

        public override int AntalSæder
        {
            get { return _antalSæder; }
            set
            {
                if (2 <= value && value <= 7)
                {
                    _antalSæder = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                
            }
        }

        public override Kørekorttype Kørekorttype
        {
            get
            {
                return Kørekorttype.B;
            }
        }
    }
}
