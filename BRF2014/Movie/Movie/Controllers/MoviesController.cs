using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using Movie.Models;

namespace Movie.Controllers
{
    public class MoviesController : Controller
    {

        static List<MovieViewModel> _movies = new List<MovieViewModel>{
            new MovieViewModel{Id=1, Title = "Gone Girl", Director = "David Fincher"}, 
            new MovieViewModel{Id=2, Title = "Jaws", Director = "Steven Speilberg"}
        };
        // GET: Movies
        public ActionResult Index()
        {
            string @class = "fred";
            return View(_movies);
        }

        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var movie = _movies[id.Value - 1];
            return View(movie);
        }

        public ActionResult New()
        {
            User u = new User {Name = "Fred"};
            return View(new CreateMovieViewModel{Director = "Alice Smith", ContactMe = "kevinj@develop.com", User = u});
        }

        [HttpPost]
        public ActionResult Create(CreateMovieViewModel movie)
        {
            if (ModelState.IsValid)
            {
                _movies.Add(new MovieViewModel { Title = movie.Title, Director = movie.Director, Id = _movies.Count });
                return RedirectToAction("Index");
            }
            else
            {
                return View("New");
            }
        }

        public ActionResult GetAsJson(int id)
        {
            return new JsonResult { Data = _movies[id], JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}