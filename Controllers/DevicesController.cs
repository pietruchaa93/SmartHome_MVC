﻿using Microsoft.AspNetCore.Mvc;
using SmartHome_Database;

namespace SmartHome_MVC.Controllers
{
    public class DevicesController : Controller
    {
        private readonly DevicesManager _deviceManager;
        private readonly SerialPortService _serialPortService;

        public DevicesController(SerialPortService serialPortService) 
        {
            _serialPortService = serialPortService;
            _deviceManager = new DevicesManager();
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
    }
}
