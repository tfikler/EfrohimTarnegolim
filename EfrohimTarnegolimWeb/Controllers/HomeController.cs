using EfrohimTarnegolimWeb.Models;
using EfrohimTarnegolimWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EfrohimTarnegolimWeb.Controllers
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
            // Get the user's name from TempData set in SuccessLogin action
            string userName = TempData["UserName"] as string;

            if (!string.IsNullOrEmpty(userName))
            {
                ViewData["Title"] = "Home Page";
                ViewData["UserName"] = userName; // Pass the user's name to the view
            }
            else
            {
                ViewData["Title"] = "Home Page";
            }

            return View();
        }

        public IActionResult Privacy()
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