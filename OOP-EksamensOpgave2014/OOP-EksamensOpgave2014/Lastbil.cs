using System;

namespace OOP_EksamensOpgave2014
{
    public class Lastbil : StortKøretøj
    {
        public double Lasteevne; // TODO: Måske lidt forvirende når evher også har, lav evt et interface

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

        public override bool Trækkrog
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        
    }
}
