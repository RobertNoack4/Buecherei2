using System;
using System.Diagnostics;
using ConsoleTables;
using Newtonsoft.Json;

namespace Buecherei.Properties
{
    public class LeihVorgang 
    {
        public Exemplar GeliehenesExemplar { get; set; }
        public Guid ExemplarId { get; set; }
        public Guid Leihnummer { get; set; }
        public string Name { get; set; }
        public DateTime AbgabeDatum { get; set; }

        public LeihVorgang(Exemplar exemplar, string name)
        {
            GeliehenesExemplar = exemplar;
            Name = name;
            Leihnummer = Guid.NewGuid();
            AbgabeDatum = DateTime.Now.AddDays(30).Date;
        }

        [JsonConstructor]
        public LeihVorgang(Guid exemplarId, Guid leihnummer, string name, DateTime abgabeDatum)
        {
            ExemplarId = exemplarId;
            Name = name;
            Leihnummer = leihnummer;
            AbgabeDatum = abgabeDatum;
        }


        public void ExemplarHinzufuegen(Exemplar exemplar)
        {
            GeliehenesExemplar = exemplar;
        }

        public void Anzeigen()
        {
            var table = new ConsoleTable("Name", "Wert");
            table.AddRow("geliehenes Exemplar", this.GeliehenesExemplar.Id);
            table.AddRow("Leihnummer", this.Leihnummer);
            table.AddRow("Name", this.Name);
            table.AddRow("Abgabedatum", this.AbgabeDatum);
                
            Console.WriteLine(table);
        }

        public void Anpassen()
        {
            bool sicher;
            bool datumRichtig;
            string aenderung;
            
            Console.WriteLine("aktueller Name des Leihers ist: " + this.Name);
            if (!Pruefungen.EnterGedrueckt())
            {
                do
                {
                    sicher = false;
                    aenderung = Console.ReadLine();
                    Console.WriteLine("Der neue Name des Leihers ist: " + aenderung);
                    Console.WriteLine("Sind sie sicher? (Y/N)");
                    if (Pruefungen.JaNeinTest())
                    {
                        this.Name = aenderung;
                        sicher = true;
                        aenderung = "";
                    }
                } while (!sicher);

            }

            Console.WriteLine("aktuelles Abgabedatum ist: " + this.AbgabeDatum);
            if (!Pruefungen.EnterGedrueckt())
            {
                do
                {
                    datumRichtig = false;
                    DateTime datum = DateTime.Now;
                    do
                    {
                        aenderung = Console.ReadLine();
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
                        this.AbgabeDatum = datum;
                        sicher = true;
                        aenderung = "";
                    }
                } while (!sicher);
            }
        }

        public void Loeschen()
        {
            Console.WriteLine("Sind sie sicher dass sie diesen Leihvorgang löschen wollen? Das verwendete Exemplar wird dadurch wieder verfügbar");
            if (Pruefungen.JaNeinTest())
            {
                this.GeliehenesExemplar.Verfuegbar = true;
                Listen.LeihvorgangEntfernen(this);
                Console.WriteLine("Leihvorgang wurde gelöscht");
            }

        }
    }
}