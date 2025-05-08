using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace WpfApp1
{
    public partial class Pop3 : Window
    {
        private Window rodzic; 

        public Pop3(Window parent)
        {
            InitializeComponent();
            rodzic = parent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            rodzic.Close();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
