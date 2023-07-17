namespace BookingWebProject.Core.Models.RentCar
{
    public class AllCarsSortedAndFilteredDataModel
    {
        public AllCarsSortedAndFilteredDataModel()
        {
            Cars = new List<CarViewModel>();
        }
        public IEnumerable<CarViewModel> Cars { get; set; }
    }
}
