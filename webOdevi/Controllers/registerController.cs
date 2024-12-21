using Microsoft.AspNetCore.Mvc;
using webOdevi.Models;

namespace webOdevi.Controllers
{
    public class registerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public registerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new musteriler
                {
                    eposta = model.eposta,
                    musteriadi = model.musteriadi,
                    musterisoyadi = model.musterisoyadi,
                    musteritelefon = model.musteritelefon,
                    sifre = model.sifre // Şifre doğrudan alınır ve kaydedilir.
                };

                _context.Musteriler.Add(user);
                _context.SaveChanges();  // Veritabanına kaydedilir

                return RedirectToAction("login", "login");
                // Giriş sayfasına yönlendirilir
            }

            return View(model);
        }

    }
}
