
using Newtonsoft.Json;
using project3.Models;
using project3.Services;
using System.Web.Mvc;

namespace project3.Controllers
{
    //Google Maps
    public class GoogleGeoCodeResponse
    {

        public string Status { get; set; }
        public Results[] results { get; set; }

    }

    public class Results
    {
        public string Formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public string[] Types { get; set; }
        public Address_component[] address_components { get; set; }
    }

    public class Geometry
    {
        public string Location_type { get; set; }
        public Location location { get; set; }
    }

    public class Location
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    public class Address_component
    {
        public string Long_name { get; set; }
        public string Short_name { get; set; }
        public string[] Types { get; set; }
    }

    public class StoreController : Controller
    {
        private readonly IceCreamService _iceCreamService;
        private readonly StoreService _storeService;
        private readonly ApiService _apiService;
     
        //Ctor
        public StoreController()
        {
           _storeService = new StoreService();
            _apiService = new ApiService();
            _iceCreamService = new IceCreamService();
        }

        // GET: Store
        public ActionResult Index()
        {
            var storeDetails = _storeService.Get();
            return View(storeDetails);
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        //Add Store Func called by ajax return json
        [HttpPost]
        public JsonResult Create(Store storeIce)
        {
            var url = "https://maps.googleapis.com/maps/api/geocode/json?address=" + storeIce.Address + "&key=AIzaSyA_LqinivTa-2oUcvIt7NoNV8IpBIdPT4c";
            var result2 = new System.Net.WebClient().DownloadString(url);
            GoogleGeoCodeResponse test = JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(result2);
            Location loc = test.results[0].geometry.location;
            var latLocation = loc.Lat;
            var langLocation = loc.Lng;
            storeIce.Lat = latLocation;
            storeIce.Lang = langLocation;
            _storeService.Create(storeIce);
            return Json(storeIce, JsonRequestBehavior.AllowGet);
        }


        //Store Details Page
        public ActionResult Details(string id)
        {
            var storeDetail = _storeService.Get(id);
            storeDetail.ListOfIce = _storeService.GetProductsOfStore(id);
            return View(storeDetail);
        }

        //Get Store By Id Func. called by ajax, return json
        [HttpPost]
        public JsonResult GetStore(string id)
        {
            var store = _storeService.Get(id);
            return Json(store, JsonRequestBehavior.AllowGet);
        }

        // All Stores List
        public ActionResult AllStores()
        {
            var allStores = _storeService.Get();
            return View(allStores);
        }

    }
}
