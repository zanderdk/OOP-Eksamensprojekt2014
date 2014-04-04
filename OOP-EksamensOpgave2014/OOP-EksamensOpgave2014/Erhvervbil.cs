using System;

namespace OOP_EksamensOpgave2014
{
    // Personbil til erhverv
    class Erhvervbil : Personbil
    {
        public bool Sikkerhedsbøjle;

        public double Lasteevne;

        public Erhvervbil(Brændstof brændstof, int årgang) : base(brændstof, årgang)
        {
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
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
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
