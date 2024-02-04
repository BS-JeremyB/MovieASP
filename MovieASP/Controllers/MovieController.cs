using Microsoft.AspNetCore.Mvc;
using MovieASP.Data;

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
    }
}
