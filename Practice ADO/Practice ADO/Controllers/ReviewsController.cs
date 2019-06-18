using System.Web.Mvc;

namespace ECommerceWebSite.Controllers
{

    //[RoutePrefix("reviews")]
    public class ReviewsController : Controller
    {
        // eg: /reviews
        [Route("reviews")]
        public ActionResult Index()
        { return View();
        }
        // eg: /reviews/5
        [Route("reviews/{reviewId}")]
        public ActionResult Show(int reviewId)
        {
            return View();
        }
        // eg: /reviews/5/edit
        [Route("reviews/{reviewId}/edit")]
        public ActionResult Edit(int reviewId)
        {
            return View();
        }
    }
}