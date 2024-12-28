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

       
    }
}

