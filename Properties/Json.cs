using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Buecherei.Properties
{
    public static class Json
    {
        private static string directory = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();
        public static void LoadJsonBuch()
        {
            using (StreamReader r = new StreamReader(directory + "/books.json"))
            {
                string json = r.ReadToEnd();
                List<Buch> listBuecher = JsonConvert.DeserializeObject<List<Buch>>(json);

                foreach (Buch buch in listBuecher)
                {
                    Listen.BuchHinzufuegen(buch);
                }
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
                StringBuilder builder = new StringBuilder();
                foreach (Exemplar exemplar in buch.Exemplare)
                {
                    builder.Append(exemplar.Id);
                    builder.Append(" ");
                }

                buch.ExemplarIds = builder.ToString();
                buch.Exemplare.Clear();
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
            foreach (Exemplar exemplar in exemplare)
            {
                exemplar.Buch = null;
            }
            
            using (StreamWriter file = File.CreateText(directory + "/exemplar.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, exemplare);
            }

        }
    }
}