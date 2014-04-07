﻿using System;

namespace OOP_EksamensOpgave2014
{
    public class Autocamper : Køretøj, IBeboelig
    {

        public Varmesystem Varmesystem;

        public Autocamper(Brændstof brændstof, int årgang, Varmesystem varmesystem)
            : base(brændstof, årgang)
        {
            Varmesystem = varmesystem;
        }

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

        public int Siddepladser { get; set; }
        public int Sovepladser { get; set; }
        public bool Toilet { get; set; }
    }
}
