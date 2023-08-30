using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCarSell.BusinessLogic.DTO;
using WebCarSell.BusinessLogic.Interfaces;
using WebCarSell.Models;
using WEBCarSell.BusinessLogic.DTO;
using WEBCarSell.BusinessLogic.Interfaces;

namespace WebCarSell.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ICarSellService _carSellService;
        private readonly ICreateModelService _createModelService;
        private readonly ILogger<AdminController> _logger;
        private readonly IMapper _mapper;

        public AdminController(ILogger<AdminController> logger, ICarSellService carSellService, IMapper mapper, ICreateModelService createModelService)
        {
            _carSellService = carSellService;
            _logger = logger;
            _mapper = mapper;
            _createModelService = createModelService;
        }

        [HttpGet]
        public IActionResult AdminPanel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand(BrandModelView brandModel) 
        {
            var brand = _mapper.Map<BrandDto>(brandModel);
            await _carSellService.AddBrand(brand);
            return View(brandModel);
        }

        [HttpGet]
        public IActionResult AddRegion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRegion(RegionModelView regionModel)
        {
            var region = _mapper.Map<RegionDto>(regionModel);
            await _carSellService.AddRegion(region);
            return View(regionModel);
        }

        [HttpGet]
        public IActionResult AddCarBody()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCarBody(Car_bodyViewModel carBodyModel)
        {
            var body = _mapper.Map<Car_bodyDto>(carBodyModel);
            await _carSellService.AddBody(body);
            return View(carBodyModel);
        }

        [HttpGet]
        public IActionResult AddCategory() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(SportsCategoryView sportsCategoryModel) 
        {
            var category = _mapper.Map<SportsCategoryDto>(sportsCategoryModel);
            await _carSellService.AddCategory(category);
            return View(sportsCategoryModel);
        }

        [HttpGet]
        public async Task<ActionResult> AddModification()
        {
            var categoryModification = await _createModelService.GetCategories();
            ViewBag.Category = new SelectList(categoryModification, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddModification(ModificationsView modificationsModel) 
        {
            var modifications = _mapper.Map<ModificationsDto>(modificationsModel);
            await _carSellService.AddModification(modifications);
            return View(modificationsModel);
        }

        public async Task<IActionResult> GrudBrand() 
        {
            var brand = await _carSellService.GetBrands();
            var brands = new List<BrandModelView>();
            foreach (var brandModel in brand) 
            {
                brands.Add(_mapper.Map<BrandModelView>(brandModel));
            }
            BrandList brandList = new BrandList(brands);
            return View(brandList);
        }

        [HttpGet]
        public async Task<IActionResult> EditBrand(Guid? id)
        {
            if (id != null)
            {
                var requestId = await _carSellService.GetBrandById(id);
                var model = _mapper.Map<BrandModelView>(requestId);
                if (requestId != null) return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditBrand(BrandModelView modelView)
        {
            var brand = _mapper.Map<BrandDto>(modelView);
            await _carSellService.UpdateBrand(brand);
            return RedirectToAction("GrudBrand", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBrand(Guid? id)
        {
            if (id != null)
            {
                var request = await _carSellService.GetBrandById(id);
                var model = _mapper.Map<BrandModelView>(request);
                if (request != null) return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBrand(BrandModelView modelView)
        {
            var models = _mapper.Map<BrandDto>(modelView);
            await _carSellService.DeleteBrand(models);
            return RedirectToAction("GrudBrand", "Admin");
        }

        public async Task<IActionResult> GrudRegion()
        {
            var region = await _carSellService.GetRegions();
            var regions = new List<RegionModelView>();
            foreach (var regionModel in region)
            {
                regions.Add(_mapper.Map<RegionModelView>(regionModel));
            }
            RegionList regionList = new RegionList(regions);
            return View(regionList);
        }

        [HttpGet]
        public async Task<IActionResult> EditRegion(Guid? id)
        {
            if (id != null)
            {
                var requestId = await _carSellService.GetRegionById(id);
                var model = _mapper.Map<RegionModelView>(requestId);
                if (requestId != null) return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditRegion(RegionModelView modelView)
        {
            var region = _mapper.Map<RegionDto>(modelView);
            await _carSellService.UpdateRegion(region);
            return RedirectToAction("GrudBrand", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRegion(Guid? id)
        {
            if (id != null)
            {
                var request = await _carSellService.GetRegionById(id);
                var model = _mapper.Map<RegionModelView>(request);
                if (request != null) return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRegion(RegionModelView modelView)
        {
            var region = _mapper.Map<RegionDto>(modelView);
            await _carSellService.DeleteRegion(region);
            return RedirectToAction("GrudBrand", "Admin");
        }
        public async Task<IActionResult> GrudCarBody()
        {
            var body = await _carSellService.GetBody();
            var bodies = new List<Car_bodyViewModel>();
            foreach (var bodyModel in body)
            {
                bodies.Add(_mapper.Map<Car_bodyViewModel>(bodyModel));
            }
            CarBodyList carList = new CarBodyList(bodies);
            return View(carList);
        }

        [HttpGet]
        public async Task<IActionResult> EditBody(Guid? id)
        {
            if (id != null)
            {
                var requestId = await _carSellService.GetBodyById(id);
                var model = _mapper.Map<Car_bodyViewModel>(requestId);
                if (requestId != null) return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditBody(Car_bodyViewModel modelView)
        {
            var body = _mapper.Map<Car_bodyDto>(modelView);
            await _carSellService.UpdateCarBody(body);
            return RedirectToAction("GrudBrand", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBody(Guid? id)
        {
            if (id != null)
            {
                var request = await _carSellService.GetBodyById(id);
                var model = _mapper.Map<Car_bodyViewModel>(request);
                if (request != null) return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBody(Car_bodyViewModel modelView)
        {
            var body = _mapper.Map<Car_bodyDto>(modelView);
            await _carSellService.DeleteBody(body);
            return RedirectToAction("GrudBrand", "Admin");
        }

        public async Task<IActionResult> CrudCategory()
        {
            var category = await _createModelService.GetCategories();
            var categories = new List<SportsCategoryView>();
            foreach (var categoryModel in category)
            {
                categories.Add(_mapper.Map<SportsCategoryView>(categoryModel));
            }
            CategoryList categotyList = new CategoryList(categories);
            return View(categotyList);
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(Guid? id)
        {
            if (id != null)
            {
                var requestId = await _carSellService.GetCategoryById(id);
                var model = _mapper.Map<SportsCategoryView>(requestId);
                if (requestId != null) return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(SportsCategoryView modelView)
        {
            var category = _mapper.Map<SportsCategoryDto>(modelView);
            await _carSellService.UpdateCategory(category);
            return RedirectToAction("CrudCategory", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(Guid? id)
        {
            if (id != null)
            {
                var request = await _carSellService.GetCategoryById(id);
                var model = _mapper.Map<SportsCategoryView>(request);
                if (request != null) return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(SportsCategoryView modelView)
        {
            var category = _mapper.Map<SportsCategoryDto>(modelView);
            await _carSellService.DeleteCategory(category);
            return RedirectToAction("CrudCategory", "Admin");
        }
        public async Task<IActionResult> CrudModification()
        {
            var modification = await _createModelService.GetModifications();
            var modifications = new List<ModificationsView>();
            foreach (var modificationModel in modification)
            {
                modifications.Add(_mapper.Map<ModificationsView>(modificationModel));
            }
            ModificationList modificationList = new ModificationList(modifications);
            return View(modificationList);
        }

        [HttpGet]
        public async Task<IActionResult> EditModification(Guid? id)
        {
            if (id != null)
            {
                var requestId = await _carSellService.GetModificationById(id);
                var model = _mapper.Map<ModificationsView>(requestId);
                if (requestId != null) return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditModification(ModificationsView modelView)
        {
            var modification = _mapper.Map<ModificationsDto>(modelView);
            await _carSellService.UpdateModification(modification);
            return RedirectToAction("CrudModification", "Admin");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteModification(Guid? id)
        {
            if (id != null)
            {
                var request = await _carSellService.GetModificationById(id);
                var model = _mapper.Map<ModificationsView>(request);
                if (request != null) return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteModifications(ModificationsView modelView)
        {
            var modification = _mapper.Map<ModificationsDto>(modelView);
            await _carSellService.DeleteModification(modification);
            return RedirectToAction("CrudModification", "Admin");
        }
    }
}
