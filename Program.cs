using Buecherei.Properties;

namespace Buecherei
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Listen.BuchInit();
            Json.LoadJsonBuch();
            Menues.Hauptmenue();
        }   
    }
}