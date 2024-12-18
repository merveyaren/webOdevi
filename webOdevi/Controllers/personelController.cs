using Microsoft.AspNetCore.Mvc;
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

        // Listeleme (Read)
        public IActionResult Index()
        {
            var personeller = _context.Personel.ToList();
            return View(personeller);
        }

        // Yeni Personel Ekleme (Create)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(personel personel)
        {
            if (ModelState.IsValid)
            {
                _context.Personel.Add(personel);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(personel);
        }

        // Güncelleme (Update)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var personel = _context.Personel.Find(id);
            if (personel == null)
            {
                return NotFound();
            }
            return View(personel);
        }

        [HttpPost]
        public IActionResult Edit(personel personel)
        {
            if (ModelState.IsValid)
            {
                _context.Personel.Update(personel);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(personel);
        }

        // Silme (Delete)
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var personel = _context.Personel.Find(id);
            if (personel == null)
            {
                return NotFound();
            }
            return View(personel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var personel = _context.Personel.Find(id);
            _context.Personel.Remove(personel);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
