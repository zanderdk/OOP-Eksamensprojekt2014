using System;

namespace OOP_EksamensOpgave2014
{
    public class Autocamper : Køretøj
    {
        public int Siddepladser;
        public int Sovepladser;
        public bool Toilet;
        public Varmesystem Varmesystem;

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

    }
}
