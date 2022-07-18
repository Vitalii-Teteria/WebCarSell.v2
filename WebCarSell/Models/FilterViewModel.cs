using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebCarSell.Models
{
    public class FilterViewModel
    {
        public SelectList CarModels { get; }
        public string? SelectedName { get; }
        public FilterViewModel(List<ModelView> models, string name)
        {
            models.Insert(0, new ModelView { Name = "All", Id = Guid.NewGuid() });
            CarModels = new SelectList(models, "Id", "Name");
            SelectedName = name;
        }
    }
}
