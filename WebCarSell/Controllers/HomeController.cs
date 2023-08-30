using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebCarSell.BusinessLogic.Interfaces;
using WebCarSell.Models;
using WEBCarSell.BusinessLogic.DTO;
using WEBCarSell.BusinessLogic.Interfaces;

namespace WebCarSell.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarSellService _carSellService;
        private readonly ICreateModelService _createModelService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, ICarSellService carSellService, IMapper mapper, ICreateModelService createModelService)
        {
            _carSellService = carSellService;
            _logger = logger;
            _mapper = mapper;
            _createModelService = createModelService;
        }

        [HttpGet]
        public async Task<ActionResult> Index(int page=1)
        {
            int pageSize = 6;
            var model = await _createModelService.GetModels();           
            var models = new List<ModelView>();
            foreach (var modelcar in model) 
            {
                models.Add(_mapper.Map<ModelView>(modelcar));
            }
            var count =  models.Count();
            var item =  models.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            OperationDataViewModel modelView = new OperationDataViewModel
            (
                new PageViewModel(count, page, pageSize),
                item
            );
            return View(modelView);
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