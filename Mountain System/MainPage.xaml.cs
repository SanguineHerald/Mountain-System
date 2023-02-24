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
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Mountain_System
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class MainPage : Page
    {
        private SqlConn connection;
        private List<Employee> employees;
        private readonly List<Customer> customers;

        public MainPage()
        {
            this.InitializeComponent();
            connection = new SqlConn();
            employees = connection.GetEmployeeID();
            customers = connection.GetCustomerID();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Employee_ID_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            InitializeComponent();
            string employee = Employee_ID.Text;

        }

        private async void DB_Connect_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            if(string.IsNullOrEmpty(Employee_ID.Text) && string.IsNullOrEmpty(CustomerID.Text))
            {
                //TODO message to fill out some ID. LAN 19Feb. See Code Below.
                var messageDialog = new Windows.UI.Popups.MessageDialog("Input Employee or Customer ID");

                //This shows the popup with the message.
                var result = await messageDialog.ShowAsync();
                return;
            }
            if (!string.IsNullOrEmpty(Employee_ID.Text) && !string.IsNullOrEmpty(CustomerID.Text))
            {
                //TODO message to only fill out one ID. LAN 19Feb. See Code Below.
                var messageDialog2 = new Windows.UI.Popups.MessageDialog("ONLY Input Employee or Customer ID...Not Both");

                //This shows the popup with the message.
                var result = await messageDialog2.ShowAsync();
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
                        // Insert user-entered CustomerID into database table
                        connection.InsertSplashCustomerIDIntoDB(customer.CustomerID);

                        //TODO move to customer page with Customer ID. LAN 19Feb. Copied code from above. No customer page has been created yet. 
                        this.Frame.Navigate(typeof(CustomerPage));
                        return;
                    }
                }
                //TODO message that customer is not found. LAN 18Feb See Code Below
                var messageDialog3 = new Windows.UI.Popups.MessageDialog("Customer ID Not Found");
                //This shows the popup with the message.
                var result = await messageDialog3.ShowAsync();
            }

        }

        private void CustomerID_TextChanged(object sender, TextChangedEventArgs e)
        {
            InitializeComponent();
            string customer = CustomerID.Text;
        }
    }
}
