using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using ConsoleTables;
using Newtonsoft.Json;

namespace Buecherei.Properties
{
    public class Buch : IProduct
    {
        public string Author { get; set; }
        public string Country { get; set; }
        public string ImageLink { get; set; }
        public string Language { get; set; }
        public string Link { get; set; }
        public int Pages { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Art { get; set; }
        public List<Exemplar> Exemplare { get; set; }
        public Guid BuchId { get; set; }

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
            BuchId = Guid.NewGuid();
            Exemplare = new List<Exemplar>();
        }

        [JsonConstructor]
        public Buch(string author, string country, string imageLink, string language, string link, int pages,
            string title, int year, Guid guid)
        {
            Author = author;
            Country = country;
            ImageLink = imageLink;
            Language = language;
            Link = link;
            Pages = pages;
            Title = title;
            Year = year;
            BuchId = guid;
            Art = "Buch";
            Exemplare = new List<Exemplar>();
        }

        public string TitelAusgeben()
        {
            return Title;
        }

        public string ArtAusgeben()
        {
            return Art;
        }
        public void ExemplarHinzufuegen(Exemplar exemplar)
        {
            Exemplare.Add(exemplar);
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

        public void BuchIdGenerieren()
        {
            this.BuchId = Guid.NewGuid();
        }
    }
}