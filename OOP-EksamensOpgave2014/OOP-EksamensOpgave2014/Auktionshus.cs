using System;

namespace OOP_EksamensOpgave2014
{
    public class Auktionshus
    {
        //TODO skal havde en list over ting til salg

        public int SætTilSalg(Køretøj k, Sælger s, decimal minPris)
        {
            throw  new NotImplementedException();
        }

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
