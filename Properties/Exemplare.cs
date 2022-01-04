using System;
using Newtonsoft.Json;

namespace Buecherei.Properties
{
    public class Exemplar
    {
        public Guid GehoertZu { get; set; }
        public Guid Id { get; set; }
        public Boolean Verfuegbar { get; set; }

        public Exemplar(Guid gehoertZu ,bool verfuegbar)
        {
            GehoertZu = gehoertZu;
            Verfuegbar = verfuegbar;
            Id = Guid.NewGuid();
            
            Listen.ExemplarHinzufuegen(this);
        }
        
        [JsonConstructor]
        public Exemplar(Guid productId ,bool verfuegbar, Guid guid)
        {
            GehoertZu = productId;
            Verfuegbar = verfuegbar;
            Id = guid;
        }

        public void VerfuegbarkeitAendern(bool verfuegbarkeit)
        {
            Verfuegbar = verfuegbarkeit;
        }
    }
}