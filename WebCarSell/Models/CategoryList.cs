namespace WebCarSell.Models
{
    public class CategoryList
    {
        public List<SportsCategoryView> SportsCategories { get; set; }

        public CategoryList(List<SportsCategoryView> sportsCategoryViews) 
        { 
            SportsCategories = sportsCategoryViews;
        }
    }
}
