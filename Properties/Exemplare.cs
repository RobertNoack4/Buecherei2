using System;

namespace Buecherei.Properties
{
    public class Exemplar
    {
        public Buch Buch { get; set; }
        public Guid Id { get; set; }
        public Boolean Verfuefbar { get; set; }

        public Exemplar(Buch buch, bool verfuegbar)
        {
            Buch = buch;
            Verfuefbar = verfuegbar;
            Id = Guid.NewGuid();
        }
    }
}