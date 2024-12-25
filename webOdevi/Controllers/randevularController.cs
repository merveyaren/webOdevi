using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
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
        [ValidateAntiForgeryToken]
        public IActionResult randevular(randevular model)
        {
            var musteriid = HttpContext.Session.GetInt32("musteriid");

            if (musteriid == null)
            {
                TempData["Hata"] = "Randevu almak için giriş yapmalısınız.";
                return RedirectToAction("login", "login");
            }

            model.musteriid = musteriid.Value;
            model.durum = "Bekliyor";

            if (ModelState.IsValid)
            {
                try
                {
                    Console.WriteLine("Model Before Save: " + JsonSerializer.Serialize(model));
                    _context.Randevular.Add(model);
                    _context.SaveChanges();
                    TempData["Basari"] = "Randevunuz başarıyla kaydedildi!";
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata: {ex.Message}");
                    TempData["Hata"] = "Randevu kaydedilirken bir hata oluştu. Lütfen tekrar deneyin.";
                }
            }
            else
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }



            // Dropdown'ları tekrar doldur
            ViewBag.Services = new SelectList(_context.Services.ToList(), "hizmetid", "hizmetadi");
            ViewBag.Personel = _context.Personel
                .Select(p => new SelectListItem
                {
                    Value = p.personelid.ToString(),
                    Text = $"{p.personeladi} {p.personelsoyadi} - {p.pozisyon}"
                }).ToList();

            Console.WriteLine($"Musteri ID: {model.musteriid}");
            Console.WriteLine($"Personel ID: {model.personelid}");
            Console.WriteLine($"Hizmet ID: {model.hizmetid}");
            Console.WriteLine($"Randevu Tarihi: {model.randevutarihi}");
            Console.WriteLine($"Başlangıç Saati: {model.baslangicsaati}");
            Console.WriteLine($"Randevuid: {model.randevuid}");
            Console.WriteLine($"Randevuid: {model.durum}");
            return View(model);
        }
    }
}
