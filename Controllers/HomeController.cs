using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartHome_Database;
//using SmartHome_MVC.Helpers;
using SmartHome_MVC.Models;
using System.Diagnostics;
using SmartHome_MVC.App_Start;
using SmartHome_MVC;
using SmartHome_Database.Enities;

namespace SmartHome_MVC
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SerialPortService _serialPortService;

        public HomeController(ILogger<HomeController> logger, SerialPortService serialPortService)
        {
            _logger = logger;
            _serialPortService = serialPortService;

        }

        public IActionResult Dashboard()
        {

            return View();
        }


        public IActionResult Rooms()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Devices()
        {
            PortCOMS existingPortCOMS = new PortCOMS();
            DevicesViewModel model = new DevicesViewModel();

            var dbContext = new SmartHomeDbContext(); // My DbContext

            var lastSave = dbContext.selectportCOM // My table Name
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();

            // If the last Write is null, the database is empty

            if (lastSave != null)
            {
                // Use last save as needed
                int id = lastSave.Id;
                model.viewPortCOMS.portCOM = lastSave.portCOM;
            }


            return View(model);

        }

        [HttpPost]
        public IActionResult Devices(DevicesViewModel model)
        {

            var wselectedCOM = model.viewPortCOMS.portCOM;

            DatabaseLocator.Database.selectportCOM.Add(new SelectedPort
            {
                portCOM = wselectedCOM,
            });
            DatabaseLocator.Database.SaveChanges();

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