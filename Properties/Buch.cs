using System;

namespace Buecherei.Properties
{
    public class Buch
    {
        private string Author {  get; set; }
        private string Country { get; set; }
        private string ImageLink { get; set; }
        private string Language { get; set; }
        private string Link { get; set; }
        private int Pages { get; set; }
        private string Title { get; set; }
        private int Year { get; set; }

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
        }
    }
}