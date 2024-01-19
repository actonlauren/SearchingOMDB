using Microsoft.AspNetCore.Mvc;
using SearchingOMDB.Models;
using System.Diagnostics;

namespace SearchingOMDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult MovieSearch()
        {
               return View();
        }

        [HttpGet]
        public IActionResult MovieSearchForm(string userTitle)
        {
            return View(MovieSearch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MovieSearchResults()
        {
            return View(MovieSearch);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}