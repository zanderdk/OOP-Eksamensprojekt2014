using System;

namespace OOP_EksamensOpgave2014
{
    // Personbil til privat brug
    class Privatbil : Personbil
    {
        public bool IsofixBeslag;

        public Privatbil(Brændstof brændstof, int årgang)
            : base(brændstof, årgang)
        {
            
        }

        // TODO vi skal havde kigget på sæder
        public override int AntalSæder
        {
            get { return _antalSæder; }
            set
            {
                if (2 <= value && value >= 7)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                _antalSæder = value;
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
