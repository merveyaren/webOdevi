using Microsoft.AspNetCore.Mvc;

namespace webOdevi.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }
    }
}
