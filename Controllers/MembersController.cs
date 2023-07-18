using Microsoft.AspNetCore.Mvc;

namespace SmartHome_MVC.Controllers
{
    public class MembersController : Controller
    {
        public IActionResult Members()
        {
            return View();
        }
    }
}
