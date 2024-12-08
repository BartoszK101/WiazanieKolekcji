using System;

namespace WiazanieKolekcji
{

    public class Produkt
    {
        public string Symbol { get; set; }
        public string Nazwa { get; set; }
        public int LiczbaSztuk { get; set; }
        public string Magazyn { get; set; }

        public Produkt(string sym, string naz, int szt, string mag)
        {
            Symbol = sym;
            Nazwa = naz;
            LiczbaSztuk = szt;
            Magazyn = mag;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3}", Symbol, Nazwa, LiczbaSztuk, Magazyn);
        }
    }
}