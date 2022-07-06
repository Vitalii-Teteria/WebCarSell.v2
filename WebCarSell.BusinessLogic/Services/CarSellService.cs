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
        //public async Task<IEnumerable<ModelDto>> GetModelsList(Guid? id)
        //{
        //    var models = (await _repository.GetWhere<Model>(g => g.Id == id, include: g => g.Include(g => g.Name)));
        //    return models.Select(q => q.ToModelDto()).ToList();
        //}

        public async Task<ModelDto> GetModelById(Guid? id)
        {
            var result = await _repository.GetWhere<Model>(x => x.Id == id);
            return _mapper.Map<ModelDto>(result);
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
