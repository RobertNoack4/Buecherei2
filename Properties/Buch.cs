using System;
using System.Collections.Generic;

namespace Buecherei.Properties
{
    public class Buch
    {
        public string Author {  get; set; }
        public string Country { get; set; }
        public string ImageLink { get; set; }
        public string Language { get; set; }
        public string Link { get; set; }
        public int Pages { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public List<Exemplar> Exemplare { get; set;}

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
            Exemplare = new List<Exemplar>();
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
    }
}