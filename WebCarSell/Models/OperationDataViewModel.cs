namespace WebCarSell.Models
{
    public class OperationDataViewModel
    {
        public List<ModelView> ModelView { get; set; }
        public PageViewModel PageViewModel { get; set; }

        public OperationDataViewModel(PageViewModel pageViewModel, List<ModelView> modelView) 
        {
            PageViewModel = pageViewModel;
            ModelView = modelView;
        }
    }
}
