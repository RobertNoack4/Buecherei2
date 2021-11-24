using System.Collections.Generic;

namespace Buecherei.Properties
{
    public static class Listen
    {
        private static List<Buch> buchListe;
        private static List<Exemplar> exemplarListe;

        public static void ListenInit()
        {
            buchListe = new List<Buch>();
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

        public static void ExemplarHinzufuegen(Exemplar neuesExemplar)
        {
            exemplarListe.Add(neuesExemplar);
        }

        public static List<Exemplar> ExemplarListeAusgeben()
        {
            return exemplarListe;
        }
    }
}