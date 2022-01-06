using Buecherei.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buecherei
{
    static class MenueServices
    {
        public static int EingabeZahl(bool option = true, int moeglichkeiten = 0)
        {
            string eingabe;
            bool bestanden;
            do
            {
                if(option == true)
                {
                    Console.WriteLine("Bitte wählen sie eine der Optionen aus");
                }
                else
                {
                    Console.WriteLine("Bitte geben sie eine Zahl ein");
                }

                eingabe = Console.ReadLine();
                bestanden = Pruefungen.EingabeZahlPruefung(eingabe);
                if (moeglichkeiten != 0 && bestanden)
                {
                    bestanden = Pruefungen.EingabeZahlIstOption(Convert.ToInt32(eingabe), moeglichkeiten);
                }
            }
            while (!bestanden);
            return Convert.ToInt32(eingabe);
        }
    }
}
