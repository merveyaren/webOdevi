using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using webOdevi.Models;

namespace webOdevi.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<musteriler> _userManager;
        private readonly SignInManager<musteriler> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<musteriler> userManager, SignInManager<musteriler> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public IActionResult Register(musteriler model)
        {
            if (ModelState.IsValid)
            {
                var user = new musteriler
                {
                    
                    eposta = model.eposta,
                    musteriadi = model.musteriadi,
                    musterisoyadi = model.musterisoyadi,
                    musteritelefon = model.musteritelefon,
                    sifre = model.sifre  // Şifre doğrudan alınır ve kaydedilir.
                };

                _context.Musteriler.Add(user);
                _context.SaveChanges();  // Veritabanına kaydedilir

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(musteriler model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Musteriler.SingleOrDefault(u => u.eposta == model.eposta);

                if (user != null && user.sifre == model.sifre)  // Şifre doğrudan karşılaştırılır.
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

        // POST: /Account/Logout
        [HttpPost]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
