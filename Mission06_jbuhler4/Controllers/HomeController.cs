using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission06_jbuhler4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_jbuhler4.Controllers
{
    public class HomeController : Controller
    {
        private MovieDatabaseContext _movieContext { get; set; }

        public HomeController(MovieDatabaseContext mdc)
        {
            _movieContext = mdc;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Form()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            var movie = new Movies();

            return View("Form", movie);
        }

        [HttpPost]
        public IActionResult Form(Movies m)
        {
            if(ModelState.IsValid)
            {

                _movieContext.Add(m);
                _movieContext.SaveChanges();
                return View("Thanks", m);
            } 
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();
                return View(m);
            }
            
        }

        [HttpGet]
        public IActionResult Collection()
        {
            var movies = _movieContext.Movies
                .Include(x=> x.Category)
                .ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            var movie = _movieContext.Movies.Single(x => x.MovieID == id);

            return View("Form", movie );
        }

        [HttpPost]
        public IActionResult Edit(Movies m)
        {
            _movieContext.Update(m);
            _movieContext.SaveChanges();
            return RedirectToAction("Collection");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _movieContext.Movies.Single(x => x.MovieID == id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Movies m)
        {
            _movieContext.Movies.Remove(m);
            _movieContext.SaveChanges();
            return RedirectToAction("Collection");
        }
    }
}
