using HomeWork2.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeWork2.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationContext _context;

        public MoviesController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var selectedItem = await _context.Movies.FirstOrDefaultAsync(i => i.Id == id);
            if (selectedItem == null) { return NotFound(); }
            return View(selectedItem);
        }
    }
}
