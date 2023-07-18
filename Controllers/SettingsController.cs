using Microsoft.AspNetCore.Mvc;

namespace SmartHome_MVC.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Settings()
        {
            return View();
        }
    }
}
