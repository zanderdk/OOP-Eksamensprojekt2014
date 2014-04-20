using System;

namespace OOP_EksamensOpgave2014
{
    public class Lastbil : StortKøretøj
    {
        public double Lasteevne;

        public Lastbil(String registreringsnummer, string navn, Brændstof brændstof, double motorStørelse, int årgang, double vægt)
            : base(registreringsnummer, navn ,brændstof, motorStørelse, årgang, vægt)
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
