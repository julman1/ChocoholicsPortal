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
    public partial class AddOperatorWindow : Window
    {
        OperatorFunctions operatorFuncs = new OperatorFunctions();


        public AddOperatorWindow()
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

            //Create operator entity

            var newOperator = new @operator();
            newOperator.FirstName = FirstNameTextbox.Text;
            newOperator.LastName = LastNameTextbox.Text;
            newOperator.IsManager = checkBox.IsChecked;

            //Add The operator to the database
            if(operatorFuncs.InsertOperator(newOperator))
            {
                MessageBox.Show("Operator Created.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error Creating Operator.");
            }
            
        }
    }
}
