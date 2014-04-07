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

        // 1) Find køretøjer hvis navn indeholder en angivet søgestreng.
        public IEnumerable<Køretøj> Søg(string søgestreng)
        {
            return _salgsListe.Select(a => a.Køretøj)
                .Where(k => k.Navn.Contains(søgestreng));
        }

        // 2) Find køretøjer der har et minimum angivet antal siddepladser samt toiletfaciliteter.
        public IEnumerable<Køretøj> Pladser(int antal)
        {
            return _salgsListe.Select(a => a.Køretøj)
                .OfType<IBeboelig>()
                .Where(k => k.Toilet)
                .Where(k => k.Siddepladser >= antal)
                .Select(k => k as Køretøj);
        }

        // 3) Find køretøjer der kræver stort kørekort (kategori C, D, CE eller DE) og vejer under en angivet 
        // maksimalvægt.
        public IEnumerable<Køretøj> StortKørekort(double maksimalvægt)
        {
            return _salgsListe.Select(a => a.Køretøj)
                .OfType<StortKøretøj>()
                .Where(k => k.Vægt < maksimalvægt)
                .Select(k => k as Køretøj);
        }

        // 4) Find alle personbiler til privatbrug som har kørt under et angivet antal km, og hvor minimum
        // salgsprisen samtidig ligger under et angivet beløb. Køretøjerne skal returneres i sorteret
        // rækkefølge efter antal kørte km.
        public IEnumerable<Køretøj> PrivatBiler(decimal maksimalKm, decimal maxMinPris)
        {
            return _salgsListe.Select(a => a.Køretøj)
                .Where(k => k is Privatbil)
                .Where(k => k.Km < maksimalKm)
                .Where(k => k.Auktion.MinPris < maxMinPris)
                .OrderBy(k => k.Km);
        }

        // 5) Find alle køretøjer hvor køretøjets sælger er bosiddende inden for en bestemt radius af et
        // angivet postnummer. I denne forbindelse kan radius blot anskues som et tal der skal lægges
        // til/trækkes fra postnummeret. F.eks. vil en søgning efter køretøjer indenfor en radius af 1500 fra
        // postnummer 8000, inkludere alle køretøjer hvor sælgers postnummer ligger mellem 6500 og
        // 9500.
        public IEnumerable<Køretøj> Nærliggende(int postnummer, int radius)
        {
            return _salgsListe.Where(a =>
            {
                int post = a.Sælger.Postnummer;
                int min = postnummer - radius;
                int max = postnummer + radius;
                return min <= post && post <= max;
            }).Select(a => a.Køretøj);
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

        //  Listen af solgte køretøjer skal kunne gennemløbes udenfor AuktionsHus klassen.
        public IEnumerable<Auktion> SolgteKøretøjer
        {
            get
            {
                foreach (Auktion auktion in _solgteKøretøjer)
                    yield return auktion;
            }
        }
    }
}
