using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dataContext = new CoffeeReviewEntities();
            
            IQueryable<ReviewDisplay> reviewDisplay = from r in dataContext.reviews
                                         join p in dataContext.products on r.product_id equals p.product_id
                                         join re in dataContext.reviewers on r.reviewer_id equals re.reviewer_id
                                         group new {r.review_rating } by new { p.product_name, p.product_vendor, p.product_id}
                                         into g
                                         select new ReviewDisplay()
                                         {
                                             review_rating = g.Average(x => x.review_rating),
                                             review_count = g.Count(x => x.review_rating.HasValue),
                                             product_name = g.Key.product_name,
                                             product_vendor = g.Key.product_vendor,
                                             product_id = g.Key.product_id
                                          };
            return View(reviewDisplay);
        }
    }
}