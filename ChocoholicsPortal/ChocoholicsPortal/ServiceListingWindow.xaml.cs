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
    /// Interaction logic for ServiceListing.xaml
    /// </summary>
    public partial class ServiceListing : Window
    {
        ServiceFunctions serviceClass = new ServiceFunctions();

        public ServiceListing()
        {
            InitializeComponent();
            ServiceDataGrid.ItemsSource = serviceClass.ReturnAllServices();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
    }
}
