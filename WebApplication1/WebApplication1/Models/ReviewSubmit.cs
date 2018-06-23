using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class ReviewSubmit : ReviewDisplay
    {
        public string submitStatus { get; set; }
        public IEnumerable<SelectListItem> products { get; set; }
        public int selectedProductId { get; set; }

    }
}