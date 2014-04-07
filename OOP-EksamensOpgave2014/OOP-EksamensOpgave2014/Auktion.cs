using System;

namespace OOP_EksamensOpgave2014
{
    public class Auktion
    {
        private Køretøj _Køretøj;
        public Køretøj Køretøj 
        { 
            get { return _Køretøj; } 

        }

        public readonly Sælger Sælger;
        public readonly int Auktionsnummer;
        public Køber HøjesteByder { get; set; }


        public decimal MinPris { get; private set; }
        // TODO immutable for now, M:Forklar immutable
        public Auktion(Køretøj køretøj, Sælger sælger, decimal minPris)
        {
            MinPris = minPris;
            Sælger = sælger;
            _Køretøj = køretøj;
            Auktionsnummer = NextId++;

            if(køretøj == null || sælger == null)
            {
                throw new ArgumentNullException("sælger og køretøj kan ikke være null.");
            }

            _Køretøj = køretøj;

            køretøj.Auktion = this;

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

        public void AfgivBud(Køber køber, decimal bud)
        {
            MinPris = bud;
            HøjesteByder = køber;
            var args = new AuktionArgs(Auktionsnummer, bud);
            _vedNytBud(args);
        }
    }
}
