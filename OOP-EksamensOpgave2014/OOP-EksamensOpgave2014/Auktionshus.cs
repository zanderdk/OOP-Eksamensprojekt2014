using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_EksamensOpgave2014
{
    public class Auktionshus
    {
        public Auktionshus()
        {
            _salgsListe = new List<Auktion>();
            _solgteKøretøjer = new List<Auktion>();
        }

        private readonly List<Auktion> _salgsListe;
        private readonly List<Auktion> _solgteKøretøjer;
        public IEnumerable<Auktion> SolgteKøretøjer
        {
            get
            {
                foreach (Auktion auktion in _solgteKøretøjer)
                {
                    yield return auktion;
                }
            }
        }

        public int SætTilSalg(Køretøj k, ISælger s, decimal minPris)
        {
            return SætTilSalg(k, s, minPris, s.ModtagNotifikationOmBud);
        }

        public int SætTilSalg(Køretøj k, ISælger s, decimal minPris, EventHandler<Auktion.AuktionArgs> notifikationsMetode) 
        {
            Auktion nyAuktion = new Auktion(k, s, minPris);
            _salgsListe.Add(nyAuktion);
            nyAuktion.VedNytBud += notifikationsMetode;

            return nyAuktion.Auktionsnummer;
            // TODO test event delegate
        }

        public bool ModtagBud(IKøber køber, int auktionsNummer, decimal bud)
        {
            Auktion auk = _salgsListe.Find(a => a.Auktionsnummer == auktionsNummer);
            if (auk == null)
            {
                throw new InvalidOperationException("Kan ikke find auktionsNummer");
            }
                       
            return auk.AfgivBud(køber, bud);
        }

        public bool AccepterBud(ISælger sælger, int auktionsNummer)
        {
            var auk = _salgsListe.Find(a => a.Auktionsnummer == auktionsNummer);
            if (auk == null)
            {
                throw new InvalidOperationException("Kan ikke find auktionsNummer");
            }
            if (!ReferenceEquals(sælger, auk.Sælger))
            {
                return false;
            }
            if (auk.HøjesteByder == null)
            {
                return false;
            }
            decimal købspris = auk.MinPris;
            IKøber køber = auk.HøjesteByder;

            køber.Saldo -= købspris;
            decimal salær = Salær(købspris);
            auk.Sælger.Saldo += købspris - salær;
            // salær forsvinder i intetheden

            _salgsListe.Remove(auk);
            _solgteKøretøjer.Add(auk);

            return true;
        }

        static private decimal Salær(decimal salgspris)
        {
            if (salgspris < 10000)
                return 1900;
            if (salgspris < 50000)
                return 2250;
            if (salgspris < 100000)
                return 2550;
            if (salgspris < 150000)
                return 2850;
            if (salgspris < 200000)
                return 3400;
            if (salgspris < 300000)
                return 3700;
            return 4400;
        }

        // TODO disse retunere Auktioner for now, Det giver ikke rigtig mener at returnere køre tøjer
        // 1) Find køretøjer hvis navn indeholder en angivet søgestreng.
        public IEnumerable<Auktion> Søg(string søgestreng)
        {
            return _salgsListe.Where(a => a.Køretøj.Navn.Contains(søgestreng));
        }

        // 2) Find køretøjer der har et minimum angivet antal siddepladser samt toiletfaciliteter.
        public IEnumerable<Auktion> Pladser(int antal)
        {
            return _salgsListe.Where(a => a.Køretøj is IBeboelig)
                .Where(a => (a.Køretøj as IBeboelig).Toilet)
                .Where(a => (a.Køretøj as IBeboelig).Siddepladser >= antal);
        }

        // 3) Find køretøjer der kræver stort kørekort (kategori C, D, CE eller DE) og vejer under en angivet 
        // maksimalvægt.
        public IEnumerable<Auktion> StortKørekort(double maksimalvægt)
        {
            return _salgsListe
                .Where(a => a.Køretøj is StortKøretøj)
                .Where(a => (a.Køretøj as StortKøretøj).Vægt < maksimalvægt);
        }

        // 4) Find alle personbiler til privatbrug som har kørt under et angivet antal km, og hvor minimum
        // salgsprisen samtidig ligger under et angivet beløb. Køretøjerne skal returneres i sorteret
        // rækkefølge efter antal kørte km.
        public IEnumerable<Auktion> PrivatBiler(decimal maksimalKm, decimal maxMinPris)
        {
            return _salgsListe
                .Where(a => a.Køretøj is Privatbil)
                .Where(t => t.Køretøj.Km < maksimalKm)
                .Where(t => t.MinPris < maxMinPris)
                .OrderBy(t => t.Køretøj.Km);
        }

        // 5) Find alle køretøjer hvor køretøjets sælger er bosiddende inden for en bestemt radius af et
        // angivet postnummer. I denne forbindelse kan radius blot anskues som et tal der skal lægges
        // til/trækkes fra postnummeret. F.eks. vil en søgning efter køretøjer indenfor en radius af 1500 fra
        // postnummer 8000, inkludere alle køretøjer hvor sælgers postnummer ligger mellem 6500 og
        // 9500.
        public IEnumerable<Auktion> Nærliggende(int postnummer, int radius)
        {
            return _salgsListe.Where(a =>
            {
                int post = a.Sælger.Postnummer;
                int min = postnummer - radius;
                int max = postnummer + radius;
                return min <= post && post <= max;
            });
        }

        // Til slut, lav en metode der returnerer den gennemsnitlige energi-klasse for alle køretøjer til salg. I den
        // forbindelse kan energi-klasserne konverteres til tal (A = 1, B = 2, C = 3, D = 4). Afrund resultatet til
        // nærmeste heltal inden den tilhørende energiklasse returneres.
        // Vi konvertere til 0 1 2 3, det skulle gerne give det samme resultat
        public Energiklasse GennemsnitligeEnergiKlasse()
        {
            double gennemsnit = _salgsListe.Average(a => (int)a.Køretøj.Energiklasse);
            int afrundet = Convert.ToInt32(gennemsnit);
            return (Energiklasse) afrundet;
        }
    }
}
