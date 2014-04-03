using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_EksamensOpgave2014
{
    public class Autocamper : Køretøj
    {
        public int Siddepladser;
        public int Sovepladser;
        public bool Toilet;
        public Varmesystem Varmesystem;
        public override int Energiklasse //TODO
        {
            get
            {
                return base.Energiklasse;
            }
        }

        public override Kørekorttype Kørekorttype {get; set;}

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

        public override double Motorstørrelse
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
