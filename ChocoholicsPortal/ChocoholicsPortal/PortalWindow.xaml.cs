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
    /// Interaction logic for PortalWindow.xaml
    /// </summary>

    public partial class PortalWindow : Window
    {
        public string aUserID { get; set; }
        public bool isProvider { get; set; }
        public bool isManager { get; set; }

        ProviderFunctions _providerFuncs = new ProviderFunctions();
        OperatorFunctions _operatorFuncs = new OperatorFunctions();

        public PortalWindow(string userID, bool Provider, bool Manager)
        {
            InitializeComponent();
            aUserID = userID;
            isProvider = Provider;
            isManager = Manager;

            var prov = _providerFuncs.FindProvider(userID);

            if(prov == null)
            {
                var op = _operatorFuncs.FindOperator(userID);
                label.Content += op.FirstName + " " + op.LastName;
            }
            else
            {
                label.Content += prov.FirstName + " " + prov.LastName;
            }
            
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(isProvider)
            {
                AddServiceBilling NewServiceListing = new AddServiceBilling(aUserID);
                NewServiceListing.Show();
            }
            else
            {
                MessageBox.Show("Not Logged in as a Provider.");
            }
        }

        private void Button_Copy_Click(object sender, RoutedEventArgs e)
        {
            AddMember AddMemberWindow = new AddMember();
            AddMemberWindow.Show();
        }

        private void Button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            ServiceListing newServicesWindow = new ServiceListing();
            newServicesWindow.Show();
        }

        private void Button_Copy3_Click(object sender, RoutedEventArgs e)
        {
            if (isManager)
            {
                //Run the process
                MessageBox.Show("Process Complete");
            }
            else
            {
                MessageBox.Show("Not Logged in as a Manager.");
            }
        }

        private void Button_Copy4_Click(object sender, RoutedEventArgs e)
        {
            if (isProvider)
            {
                var billingWindow = new BillingListing(aUserID);
                billingWindow.Show();
            }
            else
            {
                MessageBox.Show("Not Logged in as a Provider.");
            }
        }

        private void EditMember_Click(object sender, RoutedEventArgs e)
        {
            var alterWindow = new AlterMemberWindow();
            alterWindow.Show();
        }

        private void AddOperatorBtn_Click(object sender, RoutedEventArgs e)
        {
            var addOperatorWindow = new AddOperatorWindow();
            addOperatorWindow.Show();
        }

        private void AddProviderBtn_Click(object sender, RoutedEventArgs e)
        {
            var addProviderWindow = new AddProviderWindow();
            addProviderWindow.Show();
        }

        private void EditProviderBtn_Click(object sender, RoutedEventArgs e)
        {
            var alterWindow = new AlterProviderWindow();
            alterWindow.Show();
        }
    }
}
