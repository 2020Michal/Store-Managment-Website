
using project3.Models;
using project3.Services;
using System.Web.Mvc;

namespace project3.Controllers
{
    public class UsersController : Controller
    {
       private readonly ApiService _apiService;
        private readonly StoreService _storeService;
        private readonly IceCreamService _iceCreamService;

        //Ctor
        public UsersController()
       {
            _apiService = new ApiService();
            _storeService = new StoreService();
            _iceCreamService = new IceCreamService();
        }

        // GET: UsersModel
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users user)
        {
            if (user.Password == null ||user.UserName==null)
            {
                ViewBag.Error = "Please Enter All Fields";
                return View("Login", user);
            }

            var isUserValid = _apiService.userValidation(user);

            //Check if User Login Exist
            if (!isUserValid)
            {
              ViewBag.Error = "This User doesn't Exists";
                return View("Login", user);
           }
           else
           {
             return RedirectToAction("AllStores", "Store");
            }
               
        }

        // GET: Users/SignUp
        public ActionResult SignUp()
        {
            return View();
        }

        //POST: Users/SignUp
        [HttpPost]
         public ActionResult SignUp(Users user)
        {
            if (user.Password == null || user.UserName == null)
            {
                ViewBag.Error = "Please Enter All Fields";
                return View("SignUp", user);
            }

            var isExist= _apiService.isExist(user);
            if(isExist)
            {
                ViewBag.Error = "This user Already Exists, Try Again";
                return View("SignUp", user);
            }
        
            _apiService.Create(user);
            return RedirectToAction("AllStores", "Store");
        }

    }
}
