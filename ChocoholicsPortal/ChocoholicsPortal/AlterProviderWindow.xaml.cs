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
    /// Interaction logic for AlterMemberWindow.xaml
    /// </summary>
    public partial class AlterProviderWindow : Window
    {
        ProviderFunctions _providerFuncs = new ProviderFunctions();

        public AlterProviderWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {
            //Pull in provider info
            var prov = _providerFuncs.FindProvider(IDTextBox.Text);
            FirstNameTextbox.Text = prov?.FirstName;
            LastNameTextbox.Text = prov?.LastName;
            PhoneTextBox.Text = prov?.Phone;
            EmailTextbox.Text = prov?.Email;
            AddressTextBox.Text = prov?.Address;
            CityTextBox.Text = prov?.City;
            StateTextBox.Text = prov?.State;
            ZipTextBox.Text = prov?.Zip;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //Delete Provider
            var prov = _providerFuncs.FindProvider(IDTextBox.Text);
            if (_providerFuncs.DeleteProvider(prov))
            {
                MessageBox.Show("Provider Deleted.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error Deleting Provider.");
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            var UpdatedProvider = new provider();
            UpdatedProvider.ProviderID = Convert.ToInt32(IDTextBox.Text);
            UpdatedProvider.FirstName = FirstNameTextbox.Text;
            UpdatedProvider.LastName = LastNameTextbox.Text;
            UpdatedProvider.Phone = PhoneTextBox.Text;
            UpdatedProvider.Email = EmailTextbox.Text;
            UpdatedProvider.Address = AddressTextBox.Text;
            UpdatedProvider.City = CityTextBox.Text;
            UpdatedProvider.State = StateTextBox.Text;
            UpdatedProvider.Zip = ZipTextBox.Text;

            if (_providerFuncs.UpdateProvider(UpdatedProvider))
            {
                MessageBox.Show("Provider Updated.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error Updating Provider.");
            }
        }
    }
}
