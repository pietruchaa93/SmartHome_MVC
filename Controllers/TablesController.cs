using Microsoft.AspNetCore.Mvc;
using SmartHome_Database;
using SmartHome_Database.Enities;

namespace SmartHome_MVC.Controllers
{
    public class TablesController : Controller
    {
        public static DateTime selectedDateStatic = DateTime.Now;

        public IActionResult Tables()
        {
            using (SmartHomeDbContext dbContext = new SmartHomeDbContext())
            {
                List<ReadValuesFromArduino> table = dbContext.ReadValuesArduino.ToList();

                // Get last 150 records sorting by date
                List<ReadValuesFromArduino> last150Records = table
                    .OrderByDescending(k => k.DateTime)
                    .Take(150)
                    .ToList();

                TablesViewModel viewModel = new TablesViewModel();
                viewModel.ReadValuesFromArduinoViewModel = last150Records;

                return View(viewModel);

            }
        }
        public ActionResult SetSelectedDate(int index, DateTime selectedDate)
        {
            selectedDateStatic = selectedDate;
            return Json(new { success = true });
        }

        public ActionResult GetData(DateTime selectedDate)
        {
            using (SmartHomeDbContext dbContext = new SmartHomeDbContext())
            {
                List<ReadValuesFromArduino> table = dbContext.ReadValuesArduino.ToList();
  
                List<ReadValuesFromArduino> selectedDateTable = table
                    .Where(k => k.DateTime.Date == selectedDate.Date)
                    .ToList();

                TablesViewModel viewModel = new TablesViewModel();
                viewModel.ReadValuesFromArduinoViewModel = selectedDateTable;

                return PartialView("_TablePartial", viewModel);
            }
        }






    }
    } 
