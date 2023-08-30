namespace WebCarSell.Models
{
    public class ModificationList
    {
        public List<ModificationsView> Modifications { get; set; }

        public ModificationList(List<ModificationsView> modificationsViews) 
        {
            Modifications = modificationsViews;
        }
    }
}
