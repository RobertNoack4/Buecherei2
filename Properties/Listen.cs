using System;
using System.Collections.Generic;

namespace Buecherei.Properties
{
    public static class Listen
    {
        private static List<Buch> buchListe;
        private static List<Exemplar> exemplarListe;
        private static List<LeihVorgang> leihvorgaenge;

        public static void ListenInit()
        {
            buchListe = new List<Buch>();
            exemplarListe = new List<Exemplar>();
            leihvorgaenge = new List<LeihVorgang>();
        }

        public static void BuchHinzufuegen(Buch neuesBuch)
        {
            buchListe.Add(neuesBuch);
        }

        public static List<Buch> BuchListeAusgeben()
        {
            return buchListe;
        }

        public static void BuchEntfernen(int index)
        {
            index = index - 1;
            Console.WriteLine(buchListe.Count);
            buchListe.RemoveAt(99);
        }

        public static void ExemplarHinzufuegen(Exemplar neuesExemplar)
        {
            exemplarListe.Add(neuesExemplar);
        }

        public static List<Exemplar> ExemplarListeAusgeben()
        {
            return exemplarListe;
        }

        public static List<LeihVorgang> LeihVorgangsListeAusgeben()
        {
            return leihvorgaenge;
        }

        public static void LeihvorgangHinzufuegen(LeihVorgang neuerLeihvorgang)
        {
            leihvorgaenge.Add(neuerLeihvorgang);
        }
    }
}