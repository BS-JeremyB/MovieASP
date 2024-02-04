using Microsoft.AspNetCore.Mvc;

namespace MovieASP.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
