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
        private string connectionString = @"server=AZURE-D8JGSQ4UA\SQLEXPRESS;initial catalog=Capstone;integrated Security=SSPI;";

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
            string sql = "SELECT OrderID,CustomerID,EmployeeID,ProductID,Quantity,ShipperID,OrderComplete FROM Orders WHERE OrderComplete = 0";
            List<Order> orders = this.sqlConnection.Query<Order>(sql).ToList();
            return orders;
        }
        public void CompleteOrder(Order order, int shipperId, int employeeID)
        {
            //DateTime myDateTime = DateTime.Now;
            //string sqlDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sqlOrder = "UPDATE Orders SET OrderComplete=1, ShipperID=@shipID,EmployeeID=@employeeID WHERE OrderID=@orderID";
            this.sqlConnection.Execute(sqlOrder, new {  shipID = shipperId, employeeID = employeeID, orderID = order.OrderID });
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
        public void CreateOrder(int OrderID, int CustomerIDint, int ProductIDInt, int QtyInt)
        {            
            DateTime myDateTime = DateTime.Now;
            string sqlDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sql = "INSERT INTO Capstone.dbo.Orders VALUES (@OrderID,@CustomerIDint,null,@sqlDate,@ProductIDInt,@QtyInt,null,null,null,0)";
            this.sqlConnection.Execute(sql, new { OrderID = OrderID, CustomerIDint = CustomerIDint, sqlDate = sqlDate, ProductIDInt = ProductIDInt, QtyInt = QtyInt });
        }
        public int GetNextOrderID()
        {
            string sql = "select MAX(OrderID) from Orders";
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            int OrderIDint = (int)cmd.ExecuteScalar();
            return OrderIDint + 1;
        }
        public List<Product> GetLowSupplyProducts()
        {
            string sql = "select * from Products WHERE ReorderThreshold > UnitsInStock";
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

        public int GetProdIDfromProdName(string ProductNameInput)
        {
            // On CustomerPage, getting the ProductID from the ProductName.            

            string sql = "SELECT ProductID FROM Products WHERE ProductName = @ProductNameVar";
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.Add("@ProductNameVar", System.Data.SqlDbType.Int).Value = ProductNameInput;
            int ProductIDInt = (int)cmd.ExecuteScalar();
            return ProductIDInt;

        }

        public List<Shipper> GetShippers()
        {
            string sql = "SELECT * FROM Shippers";
            List<Shipper> shipper = this.sqlConnection.Query<Shipper>(sql).ToList();
            return shipper;
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
        public Order(int OrderID, int CustomerId, int EmployeeID, int ProductID, int Quantity, int ShipperID, int OrderComplete)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerId;
            this.EmployeeID = EmployeeID;
            this.ProductID = ProductID;
            this.Quantity = Quantity;
            this.ShipperID = ShipperID;
            this.OrderID = OrderComplete;
        }
        public int OrderID { get; set; }
        public int  CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate  { get; set; }
        public int ProductID { get; set; }
	    public int Quantity { get; set; }
        public int ShipperID { get; set; }
        public DateTime ShippedDate { get; set; }
        public DateTime DeliveredDate { get; set; }
        public int OrderComplete { get; set; }

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
    internal class MainSplashVars
    {
        public int SplashIndex { get; set; }
        public int Employee_ID { get; set; }
        public int CustomerID { get; set; }
    }
}
