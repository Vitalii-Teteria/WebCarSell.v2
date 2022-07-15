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

        [AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> ModelsList() 
        {
            var model = await _carSellService.GetModels();
            var models = new List<ModelView>();
            foreach (var item in model) 
            {
                models.Add(_mapper.Map<ModelView>(item));
            }

            ModelsListModel modelView = new ModelsListModel
                (
                    models
                );
            return View(modelView);

        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> EditModel(Guid? id)
        {
            if (id != null)
            {
                var requestId = await _carSellService.GetModelById(id);
                var model = _mapper.Map<ModelView>(requestId);
                if(requestId!=null) return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditModel(ModelView modelView)
        {
            var models =_mapper.Map<ModelDto>(modelView);
            await _carSellService.UpdateModel(models);
            return RedirectToAction("ModelsList","CreateModel");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> ModelPage()
        {
            return View();
        }

    }
}
