using System;
using System.Collections.Generic;
using ConsoleTables;

namespace Buecherei.Properties
{
    public static class Menues
    {
        public static void Hauptmenue()
        {
            bool wiederholen = true;
            do
            {
                int auswahl;
                Console.WriteLine("Bitte wählen sie einen Menue Punkt aus:");
                Console.WriteLine("1: Buch anlegen");
                Console.WriteLine("2 Bücher ausgeben");
                Console.WriteLine("3: Programm beenden");

                auswahl = Controller.EingabeZahlPruefung(3);
                
                switch (auswahl)
                {
                    case 1:
                        BuchErstellen();
                        break;
                    case 2:
                        BuecherAnzeigen();
                        break;

                    case 3:
                        wiederholen = false;
                        break;
                }

            } while (wiederholen);
        }

        private static void BuchErstellen()
        {
            string author;
            string country;
            string imageLink;
            string language;
            string link;
            string title;

            int pages;
            int year;
            
            
            Console.WriteLine("Bitte geben sie den Namen des Authors ein:");
            author = Console.ReadLine();
            
            Console.WriteLine("Bitte geben sie das Land ein:");
            country = Console.ReadLine();
            
            Console.WriteLine("Bitte geben sie den Link zum Titlebild ein:");
            imageLink = Console.ReadLine();
            
            Console.WriteLine("Bitte geben sie die Sprache ein in dem das Buch verfasst ist:");
            language = Console.ReadLine();
            
            Console.WriteLine("Bitte geben sie den Wikipedia Link des Buches ein:");
            link = Console.ReadLine();
            
            Console.WriteLine("Bitte geben sie den Title des Buches ein:");
            title = Console.ReadLine();
            
            Console.WriteLine("Bitte geben sie die Anzahl der Seiten des Buches ein:");
            pages = Controller.EingabeZahlPruefung(0);
            
            Console.WriteLine("Bitte geben sie das Erscheinungsjahr des Buches ein:");
            year = Controller.EingabeZahlPruefung(0); 
            
            Konstruktoren.BuchErstellen(author, country, imageLink, language, link, pages, title, year);
            
        }

        private static void BuecherAnzeigen()
        {
            string author;
            string title;
            int pages;
            int index = 1;
            var table = new ConsoleTable("Index","Author", "Title", "Seiten");
            List<Buch> alleBuecher = Listen.BuchListeAusgeben();


            foreach (Buch buch in alleBuecher)
            {
                author = buch.Author;
                title = buch.Title;
                pages = buch.Pages;

                table.AddRow(index, author, title, pages);
                index++;
            }
            Console.WriteLine(table);
            Console.WriteLine("Geben sie die Index Nummer ein um mehr Informationen zu dem Buch zu erhalten oder Z um ins Hauptmenue zu gelangen");
            string eingabe = Console.ReadLine();
            if (eingabe == "Z" || eingabe== "z")
            {
                return;
            }
            else
            {
                int genauereInfos = Controller.EingabeZahlPruefung(alleBuecher.Count, eingabe);
                AlleInfosBuch(genauereInfos);
            }
        }

        public static void AlleInfosBuch(int index)
        {
            List<Buch> alleBuecher = Listen.BuchListeAusgeben();
            Buch aktuellesBuch = alleBuecher[index - 1];
            var table = new ConsoleTable("Name", "Wert");
            table.AddRow("Author", aktuellesBuch.Author);
            table.AddRow("Title", aktuellesBuch.Title);
            table.AddRow("Erscheinungsjahr", aktuellesBuch.Year);
            table.AddRow("Land", aktuellesBuch.Country);
            table.AddRow("Sprache", aktuellesBuch.Language);
            table.AddRow("Seitenanzahl", aktuellesBuch.Pages);
            table.AddRow("Link zu Wikipedia", aktuellesBuch.Link);
            table.AddRow("Link zum Cover", aktuellesBuch.ImageLink);
            
            Console.WriteLine(table);
        }
    }
}