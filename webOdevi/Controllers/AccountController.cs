using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webOdevi.Models;

namespace webOdevi.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<musteriler> _userManager;
        private readonly SignInManager<musteriler> _signInManager;

        public AccountController(UserManager<musteriler> userManager, SignInManager<musteriler> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public async Task<IActionResult> Register(musteriler model)
        {
            if (ModelState.IsValid)
            {
                var user = new musteriler
                {
                    UserName = model.eposta,
                    Email = model.eposta,
                    musteriadi = model.musteriadi,
                    musterisoyadi = model.musterisoyadi,
                    musteritelefon = model.musteritelefon
                };

                var result = await _userManager.CreateAsync(user, model.sifre);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
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
        public async Task<IActionResult> Login(musteriler model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.eposta, model.sifre, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model);
        }

        // POST: /Account/Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
