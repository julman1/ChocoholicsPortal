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
        public string goodID, ProviderID;
        public bool goodService, goodDate;
        MemberFunctions _memberFuncs = new MemberFunctions();
        ServiceFunctions _serviceCheck = new ServiceFunctions();
        BillingFunctions _billingFuncs = new BillingFunctions();

        public AddServiceBilling(string userID)
        {
            InitializeComponent();
            ProviderID = userID;
            ServiceDatePicker.SelectedDate = DateTime.Now.Date;
            validatedLabel.Visibility = Visibility.Visible;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            //Verify The user
            if (goodID != "OK")
            {
                //Recheck
                goodID = _memberFuncs.CheckTheMember(memberIDTextbox.Text);
                validatedLabel.Content = goodID;
                if (goodID != "OK")
                {
                    memberIDTextbox.BorderBrush = System.Windows.Media.Brushes.Red;
                }
                
            }

            //Verify The Service
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

            if(goodService && goodDate && goodID == "OK")
            {
                //Create object

                var newBill = new bill_info();
                newBill.EntryDate = DateTime.Now.Date;
                newBill.ServiceDate = ServiceDatePicker.SelectedDate;
                newBill.MemberID = Convert.ToInt32(memberIDTextbox.Text);
                newBill.ProviderID = Convert.ToInt32(ProviderID);
                newBill.ServiceID = Convert.ToInt32(serviceCodeTextbox.Text);
                newBill.ExpectedCost = Convert.ToDecimal(CostTextbox.Text);
                newBill.Notes = CommentsTextBox.Text;

                //Insert into database
                if(_billingFuncs.InsertBilling(newBill))
                {
                    MessageBox.Show("Created Billing Entry");
                }
                else
                {
                    MessageBox.Show("Error Creating Billing Entry");
                }              

                
                this.Close();
            }
        }

        private void MemberIDTextbox_LostFocus(object sender, RoutedEventArgs e)
        {
            //Validate the member
            goodID = _memberFuncs.CheckTheMember(memberIDTextbox.Text);
            validatedLabel.Content = goodID;
            if (goodID != "OK")
            {
                memberIDTextbox.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                memberIDTextbox.BorderBrush = System.Windows.Media.Brushes.Black;
            }
        }
    }
}
