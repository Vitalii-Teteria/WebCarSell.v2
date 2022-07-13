using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCarSell.Models;
using WEBCarSell.BusinessLogic.DTO;
using WEBCarSell.BusinessLogic.Interfaces;

namespace WebCarSell.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CreateModelController : Controller
    {
        private readonly ICarSellService _carSellService;
        private readonly ILogger<CreateModelController> _logger;
        private readonly IMapper _mapper;

        public CreateModelController(ILogger<CreateModelController> logger, ICarSellService carSellService, IMapper mapper)
        {
            _carSellService = carSellService;
            _logger = logger;
            _mapper = mapper;

        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> AddModel()
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
            var models = _mapper.Map<ModelDto>(model);
            await _carSellService.AddModel(models);
            return View(model);
        }

        //[HttpGet]
        //public async Task<IActionResult> List(string? name)
        //{

        //    //if (!string.IsNullOrEmpty(name))
        //    //{
        //    //    courses = courses.Where(s => s.Name == name);
        //    //}
        //    return View();
        //}
        //[HttpGet]
        //public async Task<ActionResult> EditModel(Guid? id)
        //{
        //    if (id != null)
        //    {
        //        var requestId = await _carSellService.GetModelById(id);
        //        var request = _mapper.Map<ModelDto, ModelView>(requestId);
        //        var modelRegion = await _carSellService.GetRegions();
        //        var modelBrand = await _carSellService.GetBrands();
        //        var modelBody = await _carSellService.GetBody();
        //        ViewBag.Region = new SelectList(modelRegion, "Id", "Name");
        //        ViewBag.Brand = new SelectList(modelBrand, "Id", "Name");
        //        ViewBag.Body = new SelectList(modelBody, "Id", "Name");
        //        return View(request);
        //    }
        //    return NotFound();
        //}
        //[HttpPost]
        //public async Task<ActionResult> EditModel(ModelView modelView)
        //{

        //    var models = _mapper.Map<ModelView, ModelDto>(modelView);
        //    await _carSellService.UpdateModel(models);
        //    return View();
        //}


    }
}
