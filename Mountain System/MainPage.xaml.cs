using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Mountain_System
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string getEmployeeID;
        private string getCustomerID;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Employee_ID_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            InitializeComponent();
            string employee = getEmployeeID;

        }

        private async void DB_Connect_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            if(string.IsNullOrEmpty(Employee_ID.Text) && string.IsNullOrEmpty(CustomerID.Text))
            {
                //TODO message to fill out some ID. LAN 19Feb. See Code Below.
                var messageDialog = new Windows.UI.Popups.MessageDialog("Input Employee or Customer ID");

                return;
            }
            if (!string.IsNullOrEmpty(Employee_ID.Text) && !string.IsNullOrEmpty(CustomerID.Text))
            {
                //TODO message to only fill out one ID. LAN 19Feb. See Code Below.
                var messageDialog2 = new Windows.UI.Popups.MessageDialog("ONLY Input Employee or Customer ID...Not Both");
                return;
            }
            if(!string.IsNullOrEmpty(Employee_ID.Text) && string.IsNullOrEmpty(CustomerID.Text))
            {
                foreach(Employee employee in employees)
                {
                    if(employee.EmployeeID.ToString() == Employee_ID.Text)
                    {
                        //TODO move to employee page with employee ID. 
                        this.Frame.Navigate(typeof(EmployeePage));
                        return;
                    }
                }
                //TODO message that employee is not found. LAN 19Feb. See Code Below. 
                var messageDialog3 = new Windows.UI.Popups.MessageDialog("Employee ID was not found");
            }
            if (string.IsNullOrEmpty(Employee_ID.Text) && !string.IsNullOrEmpty(CustomerID.Text))
            {
                foreach (Customer customer in customers)
                {
                    if (customer.CustomerID.ToString() == CustomerID.Text)
                    {
                        //TODO move to customer page with Customer ID. LAN 19Feb. Copied code from above. No customer page has been created yet. 
                        this.Frame.Navigate(typeof(CustomerPage));
                        return;
                    }
                }
                //TODO message that employee is not found
            }

        }

        private void CustomerID_TextChanged(object sender, TextChangedEventArgs e)
        {
            InitializeComponent();
            string customer = getCustomerID;
        }
    }
}
