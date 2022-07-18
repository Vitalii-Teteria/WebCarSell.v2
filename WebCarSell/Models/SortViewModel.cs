using WebCarSell.Other;

namespace WebCarSell.Models
{
    public class SortViewModel
    {
        public SortState NameSort { get; set; }
        public SortState Mileage { get; set; }
        public SortState Current { get; set; }
        public bool Up { get; set; }

        public SortViewModel(SortState state)
        {
            NameSort = SortState.NameAsc;
            Mileage = SortState.MileageAsc;
            Up = true;

            if (state == SortState.NameDesc || state == SortState.MileageDesc)
            {
                Up = false;
            }
            switch (state)
            {
                case SortState.NameDesc:
                    Current = NameSort = SortState.NameAsc;
                    break;
                case SortState.MileageAsc:
                    Current = NameSort = SortState.MileageDesc;
                    break;
                case SortState.MileageDesc:
                    Current = NameSort = SortState.MileageAsc;
                    break;
                case SortState.NameAsc :
                    Current = NameSort = SortState.NameDesc;
                    break;
            }
        }
    }
}
