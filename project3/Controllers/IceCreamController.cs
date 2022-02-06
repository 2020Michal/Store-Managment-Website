
using project3.Models;
using project3.Services;
using System.Web.Mvc;

namespace project3.Controllers
{
    public class IceCreamController : Controller
    {
        private readonly IceCreamService _iceCreamService;

        //Ctor
        public IceCreamController()
        {
            _iceCreamService = new IceCreamService();
        }

        public ActionResult Index()
        {
            var iceCreamService = _iceCreamService.Get();
            return View(iceCreamService);
        }

        //Ice Creams Search Page
        public ActionResult SearchIceCreamPage()
        {
            var iceCreamService = _iceCreamService.Get();
            return View(iceCreamService);
        }


        //Search IceCream Func called by ajax return json
        public JsonResult IcecreamsByFilter(SearchIceCream searchIceCream)
        {
            var result = _iceCreamService.Get(searchIceCream);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //IceCream Details Page
        public ActionResult Details(string id)
        {
            var iceDetail = _iceCreamService.Get(id);
            if(iceDetail.Rating==0)
            {
                ViewBag.Error = "Be The First To Write A Comment";
            }
            return View(iceDetail);
        }

        //Add IceCream Func called by ajax return json
        [HttpPost]
        public JsonResult Create(IceCream icecream)
        {
            var ice= _iceCreamService.Create(icecream);
            return Json("{ }", JsonRequestBehavior.AllowGet);
        }
        
    }
}
