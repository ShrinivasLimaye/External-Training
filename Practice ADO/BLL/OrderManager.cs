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
        public static bool Insert(Product Prodfound)
        {
            bool status = false;
            status = OrderDAL.Add(Prodfound);
            status = ProductDAL.Updatequant(Prodfound);
            return status;

        }
    }
}
