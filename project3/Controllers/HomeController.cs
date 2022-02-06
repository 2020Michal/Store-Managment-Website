
using System.Web.Mvc;
using project3.Models;
using project3.Services;

namespace project3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IceCreamService _iceCreamService;
        
        //Ctor
        public HomeController()
        {
            _iceCreamService = new IceCreamService();
        }
    
        //Main Page 
        public ActionResult Index()
        {
           var iceCreams = _iceCreamService.Get();
            return View(iceCreams);
        }

    }
}