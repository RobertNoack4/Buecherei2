using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Buecherei.Properties
{
    public class Exemplar
    {
        public Guid Buch { get; set; }
        public Guid Id { get; set; }
        public Boolean Verfuegbar { get; set; }

        public Exemplar(Guid buch ,bool verfuegbar)
        {
            Buch = buch;
            Verfuegbar = verfuegbar;
            Id = Guid.NewGuid();
            
            Listen.ExemplarHinzufuegen(this);
        }
        
        [JsonConstructor]
        public Exemplar(Guid buch ,bool verfuegbar, Guid guid)
        {
            Buch = buch;
            Verfuegbar = verfuegbar;
            Id = guid;
        }

        public void VerfuegbarkeitAendern(bool verfuegbarkeit)
        {
            Verfuegbar = verfuegbarkeit;
        }

        public void BuchHinzufuegen(Guid BuchId)
        {
            Buch = BuchId;
        }
    }
}