using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebCarSell.Models;

namespace WebCarSell.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        List<LoginModel> loginModels;
        List<RegisterModel> registerModels;
        CarModel carModels;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            loginModels = new List<LoginModel>() 
            {
                new LoginModel(1,"asd@gmail.com","adcdsg1f"),
                new LoginModel(2,"asd1@gmail.com","adcdsg3f"),
            };
            registerModels = new List<RegisterModel>();
         
            carModels = new CarModel()
            {
                Id=1,
                Name="BMW",
                Year=2021,
                Mileage=2123,
                Engine_Volume=4,
                Color="Black",
                Transmition="Automatic"
            };
        }
        [HttpGet]
        public IActionResult Index()
        {        
            return View(carModels);
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
        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginPage(LoginModel? model)
        {
            if (model != null) 
            {
                loginModels.Add(model);
                return Ok($"Email: {model.Email}---- Password:{model.Password}");
            }
            else
                return NotFound();
        }
        [HttpGet]
        public IActionResult Regpage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegPage(RegisterModel? model) 
        {
            if (model != null)
            {
                registerModels.Add(model);
                return Ok($"Email:{model.Email}---Password:{model.Password}----Name:{model.Name}---{model.SName}");
            }
            else
                return NotFound();
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