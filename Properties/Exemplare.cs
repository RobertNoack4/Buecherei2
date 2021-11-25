using System;
using System.Runtime.CompilerServices;

namespace Buecherei.Properties
{
    public class Exemplar
    {
        public Buch Buch { get; set; }
        public Guid Id { get; set; }
        public Boolean Verfuegbar { get; set; }

        public Exemplar(Buch buch, bool verfuegbar)
        {
            Buch = buch;
            Verfuegbar = verfuegbar;
            Id = Guid.NewGuid();
            
            Listen.ExemplarHinzufuegen(this);
        }

        public void VerfuegbarkeitAendern(bool verfuegbarkeit)
        {
            Verfuegbar = verfuegbarkeit;
        }
    }
}