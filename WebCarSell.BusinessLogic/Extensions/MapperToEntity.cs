using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCarSell.DataAccess.Entities;
using WEBCarSell.BusinessLogic.DTO;

namespace WEBCarSell.BusinessLogic.Extensions
{
    public static class MapperToEntity
    {
        public static Model ToEntity(this ModelDto model)
        {
            return model == null ? null :
                new Model
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
        public static Client ToEntity(this ClientDto model)
        {
            return model == null ? null :
                new Client
                {
                    Id = model.Id,
                    Name = model.Name,
                    City = model.City,
                    Phone = model.Phone,
                    Email = model.Email
                };
        }
        public static Employee ToEntity(this EmployeeDto model)
        {
            return model == null ? null :
                new Employee
                {
                    Name = model.Name,
                    Phone = model.Phone,
                    Email = model.Email
                };
        }
        public static Region ToEntity(this RegionDto model)
        {
            return model == null ? null :
                new Region
                {
                    Name = model.Name
                };
        }
    }
}
