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
                var user = _context.Musteriler.SingleOrDefault(u => u.eposta == model.eposta);

                if (user != null && user.sifre == model.sifre)
                {
                    // Oturum verilerini ayarla
                    HttpContext.Session.SetInt32("musteriid", user.musteriid);
                    HttpContext.Session.SetString("UserEmail", user.eposta);
                    HttpContext.Session.SetString("UserName", user.musteriadi);

                    return RedirectToAction("Index", "Home"); // Giriş sonrası yönlendirme
                }

                ModelState.AddModelError(string.Empty, "Eposta veya şifre hatalı.");
            }

            return View(model);
        }
    }
}
