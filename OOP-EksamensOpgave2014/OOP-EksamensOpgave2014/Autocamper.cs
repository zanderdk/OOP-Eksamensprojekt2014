using System;

namespace OOP_EksamensOpgave2014
{
    public class Autocamper : Køretøj, IBeboelig
    {

        public Varmesystem Varmesystem;

        public Autocamper(string registreringsnummer, string navn , Brændstof brændstof, double motorStørelse, int årgang, Varmesystem varmesystem, int siddepladser, int sovepladser)
            : base(registreringsnummer, navn, brændstof, motorStørelse, årgang)
        {
            Varmesystem = varmesystem;
            Siddepladser = siddepladser;
            Sovepladser = Sovepladser;
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
    }
}
