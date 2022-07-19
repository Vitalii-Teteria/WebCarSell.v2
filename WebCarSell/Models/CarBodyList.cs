namespace WebCarSell.Models
{
    public class CarBodyList
    {
        public List<Car_bodyViewModel> BodyViewModels { get; set; }
        public CarBodyList(List<Car_bodyViewModel> car_BodyViews) 
        {
            BodyViewModels = car_BodyViews;
        }
    }
}
