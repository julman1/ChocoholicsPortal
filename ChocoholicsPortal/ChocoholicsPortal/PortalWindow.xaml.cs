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
        
        MemberFunctions _memberFuncs = new MemberFunctions();

        public PortalWindow(string userID)
        {
            InitializeComponent();
            aUserID = userID;
            var member = _memberFuncs.FindMember(userID);
            label.Content += member.FirstName + " " + member.LastName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddServiceBilling NewServiceListing = new AddServiceBilling(aUserID);
            NewServiceListing.Show();
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
            //Run the process
            MessageBox.Show("Process Complete");
        }

        private void Button_Copy4_Click(object sender, RoutedEventArgs e)
        {
            var billingWindow = new BillingListing(aUserID);
            billingWindow.Show();
        }

        private void EditMember_Click(object sender, RoutedEventArgs e)
        {
            var alterWindow = new AlterMemberWindow();
            alterWindow.Show();
        }
    }
}
