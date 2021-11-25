using System;
using System.Collections.Generic;
using ConsoleTables;

namespace Buecherei.Properties
{
    public static class Menues
    {

        public static void HauptMenue()
        {
            bool wiederholen = true;
            do
            {
                int auswahl;
                Console.WriteLine("Bitte Wählen sie einen Menue Punkt aus:");
                Console.WriteLine("1: Bücher");
                Console.WriteLine("2: Exemplare");
                Console.WriteLine("3: Leihvorgänge");
                Console.WriteLine("4: Programm beenden");

                auswahl = Controller.EingabeZahlPruefung(4);
                switch (auswahl)
                {
                    case 1:
                        BuchMenue();
                        break;
                    case 2:
                        ExemplarMenue();
                        break;
                    case 3:
                        LeihMenue();
                        break;
                    case 4:
                        wiederholen = false;
                        break;
                }
            } while (wiederholen);
        }
        public static void BuchMenue()
        {
            bool wiederholen = true;
            do
            {
                int auswahl;
                Console.WriteLine("Bitte wählen sie einen Menue Punkt aus:");
                Console.WriteLine("1: Buch anlegen");
                Console.WriteLine("2: Buch anpassen");
                Console.WriteLine("3: Buch entfernen");
                Console.WriteLine("4: Bücher ausgeben");
                Console.WriteLine("5: zum Hauptmenue wechseln");

                auswahl = Controller.EingabeZahlPruefung(5);
                
                switch (auswahl)
                {
                    case 1:
                        Erstellen(1);
                        break;
                    case 2:
                        InformationenAnpassen(1);
                        break;
                    case 3:
                        BuchLoeschen();
                        break;
                    
                    case 4:
                        BuecherAnzeigen();
                        break;
                    case 5:
                        wiederholen = false;
                        break;
                }

            } while (wiederholen);
        }
        public static void ExemplarMenue()
        {
            bool wiederholen = true;
            do
            {
                int auswahl;
                Console.WriteLine("Bitte wählen sie einen Menue Punkt aus:");
                Console.WriteLine("1: Exemplar anlegen");
                Console.WriteLine("2: Exemplar anpassen");
                Console.WriteLine("3: Exemplar entfernen");
                Console.WriteLine("4: Exemplare ausgeben");
                Console.WriteLine("5: zum Hauptmenue wechseln");

                auswahl = Controller.EingabeZahlPruefung(5);
                
                switch (auswahl)
                {
                    case 1:
                        Erstellen(2);
                        break;
                    case 2:
                        InformationenAnpassen(2);
                        break;
                    case 3:
                        BuchLoeschen();
                        break;
                    
                    case 4:
                        BuecherAnzeigen();
                        break;
                    case 5:
                        wiederholen = false;
                        break;
                }

            } while (wiederholen);
        }
        public static void LeihMenue()
        {
            bool wiederholen = true;
            do
            {
                int auswahl;
                Console.WriteLine("Bitte wählen sie einen Menue Punkt aus:");
                Console.WriteLine("1: Leihvorgang anlegen");
                Console.WriteLine("2: Leihvorgang anpassen");
                Console.WriteLine("3: Leihvorgang entfernen");
                Console.WriteLine("4: Leihvorgänge ausgeben");
                Console.WriteLine("5: zum Hauptmenue wechseln");

                auswahl = Controller.EingabeZahlPruefung(5);
                
                switch (auswahl)
                {
                    case 1:
                        Erstellen(1);
                        break;
                    case 2:
                        InformationenAnpassen(3);
                        break;
                    case 3:
                        BuchLoeschen();
                        break;
                    
                    case 4:
                        BuecherAnzeigen();
                        break;
                    case 5:
                        wiederholen = false;
                        break;
                }

            } while (wiederholen);
        }

        private static void Erstellen(int option)
        {
            if (option == 1)
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

            else if (option == 2)
            {
                Buch buch;
                bool verfuegbar;
                AllgemeineInfosBuecher();
                Console.WriteLine("Bitte wählen sie aus zu welchen Buch sie ein neues Exemplar erstellen möchten");
                int auswahl = Controller.EingabeZahlPruefung(Listen.BuchListeAusgeben().Count, Console.ReadLine());
                buch = Listen.BuchListeAusgeben()[auswahl - 1];
                Console.WriteLine("Ist dieses Exemplar aktuell verfügbar?");
                verfuegbar = Controller.JaNeinTest();
                Konstruktoren.ExemplarErstellen(buch, verfuegbar);
                Console.WriteLine("Es wurde ein neues exemplar von " + buch.Title + " erstellt");
            }
            else if (option == 3)
            {
                AllgemeineInfosBuecher();
                Console.WriteLine("Bitte geben geben sie den Index des Buches an welches sie verleihen wollen!");
                string eingabe = Console.ReadLine();
                int auswahl = Controller.EingabeZahlPruefung(0, eingabe);
                int verfuegbareExemplare = Listen.BuchListeAusgeben()[auswahl - 1].ExemplareVerfuegbar();
            
                if (verfuegbareExemplare == 0)
                {
                    Console.WriteLine("Leider sind alle Exemplare dieses Buches ausgeliehen!");
                    return;
                }
            
                Console.WriteLine("Sind sie sicher dass sie " + Listen.BuchListeAusgeben()[auswahl - 1].Title + " Verleihen wollen?");
            
                if (Controller.JaNeinTest())
                {
                    Console.WriteLine("Unter welchem Namen soll dieses Buch verliehen werden?");
                    string name = Console.ReadLine();
                    Konstruktoren.LeihvorgangErstellen(Listen.BuchListeAusgeben()[auswahl - 1], name);
                }

            }
        }

        private static void BuecherAnzeigen()
        {
            List<Buch> alleBuecher = Listen.BuchListeAusgeben();
            AllgemeineInfosBuecher();
            Console.Write("Möchten sie alle Einträge zu einem Buch sehen?");
            if (!Controller.JaNeinTest())
            {
                return;
            }
            Console.WriteLine("Bitte geben sie den Index des Buches ein:");
            
            string eingabe = Console.ReadLine();
            int genauereInfos = Controller.EingabeZahlPruefung(alleBuecher.Count, eingabe);
            AlleInfos(genauereInfos, 1);
        }

        private static void InformationenAnpassen(int option)
        {
            if (option == 1)
            {
                List<Buch> alleBücher = Listen.BuchListeAusgeben();
                Buch buch;
                string aenderung = "";
                bool sicher;

                AllgemeineInfosBuecher();
                Console.WriteLine("Bitte geben Sie den Index des Buches ein welches Sie bearbeiten möchten");
                int genauereInfos = Controller.EingabeZahlPruefung(alleBücher.Count, Console.ReadLine());
                AlleInfos(genauereInfos, 1);
                buch = alleBücher[genauereInfos - 1];
                Console.WriteLine("Möchten sie dieses Buch verändern? (Y/N)");
                if (Controller.JaNeinTest() == false)
                {
                    return;
                }

                Console.WriteLine(
                    "Sollten sie bei einem Punkt keine änderungen haben lassen sie das Änderungsfeld frei");
                Console.WriteLine("aktueller Author ist: " + buch.Author);
                if (!Controller.EnterGedrueckt())
                {
                    do
                    {
                        sicher = false;

                        aenderung = Console.ReadLine();
                        Console.WriteLine("Der neue Author name ist " + aenderung);
                        Console.WriteLine("Sind sie sicher? (Y/N)");
                        if (Controller.JaNeinTest())
                        {
                            buch.Author = aenderung;
                            sicher = true;
                            aenderung = "";
                        }
                    } while (!sicher);
                }

                Console.WriteLine("aktueller Titel ist: " + buch.Title);
                if (!Controller.EnterGedrueckt())
                {
                    do
                    {
                        sicher = false;
                        aenderung = Console.ReadLine();
                        Console.WriteLine("Der Neue Titel ist " + aenderung);
                        Console.WriteLine("Sind sie sicher? (Y/N)");
                        if (Controller.JaNeinTest())
                        {
                            buch.Title = aenderung;
                            sicher = true;
                            aenderung = "";
                        }
                    } while (!sicher);
                }

                Console.WriteLine("aktuelles Erscheinungsjahr ist: " + buch.Year);
                if (!Controller.EnterGedrueckt())
                {
                    do
                    {
                        sicher = false;
                        aenderung = Console.ReadLine();
                        int aenderungInt = Controller.EingabeZahlPruefung(0, aenderung);
                        Console.WriteLine("Das neue Erscheinungsjahr ist: " + aenderungInt);
                        Console.WriteLine("Sind sie sicher? (Y/N)");
                        if (Controller.JaNeinTest())
                        {
                            buch.Year = aenderungInt;
                            sicher = true;
                            aenderung = "";
                        }
                    } while (!sicher);
                }

                Console.WriteLine("aktuelles Land ist: " + buch.Country);
                if (!Controller.EnterGedrueckt())
                {
                    do
                    {
                        sicher = false;
                        aenderung = Console.ReadLine();
                        Console.WriteLine("Das neue Land ist: " + aenderung);
                        Console.WriteLine("Sind sie sicher? (Y/N)");
                        if (Controller.JaNeinTest())
                        {
                            buch.Title = aenderung;
                            sicher = true;
                            aenderung = "";
                        }
                    } while (!sicher);
                }

                Console.WriteLine("aktuelle Sprache ist: " + buch.Language);
                if (!Controller.EnterGedrueckt())
                {
                    do
                    {
                        sicher = false;
                        aenderung = Console.ReadLine();
                        Console.WriteLine("Die neue Sprache ist " + aenderung);
                        Console.WriteLine("Sind sie sicher? (Y/N)");
                        if (Controller.JaNeinTest())
                        {
                            buch.Language = aenderung;
                            sicher = true;
                            aenderung = "";
                        }
                    } while (!sicher);
                }

                Console.WriteLine("aktuelle Seitenanzahl ist: " + buch.Pages);
                if (!Controller.EnterGedrueckt())
                {
                    do
                    {
                        sicher = false;
                        aenderung = Console.ReadLine();
                        int aenderungInt = Controller.EingabeZahlPruefung(0, aenderung);
                        Console.WriteLine("Die neue Seitenanzahl ist: " + aenderungInt);
                        Console.WriteLine("Sind sie sicher? (Y/N)");
                        if (Controller.JaNeinTest())
                        {
                            buch.Pages = aenderungInt;
                            sicher = true;
                            aenderung = "";
                        }
                    } while (!sicher);
                }

                Console.WriteLine("aktueller Link zu Wikipedia ist: " + buch.Link);
                if (!Controller.EnterGedrueckt())
                {
                    do
                    {
                        sicher = false;
                        aenderung = Console.ReadLine();
                        Console.WriteLine("Der neue Link zu Wikipedia ist: " + aenderung);
                        Console.WriteLine("Sind sie sicher? (Y/N)");
                        if (Controller.JaNeinTest())
                        {
                            buch.Link = aenderung;
                            sicher = true;
                            aenderung = "";
                        }
                    } while (!sicher);
                }

                Console.WriteLine("aktueller Link zum Cover ist: " + buch.ImageLink);
                if (!Controller.EnterGedrueckt())
                {

                    do
                    {
                        sicher = false;
                        aenderung = Console.ReadLine();
                        Console.WriteLine("Der neue Link zum Cover ist: " + aenderung);
                        Console.WriteLine("Sind sie sicher? (Y/N)");
                        if (Controller.JaNeinTest())
                        {
                            buch.ImageLink = aenderung;
                            sicher = true;
                            aenderung = "";
                        }
                    } while (!sicher);

                }

            }

            if (option == 2)
            {
                List<Exemplar> alleExemplare = Listen.ExemplarListeAusgeben();
                List<Buch> alleBücher = Listen.BuchListeAusgeben();
                Exemplar exemplar;

                AllgemeineInfosBuecher();
                Console.WriteLine("Bitte geben Sie den Index des Buches ein bei welchem sie ein Exemplar bearbeiten wollen");
                
                int genauereInfos = Controller.EingabeZahlPruefung(alleBücher.Count, Console.ReadLine());
                AlleInfos(genauereInfos, 2);
                Console.WriteLine("Welches Exemplar möchten sie von diesem Buch verändern?");
                
                string auswahlExemplar = Console.ReadLine();
                int exemplarIndex = Controller.EingabeZahlPruefung(0, auswahlExemplar);
                
                AlleInfos(exemplarIndex,2);
                exemplar = alleExemplare[exemplarIndex - 1];
                Console.WriteLine("Sollten sie bei einem Punkt keine änderungen haben lassen sie das Änderungsfeld frei");
                string verfuegbarkeit;

                if (exemplar.Verfuegbar)
                {
                    verfuegbarkeit = "verfügbar";
                }
                else
                {
                    verfuegbarkeit = "nicht verfügbar";
                }
                Console.WriteLine("aktueller Status ist: " + verfuegbarkeit);
                Console.WriteLine("Schreiben sie Y um den Status auf Verfuegbar zu setzen oder N um ihn auf nicht verfügbar zu setzen");
                Console.WriteLine("Sollte das Buch aufgrund eines Leihvorgangs nicht verfügbar sein empfehlen wir den Leihvorgang zu löschen anstatt es hier zu ändern");
                if (!Controller.EnterGedrueckt())
                {
                    exemplar.Verfuegbar = Controller.JaNeinTest();
                    if (exemplar.Verfuegbar)
                    {
                        verfuegbarkeit = "verfügbar";
                    }
                    else
                    {
                        verfuegbarkeit = "nicht verfügbar";
                    }
                    Console.WriteLine("Der neue Status ist: " + verfuegbarkeit);

                }
            }
        }


        private static void BuchLoeschen()
        {
            AllgemeineInfosBuecher();
            Console.WriteLine("Bitte geben sie den Index des Buches ein welches sie löschen wollen!");
            string eingabe = Console.ReadLine();
            int auswahl = Controller.EingabeZahlPruefung(0, eingabe);
            Console.WriteLine("Sind sie sicher das sie " + Listen.BuchListeAusgeben()[auswahl-1].Author + "löschen wollen?");
            if (Controller.JaNeinTest())
            {
                Listen.BuchEntfernen(auswahl);
                Console.WriteLine("Das Buch wurde erfolgreich gelöscht");
            }
        }
        
        private static void AlleInfos(int index, int option)
        {
            if (option == 1)
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
            else if (option == 2)
            {
            }
        }

        private static Exemplar ExemplarAusgeben(Buch buch, int index)
        {
            List<Buch> alleBuecher = Listen.BuchListeAusgeben();
            Buch aktuellesBuch = alleBuecher[index - 1];
            var table = new ConsoleTable("Index", "Verfuegbar", "ID");

            int indexExemplar = 1;
            foreach (Exemplar exemplar in aktuellesBuch.Exemplare)
            {
                table.AddRow(indexExemplar, exemplar.Verfuegbar, exemplar.Id);
                indexExemplar = indexExemplar + 1;
            }
            Console.WriteLine(table);

        }

        private static void AllgemeineInfosBuecher()
        {
            string author;
            string title;
            int pages;
            int index = 1;
            int verfuegbareExemplare;
            var table = new ConsoleTable("Index","Author", "Title", "Seiten", "Verfügbare Exemplare");
            List<Buch> alleBuecher = Listen.BuchListeAusgeben();


            foreach (Buch buch in alleBuecher)
            {
                author = buch.Author;
                title = buch.Title;
                pages = buch.Pages;
                verfuegbareExemplare = buch.ExemplareVerfuegbar();
                
                table.AddRow(index, author, title, pages, verfuegbareExemplare);
                index++;
            }
            Console.WriteLine(table);
        }

        private static void AllgemeineInfosLeihvorgaenge()
        {
            List<LeihVorgang> leihvorgangsListe = Listen.LeihVorgangsListeAusgeben();
            var table = new ConsoleTable("Ausgeliehenes Buch", "Verliehen an", "Verliehen bis", "Exemplar ID");

            foreach (LeihVorgang leihVorgang in leihvorgangsListe)
            {
                table.AddRow(leihVorgang.GeliehenesExemplar.Buch.Title, leihVorgang.Name, leihVorgang.AbgabeDatum, leihVorgang.GeliehenesExemplar.Id);
            }
            Console.WriteLine(table);
        }
    }
}