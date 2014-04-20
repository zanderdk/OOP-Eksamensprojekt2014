using System;

namespace OOP_EksamensOpgave2014
{
    public class Lastbil : StortKøretøj
    {
        public double Lasteevne;

        public Lastbil(String registreringsnummer, string navn, Brændstof brændstof, double motorStørelse, int årgang)
            : base(registreringsnummer, navn ,brændstof, motorStørelse, årgang)
        {
        }

        public override Kørekorttype Kørekorttype
        {
            get
            {
                if (Trækkrog)
                {
                    return Kørekorttype.CE;
                }
                return Kørekorttype.C;
            }
        }   
    }
}
