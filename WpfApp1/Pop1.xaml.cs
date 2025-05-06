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
            string? imiezmienna;
            string? peselzmienna;
            string? drugiezmienna;
            string? nazwiskozmienna;
            string? datazmienna;
            string? nrzmienna;
            string? adreszmienna;
            string? miejscowosczmienna;
            string? kodzmienna;

            drugiezmienna = char.ToUpper(drugieimie.Text.Trim()[0]) + drugieimie.Text.Trim().Substring(1).ToLower();
            drugiezmienna = drugiezmienna.Replace(" ", "");

            if (string.IsNullOrEmpty(imie.Text))
            { imie.Background = Brushes.Red;
            }
            else
            {
                imiezmienna=char.ToUpper(imie.Text.Trim()[0]) + imie.Text.Trim().Substring(1).ToLower();
                imiezmienna = imiezmienna.Replace(" ", "");
                imie.Background = Brushes.White;
            }

            if (string.IsNullOrEmpty(nazwisko.Text))
            {
                nazwisko.Background = Brushes.Red;
            }
            else
            {
                string[] czlony = nazwisko.Text.Trim().Split('-');
                for (int i = 0; i < czlony.Length; i++)
                {
                    if (czlony[i].Length > 0 && char.IsLetter(czlony[i][0]))
                    {
                        string pierwsza = czlony[i].Substring(0, 1).ToUpper();
                        string reszta = czlony[i].Substring(1).ToLower();
                        czlony[i] = pierwsza + reszta;
                    }
                }
                nazwiskozmienna = string.Join("-", czlony);
                nazwiskozmienna = nazwiskozmienna.Replace(" ", "");
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

           

            if (string.IsNullOrEmpty(adres.Text))
            {
                adres.Background = Brushes.Red;
            }
            else
            {
                string[] slowa = adres.Text.Trim().Split(' ');
                for (int i = 0; i < slowa.Length; i++)
                {
                    if (slowa[i].Length > 0 && char.IsLetter(slowa[i][0]))
                    {
                        string pierwsza = slowa[i].Substring(0, 1).ToUpper();
                        string reszta = slowa[i].Substring(1).ToLower();
                        slowa[i] = pierwsza + reszta;
                    }
                }
               adreszmienna = string.Join(" ", slowa);
                adres.Background = Brushes.White;
            }

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

           
            if (pesel.Text.Length != 11)
            {
                pesel.Background = Brushes.Red;
            }
            else { for (int i = 0; i < pesel.Text.Length; i++)
            {
                if (!char.IsDigit(pesel.Text[i]))
                {
                    pesel.Background = Brushes.Red;
                }
                else
                {

                        int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
                        int suma = 0;

                        for (int j = 0; i < 10; i++)
                        {
                            suma += (pesel.Text[j] - '0') * wagi[j];
                        }

                        int cyfraKontrolna = (10 - (suma % 10)) % 10;

                        if (cyfraKontrolna != (pesel.Text[10] - '0'))
                        {
                            pesel.Background = Brushes.Red;
                        }
                    }

                    
                }
            }}
            

            
            

        }
    }

