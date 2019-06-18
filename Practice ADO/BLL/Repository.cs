using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLayer;
using BLL;

namespace BLL
{
    public class Repository
    {
        List<Customer> customers = new List<Customer>();
        public static List<Customer> GetAllCustomers()
        {

            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer { Id = 1, Name = "Nihilent", Email = "shiv.khera@nihilent.com", RegistrationDate = DateTime.Parse("9/2/2015"), isMVC = true, Location = "Mumbai", Membership = "Gold" });
            customers.Add(new Customer { Id = 2, Name = "IBM", Email = "sarang.sharma@ibm.com", RegistrationDate = DateTime.Parse("12/2/2016"), isMVC = false, Location = "Delhi", Membership = "Silver" });
            customers.Add(new Customer { Id = 3, Name = "Rational", Email = "patrik.s@rational.in", RegistrationDate = DateTime.Parse("8/3/2012"), isMVC = true, Location = "Mumbai", Membership = "Platinum" });
            customers.Add(new Customer { Id = 4, Name = "Mastercard", Email = "Kiran.patil@mastercard.com", RegistrationDate = DateTime.Parse("9/5/2014"), isMVC = true, Location = "Mumbai", Membership = "Gold" });
            customers.Add(new Customer { Id = 5, Name = "honeywell", Email = "meenal.sagade@honeywell.com", RegistrationDate = DateTime.Parse("9/7/2015"), isMVC = false, Location = "Mumbai", Membership = "Gold" });
            customers.Add(new Customer { Id = 6, Name = "jhonDeer", Email = "karan.varma@jhondeer.com", RegistrationDate = DateTime.Parse("11/8/2013"), isMVC = true, Location = "Pune", Membership = "Gold" });
            customers.Add(new Customer { Id = 7, Name = "Extentia", Email = "surabhi.nene@extentia.in", RegistrationDate = DateTime.Parse("12/10/2016"), isMVC = true, Location = "Chennai", Membership = "Gold" });
            customers.Add(new Customer { Id = 8, Name = "KloudWorks", Email = "sharayu.rane@kloudworks.in", RegistrationDate = DateTime.Parse("8/12/2014"), isMVC = true, Location = "Mumbai", Membership = "Silver" });
            return customers;
        }
        public static Customer GetCustomer(int id)
        {
            return new Customer
            {
                Id = 1,
                Name = "Nihilent",
                Email = "shiv.khera@nihilent.com",
                RegistrationDate = DateTime.Parse("9/2/2015"),
                isMVC = true,
                Location = "Mumbai",
                Membership = "Gold"
            };
        }

        public static bool Update(Customer customer)
        {
            return true;
        }

        public static bool Delete(Customer customer)
        {
            return true;
        }

        public static bool Insert(Customer customer)
        {
            return true;
        }

    }


    public class FlowerDatabase : List<Produce>
    {
        public FlowerDatabase()
        {
            Add(new Produce() { Id = 1, Name = "Gerbera", Price = 16, Category = "Flowers" });
            Add(new Produce() { Id = 2, Name = "Lilly", Price = 19, Category = "Flowers" });
            Add(new Produce() { Id = 3, Name = "Rose", Price = 10, Category = "Flowers" });
            Add(new Produce() { Id = 4, Name = "Marigold", Price = 15, Category = "Flowers" });
            Add(new Produce() { Id = 5, Name = "Carnation", Price = 20, Category = "Flowers" });
            Add(new Produce() { Id = 6, Name = "Lotus", Price = 40, Category = "Flowers" });
        }
    }

    public class DataAccessFlower
    {
        public List<Produce> GetDataFlowers()
        {
            return new FlowerDatabase();
        }
    }

    public class VegetableDatabase : List<Produce>
    {
        public VegetableDatabase()
        {
            Add(new Produce() { Id = 1, Name = "Capsicum", Price = 28, Category = "Vegetables" });
            Add(new Produce() { Id = 2, Name = "Cucumber", Price = 32, Category = "Vegetables" });
            Add(new Produce() { Id = 3, Name = "Spinach", Price = 22, Category = "Vegetables" });
            Add(new Produce() { Id = 4, Name = "Tomatto", Price = 30, Category = "Vegetables" });
            Add(new Produce() { Id = 5, Name = "Onion", Price = 90, Category = "Vegetables" });
        }
    }

    public class DataAccessVegetable
    {
        public List<Produce> GetDataVegetable()
        {
            return new VegetableDatabase();
        }
    }

    public class TFLFarmTestData
    {
        public List<TFLFarm> TFLFarms = new List<TFLFarm>();
        public List<Greenhouse> Units = new List<Greenhouse>();

        public TFLFarmTestData()
        {
            TFLFarms.Add(new TFLFarm { ID = 12, Name = "Maal" });
            TFLFarms.Add(new TFLFarm { ID = 13, Name = "Pathar" });
            TFLFarms.Add(new TFLFarm { ID = 14, Name = "Malayee" });
            TFLFarms.Add(new TFLFarm { ID = 15, Name = "Partan" });
            TFLFarms.Add(new TFLFarm { ID = 16, Name = "Khasar" });


            Units.Add(new Greenhouse { ID = 12, Name = "Gerbera", Property = new TFLFarm { ID = 12, Name = "Maal" } });
            Units.Add(new Greenhouse { ID = 13, Name = "Cucumber", Property = new TFLFarm { ID = 13, Name = "Pathar" } });
            Units.Add(new Greenhouse { ID = 14, Name = "Carnation", Property = new TFLFarm { ID = 13, Name = "Pathar" } });


        }
    }
}
