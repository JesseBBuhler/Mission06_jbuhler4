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
            return View();
        }

        [HttpPost]
        public IActionResult Form(Movies m)
        {
            _movieContext.Add(m);
            _movieContext.SaveChanges();
            return View("Thanks", m);
        }

        [HttpGet]
        public IActionResult Collection()
        {
            var movies = _movieContext.Movies
                .Include(x=> x.Category)
                .ToList();
            return View(movies);
        }
    }
}
