using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain_System
{
    internal class EmployeeViewModel
    {
        public ObservableCollection<Order> unfilledOrders = new ObservableCollection<Order>();
        public ObservableCollection<Product> lowProducts = new ObservableCollection<Product>();
        public EmployeeViewModel() 
        {
            SqlConn conn = new SqlConn();
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
        }        
    }
}
