using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCarSell.BusinessLogic.DTO;
using WEBCarSell.BusinessLogic.DTO;

namespace WEBCarSell.BusinessLogic.Interfaces
{
    public interface ICarSellService
    {
        Task<BrandDto> AddBrand(BrandDto model);
        Task<RegionDto> AddRegion(RegionDto model);
        Task<Car_bodyDto> AddBody(Car_bodyDto model);
        Task<SportsCategoryDto> AddCategory(SportsCategoryDto model);
        Task<ModificationsDto> AddModification(ModificationsDto model);
        Task<IEnumerable<RegionDto>> GetRegions();
        Task UpdateModel(ModelDto model);
        Task UpdateCategory(SportsCategoryDto model);
        Task UpdateModification(ModificationsDto model);
        Task DeleteModel(ModelDto model);
        Task UpdateBrand(BrandDto model);
        Task DeleteBrand(BrandDto brand);
        Task UpdateRegion(RegionDto model);
        Task DeleteRegion(RegionDto model);
        Task UpdateCarBody(Car_bodyDto model);
        Task DeleteBody(Car_bodyDto model);
        Task DeleteCategory(SportsCategoryDto model);
        Task DeleteModification(ModificationsDto model);
        Task<IEnumerable<BrandDto>> GetBrands();
        Task<IEnumerable<Car_bodyDto>> GetBody();
        Task<ModelDto> GetModelById(Guid? id);
        Task<BrandDto> GetBrandById(Guid? id);
        Task<RegionDto> GetRegionById(Guid? id);
        Task<Car_bodyDto> GetBodyById(Guid? id);
        Task<SportsCategoryDto> GetCategoryById(Guid? id);
        Task<ModificationsDto> GetModificationById(Guid? id);
        Task<IEnumerable<UserDto>> GetUsers();
        Task<RegionDto> GetModelByRegion(Guid? id);
        Task<bool> IfExist(Guid? carId);
    }
}
