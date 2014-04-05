namespace OOP_EksamensOpgave2014
{
    public class Salg //TODO bedre navn
    {
        public readonly Køretøj Køretøj;
        public readonly Sælger Sælger;
        public readonly int MinPris;

        public Salg(Køretøj køretøj, Sælger sælger, int minPris)
        {
            MinPris = minPris;
            Sælger = sælger;
            Køretøj = køretøj;
        }
    }
}
