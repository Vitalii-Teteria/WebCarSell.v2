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

        public HomeController(ILogger<HomeController> logger, ICarSellService carSellService, IMapper mapper)
        {
            _carSellService = carSellService;
            _logger = logger;
            _mapper = mapper;
         
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
        public  async Task<ActionResult> AddModel() 
        {
            var modelRegion = await _carSellService.GetRegions();
            var modelBrand = await _carSellService.GetBrands();
            var modelBody = await _carSellService.GetBody();
            ViewBag.Region = new SelectList(modelRegion, "Id", "Name");
            ViewBag.Brand = new SelectList(modelBrand, "Id", "Name");
            ViewBag.Body = new SelectList(modelBody, "Id", "Name");
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddModel(ModelView model) 
        {

            var models =_mapper.Map<ModelDto>(model);
            await _carSellService.AddModel(models);
            return View(model);
        }

        //[HttpGet]
        //public async Task<ActionResult> GetModelById(Guid? id) 
        //{
        //    var result = await _carSellService.GetModelById(id);
        //    return result==null? NotFound() : View(result);
        //}

        [HttpGet]
        public IActionResult LoginPage()
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