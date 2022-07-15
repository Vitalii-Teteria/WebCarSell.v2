namespace WebCarSell.Models
{
    public class ModelsListModel
    {
        public List<ModelView> ModelView { get; set; }

        public ModelsListModel(List<ModelView> modelView) 
        {
            ModelView = modelView;
        }
    }
}
