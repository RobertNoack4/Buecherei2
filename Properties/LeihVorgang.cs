using System;
using System.Diagnostics;
using ConsoleTables;
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
        public string Downloadlink { get; set; }

        public LeihVorgang(Exemplar exemplar, string name, int tage)
        {
            GeliehenesExemplar = exemplar;
            Name = name;
            Leihnummer = Guid.NewGuid();
            AbgabeDatum = DateTime.Now.AddDays(tage).Date;
        }

        public LeihVorgang(Exemplar exemplar, string name, int tage, string downloadlink)
        {
            GeliehenesExemplar = exemplar;
            Name = name;
            Leihnummer = Guid.NewGuid();
            AbgabeDatum = DateTime.Now.AddDays(tage).Date;
            Downloadlink = downloadlink;
        }

        [JsonConstructor]
        public LeihVorgang(Guid exemplarId, Guid leihnummer, string name, DateTime abgabeDatum, string downloadlink)
        {
            ExemplarId = exemplarId;
            Name = name;
            Leihnummer = leihnummer;
            AbgabeDatum = abgabeDatum;
            Downloadlink = downloadlink;
        }


        public void ExemplarHinzufuegen(Exemplar exemplar)
        {
            GeliehenesExemplar = exemplar;
        }
    }
}