using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCarSell.Models;
using WebCarSell.Other;
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
        public async Task<IActionResult> ModelsList(string? name,SortState sortOrder = SortState.NameAsc) 
        {
            var model = await _carSellService.GetModels();
            var models = new List<ModelView>();
            foreach (var item in model) 
            {
                models.Add(_mapper.Map<ModelView>(item));
            }
            IQueryable<ModelView> query = models.AsQueryable();
            query = sortOrder switch
            {
                SortState.NameAsc => query.OrderBy(c => c.Name),
                SortState.NameDesc => query.OrderByDescending(c => c.Name),
                SortState.MileageAsc => query.OrderBy(c => c.Mileage),
                SortState.MileageDesc => query.OrderByDescending(c => c.Mileage)
            };
            if (!string.IsNullOrEmpty(name))
            {
                query.Where(s => s.Name!.Contains(name));
            }

            ModelsListModel modelView = new ModelsListModel
                (
                    models,
                    new SortViewModel(sortOrder),
                    new FilterViewModel(models,name)
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
        public async Task<IActionResult> ModelPage(Guid? id)
        {
            var request = await _carSellService.GetModelById(id);
            var model = _mapper.Map<ModelView>(request);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteModel(Guid? id) 
        {
            if (id != null) 
            {
                var request = await _carSellService.GetModelById(id);
                var model = _mapper.Map<ModelView>(request);
                if (request != null) return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteModel(ModelView modelView)
        {
            var models = _mapper.Map<ModelDto>(modelView);
            await _carSellService.DeleteModel(models);
            return RedirectToAction("ModelsList", "CreateModel");
        }
    }
}
