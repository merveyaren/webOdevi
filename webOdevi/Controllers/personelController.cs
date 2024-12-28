using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using webOdevi.Models;

namespace webOdevi.Controllers
{

    public class personelController : Controller
	{
		private readonly ApplicationDbContext _context;

		public personelController(ApplicationDbContext context)
		{
			_context = context;
		}
        public IActionResult Admin()
        {
            ViewData["IsAdmin"] = true; // Admin kontrol değişkeni
            return View();
        }
        // Personel Listeleme
        public IActionResult PersonelListele()
		{
			var personel = _context.Personel.ToList(); // Veritabanından tüm personeli çeker.
			return View(personel);
		}

		// Yeni Personel Ekleme Sayfası
		public IActionResult PersonelEkle()
		{
			return View(new personel());
		}

		// Yeni Personel Kaydetme İşlemi
		[HttpPost]
		public IActionResult PersonelEkle(personel model)
		{
			if (ModelState.IsValid)
			{
				var personel = new personel
				{
					personeladi = model.personeladi,
					personelsoyadi = model.personelsoyadi,
					pozisyon = model.pozisyon,
					personeltelefon = model.personeltelefon,
					personeleposta = model.personeleposta,
				};

				_context.Personel.Add(personel);
				_context.SaveChanges();

				TempData["Mesaj"] = "Yeni personel başarıyla eklendi.";
				return RedirectToAction("PersonelListele");
			}

			return View(model);
		}

		// Personel Güncelleme Sayfası
		public IActionResult PersonelGuncelle(int id)
		{
			var personel = _context.Personel.Find(id);
			if (personel == null)
			{
				TempData["Mesaj"] = "Personel bulunamadı.";
				return RedirectToAction("PersonelListele");
			}

			return View(personel);
		}

		// Güncelleme İşlemi
		[HttpPost]
		public IActionResult PersonelGuncelle(personel model)
		{
			if (ModelState.IsValid)
			{
				var guncellenecek = _context.Personel.Find(model.personelid);
				if (guncellenecek != null)
				{
					guncellenecek.personeladi = model.personeladi;
					guncellenecek.personelsoyadi = model.personelsoyadi;
					guncellenecek.pozisyon = model.pozisyon;
					guncellenecek.personeltelefon = model.personeltelefon;
					guncellenecek.personeleposta = model.personeleposta;

					_context.Personel.Update(guncellenecek);
					_context.SaveChanges();

					TempData["Mesaj"] = "Personel başarıyla güncellendi.";
					return RedirectToAction("PersonelListele");
				}

				TempData["Mesaj"] = "Güncelleme sırasında bir hata oluştu.";
			}

			return View(model);
		}

		// Silme İşlemi
		[HttpPost]
		public IActionResult SilPersonel(int id)
		{
			var silinecek = _context.Personel.Find(id);
			if (silinecek != null)
			{
				_context.Personel.Remove(silinecek);
				_context.SaveChanges();

				TempData["Mesaj"] = "Personel başarıyla silindi.";
			}
			else
			{
				TempData["Mesaj"] = "Personel bulunamadı.";
			}

			return RedirectToAction("PersonelListele");
		}

        public IActionResult PersonelVerimTablosu()
        {
            var bugun = DateTime.Today;

            var verimlilik = _context.Randevular
                .Where(r => r.randevutarihi.Value.Date == bugun) // Bugün için olan randevular
                .GroupBy(r => r.personelid)
                .Select(g => new
                {
                    PersonelAdi = g.FirstOrDefault().Personel.personeladi,
                    PersonelSoyadi = g.FirstOrDefault().Personel.personelsoyadi,
                    RandevuSayisi = g.Count(), // Randevu sayısı
                    ToplamKazanc = g.Sum(r => r.Hizmet.fiyat), // Hizmetlerin toplam fiyatı
                    ToplamSure = g.Sum(r => r.Hizmet.sure) // Hizmetlerin toplam süresi
                })
                .ToList();

            return View(verimlilik);
        }



    }
}
