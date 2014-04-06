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
                foreach (var auktion in _solgteKøretøjer)
                {
                    yield return auktion;
                }
            }
        }

        public int SætTilSalg(Køretøj k, Sælger s, decimal minPris)
        {
            return SætTilSalg(k, s, minPris, s.ModtagNotifikationOmBud);
        }

        public int SætTilSalg(Køretøj k, Sælger s, decimal minPris, EventHandler<Auktion.AuktionArgs> notifikationsMetode) 
        {
            Auktion nyAuktion = new Auktion(k, s, minPris);
            _salgsListe.Add(nyAuktion);
            nyAuktion.VedNytBud += notifikationsMetode;

            return nyAuktion.Auktionsnummer;
            // TODO test event delegate
        }

        public bool ModtagBud(Køber køber, int auktionsNummer, decimal bud)
        {
            //TODO skal vi bruge var?
            var auk = _salgsListe.Find(a => a.Auktionsnummer == auktionsNummer);
            if (auk == null)
            {
                throw new InvalidOperationException("Kan ikke find auktionsNummer");
            }
            if (auk.MinPris >= bud || køber.Saldo <= bud) return false;
            auk.AfgivBud(køber, bud);
            return true;
        }

        public bool AccepterBud(Sælger sælger, int auktionsNummer)
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
            //TODO
            return true;
        }
/*Ovenstående metode skal implementeres for at afslutte en handel med et bestemt
auktionsnummer. Der skal først laves et tjek på at den angivne sælger er identisk med den
sælger der har sat køretøjet til salg. Såfremt sælgerens identitet er i orden, så afsluttes salget
ved at købssummen trækkes fra købers saldo (den køber der har afgivet det største accepterede
bud). Herefter trækker auktionshuset sit salær i overensstemmelse med Tabel 1, og endelig
indsættes det resterende beløb på sælgers saldo. På dette tidspunkt skal køretøjet ikke længere
figurere som værende til salg i auktionshuset, men skal i stedet overgå til en liste af solgte
køretøjer. Listen af solgte køretøjer skal kunne gennemløbes udenfor AuktionsHus klassen.
Metodens returværdi angiver om handlen blev succesfuldt gennemført.*/

        // TODO disse retunere Auktioner for now, Det giver ikke rigtig mener at returnere køre tøjer
        // 1) Find køretøjer hvis navn indeholder en angivet søgestreng.
        public IEnumerable<Auktion> Søg(string søgestreng)
        {
            return _salgsListe.Where(a => a.Køretøj.Navn.Contains(søgestreng));
        }

        // 2) Find køretøjer der har et minimum angivet antal siddepladser samt toiletfaciliteter.
        public IEnumerable<Auktion> Pladser(int antal)
        {
            throw new System.NotImplementedException();
        }

        // 3) Find køretøjer der kræver stort kørekort (kategori C, D, CE eller DE) og vejer under en angivet 
        // maksimalvægt.
        public IEnumerable<Auktion> StortKørekort(double maksimalvægt)
        {
            //TODO hmmm
            return _salgsListe
                .Where(a => a.Køretøj is StortKøretøj)
                .Select(a => Tuple.Create<Auktion, StortKøretøj>(a, a.Køretøj as StortKøretøj))
                .Where(t => t.Item2.Vægt < maksimalvægt)
                .Select(t => t.Item1);
        }

        // 4) Find alle personbiler til privatbrug som har kørt under et angivet antal km, og hvor minimum
        // salgsprisen samtidig ligger under et angivet beløb. Køretøjerne skal returneres i sorteret
        // rækkefølge efter antal kørte km.
        public IEnumerable<Auktion> PrivatBiler(decimal maksimalKm, decimal maxMinPris)
        {
            //TODO hmmm
            return _salgsListe
                .Where(a => a.Køretøj is Privatbil)
                .Select(a => Tuple.Create<Auktion, Privatbil>(a, a.Køretøj as Privatbil))
                .Where(t => t.Item2.Km < maksimalKm)
                .Where(t => t.Item1.MinPris < maxMinPris)
                .OrderBy(t => t.Item2.Km)
                .Select(t => t.Item1);
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
                var test = a.Sælger.PostNummer;
                var min = postnummer - radius;
                var max = postnummer + radius;
                return min < test && test < max;
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
