namespace WebCarSell.Models
{
    public class ModelsListModel
    {
        public IEnumerable<ModelView> ViewModels { get; set; }
        public string filtrationName { get; set; }
        public ModelsListModel(IEnumerable<ModelView> modelViews, string filtr)
        {
            ViewModels = modelViews;
            filtrationName = filtr;

        }
    }
}
