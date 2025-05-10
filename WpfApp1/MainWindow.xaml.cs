using System.Collections.Generic;
using System.Windows;

namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        private List<Osoba> listaucznioww = new List<Osoba>();

        public MainWindow()
        {
            listaucznioww.Add(new Osoba
            {
                Pesel = "99010112345",
                Imie = "Anna",
                Drugieimie = "Maria",
                Nazwisko = "Kowalska",
                Data = "1999-01-01",
                Numer = "+48123456789",
                Adres = "ul. Polna 12",
                Miejscowosc = "Tarnów",
                Kod = "33-100"
            });

            listaucznioww.Add(new Osoba
            {
                Pesel = "01020345678",
                Imie = "Jan",
                Drugieimie = "Paweł",
                Nazwisko = "Nowak",
                Data = "2001-02-03",
                Numer = "+48551234567",
                Adres = "ul. Szkolna 3",
                Miejscowosc = "Kraków",
                Kod = "30-001"
            });

            listaucznioww.Add(new Osoba
            {
                Pesel = "02123198765",
                Imie = "Karolina",
                Drugieimie = "",
                Nazwisko = "Wiśniewska",
                Data = "2002-12-31",
                Numer = "600123456",
                Adres = "ul. Kwiatowa 9",
                Miejscowosc = "Warszawa",
                Kod = "00-001"
            });

            listaucznioww.Add(new Osoba
            {
                Pesel = "98101534567",
                Imie = "Michał",
                Drugieimie = "Adam",
                Nazwisko = "Zieliński",
                Data = "1998-10-15",
                Numer = "+48771122334",
                Adres = "ul. Długa 22",
                Miejscowosc = "Poznań",
                Kod = "60-001"
            });

            listaucznioww.Add(new Osoba
            {
                Pesel = "00040567891",
                Imie = "Julia",
                Drugieimie = "Natalia",
                Nazwisko = "Dąbrowska",
                Data = "2000-04-05",
                Numer = "789456123",
                Adres = "ul. Leśna 5",
                Miejscowosc = "Gdańsk",
                Kod = "80-001"
            });

            listaucznioww.Add(new Osoba
            {
                Pesel = "95072311234",
                Imie = "Tomasz",
                Drugieimie = "Marek",
                Nazwisko = "Wójcik",
                Data = "1995-07-23",
                Numer = "+48601234567",
                Adres = "ul. Spokojna 1",
                Miejscowosc = "Lublin",
                Kod = "20-001"
            });

            listaucznioww.Add(new Osoba
            {
                Pesel = "02111222333",
                Imie = "Zuzanna",
                Drugieimie = "",
                Nazwisko = "Kamińska",
                Data = "2002-11-12",
                Numer = "501501501",
                Adres = "ul. Miodowa 11",
                Miejscowosc = "Rzeszów",
                Kod = "35-001"
            });

            listaucznioww.Add(new Osoba
            {
                Pesel = "96022877777",
                Imie = "Paweł",
                Drugieimie = "Grzegorz",
                Nazwisko = "Lewandowski",
                Data = "1996-02-28",
                Numer = "+48777777777",
                Adres = "ul. Sportowa 6",
                Miejscowosc = "Szczecin",
                Kod = "70-001"
            });

            listaucznioww.Add(new Osoba
            {
                Pesel = "03030344444",
                Imie = "Aleksandra",
                Drugieimie = "Katarzyna",
                Nazwisko = "Król",
                Data = "2003-03-03",
                Numer = "666333999",
                Adres = "ul. Krótka 8",
                Miejscowosc = "Opole",
                Kod = "45-001"
            });

            listaucznioww.Add(new Osoba
            {
                Pesel = "99123111111",
                Imie = "Kacper",
                Drugieimie = "",
                Nazwisko = "Mazur",
                Data = "1999-12-31",
                Numer = "+48500500500",
                Adres = "ul. Słoneczna 14",
                Miejscowosc = "Zielona Góra",
                Kod = "65-001"
            });


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
           
            List<Osoba> dousuniecia = new List<Osoba>();

            
            foreach (Osoba o in listauczniow.SelectedItems)
            {
                dousuniecia.Add(o);
            }

                      foreach (Osoba o in dousuniecia)
            {
                listaucznioww.Remove(o);
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
            // Dodaj kod wczytywania danych
        }

        private void zapisz(object sender, RoutedEventArgs e)
        {
            // Dodaj kod zapisywania danych
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
