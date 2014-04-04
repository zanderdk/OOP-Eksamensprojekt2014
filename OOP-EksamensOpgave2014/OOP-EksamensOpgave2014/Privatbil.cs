using System;

namespace OOP_EksamensOpgave2014
{
    // Personbil til privat brug
    class Privatbil : Personbil
    {
        public bool IsofixBeslag;

        public Privatbil(Brændstof brændstof, int årgang) : base(brændstof, årgang)
        {
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

        public override Kørekorttype Kørekorttype
        {
            get
            {
                return Kørekorttype.B;
            }
        }
    }
}
