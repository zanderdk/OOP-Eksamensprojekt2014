using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_EksamensOpgave2014
{
    public class Lastbil : Køretøj
    {
        public double Lasteevne; // Måske lidt forvirende når evher også har
        public double Højde;
        public double Længde;
        public double Vægt;

        public override Kørekorttype Kørekorttype
        {
            get
            {
                if (this.Trækkrog)
                {
                    return Kørekorttype.CE;
                }
                return Kørekorttype.C;
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
