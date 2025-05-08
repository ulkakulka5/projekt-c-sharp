using System.Collections.Generic;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private List<Osoba> listaucznioww = new List<Osoba>();

        public MainWindow()
        {
            InitializeComponent();
            listauczniow.ItemsSource = listaucznioww;
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            var pop1 = new Pop1();
            if (pop1.ShowDialog() == true)
            {
                listaucznioww.Add(pop1.NowaOsoba);
                listauczniow.Items.Refresh();
            }
        }

        private void usun(object sender, RoutedEventArgs e)
        {
            while (listauczniow.SelectedItems.Count > 0)
            {
                listaucznioww.Remove((Osoba)listauczniow.SelectedItems[0]);
            }
            listauczniow.Items.Refresh();
        }

        private void oprogramie(object sender, RoutedEventArgs e)
        {
            var pop2 = new Pop2();
            pop2.ShowDialog();
        }

        private void wczytaj(object sender, RoutedEventArgs e)
        {
            // 
        }

        private void zapisz(object sender, RoutedEventArgs e)
        {
            //
        }

        private void wyjscie(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    public class Osoba
    {
        public string? Pesel { get; set; }
        public string? Imie { get; set; }
        public string? Drugieimie { get; set; }
        public string? Nazwisko { get; set; }
        public string? Data { get; set; }
        public string? Numer { get; set; }
        public string? Adres { get; set; }
        public string? Miejscowosc { get; set; }
        public string? Kod { get; set; }
    }
}
