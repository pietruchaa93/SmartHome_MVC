using Microsoft.AspNetCore.Mvc;
using SmartHome_Database;
using SmartHome_Database.Enities;

namespace SmartHome_MVC.Controllers
{
    public class TablesController : Controller
    {
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
                viewModel.ReadValuesFromArduinoViewModel = table;

                return View(viewModel);

            }
        }
            public ActionResult SetSelectedDate(int index, string selectedDate)
            {

                return Json(new { success = true });
            }
        }
    } 
