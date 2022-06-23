using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebCarSell.Models;

namespace WebCarSell.Controllers
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
        [HttpGet]
        public IActionResult Test()
        {
            return View();
        }
        [HttpPost]
        public string Test(int id, string name) 
        {
            return $"{id}----{name}";
        }

        public IActionResult AddCarPage() 
        {
            return View();
        }
        public IActionResult LoginPage()
        {
            return View();
        }
        public IActionResult Regpage()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}