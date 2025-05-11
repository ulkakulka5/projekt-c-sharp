using System.Collections.Generic;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        private List<Osoba> listaucznioww = new List<Osoba>();

        public MainWindow()
        {
            /* listaucznioww.Add(new Osoba
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
            }); */


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

        private void usun(object sender, RoutedEventArgs e)//to krotsze z moodla zwieszalo mi komputer
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki CSV z separatorem (,)|*.csv|Pliki CSV z separatorem (;)|*.csv";
            openFileDialog.Title = "Otwórz plik CSV";

            if (openFileDialog.ShowDialog() == true)
            {
                listaucznioww.Clear(); 

                string filePath = openFileDialog.FileName;
                int selectedFilterIndex = openFileDialog.FilterIndex;
                string delimiter = ";";

                if (selectedFilterIndex == 1)
                {
                    delimiter = ",";
                }

                Encoding encoding = Encoding.UTF8;

                if ( File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath, encoding);
                    foreach (var line in lines)
                    {
                        string[] columns = line.Split(delimiter);
                        if (columns != null)
                        {
                            Osoba uczen = new Osoba();
                            uczen.Imie = columns.ElementAtOrDefault(0);
                            uczen.Drugieimie = columns.ElementAtOrDefault(1);
                            uczen.Nazwisko = columns.ElementAtOrDefault(2);
                            uczen.Pesel = columns.ElementAtOrDefault(3);
                            uczen.Data = columns.ElementAtOrDefault(4);
                            uczen.Numer = columns.ElementAtOrDefault(5);
                            uczen.Adres = columns.ElementAtOrDefault(6);
                            uczen.Miejscowosc = columns.ElementAtOrDefault(7);
                            uczen.Kod = columns.ElementAtOrDefault(8);
                            listaucznioww.Add(uczen);

                        }
                    }
                }
                
            }listauczniow.Items.Refresh();
        }

        
           private void zapisz(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki CSV z separatorem (,)|*.csv|Pliki CSV z separatorem (;)|*.csv";
            saveFileDialog.Title = "Zapisz jako plik CSV";

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                string delimiter = ";";

                if (saveFileDialog.FilterIndex == 1)
                {
                    delimiter = ",";
                }

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Osoba item in listauczniow.Items)
                    {
                        var row = $"{item.Imie}{delimiter}{item.Drugieimie}{delimiter}{item.Nazwisko}{delimiter}{item.Pesel}{delimiter}{item.Data}{delimiter}{item.Numer}{delimiter}{item.Adres}{delimiter}{item.Miejscowosc}{delimiter}{item.Kod}";
                        writer.WriteLine(row);
                    }
                }
            }
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
