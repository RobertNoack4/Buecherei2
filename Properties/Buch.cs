using System;

namespace Buecherei.Properties
{
    public class Buch
    {
        public string Author {  get; private set; }
        public string Country { get; private set; }
        private string ImageLink { get; set; }
        public string Language { get; private set; }
        private string Link { get; set; }
        public int Pages { get; private set; }
        public string Title { get; private set; }
        public int Year { get; private set; }

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