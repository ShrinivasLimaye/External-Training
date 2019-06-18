using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    namespace Sales
    {

        public partial class Customer
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }

        }
        public partial class Customer
        {
            public List<Customer> customers { get; set; }
        }


        public partial class Product
        {
            public string Name { get; set; }
            public int Balance { get; set; }
            public float UnitPrice { get; set; }
        }

        public partial class Product
        {
            public List<Product> products { get; set; }
        }
        public partial class Billing
        {
            public int Total { get; set; }
            public float Price { get; set; }
            public List<Billing> billing { get; set; }
        }
        public class Repository
        {

            public List<Product> products = new List<Product>();
            public List<Customer> customers = new List<Customer>();
            public Repository()
            {
                products = FillProducts();
                customers = FillCustomers();
            }
            private List<Customer> FillCustomers()
            {
                customers.Add(new Customer() { Name = "Rajan Patil", Age = 28, Address = "Mumbai" });
                customers.Add(new Customer() { Name = "Mangesh More", Age = 27, Address = "Chennai" });
                customers.Add(new Customer() { Name = "Shiv Kumar", Age = 23, Address = "Nashik" });
                customers.Add(new Customer() { Name = "Rajan Patil", Age = 28, Address = "Mumbai" });
                return customers;
            }
            private List<Product> FillProducts()
            {
                products.Add(new Product() { Name = "Gerbera", UnitPrice = 25, Balance = 2450 });
                products.Add(new Product() { Name = "Lilly", UnitPrice = 18, Balance = 9900 });
                products.Add(new Product() { Name = "Jasmine", UnitPrice = 25, Balance = 12600 });
                products.Add(new Product() { Name = "Marigold", UnitPrice = 7, Balance = 3500 });
                products.Add(new Product() { Name = "Carnation", UnitPrice = 20, Balance = 1500 });
                return products;
            }
        }
    }

}
