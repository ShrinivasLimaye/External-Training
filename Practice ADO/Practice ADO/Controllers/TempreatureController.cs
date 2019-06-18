using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceWebSite.Controllers
{
    public class TempreatureController : Controller
    {
        //
        // GET: /Tempreature/
        [Route("temp/{scale:values(celsius|fahrenheit)}")]
        public ActionResult Show(string scale)
        {
            return Content("scale is " + scale);
        }
	}
}