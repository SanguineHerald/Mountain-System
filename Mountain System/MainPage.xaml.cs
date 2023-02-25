using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private SqlConn connection;
        private List<Employee> employees;
        private List<Customer> customers;

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
            string employee = getEmployeeID;

        }

        private void DB_Connect_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            if(string.IsNullOrEmpty(Employee_ID.Text) && string.IsNullOrEmpty(CustomerID.Text))
            {
                //TODO message to fill out some ID
                return;
            }
            if (!string.IsNullOrEmpty(Employee_ID.Text) && !string.IsNullOrEmpty(CustomerID.Text))
            {
                //TODO message to only fill out one ID
                return;
            }
            if(!string.IsNullOrEmpty(Employee_ID.Text) && string.IsNullOrEmpty(CustomerID.Text))
            {
                foreach(Employee employee in employees)
                {
                    if(employee.EmployeeID.ToString() == Employee_ID.Text)
                    {
                        //TODO move to employee page with employee ID
                        this.Frame.Navigate(typeof(EmployeePage), employee);
                        return;
                    }
                }
                //TODO message that employee is not found
            }
            if (string.IsNullOrEmpty(Employee_ID.Text) && !string.IsNullOrEmpty(CustomerID.Text))
            {
                foreach (Customer customer in customers)
                {
                    if (customer.CustomerID.ToString() == CustomerID.Text)
                    {
                        //TODO move to customer page with Customer ID
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
