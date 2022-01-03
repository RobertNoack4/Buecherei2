using Buecherei.Properties;

namespace Buecherei
{
    internal class Program
    {
        public static void Main()
        {
            Listen.ListenInit();
            Json.LoadBuch();
            Json.LoadMagazine();
            Json.LoadExemplar();
            Json.LoadLeihvorgaenge();
            Menues.HauptMenue();
        }   
    }
}