using Microsoft.AspNetCore.Mvc;
using webOdevi.Models;

namespace webOdevi.Controllers
{
    public class musterilerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public musterilerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var musteriler = _context.Musteriler.ToList();
            return View(musteriler);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(musteriler musteri)
        {
            if (ModelState.IsValid)
            {
                _context.Musteriler.Add(musteri);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(musteri);
        }

        public IActionResult Edit(int id)
        {
            var musteri = _context.Musteriler.Find(id);
            if (musteri == null)
            {
                return NotFound();
            }
            return View(musteri);
        }

        [HttpPost]
        public IActionResult Edit(musteriler musteri)
        {
            if (ModelState.IsValid)
            {
                _context.Musteriler.Update(musteri);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(musteri);
        }

        public IActionResult Delete(int id)
        {
            var musteri = _context.Musteriler.Find(id);
            if (musteri == null)
            {
                return NotFound();
            }

            _context.Musteriler.Remove(musteri);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

