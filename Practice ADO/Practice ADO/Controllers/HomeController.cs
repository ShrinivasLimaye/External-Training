using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOLayer;

namespace ECommerceWebSite.Controllers
{

    //handlling GET and POST request types

    public class HomeController : Controller
    {

        public HomeController()
        {

        }
        //action methods
        // receive request and process  request and send model to view


        //Request types: HTTP Request
        //GET, POST, PUT, DELETE, PATCH,etc. 
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            string name = "Transflower Learning Pvt. Ltd.";

            ViewData["company"] = name;
            return View();
        }

        public ActionResult ContactUs()
        {
            string url = "www.transflower.in";
            ViewBag.product = new { ID = 23, Title = "Rose" };
            ViewBag.website = url;
            ViewBag.school = "iacsd";
            ViewBag.age = 45;
            ViewBag.person = new Person { FirstName = "Ravi", LastName = "Tambade" };

            return View();
        }

        public ActionResult Services()
        {
            string service = "Transforming Digital India";
            TempData["vision"] = service;

            this.Session["vision"] = service;
            this.HttpContext.Application["vision"] = service;
            this.HttpContext.Cache.Insert("vision", service);

            return View();
            /*
            
            TempData  used to store temporary data 
            which can be used in the subsequent request. 
            
            TempData will be cleared out after the completion of a subsequent request.

            TempData is useful when you want to transfer non-sensitive data from 
            one action method to another action method of the same or a different controller 
            as well as redirects.

             */
        }



        public ActionResult Revenue()
        {
            return View();
        }

        public ActionResult TopTen()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { Id = 1, FirstName = "Manoj", LastName = "Tambade", City = "Nagpur", ContactNumber = "9881735806", Email = "manoj.tambade@transflower.in" });
            employees.Add(new Employee { Id = 1, FirstName = "Manisha", LastName = "Jadhav", City = "Delhi", ContactNumber = "9881735861", Email = "manisha.jadhav@transflower.in" });
            employees.Add(new Employee { Id = 2, FirstName = "Ravi", LastName = "Pant", City = "Mumbai", ContactNumber = "9881735441", Email = "ravi.pant@transflower.in" });
            employees.Add(new Employee { Id = 3, FirstName = "Rajiv", LastName = "Gore", City = "Mumbai", ContactNumber = "9881735856", Email = "rajiv.gore@transflower.in" });
            employees.Add(new Employee { Id = 4, FirstName = "Gokul", LastName = "Varma", City = "Kanpur", ContactNumber = "9881735236", Email = "gokul.varma@transflower.in" });
            employees.Add(new Employee { Id = 5, FirstName = "sheetal", LastName = "Kulkarni", City = "Nashik", ContactNumber = "9881735765", Email = "sheetal.kulkarni@transflower.in" });
            employees.Add(new Employee { Id = 6, FirstName = "Amarn", LastName = "Sharma", City = "Delhi", ContactNumber = "9881733761", Email = "amar.sharma@transflower.in" });
            employees.Add(new Employee { Id = 7, FirstName = "Sarang", LastName = "Agarwal", City = "Pune", ContactNumber = "9881735871", Email = "sarang.Agarwal@transflower.in" });
            return View(employees);
        }

        public ActionResult Chart()
        {
            return View();
        }

        public ActionResult SalesView()
        {
            BLL.Sales.Repository list = new BLL.Sales.Repository();
            ViewBag.Message = "Transflower Sales!";
            return View(list);

        }


        public ActionResult TopTenStyle()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { Id = 1, FirstName = "Manoj", LastName = "Tambade", City = "Nagpur", ContactNumber = "9881735806", Email = "manoj.tambade@transflower.in" });
            employees.Add(new Employee { Id = 1, FirstName = "Manisha", LastName = "Jadhav", City = "Delhi", ContactNumber = "9881735861", Email = "manisha.jadhav@transflower.in" });
            employees.Add(new Employee { Id = 2, FirstName = "Ravi", LastName = "Pant", City = "Mumbai", ContactNumber = "9881735441", Email = "ravi.pant@transflower.in" });
            employees.Add(new Employee { Id = 3, FirstName = "Rajiv", LastName = "Gore", City = "Mumbai", ContactNumber = "9881735856", Email = "rajiv.gore@transflower.in" });
            employees.Add(new Employee { Id = 4, FirstName = "Gokul", LastName = "Varma", City = "Kanpur", ContactNumber = "9881735236", Email = "gokul.varma@transflower.in" });
            employees.Add(new Employee { Id = 5, FirstName = "sheetal", LastName = "Kulkarni", City = "Nashik", ContactNumber = "9881735765", Email = "sheetal.kulkarni@transflower.in" });
            employees.Add(new Employee { Id = 6, FirstName = "Amarn", LastName = "Sharma", City = "Delhi", ContactNumber = "9881733761", Email = "amar.sharma@transflower.in" });
            employees.Add(new Employee { Id = 7, FirstName = "Sarang", LastName = "Agarwal", City = "Pune", ContactNumber = "9881735871", Email = "sarang.Agarwal@transflower.in" });
            return View(employees);
        }

        public ActionResult TopTenStyleRowSelect()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { Id = 1, FirstName = "Manoj", LastName = "Tambade", City = "Nagpur", ContactNumber = "9881735806", Email = "manoj.tambade@transflower.in" });
            employees.Add(new Employee { Id = 1, FirstName = "Manisha", LastName = "Jadhav", City = "Delhi", ContactNumber = "9881735861", Email = "manisha.jadhav@transflower.in" });
            employees.Add(new Employee { Id = 2, FirstName = "Ravi", LastName = "Pant", City = "Mumbai", ContactNumber = "9881735441", Email = "ravi.pant@transflower.in" });
            employees.Add(new Employee { Id = 3, FirstName = "Rajiv", LastName = "Gore", City = "Mumbai", ContactNumber = "9881735856", Email = "rajiv.gore@transflower.in" });
            employees.Add(new Employee { Id = 4, FirstName = "Gokul", LastName = "Varma", City = "Kanpur", ContactNumber = "9881735236", Email = "gokul.varma@transflower.in" });
            employees.Add(new Employee { Id = 5, FirstName = "sheetal", LastName = "Kulkarni", City = "Nashik", ContactNumber = "9881735765", Email = "sheetal.kulkarni@transflower.in" });
            employees.Add(new Employee
            {
                Id =
                    6,
                FirstName = "Amarn",
                LastName = "Sharma",
                City = "Delhi",
                ContactNumber = "9881733761",
                Email = "amar.sharma@transflower.in"
            });
            employees.Add(new Employee { Id = 7, FirstName = "Sarang", LastName = "Agarwal", City = "Pune", ContactNumber = "9881735871", Email = "sarang.Agarwal@transflower.in" });
            return View(employees);
        }

        public ActionResult CustomHelper()
        {
            return View();
        }
    }
}



/*
 
 Inbuilt ActionRestult 

ViewResult	                                            Represents HTML and markup.
EmptyResult	                                            Represents No response.
ContentResult	                                        Represents string literal.
FileContentResult/ FilePathResult/ FileStreamResult	    Represents the content of a file
JavaScriptResult	                                    Represent a JavaScript script.
JsonResult	                                            Represent JSON that can be used in AJAX
RedirectResult	                                        Represents a redirection to a new URL
RedirectToRouteResult	                                Represent another action of same or other controller
PartialViewResult	                                    Returns HTML from Partial view
HttpUnauthorizedResult	                                Returns HTTP 403 status

 */




/*




ViewResult	            Represents HTML and markup.	                            View()
EmptyResult	            Represents No response.	
ContentResult	        Represents string literal.	                            Content()
FileContentResult,
FilePathResult,
FileStreamResult	    Represents the content of a file	                    File()
JavaScriptResult	    Represent a JavaScript script.	                        JavaScript()
JsonResult	            Represent JSON that can be used in AJAX	                Json()
RedirectResult	        Represents a redirection to a new URL	                Redirect()
RedirectToRouteResult	Represent another action of same or other controller	RedirectToRoute()
PartialViewResult	Returns HTML	                                            PartialView()
HttpUnauthorizedResult	Returns HTTP 403 status	
 */
