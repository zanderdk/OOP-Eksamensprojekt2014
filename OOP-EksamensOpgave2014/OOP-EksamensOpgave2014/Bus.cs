using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_EksamensOpgave2014
{
    public class Bus : Køretøj
    {
        public int Siddepladser;
        public int Sovepladser;
        public bool Toilet;

        // TODO evt. lave et stor køretøj med disse
        public double Højde;
        public double Længde;
        public double Vægt;


        public override Kørekorttype Kørekorttype { get; set; } //TODO

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
