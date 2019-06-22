using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOLayer;
using BLL;
namespace ECommerceWebSite.Controllers
{
    public class OrdersController : Controller
    {
        //
        // GET: /Orders/
        public ActionResult Show()
        {
            List<Product> orderd = OrderManager.Getorderd();
            return View(orderd);


        }
        public ActionResult Order1(string name)
        {
            Product ProdFound = null;
            List<Product> products = ProductManager.GetAllProduct();
            foreach (Product prod in products)
            {
                if (prod.Title == name)
                {
                    ProdFound = prod;
                }
            }
            if (OrderManager.Insert(ProdFound))
            {
                List<Product> orderd = OrderManager.Getorderd();
                return View(orderd); 
            }
            else
            {
                Response.Write("failure");
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Cancel(string name)
        {
            int name1 = Convert.ToInt32(name);
            Product ProdFound = null;
            List<Product> products = ProductManager.GetAllProduct();
            foreach (Product prod in products)
            {
                if (prod.ID == name1)
                {
                    ProdFound = prod;
                }
            }
            if (OrderManager.Cancel(ProdFound))
            {
                Response.Write("Success");
            }
            else
            {
                Response.Write("failure");
            }
            List<Product> orderd = OrderManager.Getorderd();
            if (orderd.Count == 0)
            {
                return RedirectToAction("Index", "Products");
            }
            else
            {
                return RedirectToAction("Show", "Orders");

            }
            }
        

        }
	}
