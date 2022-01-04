using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Buecherei.Properties
{
    [JsonObject(MemberSerialization.Fields)]
    public class Buch : IProduct
    {
        private string Author { get; set; }
        private string Country { get; set; }
        private string ImageLink { get; set; }
        private string Language { get; set; }
        private string Link { get; set; }
        private int Pages { get; set; }
        private string Title { get; set; }
        private int Year { get; set; }
        private string Art { get; set; }
        private string DownloadLink { get; set; }
        private List<Exemplar> Exemplare { get; set; }
        private Guid BuchId { get; set; }

        public Buch(string author, string country, string imageLink, string language, string link, int pages,
            string title, int year)
        {
            Author = author;
            Country = country;
            ImageLink = imageLink;
            Language = language;
            Link = link;
            Pages = pages;
            Title = title;
            Year = year;
            Art = "Buch";
            DownloadLink = "www.Buchladen.de/" + Title.Trim();
            BuchId = Guid.NewGuid();
            Exemplare = new List<Exemplar>();
        }

        [JsonConstructor]
        public Buch(string author, int pages, string title, Guid guid, string country, string imageLink, string language, string link, 
             int year)
        {
            Art = "Buch";
            Author = author;
            Country = country;
            ImageLink = imageLink;
            Language = language;
            Link = link;
            Pages = pages;
            Title = title;
            Year = year;
            BuchId = guid;
            Exemplare = new List<Exemplar>();
        }

        public string InformationenAusgeben(string art)
        {
            switch(art)
            {
                case "Titel":
                    return Title;
                case "Art":
                    return Art;
                case "Author":
                    return Author;
                case "Jahr":
                    return Year.ToString();
                case "Land":
                    return Country;
                case "Sprache":
                    return Language;
                case "Seiten":
                    return Pages.ToString();
                case "Link":
                    return Link;
                case "Bild":
                    return ImageLink;
                case "Download":
                    return DownloadLink;
                default:
                    return "Ein fehler ist aufgetreten!";
            }
        }

        public void Aenderung(string art, string aenderung)
        {
            switch(art)
            {
                case "Author":
                    Author = aenderung;
                    return;
                case "Titel":
                    Title = aenderung;
                    return;
                case "Jahr":
                    Year = Convert.ToInt32(aenderung);
                    return;
                case "Land":
                    Country = aenderung;
                    return;
                case "Sprache":
                    Language = aenderung;
                    return;
                case "Seiten":
                    Pages = Convert.ToInt32(aenderung);
                    return;
                case "Link":
                    Link = aenderung;
                    return;
                case "Bild":
                    ImageLink = aenderung;
                    return;
                default:
                    Console.WriteLine("Es ist ein Fehler aufgetreten");
                    return;
            }
        }

        public Guid IdAusgeben()
        {
            return BuchId;
        }

        public void BuchIdGenerieren()
        {
            this.BuchId = Guid.NewGuid();
        }

        public void ExemplarHinzufuegen(Exemplar exemplar)
        {
            Exemplare.Add(exemplar);
            exemplar.GehoertZu = IdAusgeben();
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
            DownloadLink = "www.Buchladen.de/" + this.Title.Replace(" ", "");
        }


    }
}