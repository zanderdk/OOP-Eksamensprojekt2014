namespace OOP_EksamensOpgave2014
{
    public interface Sælger : ISaldo
    {
        int Postnummer { get; set; }
        void ModtagNotifikationOmBud(object sender, Auktion.AuktionArgs args);
    }
}
