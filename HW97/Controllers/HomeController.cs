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

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromForm] UserModel model)
        {
            UserRepository user = new();
            var userModelList = user.GetDb();
            if (userModelList.Exists(c => c.NationalCode == model.NationalCode && c.CellPhone == model.CellPhone))
                return RedirectToAction(nameof(UserAction));
            else
            {
                ViewBag.ErrorMessage = "رمز عبور وارد شده اشتباه است.";
                return View();
            }
        }

        public IActionResult UserAction()
        {
            return View();
        }

        public IActionResult TransactionData()
        {
            AccountingRepository accountingRepository = new();
            var transactionsList = accountingRepository.GetDb();
            return View(transactionsList);
        }

        public IActionResult NewTransaction()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewTransaction([FromForm] AccountingModel model)
        {
            AccountingRepository accountingRepository = new();
            accountingRepository.SetDb(model);
            return RedirectToAction(nameof(UserAction));
        }
        public IActionResult Amount()
        {
            AccountingRepository accountingRepository = new();
            var remain = accountingRepository.GetAccountingRamein();
            return View(remain);
        }
        public IActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterUser([FromForm] UserModel userModel)
        {
            UserRepository user = new();
            user.SetDb(userModel);
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}