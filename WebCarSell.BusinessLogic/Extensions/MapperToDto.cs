using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBCarSell.BusinessLogic.DTO;
using WebCarSell.DataAccess.Entities;

namespace WEBCarSell.BusinessLogic.Extensions
{
    public static class MapperToDto
    {
        public static ModelDto ToModelDto(this Model model)
        {
            return model == null ? null :
                new ModelDto
                {
                    Id = model.Id,
                    Name = model.Name,
                    Year = model.Year,
                    Mileage = model.Mileage,
                    Engine_Volume = model.Engine_Volume,
                    Color = model.Color,
                    Transmission = model.Transmission,
                    Drive = model.Drive,
                    Price = model.Price,
                    Body = model.Body,
                    Region = model.Region,
                    Brand = model.Brand
                };
        }

        public static UserDto ToClientDto(this User model)
        {
            return model == null ? null :
                new UserDto
                {
                    Id = model.Id,
                    Name = model.Name,
                    SName = model.SName,
                    Phone = model.Phone,
                    Email = model.Email
                };
        }
        public static AdministratorDto ToEmployeeDto(this Administrator model)
        {
            return model == null ? null :
                new AdministratorDto
                {
                    Name = model.Name,
                    Phone = model.Phone,
                    Email = model.Email
                };
        }

        public static RegionDto ToRegionDto(this Region model)
        {
            return model == null ? null :
                new RegionDto
                {
                    Name = model.Name
                };
        }
    }
}
