using Microsoft.AspNetCore.Mvc;
using SearchingOMDB.Models;
using SearchingOMDB.Services;
using System.Diagnostics;

namespace SearchingOMDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MovieService MovieService;

        public HomeController(ILogger<HomeController> logger, MovieService movieService)
        {
            _logger = logger;
            MovieService = movieService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }       
        

        public IActionResult MovieSearch(MovieViewModel model)
        {
            return View(model);
        }

        [HttpGet]
        public IActionResult MovieSearchForm()
        {
            return View("MovieSearch");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  MovieSearchResults(string title)
        {
            var movieInfo = await MovieService.GetMovieInfo(title);            
            return View("MovieSearch", movieInfo);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}