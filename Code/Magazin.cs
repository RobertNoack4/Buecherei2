using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Buecherei.Properties
{
    [JsonObject(MemberSerialization.Fields)]
    public class Magazin : IProduct
    {
        private int Rang { get; set; }
        private string Titel { get; set; }
        private string Auflage { get; set; }
        private string Gruppe { get; set; }
        private string SachGruppe { get; set; }
        private string Verlag { get; set; }
        private string Art { get; set; }
        private string DownloadLink { get; set; }
        private List<Exemplar> Exemplare { get; set; }
        private Guid MagazinId { get; set; }

        public Magazin(int rang, string titel, string auflage, string gruppe, string sachgruppe, string verlag)
        {
            Exemplare = new List<Exemplar>();
            Rang = rang;
            Titel = titel;
            Auflage = auflage;
            Gruppe = gruppe;
            SachGruppe = sachgruppe;
            Verlag = verlag;
            Art = "Magazin";
            MagazinId = Guid.NewGuid();
        }
        
        [JsonConstructor]
        public Magazin(int rang, string titel, string auflage, string gruppe, string sachgruppe, string verlag, Guid guid, string downlod)
        {
            Exemplare = new List<Exemplar>();
            Rang = rang;
            Titel = titel;
            Auflage = auflage;
            Gruppe = gruppe;
            SachGruppe = sachgruppe;
            Verlag = verlag;
            MagazinId = guid;
            DownloadLink = downlod;
            Art = "Magazin";
        }

        public string InformationenAusgeben(string art)
        {
            switch(art)
            {
                case "Titel":
                    return Titel;
                case "Art":
                    return Art;
                case "Rang":
                    return Rang.ToString();
                case "Auflage":
                    return Auflage;
                case "Gruppe":
                    return Gruppe;
                case "SachGruppe":
                    return SachGruppe;
                case "Verlag":
                    return Verlag;
                case "Download":
                    return DownloadLink;
                default:
                    return "Es ist ein Fehler passiert";
            }
        }

        public void Aenderung(string art, string aenderung)
        {
            switch(art)
            {
                case "Titel":
                    Titel = aenderung;
                    return;
                case "Rang":
                    Rang = Convert.ToInt32(aenderung);
                    return;
                case "Auflage":
                    Auflage = aenderung;
                    return;
                case "Gruppe":
                    Gruppe = aenderung;
                    return;
                case "SachGruppe":
                    SachGruppe = aenderung;
                    return;
                case "Verlag":
                    Verlag = aenderung;
                    return;
                default:
                    Console.WriteLine("Es ist ein Fehler aufgetreten");
                    return;
            }
        }


        public void IdGenerieren()
        {
            MagazinId = Guid.NewGuid();
        }

        public Guid IdAusgeben()
        {
            return MagazinId;
        }

        public int ExemplareVerfuegbar()
        {
            int verfuegbareExemplare = 0;
            foreach (Exemplar exemplar in Exemplare)
            {
                if (exemplar.Verfuegbar == true)
                {
                    verfuegbareExemplare++;
                }
            }

            return verfuegbareExemplare;
        }

        public void ExemplarHinzufuegen(Exemplar exemplar)
        {
            Exemplare.Add(exemplar);
            exemplar.GehoertZu = IdAusgeben();
        }

        public Exemplar VerfuegbaresExemplarAusgeben()
        {
            foreach (Exemplar exemplar in Exemplare)
            {
                if (exemplar.Verfuegbar == true)
                {
                    return exemplar;
                }
            }
            return null;
        }

        public List<Exemplar> AlleExemplareAusgeben()
        {
            return Exemplare;
        }

        public void ExemplarLoeschen(int position)
        {
            Exemplare.RemoveAt(position);
        }

        public void DownloadlinkGenerieren()
        {
            DownloadLink = "www.Buchladen.de/" + this.Titel.Replace(" ", "");
        }

    }
}