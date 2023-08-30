using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCarSell.BusinessLogic.DTO;
using WebCarSell.DataAccess.Entities;
using WEBCarSell.BusinessLogic.DTO;

namespace WebCarSell.BusinessLogic.Interfaces
{
    public interface ICreateModelService
    {
        Task<ModelDto> AddModel(ModelDto model);
        Task<ModelModificationsDto> AddModelModifications(ModelModificationsDto model);
        Task<IEnumerable<ModelDto>> GetModels();
        Task<IEnumerable<RegionDto>> GetRegions();
        Task<IEnumerable<BrandDto>> GetBrands();
        Task<IEnumerable<Car_bodyDto>> GetBody();
        Task<IEnumerable<SportsCategoryDto>> GetCategories();
        Task<IEnumerable<ModificationsDto>>GetModifications();
        Task<Guid> GetIdUser(string name);
        Task<List<ModelDto>> GetModelsByIdUser(Guid guid);
        Task<List<ModelModificationsDto>> GetModificationsByIdUser(Guid guid);
        Task<int> GetPriceOfModificationByIdModification(string name);


    }
}
