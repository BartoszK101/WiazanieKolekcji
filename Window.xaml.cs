using System.ComponentModel;

namespace WiazanieKompilacji
{
    public partial class EditWindow : Window
    {
        private Produkt _produkt;

        public EditWindow(Produkt produkt)
        {
            InitializeComponent();
            _produkt = produkt;
            DataContext = _produkt;
        }

        private void btnPotwierdz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
