using System;

namespace OOP_EksamensOpgave2014
{
    public class Auktion //TODO bedre navn
    {
        public readonly Køretøj Køretøj;
        public readonly Sælger Sælger;
        public readonly decimal MinPris;
        public readonly int Auktionsnummer;

        // TODO immutable for now
        public Auktion(Køretøj køretøj, Sælger sælger, decimal minPris)
        {
            MinPris = minPris;
            Sælger = sælger;
            Køretøj = køretøj;
            Auktionsnummer = NextId++;
        }

        public event EventHandler<AuktionArgs> VedNytBud = delegate { };
        protected virtual void _vedNytBud(AuktionArgs e)
        {
            VedNytBud(this, e);
        }

        static Auktion()
        {
            NextId = 0;
        }
        public static int NextId { get; private set; }


        public class AuktionArgs : EventArgs
        {
            public readonly decimal Bud;
            public readonly int Auktionsnummer;

            public AuktionArgs(int auktionsnummer, decimal bud)
            {
                Auktionsnummer = auktionsnummer;
                Bud = bud;
            }
        }
    }
}
