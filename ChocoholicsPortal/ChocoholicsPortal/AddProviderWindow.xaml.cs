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
    /// Interaction logic for AddMember.xaml
    /// </summary>
    public partial class AddProviderWindow : Window
    {
        ProviderFunctions providerFuncs = new ProviderFunctions();


        public AddProviderWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Check the fields
            if(string.IsNullOrEmpty(FirstNameTextbox.Text))
            {
                FirstNameTextbox.BorderBrush = System.Windows.Media.Brushes.Red;
                return;
            }
            if (string.IsNullOrEmpty(LastNameTextbox.Text))
            {
                LastNameTextbox.BorderBrush = System.Windows.Media.Brushes.Red;
                return;
            }
            if (string.IsNullOrEmpty(PhoneTextBox.Text))
            {
                PhoneTextBox.BorderBrush = System.Windows.Media.Brushes.Red;
                return;
            }
            if (string.IsNullOrEmpty(EmailTextbox.Text))
            {
                EmailTextbox.BorderBrush = System.Windows.Media.Brushes.Red;
                return;
            }
            if (string.IsNullOrEmpty(AddressTextBox.Text))
            {
                AddressTextBox.BorderBrush = System.Windows.Media.Brushes.Red;
                return;
            }
            if (string.IsNullOrEmpty(CityTextBox.Text))
            {
                CityTextBox.BorderBrush = System.Windows.Media.Brushes.Red;
                return;
            }
            if (string.IsNullOrEmpty(StateTextBox.Text))
            {
                StateTextBox.BorderBrush = System.Windows.Media.Brushes.Red;
                return;
            }
            if (string.IsNullOrEmpty(ZipTextBox.Text))
            {
                ZipTextBox.BorderBrush = System.Windows.Media.Brushes.Red;
                return;
            }

            //Create provider entity

            var newProvider = new provider();
            newProvider.FirstName = FirstNameTextbox.Text;
            newProvider.LastName = LastNameTextbox.Text;
            newProvider.Phone = PhoneTextBox.Text;
            newProvider.Email = EmailTextbox.Text;
            newProvider.Address = AddressTextBox.Text;
            newProvider.City = CityTextBox.Text;
            newProvider.State = StateTextBox.Text;
            newProvider.Zip = ZipTextBox.Text;

            //Add The member to the database
            if(providerFuncs.InsertProvider(newProvider))
            {
                MessageBox.Show("Provider Created.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error Creating Provider.");
            }
            
        }
    }
}
