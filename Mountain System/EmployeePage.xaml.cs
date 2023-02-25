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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Mountain_System
{   
    
    public sealed partial class EmployeePage : Page
    {
        private Employee employee;
        public EmployeePage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            employee = (Employee)e.Parameter;
            Employee_Name_Block.Text = "Employee Name: " + employee.FirstName +" "+ employee.LastName ;
            Employee_ID_Block.Text = "ID: " + employee.EmployeeID;
        }
    }
}
