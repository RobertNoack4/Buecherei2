using System;
using System.Collections.Generic;
namespace Buecherei.Properties
{
    public interface IProduct
    {
        string InformationenAusgeben(string art);

        void Aenderung(string art, string aenderung);

        Guid IdAusgeben();

        void ExemplarHinzufuegen(Exemplar exemplar);

        int ExemplareVerfuegbar();

        Exemplar VerfuegbaresExemplarAusgeben();

        List<Exemplar> AlleExemplareAusgeben();

        void ExemplarLoeschen(int position);
    }
}