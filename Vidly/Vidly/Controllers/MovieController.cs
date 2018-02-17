using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //
        // GET: /Movie/
        public ActionResult Index()
        {
            var movie = _context.Movie.Include(x => x.Genre).ToList();

            if (User.IsInRole(UserRoles.CanManageMovies))
            {
                return View("Index", movie);
            }

            return View("IndexGuest", movie);
        }

        public ActionResult Details(int Id)
        {
            var movie = _context.Movie.Include(x => x.Genre).SingleOrDefault(x => x.Id == Id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [Authorize(Roles = UserRoles.CanManageMovies)]
        public ActionResult Create()
        {
            var genre = _context.Genre.ToList();

            var movieViewModel = new MovieViewModel
            {
                Genre = genre,
                Movie = new Movie()
            };

            return View("MovieForm", movieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieVieModel = new MovieViewModel
                {
                    Movie = movie,
                    Genre = _context.Genre.ToList()
                };

                return View("MovieForm", movieVieModel);

            }

            if (movie.Id == 0)
            {
                movie.CreateDate = DateTime.Now;
                _context.Movie.Add(movie);
            }
            else
            {
                var updatemovie = _context.Movie.Single(x => x.Id == movie.Id);

                updatemovie.MovieName = movie.MovieName;
                updatemovie.ReleaseDate = movie.ReleaseDate;
                updatemovie.NumberInStocks = movie.NumberInStocks;
                updatemovie.GenreId = movie.GenreId;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movie.Single(x => x.Id == id);
            var genre = _context.Genre.ToList();

            var movieViewModel = new MovieViewModel
            {
                Movie = movie,
                Genre = genre

            };

            return View("MovieForm", movieViewModel);
        }
    }
}