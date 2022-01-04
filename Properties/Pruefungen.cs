using System;

namespace Buecherei.Properties
{
    public static class Pruefungen
    {
        public static int EingabeZahlPruefung(int moeglichkeiten)
        {
            bool fehler;
            int probe = 0;
            do
            {
                fehler = false;
                try
                {
                    probe = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Bitte geben sie eine Zahl ein !");
                    fehler = true;
                }

                if (moeglichkeiten != 0)
                {
                    if (probe < 1 || probe > moeglichkeiten && fehler == false)
                    {
                        Console.WriteLine("Bitte wählen sie eine der möglichen Optionen aus");
                        fehler = true;
                    }
                }
            } while (fehler);

            return probe;
        }

        public static int EingabeZahlPruefung(int moeglichkeiten, string eingabe)
        {
            bool fehler;
            int probe = 0;
            do
            {
                fehler = false;
                try
                {
                    probe = Convert.ToInt32(eingabe);
                }
                catch
                {
                    Console.WriteLine("Bitte geben sie eine Zahl ein !");
                    eingabe = Console.ReadLine();
                    fehler = true;
                }

                if (moeglichkeiten != 0)
                {
                    if (probe < 1 || probe > moeglichkeiten && fehler == false)
                    {
                        Console.WriteLine("Bitte wählen sie eine der möglichen Optionen aus");
                        eingabe = Console.ReadLine();
                        fehler = true;
                    }
                }
            } while (fehler);

            return probe;
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
