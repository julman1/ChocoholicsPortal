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
    public partial class AddMember : Window
    {
        MemberFunctions memberFuncs = new MemberFunctions();


        public AddMember()
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

            //Create member entity

            var newMember = new member();
            newMember.FirstName = FirstNameTextbox.Text;
            newMember.LastName = LastNameTextbox.Text;
            newMember.Phone = PhoneTextBox.Text;
            newMember.Email = EmailTextbox.Text;
            newMember.Address = AddressTextBox.Text;
            newMember.City = CityTextBox.Text;
            newMember.State = StateTextBox.Text;
            newMember.Zip = ZipTextBox.Text;
            newMember.Status = "OK";

            //Add The member to the database
            if(memberFuncs.InsertMember(newMember))
            {
                MessageBox.Show("Member Created.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error Creating Member.");
            }
            
        }
    }
}
