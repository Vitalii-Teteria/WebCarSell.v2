using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBCarSell.BusinessLogic.DTO;

namespace WEBCarSell.BusinessLogic.Interfaces
{
    public interface ICarSellService
    {
        Task<ModelDto> AddModel(ModelDto model);
        Task<IEnumerable<ModelDto>> GetModelsList(int id);
        Task<ModelDto> GetModelById(int id);
        //Task<CommentDto> GetComments(CommentDto model);
        Task<ClientDto> GetClientById(int id);
        //Task<OrderDto> GetOrder(int id);
        Task<RegionDto> GetModelByRegion(int id);
        Task<EmployeeDto> GetEmployee(int id);
        Task<bool> IfExist(int carId);
    }
}
