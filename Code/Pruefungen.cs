using System;

namespace Buecherei.Properties
{
    public static class Pruefungen
    {
        public static bool EingabeZahlPruefung(string input)
        {
            bool fehler;
            int probe;
            if(input == null)
            {
                return false;
            }

            try
            {
                probe = Convert.ToInt32(input);
                return true;
            }
            catch
            {
                Console.WriteLine("Bitte geben sie eine Zahl ein !");
                return false;
            }
        }

        public static bool EingabeZahlIstOption(int eingabe, int moeglichkeiten)
        {
            if(eingabe < 1 || eingabe > moeglichkeiten)
            {
                return false;
            }
            return true;
        }

        public static bool JaNeinTest()
        {
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Y)
                {
                    return true;
                }
                else if (keyInfo.Key == ConsoleKey.N)
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Bitte geben sie entweder Y oder N ein!");
                }

            } while (true);
        }

        public static bool JaNeinTest(string eingabe)
        {
            if (eingabe == "Y" || eingabe == "y")
            {
                return true;
            }
            else if (eingabe == "N" || eingabe == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Bitte geben sie entweder Y oder N ein!");
                do
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Y)
                    {
                        return true;
                    }
                    else if (keyInfo.Key == ConsoleKey.N)
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("Bitte geben sie entweder Y oder N ein!");
                    }

                } while (true);
            }
        }


        public static bool DatumPruefung(string datum)
        {
            try
            {
                DateTime test = Convert.ToDateTime(datum);
            }
            catch
            {
                Console.WriteLine("Bitte geben sie das Datum im Format: MM/dd/YYYY ein");
                return false;
            }

            return true;
        }
    }
}
