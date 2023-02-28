using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Mountain_System
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomerPage : Page
    {
        private SqlConn connection;
        string connectionString = @"server=AZURE-D8JGSQ4UA\SQLEXPRESS;initial catalog=Capstone;integrated Security=SSPI;";
        int ProductIDInt;
        decimal UnitPrice;
        int QtyInt;
        int CustomerIDint;
        int OrderID;
        private Customer customer;

        public CustomerPage()
        {
            this.InitializeComponent();

            connection = new SqlConn();
            
            // Insert ProductNames into ComboBox            
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sql = "SELECT ProductName FROM Products";
                SqlCommand sqlCmd = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while(sqlReader.Read())
                {
                    CustomerProductNameComboBox.Items.Add(sqlReader.GetString(0));
                }

                sqlReader.Close();
            }

            // Insert Quanties into QtyFldComboBox ComboBox            
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sql = "SELECT TheVals FROM QuantityVals";
                SqlCommand sqlCmd = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    QtyFldComboBox.Items.Add(sqlReader.GetInt32(0));
                }

                sqlReader.Close();
            }

            //Insert the Next Order Number
            OrderIDFld.Text = connection.GetNextOrderID().ToString();
            OrderID = Int32.Parse(OrderIDFld.Text);


        }

        private void CustomerProductNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Insert the ProductID retrieved from the ProductName.
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT ProductID FROM Products WHERE ProductName=@ProductNameVar";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                cmd.Parameters.AddWithValue("@ProductNameVar", CustomerProductNameComboBox.SelectedItem);
                sqlConnection.Open();
                ProductIDInt = (int)cmd.ExecuteScalar();
                ProductIDFld.Text = ProductIDInt.ToString();
                sqlConnection.Close();
            }

            //Insert the UnitPrice retrieved from the ProductName.
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT UnitPrice FROM Products WHERE ProductName=@ProductNameVar";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                cmd.Parameters.AddWithValue("@ProductNameVar", CustomerProductNameComboBox.SelectedItem);
                sqlConnection.Open();
                UnitPrice = (decimal)cmd.ExecuteScalar();
                //format as money
                UnitPriceFld.Text = UnitPrice.ToString("C");
                sqlConnection.Close();
            }

            // Calculate total cost. Only run this if Qty is also entered.

            if (QtyFldComboBox.SelectedItem != null)
            {
                QtyInt = Int32.Parse(QtyFldComboBox.SelectedItem.ToString());

                decimal TotalPrice = UnitPrice * QtyInt;

                TotalPriceFld.Text = TotalPrice.ToString("C");
            }

        }
        
        private void QtyFldComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Calculate total cost. Only run this if Product Name is also entered.

            if (CustomerProductNameComboBox.SelectedItem != null)
            {
                QtyInt = Int32.Parse(QtyFldComboBox.SelectedItem.ToString());

                decimal TotalPrice = UnitPrice * QtyInt;

                TotalPriceFld.Text = TotalPrice.ToString("C");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            // Save Order to database

            // Need the following values
            //  - OrderID
            //  - CustomerIDint
            //  - ProductIDInt
            //  - QtyInt

            int OrderIDInt = Int32.Parse(OrderID.ToString());
            int CustomerIDintInt = Int32.Parse(CustomerIDint.ToString());
            int ProductIDIntInt = Int32.Parse(ProductIDInt.ToString());
            int QtyIntInt = Int32.Parse(QtyInt.ToString());

            connection.CreateOrder(OrderIDInt, CustomerIDintInt, ProductIDIntInt, QtyIntInt);

            // Go back to CustomerPage
            this.Frame.Navigate(typeof(MainPage));
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            customer = (Customer)e.Parameter;
            Cust_Name_Value.Text = customer.CustomerCompanyName;

            CustomerIDint = customer.CustomerID;
            Cust_ID_Value.Text = CustomerIDint.ToString();            
        }
    }
}
