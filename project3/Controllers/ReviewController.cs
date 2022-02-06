
using project3.Models;
using project3.Services;
using System.Web.Mvc;

namespace project3.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ReviewService _reviewService;

        //Ctor
        public ReviewController()
        {
            _reviewService = new ReviewService();
        }

        // Add Review
        [HttpPost]
        public JsonResult Create(Review review)
        {
            var newReview =_reviewService.Create(review);
         return Json(newReview, JsonRequestBehavior.AllowGet);
        }

    }
}
