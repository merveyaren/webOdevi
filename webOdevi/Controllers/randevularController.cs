using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using webOdevi.Models;

public class randevularController : Controller
{
    private readonly ApplicationDbContext _context;

    public randevularController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult randevular()
    {
        ViewData["IsLoggedIn"] = HttpContext.Session.GetInt32("musteriid") != null;

        if (ViewData["IsLoggedIn"] == null || !(bool)ViewData["IsLoggedIn"])
        {
            return RedirectToAction("login", "login");
        }

        ViewBag.Services = new SelectList(_context.Services.ToList(), "hizmetid", "hizmetadi");
        ViewBag.Personel = new SelectList(_context.Personel.ToList(), "personelid", "personeladi", "personelsoyadi");

        return View(new randevular());
    }



    [HttpPost]
    public IActionResult randevularEkle(randevular model)
    {
        if (ModelState.IsValid)
        {
            var mevcutRandevular = _context.Randevular
                .Where(r => r.personelid == model.personelid &&
                            r.randevutarihi == model.randevutarihi &&
                            r.baslangicsaati < model.bitissaati &&
                            model.baslangicsaati < r.bitissaati)
                .ToList();

            if (mevcutRandevular.Any())
            {
                ModelState.AddModelError("", "Seçilen saatte personelin başka bir randevusu bulunmaktadır.");
            }
            else
            {
                model.durum = "Bekliyor"; // Varsayılan durum
                _context.Randevular.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Randevularim", "Musteri");
            }
        }

        ViewBag.Services = new SelectList(_context.Services.ToList(), "hizmetid", "hizmetadi");
        ViewBag.Personel = new SelectList(_context.Personel.ToList(), "personelid", "personeladi", "personelsoyadi");

        return View("randevular", model);
    }

    [HttpGet]
    public IActionResult Randevularim()
    {
        var musteriid = HttpContext.Session.GetInt32("musteriid");

        if (musteriid == null)
        {
            return RedirectToAction("login", "login");
        }

        var randevular = _context.Randevular
            .Include(r => r.Hizmet)
            .Include(r => r.Personel)
            .Where(r => r.musteriid == musteriid)
            .Select(r => new
            {
                r.randevuid,
                r.Hizmet.hizmetadi,
                r.Personel.personeladi,
                r.Personel.personelsoyadi,
                r.randevutarihi,
                r.baslangicsaati,
                r.bitissaati,
                r.durum
            })
            .ToList();

        return View(randevular);
    }
}
