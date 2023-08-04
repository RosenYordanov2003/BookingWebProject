namespace BookingWebProject.Areas.Admin.Models.Hotel.DataModels
{
    using Core.Models.Pager;
    public class HotelDataModel
    {
        public HotelDataModel()
        {
            AllHotles = new List<HotelAllViewModel>();
        }
        public IEnumerable<HotelAllViewModel> AllHotles { get; set; }
        public Pager Pager { get; set; } = null!;
    }
}
