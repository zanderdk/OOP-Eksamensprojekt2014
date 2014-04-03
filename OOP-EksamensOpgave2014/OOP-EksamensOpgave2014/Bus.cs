using System;

namespace OOP_EksamensOpgave2014
{
    public class Bus : StortKøretøj
    {
        public int Siddepladser;
        public int Sovepladser;
        public bool Toilet;

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
