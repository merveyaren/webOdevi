using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using webOdevi.Models;

namespace webOdevi.Controllers
{
    public class randevularController : Controller
    {
        private readonly ApplicationDbContext _context;

        public randevularController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Randevular
        public IActionResult randevular()
        {
            // Oturum kontrolü
            var musteriid = HttpContext.Session.GetInt32("musteriid");

            if (musteriid == null)
            {
                return RedirectToAction("login", "login");
            }

            // Dropdown için veriler
            ViewBag.Services = new SelectList(_context.Services.ToList(), "hizmetid", "hizmetadi");
            ViewBag.Personel = _context.Personel
                .Select(p => new SelectListItem
                {
                    Value = p.personelid.ToString(),
                    Text = $"{p.personeladi} {p.personelsoyadi} - {p.pozisyon}"
                }).ToList();

            return View(new randevular());
        }

        [HttpPost]
        public IActionResult randevular(randevular model)
        {
            var musteriid = HttpContext.Session.GetInt32("musteriid");

            if (musteriid == null)
            {
                return RedirectToAction("login", "login");
            }

            if (ModelState.IsValid)
            {
                model.musteriid = musteriid.Value;
                model.durum = "Bekliyor"; // Varsayılan durum

                try
                {
                    _context.Randevular.Add(model);
                    _context.SaveChanges(); // Kaydet

                    return RedirectToAction("Index", "Home"); // Başarıyla yönlendirme
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata: {ex.Message}");
                    ModelState.AddModelError("", "Randevu kaydedilirken bir hata oluştu.");
                }
            }
            else
            {
                // Model geçerli değilse, formu tekrar doldurun
                ViewBag.Services = new SelectList(_context.Services.ToList(), "hizmetid", "hizmetadi");
                ViewBag.Personel = _context.Personel
                    .Select(p => new SelectListItem
                    {
                        Value = p.personelid.ToString(),
                        Text = $"{p.personeladi} {p.personelsoyadi} - {p.pozisyon}"
                    }).ToList();
            }

            return View("randevular", model);
        }
    }
}
