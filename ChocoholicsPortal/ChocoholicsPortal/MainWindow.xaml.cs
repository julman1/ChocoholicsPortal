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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChocoholicsPortal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ProviderFunctions _providerFuncs = new ProviderFunctions();
        OperatorFunctions _operatorFuncs = new OperatorFunctions();

        public MainWindow()
        {
            InitializeComponent();
            passwordBox.Focus();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //Do the login logic

            //Check if Numeric
            try
            {
                var intID = Convert.ToInt32(passwordBox.Password);
            }
            catch
            {
                MessageBox.Show("Error: ID Must be Numeric.");
                return;
            }

            //First Check if provider
            var goodID =_providerFuncs.CheckTheID(passwordBox.Password);
            if(goodID)
            {
                OpenPortal(true, false);
            }
            else
            {
                //Then Check Operator
                goodID = _operatorFuncs.CheckTheID(passwordBox.Password);
                if(goodID)
                {
                    OpenPortal(false, _operatorFuncs.VerifyManager(passwordBox.Password));
                }
                else
                {
                    passwordBox.BorderBrush = System.Windows.Media.Brushes.Red;
                }
            }

        }
        protected void OpenPortal(bool provider, bool manager)
        {
            //Open portal
            passwordBox.BorderBrush = System.Windows.Media.Brushes.Black;
            //Get the User ID 
            PortalWindow newPortal = new PortalWindow(passwordBox.Password, provider, manager);
            newPortal.Show();
            this.Close();
        }

        private void IDTextbox_LostFocus(object sender, RoutedEventArgs e)
        {
            button_Click(sender, e);
        }
    }
}
