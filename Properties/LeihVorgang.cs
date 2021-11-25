using System;
using System.Diagnostics;

namespace Buecherei.Properties
{
    public class LeihVorgang
    {
        public Exemplar GeliehenesExemplar { get; set; }
        public Guid Leihnummer { get; set; }
        public string Name { get; set; }
        public DateTime AbgabeDatum { get; set; }

        public LeihVorgang(Exemplar exemplar, string name)
        {
            GeliehenesExemplar = exemplar;
            Name = name;
            Leihnummer = Guid.NewGuid();
            AbgabeDatum = DateTime.Now.AddDays(30);
        }
    }
}