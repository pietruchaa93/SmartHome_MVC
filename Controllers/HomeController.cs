using Microsoft.AspNetCore.Mvc;
using SmartHome_Database;
using SmartHome_MVC.Models;
using System.Diagnostics;

namespace SmartHome_MVC
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; 
        private readonly WeatherService weatherService;
        private SmartHomeDbContext _dbContext;


        public HomeController(ILogger<HomeController> logger, SmartHomeDbContext dbContext)
        {
            _logger = logger;
            
            string apiKey = "b78914adc769484c70194fc36745f561";
            weatherService = new WeatherService(apiKey);
         
            _dbContext = dbContext;
        }

        public IActionResult Dashboard()
        {
            string city = "Bydgoszcz";
            WeatherData weatherData = weatherService.GetWeather(city);

            ViewBag.Temperature = weatherData.Temperature;
            ViewBag.Humidity = weatherData.Humidity;

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