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
        //Added MovieSubmissionDbContext attribute to HomeController class and created context in constructor, so context can be used to interact w database in HomeController
        private MovieSubmissionDbContext context { get; set; }
        public HomeController(ILogger<HomeController> logger, MovieSubmissionDbContext con)
        {
            _logger = logger;
            context = con;
        }

        //Default home page
        public IActionResult Index()
        {
            return View();
        }
        //Take user to static Podcast page
        public IActionResult Podcast()
        {
            return View();
        }
        //Pull up new movie submission form
        [HttpGet]
        public IActionResult MovieSubmission()
        {
            return View();
        }
        //Add movie to the database after user submits form, take user to Confirmation page
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
                //below is the updated submission, which adds the movie to the SqlLite database
                context.Submissions.Add(movieResponse);
                context.SaveChanges();

                return View("Confirmation", movieResponse);
            }
        }
        public IActionResult MoviesList()
        {
            //Return MovieList() view with the movies from the database, rather than the MovieStorage class
            return View(context.Submissions);
        }

        //Get the information from the movie to edit to populate the form, and send user the form to edit the movie
        [HttpPost]
        public IActionResult EditSubmissionForm(int editId)
        {
            MovieSubmissionResponse movieToEdit = context.Submissions.FirstOrDefault(s => s.SubmissionId == editId);
            ViewBag.movieToEdit = movieToEdit;
            return View("EditSubmissionForm");
        }

        //Edit the database record and return the newly-edited movie list to the user
        [HttpPost]
        public IActionResult Edit(MovieSubmissionResponse movieWithEdits)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.movieToEdit = movieWithEdits; //this might cause issues
                return View("EditSubmissionForm");
            }
            else
            {
                var movieToEdit = context.Submissions.FirstOrDefault(s => s.SubmissionId == movieWithEdits.SubmissionId);
                movieToEdit.Category = movieWithEdits.Category;
                movieToEdit.Title = movieWithEdits.Title;
                movieToEdit.Year = movieWithEdits.Year;
                movieToEdit.Director = movieWithEdits.Director;
                movieToEdit.Rating = movieWithEdits.Rating;
                movieToEdit.Edited = movieWithEdits.Edited;
                movieToEdit.LentTo = movieWithEdits.LentTo;
                movieToEdit.Notes = movieWithEdits.Notes;
                context.SaveChanges();
                return View("MoviesList", context.Submissions);
            }
            
        }

        //Delete desired record from the database and return movie list to the user
        [HttpPost]
        public IActionResult Delete(int deletionId)
        {
            context.Remove(context.Submissions.FirstOrDefault(s => s.SubmissionId == deletionId));
            context.SaveChanges();
            return View("MoviesList", context.Submissions);
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
