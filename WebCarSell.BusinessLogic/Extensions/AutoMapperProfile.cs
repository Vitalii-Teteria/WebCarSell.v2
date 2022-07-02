using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCarSell.DataAccess.Entities;
using WEBCarSell.BusinessLogic.DTO;

namespace WebCarSell.BusinessLogic.Extensions
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Administrator, AdministratorDto>().ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Car_body, Car_bodyDto>().ReverseMap();
            CreateMap<Model, ModelDto>().ReverseMap();
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
