using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace webOdevi.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            // Admin sayfası için bir işlem veya veriler sağlanabilir.
            ViewData["IsAdmin"] = true; // Admin olduğunu belirten ViewData
            return View();
        }

        public IActionResult PersonelEkle()
        {
            // Personel ekleme işlemleri
            return View();
        }

        public IActionResult PersonelListele()
        {
            // Personel listeleme işlemleri
            return View();
        }

        public IActionResult PersonelverimTablosu()
        {
            // Personel verim tablosu işlemleri
            return View();
        }

        public IActionResult RandevuOnay()
        {
            // Randevu onay işlemleri
            return View();
        }
    }


}
