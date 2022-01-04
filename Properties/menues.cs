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
                Console.WriteLine("1: Katalog");
                Console.WriteLine("2: Exemplare");
                Console.WriteLine("3: Leihvorgänge");
                Console.WriteLine("4: Programm beenden");

                auswahl = Pruefungen.EingabeZahlPruefung(4);
                switch (auswahl)
                {

                    case 1:
                        KatalogMenue();
                        break;
                    case 2:
                        ExemplarMenue();
                        break;
                    case 3:
                        LeihMenue();
                        break;
                    case 4:
                        wiederholen = false;
                        AllesSpeichern();
                        break;
                }
            } while (wiederholen);
        }
        public static void KatalogMenue()
        {
            bool wiederholen = true;
            do
            {
                int auswahl;
                Console.WriteLine("Bitte wählen sie einen Menue Punkt aus:");
                Console.WriteLine("1: Produkt anlegen");
                Console.WriteLine("2: Produkt anpassen");
                Console.WriteLine("3: Produkt entfernen");
                Console.WriteLine("4: Katalog ausgeben");
                Console.WriteLine("5: zum Hauptmenue wechseln");

                auswahl = Pruefungen.EingabeZahlPruefung(5);

                switch (auswahl)
                {
                    case 1:
                        Erstellen(1);
                        break;
                    case 2:
                        InformationenAnpassen(1);
                        break;
                    case 3:
                        Loeschen(1);
                        break;

                    case 4:
                        Anzeigen(1);
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

                auswahl = Pruefungen.EingabeZahlPruefung(5);

                switch (auswahl)
                {
                    case 1:
                        Erstellen(2);
                        break;
                    case 2:
                        InformationenAnpassen(2);
                        break;
                    case 3:
                        Loeschen(2);
                        break;

                    case 4:
                        Anzeigen(2);
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

                auswahl = Pruefungen.EingabeZahlPruefung(5);

                switch (auswahl)
                {
                    case 1:
                        Erstellen(3);
                        break;
                    case 2:
                        InformationenAnpassen(3);
                        break;
                    case 3:
                        Loeschen(3);
                        break;

                    case 4:
                        Anzeigen(3);
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
                pages = Pruefungen.EingabeZahlPruefung(0);

                Console.WriteLine("Bitte geben sie das Erscheinungsjahr des Buches ein:");
                year = Pruefungen.EingabeZahlPruefung(0);

                Konstruktoren.BuchErstellen(author, country, imageLink, language, link, pages, title, year);
            }

            else if (option == 2)
            {
                IProduct product;
                bool verfuegbar;
                AllgemeineInfos(1);
                Console.WriteLine("Bitte wählen sie aus zu welchem Produkt sie ein neues Exemplar erstellen möchten");
                int auswahl = Pruefungen.EingabeZahlPruefung(Listen.ProduktListeAusgeben().Count, Console.ReadLine());

                product = Listen.ProduktListeAusgeben()[auswahl - 1];
                Console.WriteLine("Ist dieses Exemplar aktuell verfügbar?");
                verfuegbar = Pruefungen.JaNeinTest();

                Konstruktoren.ExemplarErstellen(product, verfuegbar);
                Console.WriteLine("Es wurde ein neues exemplar von " + product.InformationenAusgeben("Titel") + " erstellt");
            }
            else if (option == 3)
            {
                AllgemeineInfos(1);
                Console.WriteLine("Bitte geben geben sie den Index des Buches an welches sie verleihen wollen!");
                string eingabe = Console.ReadLine();
                int auswahl = Pruefungen.EingabeZahlPruefung(0, eingabe);
                int verfuegbareExemplare = Listen.ProduktListeAusgeben()[auswahl - 1].ExemplareVerfuegbar();

                Console.WriteLine("Möchten sie dies als Downloadlink verleihen?");

                if(Pruefungen.JaNeinTest() == true)
                {
                    string name;
                    string link = Listen.ProduktListeAusgeben()[auswahl - 1].InformationenAusgeben("Download") + "/" + Guid.NewGuid().ToString().Replace("-", "/");
                    Console.WriteLine("Unter welchem Namen soll dieses Produkt verliehen werden?");
                    name = Console.ReadLine();
                    Konstruktoren.LeihvorgangErstellen(Listen.ProduktListeAusgeben()[auswahl - 1], name, link);
                    Console.WriteLine("Produkt wurde an " + name + " verliehen");
                    Console.WriteLine("Downloadlink: " + link);
                    return;
                }

                else if (verfuegbareExemplare == 0)
                {
                    Console.WriteLine("Leider sind alle Exemplare dieses Produktes ausgeliehen!");
                    return;
                }

                Console.WriteLine("Sind sie sicher dass sie " + Listen.ProduktListeAusgeben()[auswahl - 1].InformationenAusgeben("Titel") + " Verleihen wollen?");

                if (Pruefungen.JaNeinTest())
                {
                    Console.WriteLine("Unter welchem Namen soll dieses Produkt verliehen werden?");
                    string name = Console.ReadLine();
                    Konstruktoren.LeihvorgangErstellen(Listen.ProduktListeAusgeben()[auswahl - 1], name);
                }

            }
        }

        private static void Anzeigen(int option)
        {
            string verfuegbar;
            int index = 1;
            List<Exemplar> exemplare = Listen.ExemplarListenAusgeben();
            List<LeihVorgang> leihvorgangsListe = Listen.LeihVorgangsListeAusgeben();

            switch (option)
            {
                case 1:
                    AllgemeineInfos(1);
                    Console.WriteLine("Möchten sie alle Einträge zu einem Buch sehen?");
                    if (!Pruefungen.JaNeinTest())
                    {
                        return;
                    }
                    Console.WriteLine("Bitte geben sie den Index des Buches ein:");

                    string eingabe = Console.ReadLine();
                    int genauereInfos = Pruefungen.EingabeZahlPruefung(Listen.ExemplarListenAusgeben().Count, eingabe);
                    AlleInfos(genauereInfos, 1);
                    break;
                case 2:
                    var table2 = new ConsoleTable("Index", "ID des Exemplars", "ID des Buches", "Status");

                    foreach (Exemplar exemplar in exemplare)
                    {
                        if (exemplar.Verfuegbar)
                        {
                            verfuegbar = "Verfügbar";
                        }
                        else
                        {
                            verfuegbar = "nicht Verfügbar";
                        }

                        table2.AddRow(index, exemplar.Id, exemplar.GehoertZu, verfuegbar);
                        index++;
                    }
                    Console.WriteLine(table2);
                    break;
                case 3:
                    var table3 = new ConsoleTable("Index", "Verliehen an", "Verliehen bis", "Exemplar ID", "Downloadlink");

                    foreach (LeihVorgang leihVorgang in leihvorgangsListe)
                    {
                        table3.AddRow(index, leihVorgang.Name, leihVorgang.AbgabeDatum, leihVorgang.GeliehenesExemplar.Id, leihVorgang.Downloadlink);
                        index++;
                    }
                    Console.WriteLine(table3);
                    break;
            }
        }

        private static void InformationenAnpassen(int option)
        {
            int genauereInfos;
            string eingabe;
            List<IProduct> alleProdukte = Listen.ProduktListeAusgeben();
            Exemplar exemplar;
            IProduct product;
            LeihVorgang leihVorgang;

            switch (option)
            {
                case 1:
                    AllgemeineInfos(1);
                    Console.WriteLine("Bitte geben Sie den Index des Buches ein welches Sie bearbeiten möchten");
                    genauereInfos = Pruefungen.EingabeZahlPruefung(alleProdukte.Count, Console.ReadLine());
                    product = Listen.ProduktListeAusgeben()[genauereInfos - 1];
                    bool sicher;
                    string aenderung;
                    Console.WriteLine("Möchten sie dieses Produkt verändern? (Y/N)");
                    Console.WriteLine(product.InformationenAusgeben("Titel"));
                    if (Pruefungen.JaNeinTest() == false)
                    {
                        return;
                    }

                    if (product.InformationenAusgeben("Art") == "Buch")
                    {
                        Console.WriteLine("Sollten sie bei einem Punkt keine änderungen haben lassen sie das Änderungsfeld frei");

                        InformationenAnpassenStr("Author", product);
                        InformationenAnpassenStr("Titel", product);
                        InformationenAnpassenInt("Jahr", product);
                        InformationenAnpassenStr("Land", product);
                        InformationenAnpassenStr("Sprache", product);
                        InformationenAnpassenInt("Seiten", product);
                        InformationenAnpassenStr("Link", product);
                        InformationenAnpassenStr("Bild", product);
                    }

                    else if (product.InformationenAusgeben("Art") == "Magazin")
                    {
                        Console.WriteLine("Sollten sie bei einem Punkt keine änderungen haben lassen sie das Änderungsfeld frei");

                        InformationenAnpassenStr("Titel", product);
                        InformationenAnpassenInt("Rang", product);
                        InformationenAnpassenStr("Auflage", product);
                        InformationenAnpassenStr("Gruppe", product);
                        InformationenAnpassenStr("SachGruppe", product);
                        InformationenAnpassenStr("Verlag", product);
                    }
                    break;
                case 2:

                    AllgemeineInfos(1);
                    Console.WriteLine("Bitte geben Sie den Index des Buches ein bei welchem sie ein Exemplar bearbeiten wollen");

                    genauereInfos = Pruefungen.EingabeZahlPruefung(alleProdukte.Count, Console.ReadLine());
                    product = Listen.ProduktListeAusgeben()[genauereInfos - 1];
                    List<Exemplar> alleExemplare = product.AlleExemplareAusgeben();
                    AlleInfos(genauereInfos, 1);
                    ExemplarAusgeben(product);
                    Console.WriteLine("Welches Exemplar möchten sie von diesem Buch verändern?");

                    string auswahlExemplar = Console.ReadLine();
                    int exemplarIndex = Pruefungen.EingabeZahlPruefung(0, auswahlExemplar);

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
                    eingabe = Console.ReadLine();
                    if (!String.IsNullOrWhiteSpace(eingabe))
                    {
                        exemplar.Verfuegbar = Pruefungen.JaNeinTest(eingabe);
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

                    break;
                case 3:
                    AllgemeineInfos(3);
                    Console.WriteLine("Bitte wählen sie den Leihvorgang aus welchen sie überarbeiten wollen:");

                    eingabe = Console.ReadLine();
                    int auswahl = Pruefungen.EingabeZahlPruefung(0, eingabe);

                    AlleInfos(auswahl, 3);
                    leihVorgang = Listen.LeihVorgangsListeAusgeben()[auswahl - 1];
                    bool datumRichtig;

                    Console.WriteLine("aktueller Name des Leihers ist: " + leihVorgang.Name);
                    aenderung = Console.ReadLine();
                    if (!String.IsNullOrWhiteSpace(aenderung))
                    {
                        do
                        {
                            sicher = false;
                            Console.WriteLine("Der neue Name des Leihers ist: " + aenderung);
                            Console.WriteLine("Sind sie sicher? (Y/N)");
                            if (Pruefungen.JaNeinTest())
                            {
                                leihVorgang.Name = aenderung;
                                sicher = true;
                            }

                            Console.WriteLine("Möchten sie doch keine Veränderung vornehmen? (Y/N)");
                            if (Pruefungen.JaNeinTest())
                            {
                                return;
                            }
                            aenderung = Console.ReadLine();
                        } while (!sicher);

                    }

                    Console.WriteLine("aktuelles Abgabedatum ist: " + leihVorgang.AbgabeDatum);
                    aenderung = Console.ReadLine();
                    if (!String.IsNullOrWhiteSpace(aenderung))
                    {
                        do
                        {
                            datumRichtig = false;
                            DateTime datum = DateTime.Now;
                            do
                            {
                                if (Pruefungen.DatumPruefung(aenderung))
                                {
                                    datumRichtig = true;
                                    datum = Convert.ToDateTime(aenderung).Date;
                                }
                            } while (!datumRichtig);

                            sicher = false;
                            Console.WriteLine("Das neue Abgabedatum ist: " + datum);
                            Console.WriteLine("Sind sie sicher? (Y/N)");
                            if (Pruefungen.JaNeinTest())
                            {
                                leihVorgang.AbgabeDatum = datum;
                                sicher = true;
                            }
                            Console.WriteLine("Möchten sie doch keine Veränderung vornehmen? (Y/N)");
                            if (Pruefungen.JaNeinTest())
                            {
                                return;
                            }
                            aenderung = Console.ReadLine();
                        } while (!sicher);
                    }
                    break;
            }
        }


        private static void Loeschen(int option)
        {
            string eingabe;
            int auswahl;
            IProduct product;
            Exemplar exemplar;
            LeihVorgang leihVorgang;

            switch (option)
            {
                case 1:
                    AllgemeineInfos(1);
                    Console.WriteLine("Bitte geben sie den Index des Buches ein welches sie löschen wollen!");
                    eingabe = Console.ReadLine();
                    auswahl = Pruefungen.EingabeZahlPruefung(0, eingabe);
                    product = Listen.ProduktListeAusgeben()[auswahl - 1];
                    Console.WriteLine("Sind sie sicher das sie " + product.InformationenAusgeben("Titel") + "löschen wollen?");
                    if (Pruefungen.JaNeinTest())
                    {
                        Listen.ProduktEntfernen(product);
                        Console.WriteLine("Das Buch wurde erfolgreich gelöscht");
                    }

                    break;
                case 2:
                    AllgemeineInfos(1);
                    Console.WriteLine("Bitte geben sie den Index des Buches ein von welchem sie ein Exemplar löschen möchten");

                    eingabe = Console.ReadLine();
                    auswahl = Pruefungen.EingabeZahlPruefung(0, eingabe);
                    product = Listen.ProduktListeAusgeben()[auswahl - 1];
                    List<Exemplar> alleExemplare = product.AlleExemplareAusgeben();

                    ExemplarAusgeben(product);
                    eingabe = Console.ReadLine();
                    auswahl = Pruefungen.EingabeZahlPruefung(0, eingabe);

                    exemplar = alleExemplare[auswahl - 1];
                    Console.WriteLine("Sind sie sicher dass sie das Exemplar mit der ID " + exemplar.Id + "löschen wollen?");
                    if (Pruefungen.JaNeinTest())
                    {
                        product.ExemplarLoeschen(auswahl - 1);
                    }
                    break;
                case 3:
                    AllgemeineInfos(3);
                    Console.Write("Bitte wählen sie aus welchen Leihvorgang sie löschen wollen");
                    Console.WriteLine(Environment.NewLine);
                    eingabe = Console.ReadLine();
                    auswahl = Pruefungen.EingabeZahlPruefung(0, eingabe);
                    leihVorgang = Listen.LeihVorgangsListeAusgeben()[auswahl - 1];

                    AlleInfos(auswahl, 3);
                    Console.WriteLine("Sind sie sicher dass sie diesen Leihvorgang löschen wollen? Das verwendete Exemplar wird dadurch wieder verfügbar");
                    Console.WriteLine();
                    if (Pruefungen.JaNeinTest())
                    {
                        leihVorgang.GeliehenesExemplar.Verfuegbar = true;
                        Listen.LeihvorgangEntfernen(leihVorgang);
                        Console.WriteLine("Leihvorgang wurde gelöscht");
                    }
                    break;
            }
            AllesSpeichern();
        }

        private static void AlleInfos(int index, int option)
        {
            switch (option)
            {
                case 1:
                    IProduct product = Listen.ProduktListeAusgeben()[index - 1];
                    var table = new ConsoleTable("Name", "Wert");

                    if(product.InformationenAusgeben("Art") == "Buch")
                    {
                        table.AddRow("Art", product.InformationenAusgeben("Art"));
                        table.AddRow("Author", product.InformationenAusgeben("Author"));
                        table.AddRow("Title", product.InformationenAusgeben("Titel"));
                        table.AddRow("Erscheinungsjahr", product.InformationenAusgeben("Jahr"));
                        table.AddRow("Land", product.InformationenAusgeben("Land"));
                        table.AddRow("Sprache", product.InformationenAusgeben("Sprache"));
                        table.AddRow("Seitenanzahl", product.InformationenAusgeben("Seiten"));
                        table.AddRow("Link zu Wikipedia", product.InformationenAusgeben("Link"));
                        table.AddRow("Link zum Cover", product.InformationenAusgeben("Bild"));
                        table.AddRow("Buch Id ", product.IdAusgeben());
                    }

                    else if (product.InformationenAusgeben("Art") == "Magazin")
                    {
                        table.AddRow("Art", product.InformationenAusgeben("Art"));
                        table.AddRow("Rang", product.InformationenAusgeben("Rang"));
                        table.AddRow("Titel", product.InformationenAusgeben("Titel"));
                        table.AddRow("Auflage", product.InformationenAusgeben("Auflage"));
                        table.AddRow("Gruppe", product.InformationenAusgeben("Gruppe"));
                        table.AddRow("Sachgruppe", product.InformationenAusgeben("SachGruppe"));
                        table.AddRow("Verlag", product.InformationenAusgeben("Verlag"));
                        table.AddRow("ID", product.IdAusgeben());
                    }
                    Console.WriteLine(table);
                    break;
                case 3:
                    LeihVorgang aktuellerLeihvorgang = Listen.LeihVorgangsListeAusgeben()[index - 1];
                    table = new ConsoleTable("Name", "Wert");
                    table.AddRow("geliehenes Exemplar", aktuellerLeihvorgang.GeliehenesExemplar.Id);
                    table.AddRow("Leihnummer", aktuellerLeihvorgang.Leihnummer);
                    table.AddRow("Name", aktuellerLeihvorgang.Name);
                    table.AddRow("Abgabedatum", aktuellerLeihvorgang.AbgabeDatum);

                    Console.WriteLine(table);

                    break;
            }
        }

        private static void ExemplarAusgeben(IProduct product)
        {
            var table = new ConsoleTable("Index", "Verfuegbar", "ID");

            int indexExemplar = 1;
            List<Exemplar> alleExemplare = product.AlleExemplareAusgeben();
            foreach (Exemplar exemplar in alleExemplare)
            {
                table.AddRow(indexExemplar, exemplar.Verfuegbar, exemplar.Id);
                indexExemplar ++;
            }
            Console.WriteLine(table);

        }

        private static void AllgemeineInfos(int option)
        {
            string title;
            int index = 1;
            List<IProduct> alleProdukte = Listen.ProduktListeAusgeben();
            List<LeihVorgang> leihvorgangsListe = Listen.LeihVorgangsListeAusgeben();

            switch (option)
            {
                case 1:
                    var table = new ConsoleTable("Index", "Titel", "Art");
                    foreach (IProduct product in alleProdukte)
                    {
                        title = product.InformationenAusgeben("Titel");

                        table.AddRow(index, title, product.InformationenAusgeben("Art"));
                        index++;
                    }
                    Console.WriteLine(table);
                    break;
                case 3:
                    var table3 = new ConsoleTable("Index", "Verliehen an", "Verliehen bis", "Exemplar ID",
                        "Id des ausgeliehenen Exemplars");

                    foreach (LeihVorgang leihVorgang in leihvorgangsListe)
                    {
                        table3.AddRow(index, leihVorgang.Name, leihVorgang.AbgabeDatum, leihVorgang.GeliehenesExemplar.Id, leihVorgang.GeliehenesExemplar.GehoertZu);
                        index++;
                    }
                    Console.WriteLine(table3);
                    break;
            }
        }

        public static void AllesSpeichern()
        {
            Json.SpeicherBuch();
            Json.SpeicherMagazin();
            Json.SpeicherExemplar();
            Json.SpeicherLeihvorgang();

            Listen.ListenInit();

            Json.LoadBuch();
            Json.LoadMagazine();
            Json.LoadExemplar();
            Json.LoadLeihvorgaenge();
        }

        private static void InformationenAnpassenStr(string art, IProduct product)
        {
            bool sicher;
            string aenderung;
            Console.WriteLine("Aktuell steht in dem Feld " + art + " folgendes: " + product.InformationenAusgeben(art));
            aenderung = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(aenderung))
            {
                do
                {
                    sicher = false;
                    Console.WriteLine("Das neue Feld " + art + " ist " + aenderung);
                    Console.WriteLine("Sind sie sicher? (Y/N)");
                    if (Pruefungen.JaNeinTest())
                    {
                        product.Aenderung(art, aenderung);
                        return;
                    }
                    Console.WriteLine("Möchten sie doch keine Veränderung vornehmen? (Y/N)");
                    if(Pruefungen.JaNeinTest())
                    {
                        return;
                    }
                    aenderung = Console.ReadLine();
                } while (!sicher);
            }
        }

        private static void InformationenAnpassenInt(string art, IProduct product)
        {
            bool sicher;
            string aenderung;
            Console.WriteLine("Aktuell steht in dem Feld " + art + " folgendes: " + product.InformationenAusgeben(art));
            aenderung = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(aenderung))
            {
                do
                {
                    sicher = false;
                    int aenderungInt = Pruefungen.EingabeZahlPruefung(0, aenderung);
                    Console.WriteLine("Das neue Erscheinungsjahr ist: " + aenderungInt);
                    Console.WriteLine("Sind sie sicher? (Y/N)");
                    if (Pruefungen.JaNeinTest())
                    {
                        product.Aenderung(art, aenderungInt.ToString());
                        return;
                    }
                    Console.WriteLine("Möchten sie doch keine Veränderung vornehmen? (Y/N)");
                    if (Pruefungen.JaNeinTest())
                    {
                        return;
                    }
                    aenderung = Console.ReadLine();
                } while (!sicher);
            }
        }
    }
}