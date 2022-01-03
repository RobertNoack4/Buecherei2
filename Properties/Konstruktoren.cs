using System;

namespace Buecherei.Properties
{
    public static class Konstruktoren
    {
        public static void BuchErstellen(string author, string country, string imageLink, string language, string link,
            int pages,
            string title, int year)
        {
            Buch neuesBuch = new Buch(author, country, imageLink, language, link, pages, title, year);
            Listen.ProduktHinzufuegen(neuesBuch);
        }

        public static void ExemplarErstellen(IProduct product, bool verfuegbar)
        {
            Exemplar exemplar = new Exemplar(product.IdAusgeben(), verfuegbar);
            product.ExemplareHinzufuegen(exemplar);
        }

        public static void LeihvorgangErstellen(Buch buch, string name)
        {
            Exemplar verliehenesExemplar = buch.VerfuegbaresExemplarAusgeben();
            if (verliehenesExemplar == null)
            {
                Console.WriteLine("Sie haben versucht ein Buch zu verleihen was nicht mehr existiert");
                return;
            }

            LeihVorgang neuerLeihvorgang = new LeihVorgang(verliehenesExemplar, name);
            Listen.LeihvorgangHinzufuegen(neuerLeihvorgang);
            verliehenesExemplar.VerfuegbarkeitAendern(false);
        }
    }
}