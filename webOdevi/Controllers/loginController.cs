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
        public IActionResult login(Login model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Musteriler.SingleOrDefault(u => u.eposta == model.eposta);

                if (user != null && user.sifre == model.sifre)  // Basit şifre doğrulama
                {
                    return RedirectToAction("Register", "Home");  // Giriş başarılı yönlendirme
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }
    }
}
