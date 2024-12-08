namespace WiazanieKompilacji
{
    public partial class AddProductWindow : Window
    {
        public Produkt NowyProdukt { get; private set; }
        private bool czyNowyProdukt;

        public AddProductWindow(bool czyNowy = false)
        {
            InitializeComponent();
            czyNowyProdukt = czyNowy;
            PrzygotujWiazanie();
        }

        private void PrzygotujWiazanie()
        {
            if (czyNowyProdukt)
            {
                NowyProdukt = new Produkt("AA-00", "", 0, "");
                DataContext = NowyProdukt;
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
