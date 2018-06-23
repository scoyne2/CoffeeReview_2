using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ReviewsController : Controller
    {
        [HttpGet]
        public ActionResult Index(int pid = 0)
        {
            var dataContext = new CoffeeReviewEntities();
            IQueryable<ReviewDisplay> filteredReviewDisplay = from r in dataContext.reviews
                                                              join p in dataContext.products on r.product_id equals p.product_id
                                                              join re in dataContext.reviewers on r.reviewer_id equals re.reviewer_id
                                                              where p.product_id == pid
                                                              select new ReviewDisplay()
                                                              {
                                                                  review_id = r.review_id,
                                                                  review_description = r.review_description,
                                                                  review_rating = r.review_rating,
                                                                  reviewer_first_name = re.reviewer_first_name,
                                                                  product_name = p.product_name,
                                                                  product_vendor = p.product_vendor
                                                              };
            return View(filteredReviewDisplay);
        }

    }
}