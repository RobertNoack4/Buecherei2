using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Buecherei.Properties
{
    public static class Json
    {
        private static string directory = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();
        public static void LoadBuch()
        {
            try
            {
                using (StreamReader r = new StreamReader(directory + "/books.json"))
                {
                    string json = r.ReadToEnd();
                    List<Buch> listBuecher = JsonConvert.DeserializeObject<List<Buch>>(json);

                    foreach (Buch buch in listBuecher)
                    {
                        if (buch.BuchId == Guid.Empty)
                        {
                            buch.BuchIdGenerieren();
                        }
                        Listen.BuchHinzufuegen(buch);
                    }
                    r.Close();
                }

            }
             catch 
             {
                 Debug.Print("books.json nicht zum laden gefunden");
             }
        }
        
        public static void LoadExemplar()
        {
            try
            {
                List<Buch> alleBuecher = Listen.BuchListeAusgeben();
                using (StreamReader r = new StreamReader(directory + "/exemplar.json"))
                {
                    string json = r.ReadToEnd();
                    List<Exemplar> listExemplar = JsonConvert.DeserializeObject<List<Exemplar>>(json);

                    foreach (Exemplar exemplar in listExemplar)
                    {
                        Buch buch = alleBuecher.Find(x => x.BuchId == exemplar.Buch);
                        buch.ExemplarHinzufuegen(exemplar);
                        Listen.ExemplarHinzufuegen(exemplar);
                    }
                    r.Close();
                }
            }
            catch 
            {
                Debug.Print("books.json nicht zum laden gefunden");
            }
        }
        
        public static void LoadLeihvorgaenge()
        {
            try
            {
                List<Exemplar> alleExemplare = Listen.ExemplarListenAusgeben();
                using (StreamReader r = new StreamReader(directory + "/leihen.json"))
                {
                    string json = r.ReadToEnd();
                    List<LeihVorgang> listLeihVorgang = JsonConvert.DeserializeObject<List<LeihVorgang>>(json);

                    foreach (LeihVorgang leihvorgang in listLeihVorgang)
                    {
                        Exemplar exemplar = alleExemplare.Find(x => x.Id == leihvorgang.ExemplarId);
                        leihvorgang.ExemplarHinzufuegen(exemplar);
                        Listen.LeihvorgangHinzufuegen(leihvorgang);
                    }
                    r.Close();
                }

            }
            catch 
            {
                Debug.Print("books.json nicht zum laden gefunden");
            }
        }



        public static void SpeicherBuch()
        {
            try
            {
                File.Delete(directory + "/books.json");
            }
            catch
            {
                Debug.Print("books.json beim Speichern nicht gefunden");
            }
            List<Buch> buecher = Listen.BuchListeAusgeben();
            foreach (Buch buch in buecher)
            {
                buch.Exemplare.Clear();
                Debug.Print(Convert.ToString(buch.BuchId));
            }
            using (StreamWriter file = File.CreateText(directory + "/books.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Listen.BuchListeAusgeben());
            }
        }

        public static void SpeicherExemplar()
        {
            try
            {
                File.Delete(directory + "/exemplar.json");
            }
            catch 
            {
                Debug.Print("exemplar.json beim Speichern nicht gefunden");
            }

            List<Exemplar> exemplare = Listen.ExemplarListenAusgeben();
            
            using (StreamWriter file = File.CreateText(directory + "/exemplar.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, exemplare);
            }
        }
        public static void SpeicherLeihvorgang()
        {
            try
            {
                File.Delete(directory + "/leihen.json");
            }
            catch 
            {
                Debug.Print("leihen.json beim Speichern nicht gefunden");
            }

            List<LeihVorgang> leihVorgaenge = Listen.LeihVorgangsListeAusgeben();
            foreach (LeihVorgang leihVorgang in leihVorgaenge)
            {
                leihVorgang.ExemplarId = leihVorgang.GeliehenesExemplar.Id;
                leihVorgang.GeliehenesExemplar = null; 
            }
            
            using (StreamWriter file = File.CreateText(directory + "/leihen.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, leihVorgaenge);
            }
        }
    }
}