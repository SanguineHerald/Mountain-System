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
        public CustomerPage()
        {
            this.InitializeComponent();

            connection = new SqlConn();

            int CustomerIDint;
            CustomerIDint = connection.GetSplashCustomerIDFromDB();

            // Initial values
            Cust_ID_Value.Text = CustomerIDint.ToString();
            Cust_Name_Value.Text = connection.GetSplashCustomerCompanyNameFromDB(CustomerIDint);

            // Insert ProductNames into ComboBox
            string connectionString = @"server=AZURE-D8JGSQ4UA\SQLEXPRESS;initial catalog=Capstone;integrated Security=SSPI;";
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

        }

        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
