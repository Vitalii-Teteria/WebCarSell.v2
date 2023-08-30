using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCarSell.BusinessLogic.DTO;
using WebCarSell.BusinessLogic.Interfaces;
using WebCarSell.Models;
using WEBCarSell.BusinessLogic.DTO;
using WEBCarSell.BusinessLogic.Interfaces;

namespace WebCarSell.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CreateModelController : Controller
    {
        private readonly ICarSellService _carSellService;
        private readonly ICreateModelService _createModelService;
        private readonly ILogger<CreateModelController> _logger;
        private readonly IMapper _mapper;

        public CreateModelController(ILogger<CreateModelController> logger, ICarSellService carSellService, IMapper mapper, ICreateModelService createModelService)
        {
            _carSellService = carSellService;
            _logger = logger;
            _mapper = mapper;
            _createModelService = createModelService;
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult> AddModel()
        {
            var modelRegion = await _createModelService.GetRegions();
            var modelBrand = await _createModelService.GetBrands();
            var modelBody = await _createModelService.GetBody();
            var modelCategory = await _createModelService.GetCategories();
            var modelModification = await _createModelService.GetModifications();
            ViewBag.Region = new SelectList(modelRegion, "Id", "Name");
            ViewBag.Brand = new SelectList(modelBrand, "Id", "Name");
            ViewBag.Body = new SelectList(modelBody, "Id", "Name");
            ViewBag.Category = new SelectList(modelCategory, "Id", "Name");
            ViewBag.Modification = new SelectList(modelModification, "Id", "Name");
            return View();
        }     
        

        [HttpPost]
        public async Task<IActionResult> AddModel(ModelView model)
        {
            var id = await _createModelService.GetIdUser(User.Identity.Name);
            model.UserId = id;
            var models = _mapper.Map<ModelDto>(model);
            //if (model.Picture != null)
            //{
            //    byte[] picture = null;
            //    using (var binaryReader = new BinaryReader(model.Picture.OpenReadStream()))
            //    {
            //        picture = binaryReader.ReadBytes((int)model.Picture.Length);
            //    }
            //    // установка массива байтов
            //    models.Picture = picture;

            //}
            await _createModelService.AddModel(models);
            //return View(model);
            return RedirectToAction("Index", "Home");
        }

        //[HttpGet]
        //public async Task<ActionResult> AddModelModification()
        //{
        //   return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddModelModification(ModelModificationsView model)
        //{
        //    var id = await _createModelService.GetIdUser(User.Identity.Name);
        //    model.ModelId = id;
        //    var modifications = _mapper.Map<ModelModificationsDto>(model);
        //    await _createModelService.AddModelModifications(modifications);
        //    return RedirectToAction("Index", "Home");
        //}

        [HttpGet]
        public async Task<ActionResult> AddCustomModification()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomModification(ModificationsView modificationsModel)
        {
            var modifications = _mapper.Map<ModificationsDto>(modificationsModel);
            await _carSellService.AddModification(modifications);
            return RedirectToAction("AddModel","CreateModel");
        }

        [HttpGet]
        public async Task<ActionResult> MyModelsList() 
        {
            var id = await _createModelService.GetIdUser(User.Identity.Name);
            var request = await _createModelService.GetModelsByIdUser(id);
            var mymodels = _mapper.Map<List<ModelView>>(request);
            ListModelView listModelView = new ListModelView(
                mymodels
                ); 
            return View(listModelView);
        }
        [HttpGet]
        public async Task<IActionResult> CalculateModifications(ModelModificationsSelectList model) 
        {
           
            var modelModification = await _createModelService.GetModifications();
            List<ModelModifications> model1 = new List<ModelModifications>();
            foreach(var item in modelModification) 
            {

                model1.Add(_mapper.Map<ModelModifications>(item));
            }
            ModelModificationsSelectList modifications = new ModelModificationsSelectList(model1);
            return View(modifications);
        }

        [AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ModelsList(string name, string? filtration) 
        {
            var model = _mapper.Map<IEnumerable<ModelView>>( await _createModelService.GetModels());
            IQueryable<ModelView> modelViews = model.AsQueryable<ModelView>();
            modelViews.Include(c => c.Name);
            switch (name) 
            {
                case "Name_Asc":
                    modelViews = modelViews.OrderBy(c => c.Name);
                    break;
                case "Name_Desc":
                    modelViews = modelViews.OrderByDescending(c => c.Name);
                    break;
                case "Mileage_Asc":
                    modelViews = modelViews.OrderBy(c => c.Mileage);
                    break;
                case "Mileage_Desc":
                    modelViews = modelViews.OrderByDescending(c => c.Mileage);
                    break;
                case "EngineVolume_Asc":
                    modelViews = modelViews.OrderBy(c => c.Engine_Volume);
                    break;
                case "EngineVolume_Desc":
                    modelViews = modelViews.OrderByDescending(c => c.Engine_Volume);
                    break;
                case "Price_Asc":
                    modelViews = modelViews.OrderBy(c => c.Price);
                    break;
                case "Price_Desc":
                    modelViews = modelViews.OrderByDescending(c => c.Price);
                    break;
                case "Drive_Asc":
                    modelViews = modelViews.OrderBy(c => c.Drive);
                    break;
                case "Drive_Desc":
                    modelViews = modelViews.OrderByDescending(c => c.Drive);
                    break;
                case "Transmission_Asc":
                    modelViews = modelViews.OrderBy(c => c.Transmission);
                    break;
                case "Transmission_Desc":
                    modelViews = modelViews.OrderByDescending(c => c.Transmission);
                    break;
            }
            if (!String.IsNullOrEmpty(filtration)) 
            {
                modelViews = modelViews.Where(s=>s.Name!.Contains(filtration));
            }

            ModelsListModel modelView = new ModelsListModel
                (
                    modelViews,
                    filtration=filtration
                );
            return View(modelView);

        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> EditModel(Guid? id)
        {       
            if (id != null)
            {
                var modelRegion = await _createModelService.GetRegions();
                var modelBrand = await _createModelService.GetBrands();
                var modelBody = await _createModelService.GetBody();
                var modelCategory = await _createModelService.GetCategories();
                var modelModification = await _createModelService.GetModifications();
                ViewBag.Region = new SelectList(modelRegion, "Id", "Name");
                ViewBag.Brand = new SelectList(modelBrand, "Id", "Name");
                ViewBag.Body = new SelectList(modelBody, "Id", "Name");
                ViewBag.Category = new SelectList(modelCategory, "Id", "Name");
                ViewBag.Modification = new SelectList(modelModification, "Id", "Name");
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
            return RedirectToAction("MyModelsList","CreateModel");
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
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteModel(Guid? id) 
        {
            if (id != null) 
            {
                var modelRegion = await _createModelService.GetRegions();
                var modelBrand = await _createModelService.GetBrands();
                var modelBody = await _createModelService.GetBody();
                var modelCategory = await _createModelService.GetCategories();
                var modelModification = await _createModelService.GetModifications();
                ViewBag.Region = new SelectList(modelRegion, "Id", "Name");
                ViewBag.Brand = new SelectList(modelBrand, "Id", "Name");
                ViewBag.Body = new SelectList(modelBody, "Id", "Name");
                ViewBag.Category = new SelectList(modelCategory, "Id", "Name");
                ViewBag.Modification = new SelectList(modelModification, "Id", "Name");
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
            return RedirectToAction("MyModelsList", "CreateModel");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteModelByAdmin(Guid? id)
        {
            if (id != null)
            {
                var modelRegion = await _createModelService.GetRegions();
                var modelBrand = await _createModelService.GetBrands();
                var modelBody = await _createModelService.GetBody();
                var modelCategory = await _createModelService.GetCategories();
                var modelModification = await _createModelService.GetModifications();
                ViewBag.Region = new SelectList(modelRegion, "Id", "Name");
                ViewBag.Brand = new SelectList(modelBrand, "Id", "Name");
                ViewBag.Body = new SelectList(modelBody, "Id", "Name");
                ViewBag.Category = new SelectList(modelCategory, "Id", "Name");
                ViewBag.Modification = new SelectList(modelModification, "Id", "Name");
                var request = await _carSellService.GetModelById(id);
                var model = _mapper.Map<ModelView>(request);
                if (request != null) return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteModelByAdmin(ModelView modelView)
        {
            var models = _mapper.Map<ModelDto>(modelView);
            await _carSellService.DeleteModel(models);
            return RedirectToAction("MyModelsList", "CreateModel");
        }
    }
}
