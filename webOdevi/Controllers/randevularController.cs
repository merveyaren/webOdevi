using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            var randevular = _context.Randevular.ToList();
            return View(randevular);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(randevular randevu)
        {
            if (ModelState.IsValid)
            {
                _context.Randevular.Add(randevu);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(randevu);
        }

        public IActionResult Edit(int id)
        {
            var randevu = _context.Randevular.Find(id);
            if (randevu == null)
            {
                return NotFound();
            }
            return View(randevu);
        }

        [HttpPost]
        public IActionResult Edit(randevular randevu)
        {
            if (ModelState.IsValid)
            {
                _context.Randevular.Update(randevu);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(randevu);
        }

        public IActionResult Delete(int id)
        {
            var randevu = _context.Randevular.Find(id);
            if (randevu == null)
            {
                return NotFound();
            }

            _context.Randevular.Remove(randevu);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
