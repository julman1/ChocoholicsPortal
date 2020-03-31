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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChocoholicsPortal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ProviderFunctions _providerFuncs = new ProviderFunctions();

        public MainWindow()
        {
            InitializeComponent();
            IDTextbox.Focus();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //Do the login logic
            var goodID =_providerFuncs.CheckTheID(IDTextbox.Text);
            if(goodID)
            {
                //Open portal
                IDTextbox.BorderBrush = System.Windows.Media.Brushes.Black;
                //Get the User ID 
                PortalWindow newPortal = new PortalWindow(IDTextbox.Text);
                newPortal.Show();
                this.Close();
            }
            else
            {
                IDTextbox.BorderBrush = System.Windows.Media.Brushes.Red;
            }

        }
    }
}
