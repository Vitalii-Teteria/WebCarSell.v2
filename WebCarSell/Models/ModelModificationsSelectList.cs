namespace WebCarSell.Models
{
    public class ModelModificationsSelectList
    {
        public List<ModelModifications> ModelModifications { get; set; }
        public ModelModifications result { get; set; }

        public ModelModificationsSelectList(List<ModelModifications> modelModifications) 
        {
            ModelModifications = modelModifications;
        }
        public ModelModificationsSelectList() { }
    }
}
