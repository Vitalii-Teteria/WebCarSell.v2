using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebCarSell.Models;
using WEBCarSell.BusinessLogic.DTO;
using WEBCarSell.BusinessLogic.Interfaces;

namespace WebCarSell.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly ICarSellService _carSellService;
        private readonly ILogger<AdminController> _logger;
        private readonly IMapper _mapper;

        public AdminController(ILogger<AdminController> logger, ICarSellService carSellService, IMapper mapper)
        {
            _carSellService = carSellService;
            _logger = logger;
            _mapper = mapper;
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
    }
}
