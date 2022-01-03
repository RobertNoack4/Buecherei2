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
        public string Author {  get; private set; }
        private string Country { get; set; }
        private string ImageLink { get; set; }
        private string Language { get; set; }
        private string Link { get; set; }
        public int Pages { get; private set; }
        public string Title { get; private set; }
        private int Year { get; set; }
        public string Art { get; private set; }
        public List<Exemplar> Exemplare { get; private set;}
        public Guid BuchId { get; private set; }
        
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

        public void Anzeigen()
        {
            var table = new ConsoleTable("Name", "Wert");
            table.AddRow("Author", this.Author);
            table.AddRow("Title", this.Title);
            table.AddRow("Erscheinungsjahr", this.Year);
            table.AddRow("Land", this.Country);
            table.AddRow("Sprache", this.Language);
            table.AddRow("Seitenanzahl", this.Pages);
            table.AddRow("Link zu Wikipedia", this.Link);
            table.AddRow("Link zum Cover", this.ImageLink);
            table.AddRow("Buch Id ", this.BuchId);
            
            Console.WriteLine(table);

        }

        public void Anpassen()
        {
            bool sicher = false;
            string aenderung = "";
            Console.WriteLine("Möchten sie dieses Buch verändern? (Y/N)");
            if (Pruefungen.JaNeinTest() == false)
            {
                return;
            }

            Console.WriteLine("Sollten sie bei einem Punkt keine änderungen haben lassen sie das Änderungsfeld frei");
            Console.WriteLine("aktueller Author ist: " + this.Author);
            if (!Pruefungen.EnterGedrueckt())
            {
                do
                {
                    sicher = false;

                    aenderung = Console.ReadLine();
                    Console.WriteLine("Der neue Author name ist " + aenderung);
                    Console.WriteLine("Sind sie sicher? (Y/N)");
                    if (Pruefungen.JaNeinTest())
                    {
                        this.Author = aenderung;
                        sicher = true;
                        aenderung = "";
                    }
                } while (!sicher);
            }

            Console.WriteLine("aktueller Titel ist: " + this.Title);
            if (!Pruefungen.EnterGedrueckt())
            {
                do
                {
                    sicher = false;
                    aenderung = Console.ReadLine();
                    Console.WriteLine("Der Neue Titel ist " + aenderung);
                    Console.WriteLine("Sind sie sicher? (Y/N)");
                    if (Pruefungen.JaNeinTest())
                    {
                        this.Title = aenderung;
                        sicher = true;
                        aenderung = "";
                    }
                } while (!sicher);
            }

            Console.WriteLine("aktuelles Erscheinungsjahr ist: " + this.Year);
            if (!Pruefungen.EnterGedrueckt())
            {
                do
                {
                    sicher = false;
                    aenderung = Console.ReadLine();
                    int aenderungInt = Pruefungen.EingabeZahlPruefung(0, aenderung);
                    Console.WriteLine("Das neue Erscheinungsjahr ist: " + aenderungInt);
                    Console.WriteLine("Sind sie sicher? (Y/N)");
                    if (Pruefungen.JaNeinTest())
                    {
                        this.Year = aenderungInt;
                        sicher = true;
                        aenderung = "";
                    }
                } while (!sicher);
            }

            Console.WriteLine("aktuelles Land ist: " + this.Country);
            if (!Pruefungen.EnterGedrueckt())
            {
                do
                {
                    sicher = false;
                    aenderung = Console.ReadLine();
                    Console.WriteLine("Das neue Land ist: " + aenderung);
                    Console.WriteLine("Sind sie sicher? (Y/N)");
                    if (Pruefungen.JaNeinTest())
                    {
                        this.Title = aenderung;
                        sicher = true;
                        aenderung = "";
                    }
                } while (!sicher);
            }

            Console.WriteLine("aktuelle Sprache ist: " + this.Language);
            if (!Pruefungen.EnterGedrueckt())
            {
                do
                {
                    sicher = false;
                    aenderung = Console.ReadLine();
                    Console.WriteLine("Die neue Sprache ist " + aenderung);
                    Console.WriteLine("Sind sie sicher? (Y/N)");
                    if (Pruefungen.JaNeinTest())
                    {
                        this.Language = aenderung;
                        sicher = true;
                        aenderung = "";
                    }
                } while (!sicher);
            }

            Console.WriteLine("aktuelle Seitenanzahl ist: " + this.Pages);
            if (!Pruefungen.EnterGedrueckt())
            {
                do
                {
                    sicher = false;
                    aenderung = Console.ReadLine();
                    int aenderungInt = Pruefungen.EingabeZahlPruefung(0, aenderung);
                    Console.WriteLine("Die neue Seitenanzahl ist: " + aenderungInt);
                    Console.WriteLine("Sind sie sicher? (Y/N)");
                    if (Pruefungen.JaNeinTest())
                    {
                        this.Pages = aenderungInt;
                        sicher = true;
                        aenderung = "";
                    }
                } while (!sicher);
            }

            Console.WriteLine("aktueller Link zu Wikipedia ist: " + this.Link);
            if (!Pruefungen.EnterGedrueckt())
            {
                do
                {
                    sicher = false;
                    aenderung = Console.ReadLine();
                    Console.WriteLine("Der neue Link zu Wikipedia ist: " + aenderung);
                    Console.WriteLine("Sind sie sicher? (Y/N)");
                    if (Pruefungen.JaNeinTest())
                    {
                        this.Link = aenderung;
                        sicher = true;
                        aenderung = "";
                    }
                } while (!sicher);
            }

            Console.WriteLine("aktueller Link zum Cover ist: " + this.ImageLink);
            if (!Pruefungen.EnterGedrueckt())
            {

                do
                {
                    sicher = false;
                    aenderung = Console.ReadLine();
                    Console.WriteLine("Der neue Link zum Cover ist: " + aenderung);
                    Console.WriteLine("Sind sie sicher? (Y/N)");
                    if (Pruefungen.JaNeinTest())
                    {
                        this.ImageLink = aenderung;
                        sicher = true;
                        aenderung = "";
                    }
                } while (!sicher);

            }
        }

        public void Loeschen()
        {
            Console.WriteLine("Sind sie sicher das sie " + this.Author + "löschen wollen?");
            if (Pruefungen.JaNeinTest())
            {
                Listen.BuchEntfernen(this);
                Console.WriteLine("Das Buch wurde erfolgreich gelöscht");
            }

        }
    }
}