using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieASP.DAL.Repositories;
using MovieASP.Data;
using MovieASP.Models;
using MovieASP.Models.Mappers;

namespace MovieASP.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _data;

        public MovieController(IMovieRepository data)
        {
            _data = data;
        }

        
        public IActionResult Index()
        {
            return View(_data.GetAllMovies().Map());
        }

     
        public IActionResult Details(int id)
        {
            Movie movie = _data.GetMovieById(id).Map();

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
                _data.AddMovie(movie.Map());
                return RedirectToAction("Index");
            }
            return View(movie);
        }

   
        public IActionResult Edit(int id)
        {
            Movie movie = _data.GetMovieById(id).Map();

            return View(movie);
        }


        [HttpPost]
        
        public IActionResult Edit(Movie movie)
        {

            if (ModelState.IsValid)
            {
                 _data.UpdateMovie(movie.Map());
               
                return RedirectToAction("Index");
            }
            return View(movie);
        }


        public IActionResult Delete(int id)
        {
            Movie movie = _data.GetMovieById(id).Map();

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
