namespace OOP_EksamensOpgave2014
{
    public abstract class Personbil : Køretøj
    {
        protected Personbil(Brændstof brændstof, int årgang) : base(brændstof, årgang)
        {
        }

        protected int _antalSæder;
        public abstract int AntalSæder {
            get;
            set;
        }
        
        public Dimensioner BagagerumsDimensioner;

        protected override double MaxMotorstørrelse
        {
            get { return 10; }
        }

        protected override double MinMotorstørrelse
        {
            get { return 0.7; }
        }
    }
}
