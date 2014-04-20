using System;

namespace OOP_EksamensOpgave2014
{
    public abstract class StortKøretøj : Køretøj
    {
        public double Højde;
        public double Længde;
        public double Vægt;

        protected StortKøretøj(string registreringsnummer, string navn, Brændstof brændstof, double motorStørelse, int årgang)
            : base(registreringsnummer, navn, brændstof, motorStørelse, årgang)
        {
            if (brændstof == Brændstof.Benzin)
            {
                throw new ArgumentException("StortKøretøj kan kun køre på diesel");
            }
        }

        protected override double MinMotorstørrelse
        {
            get { return 4.2; }
        }

        protected override double MaxMotorstørrelse
        {
            get { return 15; }
        }
    }
}
