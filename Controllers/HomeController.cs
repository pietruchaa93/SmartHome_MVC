using Microsoft.AspNetCore.Mvc;
using SmartHome_MVC.Models;
using System.Diagnostics;

namespace SmartHome_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Rooms()
        {
            return View();
        }
        public IActionResult Devices()
        {
            return View();
        }
        public IActionResult Members()
        {
            return View();
        }
        public IActionResult Security()
        {
            return View();
        }
        public IActionResult Trends()
        {
            return View();
        }
        public IActionResult Settings()
        {
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