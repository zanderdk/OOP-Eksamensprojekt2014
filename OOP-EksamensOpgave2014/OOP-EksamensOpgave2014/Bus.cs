namespace OOP_EksamensOpgave2014
{
    public class Bus : StortKøretøj, IBeboelig
    {
        public Bus(Brændstof brændstof, int årgang) : base(brændstof, årgang)
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
