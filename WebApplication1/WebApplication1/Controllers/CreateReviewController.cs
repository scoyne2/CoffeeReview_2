using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CreateReviewController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var dataContext = new CoffeeReviewEntities();
            IQueryable<SelectListItem> productList = from p in dataContext.products
                                                     select new SelectListItem()
                                                       {
                                                           Text = p.product_vendor + " - " + p.product_name ,
                                                           Value = p.product_id.ToString()
                                                       };

            ReviewSubmit reviewSubmit = new ReviewSubmit();
            reviewSubmit.products = productList;

            return View(reviewSubmit);
        }

        [HttpPost]
        public ActionResult SubmitReview(ReviewSubmit reviewSubmit)
        {
            try
            {
                //do stuff here to submit form
                ViewBag.result = "Review Submitted Successfully!";
            }
            catch
            {
                ViewBag.result = "Oops something went wrong!";
            }



            return View("Index");
        }

    }
}