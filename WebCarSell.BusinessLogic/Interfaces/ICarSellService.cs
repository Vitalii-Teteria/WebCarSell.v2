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
        Task<IEnumerable<ModelDto>> GetModelsList(Guid? id);
        Task<IEnumerable<ModelDto>> GetModels();
        //Task<ModelDto> DeleteModel(Guid? id);
        Task<IEnumerable<RegionDto>> GetRegions();
        Task<ModelDto> GetModelById(Guid? id);
        Task<RegionDto> GetModelByRegion(Guid? id);
        Task<AdministratorDto> GetEmployee(Guid? id);
        Task<bool> IfExist(Guid? carId);
    }
}
