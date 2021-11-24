using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Buecherei.Properties
{
    public static class Json
    {
        public static void LoadJsonBuch()
        {
            string directory = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString(); 
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
    }
}