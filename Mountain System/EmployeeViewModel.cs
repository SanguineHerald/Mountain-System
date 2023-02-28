using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain_System
{
    internal class EmployeeViewModel
    {
        public ObservableCollection<Order> unfilledOrders = new ObservableCollection<Order>();
        public ObservableCollection<Product> lowProducts = new ObservableCollection<Product>();
        public ObservableCollection<String> shippers = new ObservableCollection<String>();
        public List<Shipper> _shippers = new List<Shipper>();
        public EmployeeViewModel _model;
        public SqlConn conn;
        public EmployeeViewModel() 
        {
            conn = new SqlConn();
            List<Order> uOrders = conn.GetUnfilledOrders();
            foreach (Order o in uOrders)
            {
                unfilledOrders.Add(o);
            }
            List<Product> uProducts = conn.GetLowSupplyProducts();
            foreach(Product p in uProducts)
            {
                lowProducts.Add(p);
            }
            _shippers = conn.GetShippers();
            foreach(Shipper shipper in _shippers)
            {
                shippers.Add(shipper.ShipperCompanyName);
            }
        }
        public void updateProductContents()
        {
            List<Product> uProducts = conn.GetLowSupplyProducts();
            lowProducts.Clear();
            foreach (Product p in uProducts)
            {
                lowProducts.Add(p);
            }
        }

        public void updateOrderContents()
        {
            List<Order> uOrders = conn.GetUnfilledOrders();
            unfilledOrders.Clear();
            foreach (Order o in uOrders)
            {
                unfilledOrders.Add(o);
            }
        }
       
    }
}
