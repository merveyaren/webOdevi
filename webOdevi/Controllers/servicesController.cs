using Microsoft.AspNetCore.Mvc;

namespace webOdevi.Controllers
{
    public class servicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
