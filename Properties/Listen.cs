using System;
using System.Collections.Generic;

namespace Buecherei.Properties
{
    public static class Listen
    {
        private static List<IProduct> produktListe;
        private static List<LeihVorgang> leihvorgaenge;
        private static List<Exemplar> exemplarListe;

        public static void ListenInit()
        {
            produktListe = new List<IProduct>();
            leihvorgaenge = new List<LeihVorgang>();
            exemplarListe = new List<Exemplar>();
        }

        public static void ProduktHinzufuegen(IProduct neuesProduct)
        {
            produktListe.Add(neuesProduct);
        }

        public static List<IProduct> ProduktListeAusgeben()
        {
            return produktListe;
        }

        public static List<Buch> BuchListeAusgeben()
        {
        }

        public static List<IProduct> BuecherUndMagazinListeAusgeben()
        {
            List<IProduct> alleProdukte = produktListe;
            List<IProduct> magazinUndBuchListe = new List<IProduct>();

            foreach (Buch buch in produktListe)
            {
                magazinUndBuchListe.Add(buch);
            }

            return magazinUndBuchListe;
        }

        public static void BuchEntfernen(int index)
        {
            produktListe.RemoveAt(index-1);
        }
        public static void BuchEntfernen(Buch buch)
        {
            produktListe.Remove(buch);
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
        
        public static void LeihvorgangEntfernen(LeihVorgang leihVorgang)
        {
            leihvorgaenge.Remove(leihVorgang);
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