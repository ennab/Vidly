using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            //var movies = GetMovies();
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }
        public ActionResult Details(int id)
        {
            //var movies = GetMovies();
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
           {
               new Movie { Id = 1, Name = "Shrek" },
               new Movie { Id = 2, Name = "Wall-e" }
           };
        }

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shark" };
            //return View(movie);
            //return Content("Hello World");// This will return Text
            //return HttpNotFound(); //404 Error
            //return RedirectToAction("Index", "Home", new { page = 1, sortby = "name" });// to redirect to an action with parameters



            var customers = new List<Customer>
            {
                new Customer { Name="custmer 1"},
                new Customer { Name="custmer 2"},
            };
            var viewModel = new RandomMovieViewModel() { Customers = customers, Movie = movie };

            return View(viewModel);

        }
        public ActionResult New()
        {
            var Genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel { Genres = Genres };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0) { _context.Movies.Add(movie); }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Edit(int id)//(string sortBy, int? pageIndex = 0)
        {
            //http://localhost:50874/Movies/edit/1
            //http://localhost:50874/Movies/edit?id=1

            //if (!pageIndex.HasValue) pageIndex = 0;
            //if (String.IsNullOrWhiteSpace(sortBy)) sortBy = "Name";

            //return Content(String.Format("pageIndex={0} sortBy={1}", pageIndex, sortBy));

            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null) { return HttpNotFound(); }

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);

        }
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int? year, byte? month)
        {

            //return Content(String.Format("Year={0} /Month={1}", year, month));
            var movie = new Movie() { Name = "Shark" };
            //ViewData["movie"] = movie;

            var customers = new List<Customer>
            {
                new Customer { Name="custmer 1"},
                new Customer { Name="custmer 2"},
            };
            var viewModel = new RandomMovieViewModel() { Customers = customers, Movie = movie };

            return View(viewModel);
        }
    }
}