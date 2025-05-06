using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy Pop1.xaml
    /// </summary>
    public partial class Pop1 : Window
    {
        public Pop1()
        {
            InitializeComponent();
        }

        private void Button_Click_cancel(object sender, RoutedEventArgs e)
        {
            Pop3 pop3 = new Pop3();
            pop3.ShowDialog();
        }

        private void Button_Click_ok(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(imie.Text))
            { imie.Background = Brushes.Red;
            }
            else
            {
                imie.Background = Brushes.White;
            }

            if (string.IsNullOrEmpty(nazwisko.Text))
            {
                nazwisko.Background = Brushes.Red;
            }
            else
            {
                nazwisko.Background = Brushes.White;
            }

            if (string.IsNullOrEmpty(pesel.Text))
            {
               pesel.Background = Brushes.Red;
            }
            else
            {
                pesel.Background = Brushes.White;
            }

            if (string.IsNullOrEmpty(data.Text))
            {
                data.Background = Brushes.Red;
            }
            else
            {
                data.Background = Brushes.White;
            }
            if (string.IsNullOrEmpty(nr.Text))
            {
                nr.Background = Brushes.Red;
            }
            else
            {
                nr.Background = Brushes.White;
            }
            if (string.IsNullOrEmpty(adres.Text))
            {
                adres.Background = Brushes.Red;
            }
            else
            {
                adres.Background = Brushes.White;
                if (string.IsNullOrEmpty(miejscowosc.Text))
                {
                    miejscowosc.Background = Brushes.Red;
                }
                else
                {
                    miejscowosc.Background = Brushes.White;
                }
                if (string.IsNullOrEmpty(kod.Text))
                {
                    kod.Background = Brushes.Red;
                }
                else
                {
                    kod.Background = Brushes.White;
                }
            }
    }
}
