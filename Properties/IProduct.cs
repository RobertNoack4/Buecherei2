using System;
namespace Buecherei.Properties
{
    public interface IProduct
    {
        string TitelAusgeben();
        string ArtAusgeben();

        Guid IdAusgeben();

        void ExemplarHinzufuegen(Exemplar exemplar);
    }
}