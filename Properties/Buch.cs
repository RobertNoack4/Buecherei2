using System;

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