using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public sealed partial class EmployeePage : Page
    {
        private Employee employee;
        private EmployeeViewModel ViewModel{get; set;}
        private SqlConn _conn;
        private string selectedShipper;
        private int selectedShipperId;
        public EmployeePage()
        {
            this.InitializeComponent();
            this.ViewModel= new EmployeeViewModel();
            _conn = new SqlConn();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            employee = (Employee)e.Parameter;
            Employee_Name_Block.Text = "Employee Name: " + employee.FirstName +" "+ employee.LastName ;
            Employee_ID_Block.Text = "ID: " + employee.EmployeeID;
            
        }

        private void Restock_Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            Product temp = (Product)button.DataContext;            
            _conn.OrderFromSuppliers(temp.ProductID);
            this.ViewModel.updateProductContents();
        }

        private void ListView_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {

        }

        private void Order_Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            Order temp = (Order)button.DataContext;
            foreach (Shipper ship in this.ViewModel._shippers)
            {
                if (ship.ShipperCompanyName == selectedShipper)
                {
                    selectedShipperId = ship.ShipperID;
                }
            }
            _conn.CompleteOrder(temp, selectedShipperId, employee.EmployeeID);
            this.ViewModel.updateOrderContents();
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedShipper = (sender as ComboBox).SelectedItem as string;
        }
    }
}
