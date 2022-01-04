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

        public static void ProduktEntfernen(int index)
        {
            produktListe.RemoveAt(index-1);
        }
        public static void ProduktEntfernen(IProduct product)
        {
            produktListe.Remove(product);
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