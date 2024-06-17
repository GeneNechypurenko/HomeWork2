using HomeWork2.Models;
using HomeWork2.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeWork2.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationContext _context;
        private IWebHostEnvironment _environment;
        private string _path;

        public MoviesController(ApplicationContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
            _path = _environment.WebRootPath + "/images/";
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

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(1000000000)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Movie movie, IFormFile poster)
        {
            if (ModelState.IsValid && poster is not null && poster.Length > 0)
            {
                using (var fs = new FileStream(_path + poster, FileMode.Create))
                {
                    await poster.CopyToAsync(fs);
                };

                movie.PosterUrl = _path + poster.FileName;

                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }
    }
}
