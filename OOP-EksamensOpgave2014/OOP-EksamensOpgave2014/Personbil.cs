using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_EksamensOpgave2014
{
    public abstract class Personbil : Køretøj
    {
        public abstract int AntalSæder {get; set;}
        public Dimensioner BagagerumsDimensioner;

    }
}
