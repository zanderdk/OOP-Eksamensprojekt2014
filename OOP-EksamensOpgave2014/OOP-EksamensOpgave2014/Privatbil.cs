﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_EksamensOpgave2014
{
    // Personbil til privat brug
    class Privatbil : Personbil
    {
        public bool IsofixBeslag;

        public override int AntalSæder
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

        public override Kørekorttype Kørekorttype
        {
            get
            {
                return Kørekorttype.B;
            }
        }
    }
}
