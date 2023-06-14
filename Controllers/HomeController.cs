using Microsoft.AspNetCore.Mvc;
using SmartHome_Database;
using SmartHome_MVC.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Net;

namespace SmartHome_MVC
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SerialPortService _serialPortService;
        private readonly WeatherService weatherService;
        private readonly DevicesManager _deviceManager;


        public HomeController(ILogger<HomeController> logger, SerialPortService serialPortService)
        {
            _logger = logger;
            _serialPortService = serialPortService;

            string apiKey = "b78914adc769484c70194fc36745f561";
            weatherService = new WeatherService(apiKey);

            _deviceManager = new DevicesManager();
        }

        public IActionResult Dashboard()
        {
            string city = "Bydgoszcz";
            WeatherData weatherData = weatherService.GetWeather(city);

            ViewBag.Temperature = weatherData.Temperature;
            ViewBag.Humidity = weatherData.Humidity;

            return View();
        }


        public IActionResult Rooms()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Devices()
        {
            DevicesViewModel model = new DevicesViewModel();
            model.viewPortCOMS.portCOM = _deviceManager.GetLastSelectedPortCOM();

            return View(model);
        }

        [HttpPost]
        public IActionResult Devices(DevicesViewModel model)
        {

            string selectedCOM = model.viewPortCOMS.portCOM;
            _deviceManager.SetSelectedPortCOM(selectedCOM);

            _serialPortService.StartAsync(CancellationToken.None);

            return View(model);

        }

        public IActionResult GetCurrentValues()
        {
            var dbContext = new SmartHomeDbContext(); // My DBContext

            var lastValue = dbContext.ReadValuesArduino
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();

            return Json(lastValue);
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