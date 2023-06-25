using HW97.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HW97.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromForm]LoginModel model)
        {
            var s = Repository.GetUsers();
            if (s.Exists(c => c.NationalCode == model.UserName && c.CellPhone == model.Password))
                return RedirectToAction("UsersAction");
            else
                return View("RegisterUsers");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult UsersAction()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterUsers([FromForm] UserModel user)
        {
            Repository.SetUsersDb(user);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}