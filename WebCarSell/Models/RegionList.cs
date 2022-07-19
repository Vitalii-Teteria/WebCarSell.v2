namespace WebCarSell.Models
{
    public class RegionList
    {
        public List<RegionModelView> RegionModels { get; set; }
        public RegionList(List<RegionModelView> regionModelViews) 
        {
            RegionModels = regionModelViews;
        }
    }
}
