using System;

namespace OOP_EksamensOpgave2014
{
    public class Auktion
    {
        public readonly Køretøj Køretøj;
        public readonly ISælger Sælger;
        public readonly int Auktionsnummer;
        public IKøber HøjesteByder { get; set; }
        public decimal MinPris { get; private set; }

        public Auktion(Køretøj køretøj, ISælger sælger, decimal minPris)
        {
            MinPris = minPris;
            Sælger = sælger;
            Køretøj = køretøj;
            Auktionsnummer = NextId++;
        }

        static Auktion()
        {
            NextId = 0;
        }
        public static int NextId { get; private set; }

        public event EventHandler<AuktionArgs> VedNytBud = delegate { };
        protected virtual void _vedNytBud(AuktionArgs e)
        {
            VedNytBud(this, e);
        }

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

        public void AfgivBud(IKøber køber, decimal bud)
        {
            MinPris = bud;
            HøjesteByder = køber;
            var args = new AuktionArgs(Auktionsnummer, bud);
            _vedNytBud(args);
        }
    }
}
