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
    }
}
