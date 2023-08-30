using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCarSell.BusinessLogic.DTO;
using WebCarSell.BusinessLogic.Interfaces;
using WebCarSell.DataAccess.Entities;
using WebCarSell.DataAccess.Repositories;
using WEBCarSell.BusinessLogic.DTO;
using WEBCarSell.DataAccess.Repositories;

namespace WebCarSell.BusinessLogic.Services
{
    public class CreateModelService :ICreateModelService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly IModelRepository _modelRepository;
        public CreateModelService(IRepository repository, IMapper autoMapper, IModelRepository modelRepository)
        {
            _mapper = autoMapper;
            _repository = repository;
            _modelRepository = modelRepository;
        }
        public async Task<ModelDto> AddModel(ModelDto model) // rabotaet
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }

            var models = _mapper.Map<Model>(model);
            await _repository.Create(models);
            return _mapper.Map<ModelDto>(models);
        } 
        public async Task<ModelModificationsDto> AddModelModifications(ModelModificationsDto model) // rabotaet
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }

            var models = _mapper.Map<Model_Modifications>(model);
            await _repository.Create(models);
            return _mapper.Map<ModelModificationsDto>(models);
        }
        public async Task<IEnumerable<ModelDto>> GetModels() // rabotaet
        {
            var models = _mapper.Map<IEnumerable<ModelDto>>(await _repository.GetAll<Model>());
            return models;
        }
        public async Task<IEnumerable<RegionDto>> GetRegions()
        {
            var models = _mapper.Map<IEnumerable<RegionDto>>(await _repository.GetAll<Region>());
            return models;
        }
        public async Task<IEnumerable<BrandDto>> GetBrands()
        {
            var models = _mapper.Map<IEnumerable<BrandDto>>(await _repository.GetAll<Brand>());
            return models;
        }
        public async Task<IEnumerable<Car_bodyDto>> GetBody()
        {
            var models = _mapper.Map<IEnumerable<Car_bodyDto>>(await _repository.GetAll<Car_body>());
            return models;
        }
        public async Task<IEnumerable<SportsCategoryDto>> GetCategories()
        {
            var models = _mapper.Map<IEnumerable<SportsCategoryDto>>(await _repository.GetAll<SportsCategory>());
            return models;
        }
        public async Task<IEnumerable<ModificationsDto>> GetModifications()
        {
            var models = _mapper.Map<IEnumerable<ModificationsDto>>(await _repository.GetAll<Modifications>());
            return models;
        }
        public async Task<Guid> GetIdUser(string name) 
        {
            if (name == null) 
            {
                throw new ArgumentNullException(nameof(name),"name is empty");
            }
            var id = await _modelRepository.GetUserId(name);
            return id;
        }    
        public async Task<List<ModelDto>> GetModelsByIdUser (Guid id) 
        {
            var model = await _modelRepository.GetModelsByIdUser(id);
            var models = new List<ModelDto>();
            foreach (var modelcar in model)
            {
                models.Add(_mapper.Map<ModelDto>(modelcar));
            }
            return models;
        }
        public async Task<List<ModelModificationsDto>> GetModificationsByIdUser(Guid id) 
        {
            var modification = await _modelRepository.GetModificationsByIdUser(id);
            var modifications = new List<ModelModificationsDto>();
            foreach(var modelcar in modification) 
            {
                modifications.Add(_mapper.Map<ModelModificationsDto>(modelcar));
            }
            return modifications;
        }
        public async Task<int> GetPriceOfModificationByIdModification(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name), "name is empty");
            }
            var price = await _modelRepository.GetPriceOfModificationByIdModification(name);
            return price;
        }

    }
}
