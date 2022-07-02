﻿using AutoMapper;
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
        }
    }
}
