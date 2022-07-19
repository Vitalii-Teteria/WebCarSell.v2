namespace WebCarSell.Models
{
    public class ModelsListModel
    {
        public IQueryable<ModelView> ViewModels { get; set; }

        public ModelsListModel( IQueryable<ModelView> modelViews) 
        {
            ViewModels = modelViews;
        }
    }
}
