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

        private void DB_Connect_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();

            SqlConn connection = new SqlConn();

        }

        private void CustomerID_TextChanged(object sender, TextChangedEventArgs e)
        {
            InitializeComponent();
            string customer = getCustomerID;
        }
    }
}
