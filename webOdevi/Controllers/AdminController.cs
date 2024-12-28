using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace webOdevi.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }



        public IActionResult PersonelVerimTablosu()
        {
            
            return View();
        }

        public IActionResult RandevuOnay()
        {
           
            return View();
        }
    }

}
