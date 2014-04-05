using System;
using System.Collections.Generic;

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
    }
}
