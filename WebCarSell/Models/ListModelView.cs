namespace WebCarSell.Models
{
    public class ListModelView
    {
        public List<ModelView> Models { get; set; }
        public ListModelView(List<ModelView> modelViews) { Models = modelViews; }
    }
}
