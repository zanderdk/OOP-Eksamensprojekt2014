namespace OOP_EksamensOpgave2014
{
    public abstract class Personbil : Køretøj
    {
        public abstract int AntalSæder {get; set;} //TODO
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
