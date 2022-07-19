namespace WebCarSell.Models
{
    public class BrandList
    {
        public List<BrandModelView> BrandsList { get; set; }

        public BrandList(List<BrandModelView> brandModelViews) 
        {
            BrandsList = brandModelViews;
        }
    }
}
