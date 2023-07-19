using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHome_Database;
using SmartHome_Database.Enities;
using System.Diagnostics.Metrics;

namespace SmartHome_MVC.Controllers
{
    public class TrendsController : Controller
    {
        private readonly SmartHomeDbContext _dbContext;
        public TrendsController(SmartHomeDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public IActionResult Trends()
        {
            // Pobierz dane z bazy
            List<ReadValuesFromArduino> measurements = _dbContext.ReadValuesArduino.ToList();

            // Przygotuj dane do wykresów
            var timeLabels = measurements.Select(m => m.DateTime.ToString("yyyy-MM-dd HH:mm:ss")).ToList();
            var temperatureData = measurements.Select(m => m.temperature).ToList();
            var button1Data = measurements.Select(m => m.button1).ToList();
            var button2Data = measurements.Select(m => m.button2).ToList();
            var analogData = measurements.Select(m => m.analog).ToList();

            ViewBag.TimeLabels = timeLabels;
            ViewBag.TemperatureData = temperatureData;
            ViewBag.Button1Data = button1Data;
            ViewBag.Button2Data = button2Data;
            ViewBag.AnalogData = analogData;

            return View();
        }
    }
}
