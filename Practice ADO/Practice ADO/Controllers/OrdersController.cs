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
        [HttpPost]
        public ActionResult Order1()
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
            ProdFound.Quantity = ProdFound.Quantity-q
            if (OrderManager.Insert(ProdFound))
            {

                if (ProductManager.Updatequant(ProdFound))
                {
                List<Product> CART = ProductManager.Getcart();
                return View(CART);
                }
            }
            else
            {
                Response.Write("failure");
            }
            return RedirectToAction("Index", "Home");
        }

        }
	}
