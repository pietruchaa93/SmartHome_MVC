using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartHome_Database;
//using SmartHome_MVC.Helpers;
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


        [HttpGet]
        public IActionResult Devices()
        {
            SmartHome_MVC.Models.PortCOMS model = new SmartHome_MVC.Models.PortCOMS();
            model.AvailablePorts = new List<string> { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8" };

            var dbContext = new SmartHomeDbContext(); // My DbContext

            var lastSave = dbContext.selectportCOM // My table Name
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();

            // If the last Write is null, the database is empty

            if (lastSave != null)
            {
                // Use last save as needed
                int id = lastSave.Id;
                model.portCOM = lastSave.portCOM;

            }

            return View(model);

        }

        [HttpPost]
        public IActionResult Devices(SmartHome_MVC.Models.PortCOMS model)
        {

            // In case of an invalid model, you can reinitialize the model and pass it to the view
            model.AvailablePorts = new List<string> { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8" };

                var wselectedCOM = model.portCOM;
                DatabaseLocator.Database.selectportCOM.Add(new SelectedPort
                {
                    portCOM = wselectedCOM,
                });
                DatabaseLocator.Database.SaveChanges();

                return View(model);
            
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