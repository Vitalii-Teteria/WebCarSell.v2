using WebCarSell.DataAccess.Entities;

namespace WebCarSell.Models
{
    public class ModelView
    {
        public string? Name { get; set; }

        public int Year { get; set; }

        public float Mileage { get; set; }

        public float Engine_Volume { get; set; }

        public string? Color { get; set; }

        public string? Transmission { get; set; }

        public string? Drive { get; set; }
        public int Price { get; set; }
        public Region? Region { get; set; }
        public Car_body? Body { get; set; }
        public Brand? Brand { get; set; }
    }
}
