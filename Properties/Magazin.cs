using System;
using Newtonsoft.Json;

namespace Buecherei.Properties
{
    public class Magazin : IProduct
    {
        public int Rang { get; set; }
        public string Titel { get; set; }
        public string Auflage { get; set; }
        public string Gruppe { get; set; }
        public string Sachgruppe { get; set; }
        public string Verlag { get; set; }
        public string Art { get; set; }
        public Guid MagazinId { get; set; }

        public Magazin(int rang, string titel, string auflage, string gruppe, string sachgruppe, string verlag)
        {
            Rang = rang;
            Titel = titel;
            Auflage = auflage;
            Gruppe = gruppe;
            Sachgruppe = sachgruppe;
            Verlag = verlag;
            Art = "Magazin";
            MagazinId = Guid.NewGuid();
        }
        
        [JsonConstructor]
        public Magazin(int rang, string titel, string auflage, string gruppe, string sachgruppe, string verlag, Guid guid)
        {
            Rang = rang;
            Titel = titel;
            Auflage = auflage;
            Gruppe = gruppe;
            Sachgruppe = sachgruppe;
            Verlag = verlag;
            MagazinId = guid;
            Art = "Magazin";
        }

        public void IdGenerieren()
        {
            MagazinId = Guid.NewGuid();
        }

        public string TitelAusgeben()
        {
            return Titel;
        }
        public string ArtAusgeben()
        {
            return Art;
        }
    }
}