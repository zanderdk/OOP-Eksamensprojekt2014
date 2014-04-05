using System;

namespace OOP_EksamensOpgave2014
{
    public class Auktionshus
    {
        //TODO skal havde en list over ting til salg

        //solgte køretøjer

        public int SætTilSalg(Køretøj k, Sælger s, decimal minPris)
        {
            throw  new NotImplementedException();
        }
        /*Et køretøj sættes til salg via ovenstående metode, hvor k er køretøjet der sættes til salg, s er
sælgeren, og minPris angiver mindstebeløbet før sælger vil overveje at sælge. Når der kommer
et bud der overstiger den angivne minimumpris, skal sælgeren notificeres herom via sælgers
ModtagNotifikationOmBud(..) metode. Endeligt skal der returneres et unikt auktionsnummer
der kan bruges til senere at referere til det givne køretøj der er sat til salg.*/

        public int SætTilSalg(Køretøj k, Sælger s, decimal minPris, object notifikationsMetode) // TODO find en passende type til notifikationsMetode
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
