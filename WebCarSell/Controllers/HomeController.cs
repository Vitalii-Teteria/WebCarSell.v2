using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WebCarSell.Models;
using WEBCarSell.BusinessLogic.DTO;
using WEBCarSell.BusinessLogic.Interfaces;

namespace WebCarSell.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarSellService _carSellService;
        private readonly IMapper _mapper;
        List<LoginModel> loginModels;
        List<RegisterModel> registerModels;
        CarModel carModels;
        public HomeController(ILogger<HomeController> logger, ICarSellService carSellService, IMapper mapper)
        {
            _carSellService = carSellService;
            _logger = logger;
            _mapper = mapper;
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
        public async Task<ActionResult<List<ModelView>>> Index()
        {
            var model = await _carSellService.GetModels();
            var models = new List<ModelView>();
            foreach (var modelcar in model) 
            {
                models.Add(_mapper.Map<ModelView>(modelcar));
            }
            
            return View(models);
        }
        [HttpGet]
        public  async Task<ActionResult<List<RegionModelView>>> AddModel() 
        {
            var models = await _carSellService.GetRegions();
            var regions = new List<RegionModelView>();
            foreach (var region in models) 
            {
                regions.Add(_mapper.Map<RegionModelView>(region));
            }
            //ViewBag.AddInfo = new SelectList(await _carSellService.GetModels(), "BrandId", "BodyId", "RegionId");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddModel(ModelView model) 
        {

            var models =_mapper.Map<ModelDto>(model);
            await _carSellService.AddModel(models);
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> GetModelById(Guid? id) 
        {
            var result = await _carSellService.GetModelById(id);
            return result==null? NotFound() : View(result);
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}