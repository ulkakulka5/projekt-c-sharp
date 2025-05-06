using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<string> items = new List<string>();
            listauczniow.ItemsSource = items;
        }
        public class Osoba
        {
            public required string Pesel { get; set; }
            public required string Imie { get; set; }

            public string? Drugieimie { get; set; }  
            public required string Nazwisko { get; set; }    
            public required string Data {  get; set; }
            public string? Numer {  get; set; }
            public required string Adres { get; set; }
            public required string Miejscowosc {  get; set; }
            public required string Kod {  get; set; }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pop1 pop1 = new Pop1();
            pop1.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Pop2 pop2 = new Pop2();
            pop2.ShowDialog();
        }

        
    }
}
