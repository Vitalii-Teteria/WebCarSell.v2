using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBCarSell.BusinessLogic.DTO;
using WEBCarSell.BusinessLogic.Interfaces;
using WEBCarSell.DataAccess.Interfaces;
using WebCarSell.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using WEBCarSell.DataAccess.Repositories;
using WebCarSell.BusinessLogic.Extensions;
using AutoMapper;
using WebCarSell.BusinessLogic.DTO;

namespace WEBCarSell.BusinessLogic.Services
{
    public class CarSellService : ICarSellService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public CarSellService(IRepository repository, IMapper autoMapper)
        {
            _mapper = autoMapper;
            _repository = repository;
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
        public async Task<BrandDto> AddBrand(BrandDto model) 
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }

            var models = _mapper.Map<Brand>(model);
            await _repository.Create(models);
            return _mapper.Map<BrandDto>(models);
        }
        public async Task<RegionDto> AddRegion(RegionDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }

            var models = _mapper.Map<Region>(model);
            await _repository.Create(models);
            return _mapper.Map<RegionDto>(models);
        }
        public async Task<Car_bodyDto> AddBody(Car_bodyDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }

            var models = _mapper.Map<Car_body>(model);
            await _repository.Create(models);
            return _mapper.Map<Car_bodyDto>(models);
        }
        public async Task<SportsCategoryDto> AddCategory(SportsCategoryDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }

            var models = _mapper.Map<SportsCategory>(model);
            await _repository.Create(models);
            return _mapper.Map<SportsCategoryDto>(models);
        }
        public async Task<ModificationsDto> AddModification(ModificationsDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }

            var models = _mapper.Map<Modifications>(model);
            await _repository.Create(models);
            return _mapper.Map<ModificationsDto>(models);
        }
        public async Task UpdateModel(ModelDto model) 
        {
            var result = _mapper.Map<Model>(model);
            await _repository.Update(result);
        }
        public async Task UpdateBrand(BrandDto model)
        {
            var result = _mapper.Map<Brand>(model);
            await _repository.Update(result);
        }
        public async Task UpdateRegion(RegionDto model)
        {
            var result = _mapper.Map<Region>(model);
            await _repository.Update(result);
        }
        public async Task UpdateCarBody(Car_bodyDto model)
        {
            var result = _mapper.Map<Car_body>(model);
            await _repository.Update(result);
        }
        public async Task UpdateCategory(SportsCategoryDto model)
        {
            var result = _mapper.Map<SportsCategory>(model);
            await _repository.Update(result);
        }
        public async Task UpdateModification(ModificationsDto model)
        {
            var result = _mapper.Map<Modifications>(model);
            await _repository.Update(result);
        }
        public async Task<ModelDto> GetModelById(Guid? id)
        {
            var model = await _repository.GetById<Model>(id);
            return _mapper.Map<ModelDto>(model);
        }
        public async Task<BrandDto> GetBrandById(Guid? id)
        {
            var model = await _repository.GetById<Brand>(id);
            return _mapper.Map<BrandDto>(model);
        }
        public async Task<RegionDto> GetRegionById(Guid? id)
        {
            var model = await _repository.GetById<Region>(id);
            return _mapper.Map<RegionDto>(model);
        }
        public async Task<Car_bodyDto> GetBodyById(Guid? id)
        {
            var model = await _repository.GetById<Car_body>(id);
            return _mapper.Map<Car_bodyDto>(model);
        }
        public async Task<SportsCategoryDto> GetCategoryById(Guid? id)
        {
            var model = await _repository.GetById<SportsCategory>(id);
            return _mapper.Map<SportsCategoryDto>(model);
        }
        public async Task<ModificationsDto> GetModificationById(Guid? id)
        {
            var model = await _repository.GetById<Modifications>(id);
            return _mapper.Map<ModificationsDto>(model);
        }
        public async Task DeleteUser(UserDto user) 
        {
            var users = _mapper.Map<User>(user);
            await _repository.HardDelete(users);
        }
        public async Task DeleteModel(ModelDto model) 
        {
            var result = _mapper.Map<Model>(model);
            await _repository.HardDelete(result);
        }
        public async Task DeleteBrand(BrandDto model)
        {
            var result = _mapper.Map<Brand>(model);
            await _repository.HardDelete(result);
        }
        public async Task DeleteRegion(RegionDto model)
        {
            var result = _mapper.Map<Region>(model);
            await _repository.HardDelete(result);
        }
        public async Task DeleteBody(Car_bodyDto model)
        {
            var result = _mapper.Map<Car_body>(model);
            await _repository.HardDelete(result);
        }
        public async Task DeleteCategory(SportsCategoryDto model)
        {
            var result = _mapper.Map<SportsCategory>(model);
            await _repository.HardDelete(result);
        }
        public async Task DeleteModification(ModificationsDto model)
        {
            var result = _mapper.Map<Modifications>(model);
            await _repository.HardDelete(result);
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = _mapper.Map<IEnumerable<UserDto>>(await _repository.GetAll<UserDto>());
            return users;
        }

        public async Task<RegionDto> GetModelByRegion(Guid? id)
        {
            var result = await _repository.GetWhere<Model>(x => x.Id == id);
            return _mapper.Map<RegionDto>(result);
        }

        public async Task<bool> IfExist(Guid? carId)
        {
            return await _repository.IfExist<Model>(x => x.Id == carId);
        }
    }
}
