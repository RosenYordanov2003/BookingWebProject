namespace BookingWebProject.Core.Models.Hotel
{
    public class AllHotelsSortedAndFilteredDataModel
    {
        public AllHotelsSortedAndFilteredDataModel()
        {
            Hotels = new List<HotelViewModel>();
        }
        public IEnumerable<HotelViewModel> Hotels { get; set; }
    }
}
