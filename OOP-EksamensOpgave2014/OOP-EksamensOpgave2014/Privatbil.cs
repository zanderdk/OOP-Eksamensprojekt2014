using System;

namespace OOP_EksamensOpgave2014
{
    // Personbil til privat brug
    class Privatbil : Personbil
    {
        public bool IsofixBeslag;

        public Privatbil(Brændstof brændstof, int årgang, int antalSæder)
            : base(brændstof, årgang)
        {
            // TODO vi skal havde kigget på sæder
            AntalSæder = antalSæder;
        }

        public override int AntalSæder
        {
            get { return _antalSæder; }
            set
            {
                if (value < 2 || value > 7)
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
