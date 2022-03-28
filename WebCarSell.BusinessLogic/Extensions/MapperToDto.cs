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

        public static ClientDto ToClientDto(this Client model)
        {
            return model == null ? null :
                new ClientDto
                {
                    Id = model.Id,
                    Name = model.Name,
                    City = model.City,
                    Phone = model.Phone,
                    Email = model.Email
                };
        }
        public static EmployeeDto ToEmployeeDto(this Employee model)
        {
            return model == null ? null :
                new EmployeeDto
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
