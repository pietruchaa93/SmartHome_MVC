using Microsoft.AspNetCore.Mvc;

namespace SmartHome_MVC.Controllers
{
    public class RoomsController : Controller
    {
        public IActionResult Rooms()
        {
            return View();
        }
    }
}
