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
        public static User ToEntity(this UserDto model)
        {
            return model == null ? null :
                new User
                {
                    Id = model.Id,
                    Name = model.Name,
                    SName = model.SName,
                    Phone = model.Phone,
                    Email = model.Email
                };
        }
        public static Administrator ToEntity(this AdministratorDto model)
        {
            return model == null ? null :
                new Administrator
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
