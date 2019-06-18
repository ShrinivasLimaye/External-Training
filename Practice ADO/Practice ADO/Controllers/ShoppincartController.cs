using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOLayer;
using BLL;

namespace ECommerceWebSite.Controllers
{
    public class ShoppincartController : Controller
    {
        //
        // GET: /Shoppincart/
        List<Product> productss = new List<Product>();
        List<Product> CART = new List<Product>();

        public ActionResult AddToCart(string name)
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
            if (ProductManager.Addcart(ProdFound))
            {
                List<Product> CART = ProductManager.Getcart();
                return View(CART);
            }
            else
            {
                Response.Write("failure");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RemoveFromCart(string name)
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
            if (ProductManager.Removecart(ProdFound))
            {
                Response.Write("Success");
            }
            else
            {
                Response.Write("failure");
            }
            List<Product> CART = ProductManager.Getcart();
            if (CART.Count == 0)
            {
                return RedirectToAction("Index", "Products");
            }
            else
            {
                return View(CART);

            }
            }
        public ActionResult dropcart()
        {
          
            if (ProductManager.dropcart())
            {
                Response.Write("Success");
            }
            else
            {
                Response.Write("failure");
            }
            return RedirectToAction("Index", "Products");
        }

            //Product ProdFound = null;
            //List<Product> Pprod = new List<Product>();
            //List<Product> products = ProductManager.GetAllProduct(); ;//(List<Product>)this.HttpContext.Application["catalog"];
            //foreach (Product prod in products)
            //{
            //    if (prod.ID == id)
            //    {
            //        ProdFound = prod;
            //    }
            //}
            //if (Session["ProductList"] != null)
            //{
            //    productss = (List<Product>)(Session["ProductList"]);
            //    if (!productss.Contains(ProdFound))
            //    {
            //        if (ProdFound!=null)
            //        productss.Add(ProdFound);
            //    }
            //}
            //else
            //{
            //    productss.Add(ProdFound);
            //    Session["ProductList"] = productss;
            //}
            ////if (TempData["ProductList"] != null)
            ////{
            ////    productss = (List<Product>)(TempData["ProductList"]);
            ////    productss.Add(ProdFound);
            ////}
            ////else
            ////{
            ////    productss.Add(ProdFound);
            ////    TempData["ProductList"] = productss;
            ////    TempData.Keep("ProductList");
            ////}
            //return View(productss);
        
        public ActionResult RemoveItem(int id)
        {
            productss = (List<Product>)(Session["ProductList"]);

            foreach (BOLayer.Product prod in (List<Product>)Session["ProductList"])
            {
                if(prod.ID==id)
                {
                    var ind = productss.Find(c => c.ID == id);
                    productss.Remove(ind);
                    break;
                }
            }
            Session["ProductList"] = productss;
            return RedirectToAction("AddToCart", new {id=0 });
        }
    }
}