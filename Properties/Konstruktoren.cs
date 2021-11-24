namespace Buecherei.Properties
{
    public static class Konstruktoren
    {
        public static void BuchErstellen(string author, string country, string imageLink, string language, string link,
            int pages,
            string title, int year)
        {
            Buch neuesBuch = new Buch(author, country, imageLink, language, link, pages, title, year);
            Listen.BuchHinzufuegen(neuesBuch);
        }

        public static void ExemplarErstellen(Buch buch, bool verfuegbar)
        {
            Exemplar neuesExemplar = new Exemplar(buch, verfuegbar);
            Listen.ExemplarHinzufuegen(neuesExemplar);
        }
    }
}