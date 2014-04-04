namespace OOP_EksamensOpgave2014
{
    abstract public class StortKøretøj : Køretøj
    {
        public double Højde;
        public double Længde;
        public double Vægt;

        protected StortKøretøj(Brændstof brændstof, int årgang) : base(brændstof, årgang)
        {
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
