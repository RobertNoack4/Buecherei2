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
        private static readonly string directory = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();
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
                        if (buch.IdAusgeben() == Guid.Empty)
                        {
                            buch.BuchIdGenerieren();
                        }

                        //Konstruktoren.ExemplarErstellen(buch, true);
                        //Konstruktoren.ExemplarErstellen(buch, true);

                        //Exemplar exemplar = new Exemplar(buch.IdAusgeben(), true);
                        //buch.ExemplarHinzufuegen(exemplar);
                        //Exemplar exemplar2 = new Exemplar(buch.IdAusgeben(), true);
                        //buch.ExemplarHinzufuegen(exemplar2);

                        Listen.ProduktHinzufuegen(buch);
                    }
                    r.Close();
                }

            }
            catch
            {
                Debug.WriteLine("books.json nicht gefunden");
            }
        }
        
        public static void LoadExemplar()
        {
            try
            {
                List<Buch> alleBuecher = new List<Buch>();
                List<IProduct> alleProdukte = Listen.ProduktListeAusgeben();
                List<Magazin> alleMagazine = new List<Magazin>();
                foreach (IProduct product in alleProdukte)
                {
                    if (product.InformationenAusgeben("Art") == "Buch")
                    {
                        Buch neuesBuch = new Buch(product.InformationenAusgeben("Author"), Convert.ToInt32(product.InformationenAusgeben("Seiten")), product.InformationenAusgeben("Titel"), product.IdAusgeben(), product.InformationenAusgeben("Land"), product.InformationenAusgeben("Bild"), product.InformationenAusgeben("Sprache"), product.InformationenAusgeben("Link"), Convert.ToInt32(product.InformationenAusgeben("Jahr")));
                        alleBuecher.Add(neuesBuch);
                    }

                    if (product.InformationenAusgeben("Art") == "Magazin")
                    {
                        Magazin neuesMagazin = new Magazin(Convert.ToInt32(product.InformationenAusgeben("Rang")), product.InformationenAusgeben("Titel"), product.InformationenAusgeben("Auflage"), product.InformationenAusgeben("Gruppe"), product.InformationenAusgeben("SachGruppe"), product.InformationenAusgeben("Verlag"), product.IdAusgeben());
                        alleMagazine.Add(neuesMagazin);
                    }
                }
                using (StreamReader r = new StreamReader(directory + "/exemplar.json"))
                {
                    string json = r.ReadToEnd();
                    List<Exemplar> listExemplar = JsonConvert.DeserializeObject<List<Exemplar>>(json);
                    if (listExemplar != null)
                    {
                        foreach (Exemplar exemplar in listExemplar)
                        {
                            
                            Buch buch = alleBuecher.Find(x => x.IdAusgeben() == exemplar.GehoertZu);
                            if (buch != null)
                            {
                                buch.ExemplarHinzufuegen(exemplar);
                            }

                            Magazin magazin = alleMagazine.Find(x => x.IdAusgeben() == exemplar.GehoertZu);

                            if (magazin != null)
                            {
                                magazin.ExemplarHinzufuegen(exemplar);
                            }

                            Listen.ExemplarHinzufuegen(exemplar);
                        }
                        r.Close();
                    }
                }
            }
            catch
            {
                Debug.Print("exemplar.json nicht zum laden gefunden");
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

                    if(listLeihVorgang != null)
                    {
                        foreach (LeihVorgang leihvorgang in listLeihVorgang)
                        {
                            Exemplar exemplar = alleExemplare.Find(x => x.Id == leihvorgang.ExemplarId);
                            leihvorgang.ExemplarHinzufuegen(exemplar);
                            Listen.LeihvorgangHinzufuegen(leihvorgang);
                        }
                    }
                    r.Close();
                }

            }
            catch 
            {
                Debug.Print("leihen.json nicht zum laden gefunden");
            }
        }

        public static void LoadMagazine()
        {
            try
            {
                using (StreamReader r = new StreamReader(directory + "/Magazine.json"))
                {
                    string json = r.ReadToEnd();
                    List<Magazin> listMagazine = JsonConvert.DeserializeObject<List<Magazin>>(json);

                    if (listMagazine != null)
                    {
                        foreach (Magazin magazin in listMagazine)
                        {
                            if (magazin.IdAusgeben() == Guid.Empty)
                            {
                                magazin.IdGenerieren();
                            }

                            //Konstruktoren.ExemplarErstellen(magazin, true);
                            //Konstruktoren.ExemplarErstellen(magazin, true);
                            //Exemplar exemplar = new Exemplar(magazin.IdAusgeben(), true);
                            //magazin.ExemplarHinzufuegen(exemplar);
                            //Exemplar exemplar2 = new Exemplar(magazin.IdAusgeben(), true);
                            //magazin.ExemplarHinzufuegen(exemplar2);

                            Listen.ProduktHinzufuegen(magazin);
                        }
                    }
                    r.Close();
                }

            }
            catch 
            {
                Debug.Print("Magazin.json zum Laden nicht gefunden");
            }

        }



        public static void SpeicherBuch()
        {
            List<Buch> alleBuecher = new List<Buch>();
            List<IProduct> produkte = Listen.ProduktListeAusgeben();
            foreach (IProduct product in produkte)
            {
                if (product.InformationenAusgeben("Art") == "Buch")
                {
                    Buch neuesBuch = new Buch(product.InformationenAusgeben("Author"), Convert.ToInt32(product.InformationenAusgeben("Seiten")), product.InformationenAusgeben("Titel"),product.IdAusgeben() ,product.InformationenAusgeben("Land"), product.InformationenAusgeben("Bild"),product.InformationenAusgeben("Sprache"), product.InformationenAusgeben("Link") ,Convert.ToInt32(product.InformationenAusgeben("Jahr")));
                    alleBuecher.Add(neuesBuch);
                }
            }
            string json = JsonConvert.SerializeObject(alleBuecher);

            File.WriteAllText(directory + "/books.json", json);
        }

        public static void SpeicherMagazin()
        {
            List<Magazin> alleMagazine = new List<Magazin>();
            List<IProduct> produkte = Listen.ProduktListeAusgeben();
            foreach (IProduct product in produkte)
            {
                if (product.InformationenAusgeben("Art") == "Magazin")
                {
                    Magazin neuesMagazin = new Magazin(Convert.ToInt32(product.InformationenAusgeben("Rang")), product.InformationenAusgeben("Titel"), product.InformationenAusgeben("Auflage"), product.InformationenAusgeben("Gruppe"), product.InformationenAusgeben("SachGruppe"), product.InformationenAusgeben("Verlag"), product.IdAusgeben());
                    alleMagazine.Add(neuesMagazin);                
                }
            }
            string json = JsonConvert.SerializeObject(alleMagazine);

            File.WriteAllText(directory + "/Magazine.json", json);
        }


        public static void SpeicherExemplar()
        {

            List<Exemplar> exemplare = Listen.ExemplarListenAusgeben();
            
            string json = JsonConvert.SerializeObject(exemplare);

            File.WriteAllText(directory + "/exemplar.json", json);
        }
        
        
        public static void SpeicherLeihvorgang()
        {

            List<LeihVorgang> leihVorgaenge = Listen.LeihVorgangsListeAusgeben();
            foreach (LeihVorgang leihVorgang in leihVorgaenge)
            {
                leihVorgang.ExemplarId = leihVorgang.GeliehenesExemplar.Id;
                leihVorgang.GeliehenesExemplar = null; 
            }

            string json = JsonConvert.SerializeObject(leihVorgaenge);

            File.WriteAllText(directory + "/leihen.json", json);
        }
    }
}