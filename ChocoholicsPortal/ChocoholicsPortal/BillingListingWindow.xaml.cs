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
using System.Collections.ObjectModel;

namespace ChocoholicsPortal
{
    /// <summary>
    /// Interaction logic for BillingListing.xaml
    /// </summary>
    public partial class BillingListing : Window
    {
        BillingFunctions billFuncs = new BillingFunctions();

        public BillingListing(string ID)
        {
            InitializeComponent();
            ProviderIDTextbox.Text = ID;
            //Fill the data grid
            var intID = Convert.ToInt32(ID);
            ServicesDataGrid.ItemsSource = billFuncs.GetBillingInfo(intID);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Filter the data in the grid
            var intID = Convert.ToInt32(ProviderIDTextbox.Text);
            ServicesDataGrid.ItemsSource = billFuncs.GetBillingInfo(intID);
        }
    }
}
