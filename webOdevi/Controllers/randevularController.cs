using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Text.Json;
using webOdevi.Models;
using Microsoft.AspNetCore.Http;
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
        [HttpGet]
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
            model.randevutarihi = model.randevutarihi?.ToUniversalTime();

            Console.WriteLine($"22222");

            try
            {
                // Session'dan müşteri ID'sini al
                var musteriid = HttpContext.Session.GetInt32("musteriid");

                if (musteriid == null)
                {
                    TempData["Hata"] = "Oturumunuz bulunamadı. Lütfen giriş yapın.";
                    return RedirectToAction("login", "login");
                }

                // Model validation kontrolü
                if (ModelState.IsValid)
                {
                    Console.WriteLine($"3333");

                    model.musteriid = musteriid.Value;
                    model.durum = "Bekliyor";

                    // Veritabanına ekle
                    _context.Randevular.Add(model);
                    _context.SaveChanges();

                    TempData["Basari"] = "Randevunuz başarıyla kaydedildi!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        Console.WriteLine($"ModelState Error: {error.ErrorMessage}");
                    }

                    // Dropdown'ları yeniden doldur
                    ViewBag.Services = new SelectList(_context.Services.ToList(), "hizmetid", "hizmetadi");
                    ViewBag.Personel = _context.Personel
                        .Select(p => new SelectListItem
                        {
                            Value = p.personelid.ToString(),
                            Text = $"{p.personeladi} {p.personelsoyadi} - {p.pozisyon}"
                        }).ToList();
                }
            }
            catch (Exception ex)
            {
                // Konsola hata mesajını daha detaylı yazdır
                Console.WriteLine($"Hata: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");

                TempData["Hata"] = "Randevu kaydedilirken bir hata oluştu. Lütfen tekrar deneyin.";
            }

            return View(model);
        }

    }
}
