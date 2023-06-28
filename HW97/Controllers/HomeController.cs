using HW97.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace HW97.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Login([FromForm] UserModel model)
        {
            UserRepository user = new();
            var userModelList = user.GetDb(model);
            if (userModelList.Exists(c => c.NationalCode == model.NationalCode && c.CellPhone == model.CellPhone))
                return RedirectToAction("UsersAction");
            else
            {
                ViewBag.ErrorMessage = "رمز عبور وارد شده اشتباه است.";
                return View("Register");
            }
        }
        public IActionResult Index()
        {
            return View();

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
        public IActionResult RegisterUsers([FromForm] UserModel userModel)
        {
            UserRepository user = new();
            user.SetDb(userModel);
            return RedirectToAction("Index");
        }
        public IActionResult MethodName()
        {
            // کدهای مورد نظر برای اجرا
            return Json(new { success = true }); // یا هر نوع پاسخی که می‌خواهید برگردانید
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}