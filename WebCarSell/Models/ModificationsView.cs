namespace WebCarSell.Models
{
    public class ModificationsView
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public Guid SportsCategory { get; set; }
    }
}
