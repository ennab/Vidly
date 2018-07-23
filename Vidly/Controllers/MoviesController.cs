﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        public ViewResult Index()
        {
            var movies = GetMovies();

            return View(movies);
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
        public ActionResult Edit(string sortBy, int? pageIndex = 0)
        {
            //http://localhost:50874/Movies/edit/1
            //http://localhost:50874/Movies/edit?id=1

            if (!pageIndex.HasValue) pageIndex = 0;
            if (String.IsNullOrWhiteSpace(sortBy)) sortBy = "Name";

            return Content(String.Format("pageIndex={0} sortBy={1}", pageIndex, sortBy));
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