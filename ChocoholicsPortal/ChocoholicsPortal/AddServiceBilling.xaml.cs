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
    public partial class AddServiceBilling : Window
    {
        public bool goodID, goodService, goodDate;
        public AddServiceBilling(string userID)
        {
            InitializeComponent();
            ServiceDatePicker.SelectedDate = DateTime.Now.Date;
            validatedLabel.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            //Verify The user
            if (!goodID)
            {
                //Recheck
                LookupMember _idCheck = new LookupMember();
                goodID = _idCheck.CheckTheMember(memberIDTextbox.Text);
                if(!goodID)
                {
                    memberIDTextbox.BorderBrush = System.Windows.Media.Brushes.Red;
                }
                
            }

            //Verify The Service
            ServiceLookup _serviceCheck = new ServiceLookup();
            goodService = _serviceCheck.CheckTheServiceCode(serviceCodeTextbox.Text);
            if(!goodService)
            {
                memberIDTextbox.BorderBrush = System.Windows.Media.Brushes.Red;
            }

            //Verify Date - make sure date not in future
            goodDate = (ServiceDatePicker.SelectedDate != null) && (ServiceDatePicker.SelectedDate.GetValueOrDefault().Date <= DateTime.Today.Date);
            if(!goodDate)
            {
                ServiceDatePicker.BorderBrush = System.Windows.Media.Brushes.Red;
            }

            if(goodService && goodDate && goodID)
            {
                //Insert into database

                MessageBox.Show("Created Billing Entry");
                this.Close();
            }
        }

        private void MemberIDTextbox_LostFocus(object sender, RoutedEventArgs e)
        {
            //Validate the member
            LookupMember _idCheck = new LookupMember();
            goodID = _idCheck.CheckTheMember(memberIDTextbox.Text);
            if (goodID)
            {
                validatedLabel.Visibility = Visibility.Visible;
            }
            else if(!goodID)
            {
                validatedLabel.Content = "Invalid Member";
                validatedLabel.Visibility = Visibility.Visible;
            }
        }
    }
}
