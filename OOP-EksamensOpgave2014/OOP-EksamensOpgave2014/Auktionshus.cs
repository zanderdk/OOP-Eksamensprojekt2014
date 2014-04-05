using System;
using System.Collections.Generic;

namespace OOP_EksamensOpgave2014
{
    public class Auktionshus
    {



        public Auktionshus()
        {
            _salgslist = new List<Auktion>();
            _solgtekøretøjer = new List<Auktion>();
        }

        private List<Auktion> _salgslist;
        private List<Auktion> _solgtekøretøjer;

        public int SætTilSalg(Køretøj k, Sælger s, decimal minPris)
        {
            Auktion nyAuktion = new Auktion(k, s, minPris);
            _salgslist.Add(nyAuktion);
            nyAuktion.VedNytBud += s.ModtagNotifikationOmBud;

            return nyAuktion.Auktionsnummer;
            // TODO test event delegate
        }

        public int SætTilSalg(Køretøj k, Sælger s, decimal minPris, Action<object, Auktion.AuktionArgs> notifikationsMetode) 
        {
            throw  new NotImplementedException();
        }

        public bool ModtagBud(Køber køber, int auktionsNummer, decimal bud)
        {
            throw  new NotImplementedException();
        }

        public bool AccepterBud(Sælger sælger, int auktionsNummer)
        {
            throw  new NotImplementedException();
        }
    }
}
