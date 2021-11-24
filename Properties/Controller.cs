using System;

namespace Buecherei.Properties
{
    public static class Controller
    {
        public static int EingabeZahlPruefung(int moeglichkeiten)
        {
            bool fehler = false;
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
            bool fehler = false;
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
    }
}