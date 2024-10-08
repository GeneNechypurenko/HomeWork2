﻿using HomeWork2.Models;
using HomeWork2.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeWork2.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IWebHostEnvironment _environment;

        public MoviesController(ApplicationContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index() => View(await _context.Movies.ToListAsync());

        public async Task<IActionResult> Details(int id)
        {
            var selectedItem = await _context.Movies.FirstOrDefaultAsync(i => i.Id == id);
            if (selectedItem == null) { return NotFound(); }
            return View(selectedItem);
        }

        public IActionResult Add() => View();

        [HttpPost]
        [RequestSizeLimit(1000000000)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Movie movie, IFormFile poster)
        {
            ModelState.Remove("poster");

            if (ModelState.IsValid)
            {
                if (poster is not null && poster.Length > 0)
                {
                    string path = "/images/" + poster.FileName;

                    using (var fs = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                    {
                        await poster.CopyToAsync(fs);
                    }
                    movie.PosterUrl = path;
                }
                else
                {
                    movie.PosterUrl = "/background/default-poster.jpg";
                }
                await _context.AddAsync(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public async Task<IActionResult> Delete(int id) => View(await _context.Movies.FindAsync(id));

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id) => View(await _context.Movies.FindAsync(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Movie movie, IFormFile poster)
        {
            ModelState.Remove("poster");

            if (ModelState.IsValid)
            {
                if (poster is not null && poster.Length > 0)
                {
                    string path = "/images/" + poster.FileName;

                    using (var fs = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                    {
                        await poster.CopyToAsync(fs);
                    }
                    movie.PosterUrl = path;
                }
                else
                {
                    movie.PosterUrl = _context.Movies.Where(m => m.Id == id).Select(m => m.PosterUrl).FirstOrDefault();
                }
                _context.Update(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }
    }
}