using System;

namespace OOP_EksamensOpgave2014
{
    // Personbil til erhverv
    class Erhvervbil : Personbil
    {
        public bool Sikkerhedsbøjle;

        public double Lasteevne;

        public Erhvervbil(Brændstof brændstof, int årgang, int antalSæder)
            : base(brændstof, årgang)
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
            get
            {
                return true;
            }
            set 
            {
                throw new NotImplementedException();
            }
        }
    }
}
