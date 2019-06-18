using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLayer;
using DAL;

namespace BLL
{
   public static class ProductManager
    {
        public static List<Product> GetAllProduct()
        {
            List<Product> Product = new List<Product>();
            Product=ProductDAL.GetAll();
            return Product;
        }
        public static bool Insert(Product product)
        {
            bool status = false;
            status = ProductDAL.Insert(product);
            return status;
        }
       public static List<Product> Getcart()
             {
                   List<Product> CART = new List<Product>();
                   CART=CartDAL.Getcart();
                   return CART;
             }

        public static bool Addcart(Product Prodfound)
        {
            bool status = false;
            status = CartDAL.Addcart(Prodfound);
            return status;
        }
        public static bool Removecart(Product Prodfound)
        {
            bool status = false;
            status = CartDAL.Removecart(Prodfound);
            return status;
        }
        public static bool dropcart()
        {
            bool status = false;
            status = CartDAL.Purge();
            return status;
        }
        public static bool Updatequant(Product Prodfound)
        {
            bool status = false;
            status = ProductDAL.Updatequant(Prodfound);
            return status;
        }  
    }
}
