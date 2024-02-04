using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieASP.Data;
using MovieASP.Models;

namespace MovieASP.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieData _data;

        public MovieController(MovieData data)
        {
            _data = data;
        }

        
        public IActionResult Index()
        {
            return View(_data.GetMovies());
        }

     
        public IActionResult Details(int id)
        {
            Movie movie = _data.GetMovieById(id);

            return View(movie);
        }

        
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _data.AddMovie(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

   
        public IActionResult Edit(int id)
        {
            Movie movie = _data.GetMovieById(id);

            return View(movie);
        }


        [HttpPost]
        
        public IActionResult Edit(Movie movie)
        {

            if (ModelState.IsValid)
            {
                 _data.UpdateMovie(movie);
               
                return RedirectToAction("Index");
            }
            return View(movie);
        }


        public IActionResult Delete(int id)
        {
            Movie movie = _data.GetMovieById(id);

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        
        public IActionResult DeleteConfirmed(int id)
        {
            _data.DeleteMovie(id);
            return RedirectToAction("Index");
        }
    }
}
