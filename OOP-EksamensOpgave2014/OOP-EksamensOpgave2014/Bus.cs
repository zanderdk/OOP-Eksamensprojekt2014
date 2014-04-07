namespace OOP_EksamensOpgave2014
{
    public class Bus : StortKøretøj, IBeboelig
    {
        public Bus(string registreringsnummer, string navn, Brændstof brændstof, double motorStørelse, int årgang)
            : base(registreringsnummer, navn ,brændstof, motorStørelse, årgang)
        {
        }

        public override Kørekorttype Kørekorttype
        {
            get
            {
                if (Trækkrog)
                {
                    return Kørekorttype.DE;
                }
                return Kørekorttype.D;
            }
        }

        public int Siddepladser { get; set; }
        public int Sovepladser { get; set; }
        public bool Toilet { get; set; }
    }
}
