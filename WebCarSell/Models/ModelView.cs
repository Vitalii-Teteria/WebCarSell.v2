using System.ComponentModel.DataAnnotations;
using WebCarSell.DataAccess.Entities;

namespace WebCarSell.Models
{
    public class ModelView
    {
        public Guid Id { get; set; } 
        [Required]
        public string? Name { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public float Mileage { get; set; }

        [Required]
        public float Engine_Volume { get; set; }

        [Required]
        public string? Color { get; set; }

        [Required]
        public string? Transmission { get; set; }

        public string? Drive { get; set; }
        public int Price { get; set; }
        //public IFormFile Picture { get; set; }
        public string? OwnerPhone { get; set; }
        public string? Description { get; set; }
        public int CountOfModifications { get; set; }
        public int SummaryPriceOfModification { get; set; }
        public Guid RegionId { get; set; }
        public Guid BodyId { get; set; }
        public Guid BrandId { get; set; }
        public Guid ModificationId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId  { get; set; }
    }
}
