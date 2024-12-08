using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WiazanieKompilacji
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Produkt> ListaProduktow = null;

        public MainWindow()
        {
            InitializeComponent();
            PrzygotujWiazanie();
        }

        private void PrzygotujWiazanie()
        {
            ListaProduktow = new ObservableCollection<Produkt>();
            ListaProduktow.Add(new Produkt("01-11", "ołówek", 8, "Katowice 1"));
            ListaProduktow.Add(new Produkt("PM-20", "pióro wieczne", 75, "Katowice 2"));
            ListaProduktow.Add(new Produkt("DZ-10", "długopis żelowy", 112, "Katowice 1"));
            ListaProduktow.Add(new Produkt("DZ-12", "długopis kulkowy", 280, "Katowice 2"));
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
    }
}
