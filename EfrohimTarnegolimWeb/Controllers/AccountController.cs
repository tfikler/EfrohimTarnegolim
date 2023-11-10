using EfrohimTarnegolimWeb.Models;
using EfrohimTarnegolimWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EfrohimTarnegolimWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly RegisterDAO _registerDAO;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
            _registerDAO = new RegisterDAO();
        }

        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SuccessLogin(UserModel userModel)
        {
            _registerDAO.InsertRegisterUserToDatabase(userModel);

            // Redirect to a success page or handle as needed
            return RedirectToAction("RegistrationSuccess");
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}