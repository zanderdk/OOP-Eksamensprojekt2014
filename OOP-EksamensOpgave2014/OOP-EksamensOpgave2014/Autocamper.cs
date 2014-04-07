using System;

namespace OOP_EksamensOpgave2014
{
    public class Autocamper : Køretøj, IBeboelig
    {

        public Varmesystem Varmesystem;

        public Autocamper(Brændstof brændstof, int årgang, Varmesystem varmesystem)
            : base(brændstof, årgang)
        {
            Varmesystem = varmesystem;
        }

        public override Kørekorttype Kørekorttype
        {
            get
            {
                return Kørekorttype.B;
            }
        }

        protected override double MaxMotorstørrelse
        {
            get { return 6.2; }
        }

        protected override double MinMotorstørrelse
        {
            get { return 2.4; }
        }

        public int Siddepladser { get; set; }
        public int Sovepladser { get; set; }
        public bool Toilet { get; set; }

        internal static double EnergimærkeRegner(Køretøj køretøj, double brændstofsforbrug)
        {
            Varmesystem varm = ((Autocamper)køretøj).Varmesystem;

            switch (varm)
            {
                case Varmesystem.Gas:
                    brændstofsforbrug *= 0.9;
                    break;
                case Varmesystem.Strøm:
                    brændstofsforbrug *= 0.8;
                    break;
                case Varmesystem.Oliefyr:
                    brændstofsforbrug *= 0.7;
                    break;
             }
            return brændstofsforbrug;            
        }
    }
}
