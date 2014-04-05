using System;

namespace OOP_EksamensOpgave2014
{
    public interface Sælger : ISaldo
    {
        int PostNummer { get; set; }
        void ModtagNotifikationOmBud(object sender, EventArgs args);
    }
}
