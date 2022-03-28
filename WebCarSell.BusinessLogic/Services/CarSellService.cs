using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBCarSell.BusinessLogic.DTO;
using WEBCarSell.BusinessLogic.Interfaces;
using WEBCarSell.DataAccess.Interfaces;
using WEBCarSell.BusinessLogic.Extensions;
using WebCarSell.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using WEBCarSell.DataAccess.Repositories;

namespace WEBCarSell.BusinessLogic.Services
{
    public class CarSellService : ICarSellService
    {
        private readonly IRepository _repository;
        public CarSellService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<ModelDto> AddModel(ModelDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }

            var models = model.ToEntity();
            return (await _repository.Create(models)).ToModelDto();
        }
        public async Task<IEnumerable<ModelDto>> GetModelsList(int id)
        {
            var models = (await _repository.GetWhere<Model>(g => g.Id == id, include: g => g.Include(g => g.Name)));
            return models.Select(q => q.ToModelDto()).ToList();
        }

        public async Task<ModelDto> GetModelById(int id)
        {
            var result = await _repository.GetWhere<Model>(x => x.Id == id);
            return result.FirstOrDefault().ToModelDto();
        }

        //public async Task<CommentDto> GetComments()
        //{
        //    //var result = await _repository.GetAll<Comment>
        //    throw new ArgumentNullException();
        //}

        public async Task<ClientDto> GetClientById(int id)
        {
            var result = await _repository.GetWhere<Client>(x => x.Id == id);
            return result.FirstOrDefault().ToClientDto();
        }

        public async Task<RegionDto> GetModelByRegion(int id)
        {
            var result = await _repository.GetWhere<Region>(x => x.Id == id);
            return result.FirstOrDefault().ToRegionDto();
        }

        public async Task<EmployeeDto> GetEmployee(int id)
        {
            var employee = await _repository.GetWhere<Employee>(x => x.Id == id);
            return employee.FirstOrDefault().ToEmployeeDto();
        }

        public async Task<bool> IfExist(int carId)
        {
            return await _repository.IfExist<Model>(x => x.Id == carId);
        }
    }
}
