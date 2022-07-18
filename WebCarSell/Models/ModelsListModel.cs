namespace WebCarSell.Models
{
    public class ModelsListModel
    {
        public List<ModelView> ModelView { get; set; }
        public SortViewModel SortViewModel { get; }
        public FilterViewModel FilterViewModel { get; set; }

        public ModelsListModel(List<ModelView> modelView, SortViewModel sortViewModel, FilterViewModel filterViewModel) 
        {
            ModelView = modelView;
            SortViewModel = sortViewModel;
            FilterViewModel = filterViewModel;
        }
    }
}
