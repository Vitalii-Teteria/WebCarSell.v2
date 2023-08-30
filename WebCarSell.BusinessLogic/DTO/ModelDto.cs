using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCarSell.DataAccess.Entities;

namespace WEBCarSell.BusinessLogic.DTO
{
    public class ModelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public float Mileage { get; set; }
        public float Engine_Volume { get; set; }
        public string Color { get; set; }
        public string Transmission { get; set; }
        public string Drive { get; set; }
        public int Price { get; set; }
        public string OwnerPhone { get; set; }
        public byte[] Picture { get; set; }
        public int CountOfModifications { get; set; }
        public int SummaryPriceOfModification  { get; set; }
        public string Description { get; set; }
        public Guid ModificationId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BodyId { get; set; }
        public Guid RegionId { get; set; }
        public Guid BrandId { get; set; }
        public Guid UserId { get; set; }
    }
}
