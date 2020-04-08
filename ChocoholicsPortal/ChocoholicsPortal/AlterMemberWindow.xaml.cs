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
    public partial class AlterMemberWindow : Window
    {
        MemberFunctions _memberFuncs = new MemberFunctions();

        public AlterMemberWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {
            //Pull in member info
            var member = _memberFuncs.FindMember(IDTextBox.Text);
            FirstNameTextbox.Text = member?.FirstName;
            LastNameTextbox.Text = member?.LastName;
            PhoneTextBox.Text = member?.Phone;
            EmailTextbox.Text = member?.Email;
            AddressTextBox.Text = member?.Address;
            CityTextBox.Text = member?.City;
            StateTextBox.Text = member?.State;
            ZipTextBox.Text = member?.Zip;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //Delete Member
            var member = _memberFuncs.FindMember(IDTextBox.Text);
            if(_memberFuncs.DeleteMember(member))
            {
                MessageBox.Show("Member Deleted.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error Deleting Member.");
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            var UpdatedMember = new member();
            UpdatedMember.MemberID = Convert.ToInt32(IDTextBox.Text);
            UpdatedMember.FirstName = FirstNameTextbox.Text;
            UpdatedMember.LastName = LastNameTextbox.Text;
            UpdatedMember.Phone = PhoneTextBox.Text;
            UpdatedMember.Email = EmailTextbox.Text;
            UpdatedMember.Address = AddressTextBox.Text;
            UpdatedMember.City = CityTextBox.Text;
            UpdatedMember.State = StateTextBox.Text;
            UpdatedMember.Zip = ZipTextBox.Text;

            if(_memberFuncs.UpdateMember(UpdatedMember))
            {
                MessageBox.Show("Member Updated.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error Updating Member.");
            }
        }
    }
}
