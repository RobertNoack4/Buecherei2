using System.Collections.Generic;

namespace Buecherei.Properties
{
    public static class Listen
    {
        private static List<Buch> buchListe;
        
        public static void BuchInit()
        {
            buchListe = new List<Buch>();
        }

        public static void BuchHinzufuegen(Buch neuesBuch)
        {
            buchListe.Add(neuesBuch);
        }

        public static List<Buch> BuchListeAusgeben()
        {
            return buchListe;
        }
    }
}