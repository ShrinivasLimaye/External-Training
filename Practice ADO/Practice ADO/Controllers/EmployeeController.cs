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
    public class EmployeesController : Controller
    {
        List<Employee> employees = new List<Employee>();

      
        public ActionResult emplist()
        {
            List<Employee> Employee = EmployeeDAL.GetAll();

            return View(Employee);
        }

        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Add(Employee emp)
        {

             if (EmployeeManager.Insert(emp))
            {
                Response.Write("Success");
            }
            else
            {
                Response.Write("failure");
            }
             return RedirectToAction("Index", "Home");
            
        }

        //[ActionName("find")]
        //public ActionResult GetById(int id)
        //{
        //    // get student from the database 
        //    return View();
        //}

        //[NonAction]
        //public Employee GetStudent(int id)
        //{
        //    return employees.Where(e => e.Id == id).FirstOrDefault();
        //}


        //[HttpPost]
        //public ActionResult PostAction()
        //{
        //    return View("Index");
        //}


        //[HttpPut]
        //public ActionResult PutAction()
        //{
        //    return View("Index");
        //}

        //[HttpDelete]
        //public ActionResult DeleteAction()
        //{
        //    return View("Index");
        //}

        //[HttpHead]
        //public ActionResult HeadAction()
        //{
        //    return View("Index");
        //}

        //[HttpOptions]
        //public ActionResult OptionsAction()
        //{
        //    return View("Index");
        //}

        //[HttpPatch]
        //public ActionResult PatchAction()
        //{
        //    return View("Index");
        //}

    }
}