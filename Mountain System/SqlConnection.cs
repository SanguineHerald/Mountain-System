using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Text;
using Windows.UI.Xaml.Controls;

namespace Mountain_System
{
    internal class SqlConn
    {
        private string connectionString = @"server=(local);initial catalog=Capstone;integrated Security=SSPI;";

        private SqlConnection sqlConnection { get; set; }

        //call when opening a page to establish SQL connection
        public SqlConn()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }
        //Call when navigating away from a page to close the connection
        public void SqlConnClose()
        {
            sqlConnection.Close();
        }
        public List<Order> GetUnfilledOrders()
        {
            string sql = "SELECT * FROM Orders WHERE OrderComplete = 0";
            List<Order> orders = this.sqlConnection.Query<Order>(sql).ToList();
            return orders;
        }
        public void CompleteOrder(Order order, int shipperId, int employeeID)
        {
            DateTime myDateTime = DateTime.Now;
            string sqlDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sqlOrder = "UPDATE Orders SET OrderComplete=1, ShippedDate=@date,ShipperID=@shipID,EmployeeID=@employeeID WHERE OrderID=@orderID";
            this.sqlConnection.Execute(sqlOrder, new { date = sqlDate, shipID = shipperId, employeeID = employeeID, orderID = order.OrderID });
        }
        public List<Product> GetProducts()
        {
            string sql = "SELECT * FROM Products";
            List<Product> products = this.sqlConnection.Query<Product>(sql).ToList();
            return products;
        }
        public void CreateOrder(Order order)
        {
            DateTime myDateTime = DateTime.Now;
            string sqlDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sql = "INSERT INTO Orders VALUES (@orderID,@customerID,null,@date,@productID,@productQty,null,null,null,0)";
            this.sqlConnection.Execute(sql, new { orderID = order.OrderID, customerID = order.CustomerID, date = sqlDate, productID = order.ProductID, productQty = order.Quantity });
        }
        public int GetNextOrderID()
        {
            string sql = "select MAX(OrderID) from Orders";
            string OrderID = this.sqlConnection.Query<int>(sql).ToString();
            int ID = int.Parse(OrderID);
            return ID + 1;
        }
        public List<Product> GetLowSupplyProducts()
        {
            string sql = "select * from Products WHERE ReorderThreshold < UnitsInStock";
            List<Product> products = this.sqlConnection.Query<Product>(sql).ToList();
            return products;
        }
        public void OrderFromSuppliers(int productID)
        {
            string sqlOrder = "UPDATE Products SET UnitsInStock=MaxDesiredStock WHERE ProductID = @product";
            this.sqlConnection.Execute(sqlOrder, new {product=productID});
        }

        public List<Customer> GetCustomerID()
        {
            string sql = "SELECT * FROM Customers";
            List<Customer> customers= this.sqlConnection.Query<Customer>(sql).ToList();
            return customers;
        }

        public List<Employee> GetEmployeeID()
        {
            string sql = "SELECT * FROM Employees";
            List<Employee> employees = this.sqlConnection.Query<Employee>(sql).ToList();
            return employees;
        }

    }
    internal class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerCompanyName { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public string CustomerZip { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerRegion { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
    }
    internal class Order
    {
        //use the getNextOrderID() method to get the ID number for this order
        public Order(int ID, int customerId, int productID, int qty)
        {
            DateTime myDateTime = DateTime.Now;
            string sqlDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            this.OrderID = ID;
            this.CustomerID = customerId;
            this.ProductID = productID;
            this.Quantity = qty;
            this.OrderDate = sqlDate;
        }
        public int OrderID { get; set; }
        public int  CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public string OrderDate  { get; set; }
        public int ProductID { get; set; }
	    public int Quantity { get; set; }
        public int ShipperID { get; set; }
        public string ShippedDate { get; set; }
        public string DeliveredDate { get; set; }
    }
    internal class Employee
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public String Role { get; set; }
        public string Phone { get; set; }
    }
    internal class Shipper
    {
        public int ShipperID { get; set; } 
        public string ShipperCompanyName { get; set; }  
        public string ShipperCompanyPhone { get; set; }
    }
    internal class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int MaxDesiredStock { get; set; }
        public int ReorderThreshhold { get; set; }
    }
    internal class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierCompanyName { get; set; }
    }    
}
