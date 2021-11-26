using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Buecherei.Properties
{
    public class LeihVorgang
    {
        public Exemplar GeliehenesExemplar { get; set; }
        public Guid ExemplarId { get; set; }
        public Guid Leihnummer { get; set; }
        public string Name { get; set; }
        public DateTime AbgabeDatum { get; set; }

        public LeihVorgang(Exemplar exemplar, string name)
        {
            GeliehenesExemplar = exemplar;
            Name = name;
            Leihnummer = Guid.NewGuid();
            AbgabeDatum = DateTime.Now.AddDays(30).Date;
        }

        [JsonConstructor]
        public LeihVorgang(Guid exemplarID, Guid leihnummer, string name, DateTime abgabeDatum)
        {
            ExemplarId = exemplarID;
            Name = name;
            Leihnummer = leihnummer;
            AbgabeDatum = abgabeDatum;
        }


        public void ExemplarHinzufuegen(Exemplar exemplar)
        {
            GeliehenesExemplar = exemplar;
        }
    }
}