using Microsoft.AspNetCore.Mvc;
using webOdevi.Models;

namespace webOdevi.Controllers
{
    public class loginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public loginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login(login model)
        {
            if (ModelState.IsValid)
            {
                // Admin kontrolü
                var adminUser = _context.Admin.SingleOrDefault(a => a.eposta == model.eposta && a.sifre == model.sifre);
                if (adminUser != null)
                {
                    // Admin oturum verilerini ayarla
                    HttpContext.Session.SetInt32("adminid", adminUser.adminid);
                    HttpContext.Session.SetString("UserEmail", adminUser.eposta);

                    return RedirectToAction("PersonelVerimTablosu", "personel"); // Admin sayfasına yönlendirme
                }

                // Musteri kontrolü
                var user = _context.Musteriler.SingleOrDefault(u => u.eposta == model.eposta && u.sifre == model.sifre);
                if (user != null)
                {
                    // Kullanıcı oturum verilerini ayarla
                    HttpContext.Session.SetInt32("musteriid", user.musteriid);
                    HttpContext.Session.SetString("UserEmail", user.eposta);
                    HttpContext.Session.SetString("UserName", user.musteriadi);

                    return RedirectToAction("Index", "Home"); // Kullanıcı sayfasına yönlendirme
                }

                // Hatalı giriş
                ModelState.AddModelError(string.Empty, "Eposta veya şifre hatalı.");
            }

            return View(model);
        }
    }
}
