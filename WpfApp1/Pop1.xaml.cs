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
using static WpfApp1.MainWindow;

namespace WpfApp1
{
  
    public partial class Pop1 : Window
    {
        public Pop1()
        {
            InitializeComponent();
        }

        private void Button_Click_cancel(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(imie.Text) ||// inaczej puste="", czyli null bedzie true
    !string.IsNullOrWhiteSpace(pesel.Text) ||
    !string.IsNullOrWhiteSpace(drugieimie.Text) ||
    !string.IsNullOrWhiteSpace(nazwisko.Text) ||
    !string.IsNullOrWhiteSpace(data.Text) ||
    !string.IsNullOrWhiteSpace(nr.Text) ||
    !string.IsNullOrWhiteSpace(adres.Text) ||
    !string.IsNullOrWhiteSpace(miejscowosc.Text) ||
    !string.IsNullOrWhiteSpace(kod.Text))
            {
                var okno = new Pop3(this);
                okno.ShowDialog();
            }
            else
            {
                Close();
            }

        }
        public Osoba? NowaOsoba { get; private set; }
        private void Button_Click_ok(object sender, RoutedEventArgs e)
        {

            string? imiezmienna = null;
            string? peselzmienna = null;
            string? drugiezmienna = null;
            string? nazwiskozmienna = null;
            string? datazmienna = null;
            string? nrzmienna = null;
            string? adreszmienna = null;
            string? miejscowosczmienna = null;
            string? kodzmienna = null;
            bool dodac = false;
            
            if (!string.IsNullOrEmpty(drugieimie.Text))
            {
                drugiezmienna = char.ToUpper(drugieimie.Text.Trim()[0]) + drugieimie.Text.Trim().Substring(1).ToLower();
                drugiezmienna = drugiezmienna.Replace(" ", "");
            }
            else
            {
                drugiezmienna = "";
            }


            if (string.IsNullOrEmpty(imie.Text))
            {
                imie.Background = Brushes.Red;
                dodac = false;
            }
            else
            {
                imiezmienna = char.ToUpper(imie.Text.Trim()[0]) + imie.Text.Trim().Substring(1).ToLower();
                imiezmienna = imiezmienna.Replace(" ", "");
                imie.Background = Brushes.White;
                dodac = true;
            }

            if (string.IsNullOrEmpty(nazwisko.Text))
            {
                nazwisko.Background = Brushes.Red;
                dodac = false;
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
                dodac = true;
            }

            

            if (string.IsNullOrEmpty(data.Text))
            {
                data.Background = Brushes.Red;
                dodac = false;
            }
            else
            {
                DateTime dataTest;
                if (!DateTime.TryParse(data.Text, out dataTest))
                {
                    data.Background = Brushes.Red;
                    dodac = false;
                }
                else
                {
                    datazmienna = dataTest.ToString("yyyy-MM-dd");
                    data.Background = Brushes.White;
                    dodac = true;
                }
                
            }



            if (string.IsNullOrEmpty(adres.Text))
            {
                adres.Background = Brushes.Red;
                dodac = false;
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
                dodac = true;
            }

            if (string.IsNullOrEmpty(miejscowosc.Text))
            {
                miejscowosc.Background = Brushes.Red;
                dodac = false;
            }
            else
            {
                string[] slowam = miejscowosc.Text.Trim().Split(' ');
                for (int i = 0; i < slowam.Length; i++)
                {
                    if (slowam[i].Length > 0 && char.IsLetter(slowam[i][0]))
                    {
                        string pierwsza = slowam[i].Substring(0, 1).ToUpper();
                        string reszta = slowam[i].Substring(1).ToLower();
                        slowam[i] = pierwsza + reszta;
                    }
                }
                miejscowosczmienna = string.Join(" ", slowam);
                miejscowosc.Background = Brushes.White;
                dodac = true;
            }

            if (string.IsNullOrEmpty(kod.Text))
            {
                kod.Background = Brushes.Red;
                dodac = false;
            }

            else
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(kod.Text, @"^\d{2}-\d{3}$")) // sprawdzanie cyz miesci sie w 12-345
                {
                    kod.Background = Brushes.Red;
                    dodac = false;
                }
                else
                {
                    kodzmienna = kod.Text;
                    kod.Background = Brushes.White;
                    dodac = true;
                }
            }


            if (pesel.Text.Length == 11 && pesel.Text.All(char.IsDigit))
            {
                int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
                int suma = 0;

                for (int i = 0; i < 10; i++)
                {
                    suma += (pesel.Text[i] - '0') * wagi[i];
                }

                int cyfrakontrolna = (10 - (suma % 10)) % 10;

                if (cyfrakontrolna == (pesel.Text[10] - '0'))
                {
                    string dzien = pesel.Text.Substring(4, 2);
                    int miesiac = int.Parse(pesel.Text.Substring(2, 2));
                    string rok = pesel.Text.Substring(0, 2);

                    int pelnyrok;

                    if (miesiac >= 1 && miesiac <= 12)
                        pelnyrok = 1900 + int.Parse(rok);  
                    else if (miesiac >= 21 && miesiac <= 32)
                    {
                        pelnyrok = 2000 + int.Parse(rok);  
                        miesiac -= 20;    
                    }
                    else if (miesiac >= 41 && miesiac <= 52)
                    {
                        pelnyrok = 2100 + int.Parse(rok); 
                        miesiac -= 40;
                    }
                    else
                    {
                        pesel.Background = Brushes.Red;
                        dodac = false;
                       // MessageBox.Show("Błąd: Miesiąc z PESEL-u jest niepoprawny. Powinien być w przedziale 01-52."); <--- nie dzialalo mi sprawdzanie peselu
                        return;
                    }

                    string datapesel = pelnyrok.ToString() + "-" + miesiac.ToString("D2") + "-" + dzien;

                    DateTime datapeseldate;
                    if (DateTime.TryParse(datapesel, out datapeseldate))
                    {
                        //MessageBox.Show("Data z PESEL: " + datapeseldate.ToString("yyyy-MM-dd"));

                        DateTime dataformularza;
                        if (DateTime.TryParse(datazmienna, out dataformularza))
                        {
                            if (dataformularza.Date == datapeseldate.Date)
                            {
                                peselzmienna = pesel.Text;
                                pesel.Background = Brushes.White;
                                dodac = true;
                              //  MessageBox.Show("Data formularza: " + dataformularza.ToString("yyyy-MM-dd") + "\nData z PESEL: " + datapeseldate.ToString("yyyy-MM-dd") + "\nData zgadza się z PESEL.");
                            }
                            else
                            {
                                pesel.Background = Brushes.Red;
                                dodac = false;
                              //  MessageBox.Show("Data formularza: " + dataformularza.ToString("yyyy-MM-dd") + "\nData z PESEL: " + datapeseldate.ToString("yyyy-MM-dd") + "\nData nie zgadza się z PESEL.");
                            }
                        }
                        else
                        {
                            pesel.Background = Brushes.Red;
                            dodac = false;
                          //  MessageBox.Show("Błąd przy parsowaniu daty formularza.");
                        }
                    }
                    else
                    {
                        pesel.Background = Brushes.Red;
                        dodac = false;
                       // MessageBox.Show("Błąd przy parsowaniu daty z PESEL.");
                    }
                }
                else
                {
                    pesel.Background = Brushes.Red;
                    dodac = false;
                   // MessageBox.Show("Cyfra kontrolna niepoprawna.");
                }
            }
            else
            {
                
                pesel.Background = Brushes.Red;
                dodac = false;
               // MessageBox.Show("PESEL jest niepoprawny. Powinien mieć 11 cyfr.");
            }





            if (!nr.Text.StartsWith("+48") && nr.Text.Length == 9)
                {

                    nrzmienna = "+48" + nr.Text;
                    dodac = true;
                }
                else if (nr.Text.Length == 11)
                {
                    if (nr.Text.StartsWith("48"))
                        nrzmienna = "+" + nr.Text;
                    dodac = true;
                }
                else if(!string.IsNullOrWhiteSpace(nr.Text)) { 
                    nr.Background = Brushes.Red;
                    dodac = false;
                }
               
                if (nrzmienna != null)
                {
                    nrzmienna = nrzmienna.Replace(" ", "");
                }





          

            if (dodac)
            {
                NowaOsoba = new Osoba
                {
                    Imie = imiezmienna,
                    Drugieimie = string.IsNullOrEmpty(drugiezmienna) ? null : drugiezmienna,
                    Nazwisko = nazwiskozmienna,
                    Pesel = peselzmienna,
                    Data = datazmienna,
                    Numer = string.IsNullOrEmpty(nrzmienna) ? null : nrzmienna,
                    Adres = adreszmienna,
                    Miejscowosc = miejscowosczmienna,
                    Kod = kodzmienna
                };

                this.DialogResult = true; 
                this.Close();             
            }


        }


    }
    }

