using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using joel_hilton_film_collection.Models;

namespace joel_hilton_film_collection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Podcast()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieSubmission()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieSubmission(MovieSubmissionResponse movieResponse)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                MovieStorage.AddMovie(movieResponse);
                return View("Confirmation", movieResponse);
            }
        }
        public IActionResult MoviesList()
        {
            return View(MovieStorage.Movies);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
