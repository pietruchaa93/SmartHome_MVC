using Microsoft.AspNetCore.Mvc;
using SmartHome_Database;
using SmartHome_MVC.Models;

namespace SmartHome_MVC.Controllers
{
    public class DevicesController : Controller
    {
        private readonly SerialPortService _serialPortService;

        public DevicesController(SerialPortService serialPortService) 
        {
            _serialPortService = serialPortService;
        }

        [HttpGet]
        public IActionResult Devices()
        {
            DevicesViewModel model = new DevicesViewModel();

            return View(model);
        }


        [HttpPost]
        public ActionResult SetSelectedPortCOM(string selectedPortCOM)
        {
            // Przypisanie wybranej daty do zmiennej selectedZmianaModel
            GlobalValues.selectedPortCOM = selectedPortCOM;
            _serialPortService.StartAsync(CancellationToken.None);
            return Json(new { success = true });
        }

        public IActionResult GetCurrentValues()
        {
            var dbContext = new SmartHomeDbContext(); // My DBContext

            var lastValue = dbContext.ReadValuesArduino
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();

            return Json(lastValue);
        }
    }
}
