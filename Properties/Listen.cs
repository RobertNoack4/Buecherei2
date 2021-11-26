using System;
using System.Collections.Generic;

namespace Buecherei.Properties
{
    public static class Listen
    {
        private static List<Buch> buchListe;
        private static List<LeihVorgang> leihvorgaenge;
        private static List<Exemplar> exemplarListe;

        public static void ListenInit()
        {
            buchListe = new List<Buch>();
            leihvorgaenge = new List<LeihVorgang>();
            exemplarListe = new List<Exemplar>();
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
            buchListe.RemoveAt(index-1);
        }
        public static void BuchEntfernen(Buch buch)
        {
            buchListe.Remove(buch);
        }

        

        
        public static List<LeihVorgang> LeihVorgangsListeAusgeben()
        {
            return leihvorgaenge;
        }

        public static void LeihvorgangHinzufuegen(LeihVorgang neuerLeihvorgang)
        {
            leihvorgaenge.Add(neuerLeihvorgang);
        }

        public static void LeihvorgangEntfernen(int index)
        {
            leihvorgaenge.RemoveAt(index - 1);
        }

        public static List<Exemplar> ExemplarListenAusgeben()
        {
            return exemplarListe;
        }

        public static void ExemplarHinzufuegen(Exemplar neuesExemplar)
        {
            exemplarListe.Add(neuesExemplar);
        }
        
    }
}