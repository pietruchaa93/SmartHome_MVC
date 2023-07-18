using Microsoft.AspNetCore.Mvc;

namespace SmartHome_MVC.Controllers
{
    public class TrendsController : Controller
    {
        public IActionResult Trends()
        {
            return View();
        }
    }
}
