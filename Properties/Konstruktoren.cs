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
            product.ExemplarHinzufuegen(exemplar);
        }

        public static void LeihvorgangErstellen(IProduct product, string name)
        {
            int tage;
            Exemplar verliehenesExemplar = product.VerfuegbaresExemplarAusgeben();
            if (verliehenesExemplar == null)
            {
                Console.WriteLine("Sie haben versucht ein Buch zu verleihen was nicht mehr existiert");
                return;
            }

            switch (product.InformationenAusgeben("Art"))
            {
                case "Buch":
                    tage = 30;
                    break;
                case "Magazin":
                    tage = 2;
                    break;
                default:
                    tage = 0;
                    break;
            }

            LeihVorgang neuerLeihvorgang = new LeihVorgang(verliehenesExemplar, name, tage);
            Listen.LeihvorgangHinzufuegen(neuerLeihvorgang);
            verliehenesExemplar.VerfuegbarkeitAendern(false);
        }
        public static void LeihvorgangErstellen(IProduct product, string name, string link)
        {
            int tage;
            Exemplar verliehenesExemplar = product.VerfuegbaresExemplarAusgeben();
            if (verliehenesExemplar == null)
            {
                Console.WriteLine("Sie haben versucht ein Buch zu verleihen was nicht mehr existiert");
                return;
            }

            switch (product.InformationenAusgeben("Art"))
            {
                case "Buch":
                    tage = 30;
                    break;
                case "Magazin":
                    tage = 2;
                    break;
                default:
                    tage = 0;
                    break;
            }

            LeihVorgang neuerLeihvorgang = new LeihVorgang(verliehenesExemplar, name, tage, link);
            Listen.LeihvorgangHinzufuegen(neuerLeihvorgang);
            verliehenesExemplar.VerfuegbarkeitAendern(false);
        }
    }
}