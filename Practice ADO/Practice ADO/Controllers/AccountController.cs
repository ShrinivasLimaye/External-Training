using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL;

namespace ECommerceWebSite.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
       
        public ActionResult Login(string Username, string Password, string returnUrl)
        {   //if(Username=="swati" && Password=="ganvir")
            if (AccountManager.Validate(Username, Password))
            {
                if (Username == "Admin")
                {
                    return this.RedirectToAction("Orders", "Orders");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(Username, false);
                    return Redirect(returnUrl ?? Url.Action("Index", "Home"));
                }
            }
            return View();
        }
	}
}