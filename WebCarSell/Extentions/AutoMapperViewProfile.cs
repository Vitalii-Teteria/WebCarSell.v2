using AutoMapper;
using WebCarSell.BusinessLogic.DTO;
using WebCarSell.Models;
using WEBCarSell.BusinessLogic.DTO;

namespace WebCarSell.Extentions
{
    public class AutoMapperViewProfile : Profile
    {
        public AutoMapperViewProfile() 
        {
            CreateMap<ModelDto, ModelView>().ReverseMap();
            CreateMap<RegionDto, RegionModelView>().ReverseMap();
            CreateMap<BrandDto, BrandModelView>().ReverseMap();
            CreateMap<Car_bodyDto, Car_bodyViewModel>().ReverseMap();
            CreateMap<ModificationsDto,ModelModifications>().ReverseMap();
            CreateMap<ModificationsDto,ModificationsView>().ReverseMap();
            CreateMap<IEnumerable<ModificationsDto>,List<ModelModifications>>().ReverseMap();
            CreateMap<SportsCategoryDto, SportsCategoryView>().ReverseMap();
            CreateMap<ModelModificationsDto, ModelModificationsView>().ReverseMap();
        }
    }
}
