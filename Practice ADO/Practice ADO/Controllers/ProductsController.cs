using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOLayer;
using BLL;
using DAL;

namespace ECommerceWebSite.Controllers
{
   [Authorize]

    public class ProductsController : Controller
    {
        //
        // GET: /Products/
        public ActionResult Index()
        {
            //List<Product> products = (List<Product>)this.HttpContext.Application["catalog"];
            List<Product> products = ProductManager.GetAllProduct();
            return View(products);
        }
        public ActionResult Details(int Id)
        {
            Product ProdFound = null;
            List<Product> products = ProductManager.GetAllProduct(); //(List<Product>)this.HttpContext.Application["catalog"];
            foreach (Product prod in products)
            {
                if (prod.ID == Id)
                {
                    ProdFound = prod;
                }
            }
            return View(ProdFound);
        }
        public ActionResult Addc()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Addprod(Product prod)
        {
            if (ProductManager.Insert(prod))
            {
                Response.Write("Success");
            }
            else
            {
                Response.Write("failure");
            }
            return View();
        }
        [Route("{productId:int}/{productTitle}")]
        public ActionResult Show(int productId)
        {
            return View();
        }

        // eg: /flowers
        // eg: /flowers/1430210079
        [Route("flowers/{isbn ?}")]
        public ActionResult Show(string isbn)
        {
            if (!String.IsNullOrEmpty(isbn))
            {
                return View("OneFlower", GetProduct(isbn));
            }
            return View("Allflowers", GetProducts());
        }

        
        List<Product> GetProduct(string isbn)
        {
            return null;

        }

        List<Product> GetProducts()
        {
            List<Product> products = (List<Product>)this.HttpContext.Application["catalog"];
            return products;
        }
        List<Product> GetBooksByLanguage(string lang)
        {
            List<Product> products = (List<Product>)this.HttpContext.Application["catalog"];
            return products;
        }
        [Route("books/lang/{lang=en}")]
        public ActionResult ViewByLanguage(string lang)
        {
            return View("OneBook", GetBooksByLanguage(lang));
        }

    }
}