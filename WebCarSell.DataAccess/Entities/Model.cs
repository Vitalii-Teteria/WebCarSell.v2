using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBCarSell.DataAccess.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace WebCarSell.DataAccess.Entities
{
    public class Model : ISoftDeletable
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }

        [Required(AllowEmptyStrings = false)]
        public float Mileage { get; set; }

        [Required(AllowEmptyStrings = false)]
        public float Engine_Volume { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Color { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Transmission { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Drive { get; set; }

        public Guid BrandId { get; set; }

        public bool IsDeleted { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int Price { get; set; }

        public Guid BodyId { get; set; }

        public Guid RegionId { get; set; }
    }

    public class Photos
    {
        public int Id { get; private set; }

        public string PhotoName { get; private set; }

        public byte[] Data { get; private set; }
    }
}
