using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WiazanieKompilacji
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Produkt> ListaProduktow = new ObservableCollection<Produkt>();

        public MainWindow()
        {
            InitializeComponent();
            PrzygotujWiazanie();
        }

        private void PrzygotujWiazanie()
        {
            ListaProduktow.Add(new Produkt { Symbol = "01-11", Nazwa = "ołówek", LiczbaSztuk = 8, Magazyn = "Katowice 1" });
            ListaProduktow.Add(new Produkt { Symbol = "PM-20", Nazwa = "pióro wieczne", LiczbaSztuk = 75, Magazyn = "Katowice 2" });
            ListaProduktow.Add(new Produkt { Symbol = "DZ-10", Nazwa = "długopis żelowy", LiczbaSztuk = 112, Magazyn = "Katowice 1" });
            ListaProduktow.Add(new Produkt { Symbol = "DZ-12", Nazwa = "długopis kulkowy", LiczbaSztuk = 280, Magazyn = "Katowice 2" });

            lstProdukty.ItemsSource = ListaProduktow;

            CollectionView widok = (CollectionView)CollectionViewSource.GetDefaultView(lstProdukty.ItemsSource);
            widok.SortDescriptions.Add(new SortDescription("Magazyn", ListSortDirection.Ascending));
            widok.SortDescriptions.Add(new SortDescription("Nazwa", ListSortDirection.Ascending));
            widok.Filter = FiltrUzytkownika;
        }

        private bool FiltrUzytkownika(object item)
        {
            if (string.IsNullOrEmpty(txtFilter.Text))
                return true;
            return ((item as Produkt).Nazwa.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void TxtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lstProdukty.ItemsSource).Refresh();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var nowyProdukt = new Produkt { Symbol = "AA-00", Nazwa = "", LiczbaSztuk = 0, Magazyn = "" };
            ListaProduktow.Add(nowyProdukt);
            lstProdukty.SelectedItem = nowyProdukt;
        }

        private void btnUsun_Click(object sender, RoutedEventArgs e)
        {
            if (lstProdukty.SelectedItem is Produkt selectedProduct)
            {
                ListaProduktow.Remove(selectedProduct);
            }
        }

        private void btnPotwierdz_Click(object sender, RoutedEventArgs e)
        {
          
            lstProdukty.Items.Refresh();
        }
    }
}
