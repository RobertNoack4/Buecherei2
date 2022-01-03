using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Buecherei.Properties
{
    public class Exemplar
    {
        public Guid Buch { get; set; }
        public Guid Id { get; set; }
        public Boolean Verfuegbar { get; set; }

        public Exemplar(Guid buch ,bool verfuegbar)
        {
            Buch = buch;
            Verfuegbar = verfuegbar;
            Id = Guid.NewGuid();
            
            Listen.ExemplarHinzufuegen(this);
        }
        
        [JsonConstructor]
        public Exemplar(Guid buch ,bool verfuegbar, Guid guid)
        {
            Buch = buch;
            Verfuegbar = verfuegbar;
            Id = guid;
        }

        public void VerfuegbarkeitAendern(bool verfuegbarkeit)
        {
            Verfuegbar = verfuegbarkeit;
        }

        public void BuchHinzufuegen(Guid BuchId)
        {
            Buch = BuchId;
        }

        public void Anzeigen()
        {
            //Da es bei Exemplaren keinen bedeutenden Grund gibt sich diese im Einzelnen anzuschauen ist diese Methode leer
        }

        public void Anpassen()
        {
            Console.WriteLine("Sollten sie bei einem Punkt keine änderungen haben lassen sie das Änderungsfeld frei");
            string verfuegbarkeit;

            if (this.Verfuegbar)
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
            
            if (!Pruefungen.EnterGedrueckt())
            {
                this.Verfuegbar = Pruefungen.JaNeinTest();
                if (this.Verfuegbar)
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

        public void Loeschen()
        {
            //Nicht benötigt
        }
    }
}