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
            string? nrzmienna = null;
            string? adreszmienna;
            string? miejscowosczmienna;
            string? kodzmienna;
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

            if (string.IsNullOrEmpty(pesel.Text))
            {
                pesel.Background = Brushes.Red;
                dodac = false;
            }
            else
            {
                pesel.Background = Brushes.White;
                dodac = true;
            }

            if (string.IsNullOrEmpty(data.Text))
            {
                data.Background = Brushes.Red;
                dodac = false;
            }
            else
            {
                data.Background = Brushes.White;
                dodac = true;
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
                kod.Background = Brushes.White;
                dodac = true;
            }


            if (pesel.Text.Length != 11)
            {
                pesel.Background = Brushes.Red;
                dodac = false;
            }
            else
            {
                for (int i = 0; i < pesel.Text.Length; i++)
                {
                    if (!char.IsDigit(pesel.Text[i]))
                    {
                        pesel.Background = Brushes.Red;
                        dodac = false;
                    }
                    else
                    {

                        int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
                        int suma = 0;

                        for (int j = 0; j < 10; j++)
                        {
                            suma += (pesel.Text[j] - '0') * wagi[j];
                        }

                        int cyfrakontrolna = (10 - (suma % 10)) % 10;

                        if (cyfrakontrolna != (pesel.Text[10] - '0'))
                        {
                            pesel.Background = Brushes.Red;
                            dodac = false;
                        }



                        string dzien = pesel.Text.Substring(4, 2);
                        int miesiac = int.Parse(pesel.Text.Substring(2, 2));
                        string rok = pesel.Text.Substring(0, 2);
                        int pelnyrok = 1900;

                        if (miesiac >= 1 && miesiac <= 12)
                            pelnyrok = 1900;
                        else if (miesiac >= 21 && miesiac <= 32)
                        {
                            pelnyrok = 2000;
                            miesiac -= 20;
                        }
                        else if (miesiac >= 41 && miesiac <= 52)
                        {
                            pelnyrok = 2100;
                            miesiac -= 40;
                        }
                        else if (miesiac >= 61 && miesiac <= 72)
                        {
                            pelnyrok = 2200;
                            miesiac -= 60;
                        }
                        else if (miesiac >= 81 && miesiac <= 92)
                        {
                            pelnyrok = 1800;
                            miesiac -= 80;
                        }

                        string datapesel = pelnyrok.ToString() + "-" + miesiac.ToString("D2") + "-" + dzien; //decimal i 2 liczby, 3-->03, 10-->10
                        string dataformularz = data.Text.Trim();

                        if (dataformularz == datapesel)
                        {
                            pesel.Background = Brushes.White;
                            dodac = true;
                        }
                    }
                }


                if (!nr.Text.StartsWith("+48") && nr.Text.Length == 9)
                {

                    nrzmienna = "+48" + nr.Text;
                }
                else if (nr.Text.Length == 11)
                {
                    if (nr.Text.StartsWith("48"))
                        nrzmienna = "+" + nr.Text;
                    else
                        nr.Background = Brushes.Red;
                    dodac = false;
                }
                else
                {
                    nr.Background = Brushes.Red;
                    dodac = false;


                }
                if (nrzmienna != null)
                {
                    nrzmienna = nrzmienna.Replace(" ", "");
                }





            }


        } 
            

        }
    }

