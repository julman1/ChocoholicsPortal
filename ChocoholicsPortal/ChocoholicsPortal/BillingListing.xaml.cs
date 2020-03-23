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

namespace ChocoholicsPortal
{
    /// <summary>
    /// Interaction logic for BillingListing.xaml
    /// </summary>
    public partial class BillingListing : Window
    {
        public BillingListing(string ID)
        {
            InitializeComponent();
            ProviderIDTextbox.Text = ID;
            //Fill the data grid
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Filter the data in the grid
        }
    }
}
