using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLayer;
using DAL;

namespace BLL
{
    public class OrderManager
    {
        public static List<Product> Getorderd()
        {
            List<Product> orderd = new List<Product>();
            orderd = OrderDAL.Getorderd();
            return orderd;
        }
        public static bool Insert(Product Prodfound)
        {
            bool status = false;
            status = OrderDAL.Add(Prodfound);
            return status;
        }
        public static bool Cancel(Product Prodfound)
        {
            bool status = false;
            status = OrderDAL.Cancel(Prodfound);
            return status;
        }
    }
}
