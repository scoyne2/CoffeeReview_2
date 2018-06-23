using System;
namespace WebApplication1.Models
{
    public class ReviewDisplay
    {
        public int review_id { get; set; }
        public int product_id { get; set; }
        public string review_description { get; set; }
        public string reviewer_first_name { get; set; }
        public string reviewer_last_name { get; set; }
        public string product_name { get; set; }
        public string product_vendor { get; set; }
        public double? review_rating { get; set; }
        public int review_count { get; set; }
    }
}