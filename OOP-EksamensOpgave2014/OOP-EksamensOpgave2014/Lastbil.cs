using System;

namespace OOP_EksamensOpgave2014
{
    public class Lastbil : StortKøretøj
    {
        public double Lasteevne;

        public Lastbil(Brændstof brændstof, int årgang) : base(brændstof, årgang)
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
