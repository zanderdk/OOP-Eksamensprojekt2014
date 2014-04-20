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

        public readonly ISælger Sælger;
        public readonly int Auktionsnummer;
        public IKøber HøjesteByder { get; set; }


        public decimal MinPris { get; private set; }
        public Auktion(Køretøj køretøj, ISælger sælger, decimal minPris)
        {
            if (køretøj == null || sælger == null)
            {
                throw new ArgumentNullException("sælger og køretøj kan ikke være null.");
            }
            MinPris = minPris;
            Sælger = sælger;
            _Køretøj = køretøj;
            Auktionsnummer = NextId++;

            køretøj.Auktion = this;
        }

        public event EventHandler<AuktionArgs> VedNytBud = delegate {};
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

        public bool AfgivBud(IKøber køber, decimal bud)
        {       
            if (this.MinPris >= bud) return false;

            if (køber is Firma)
            {
                if (køber.Saldo + (køber as Firma).Kredit < bud) return false;
            }
            else
            {
                if (køber.Saldo < bud) return false;
            }
            
            MinPris = bud;
            HøjesteByder = køber;
            var args = new AuktionArgs(Auktionsnummer, bud);

            _vedNytBud(args);
            
            return true;

        }

    }
}
