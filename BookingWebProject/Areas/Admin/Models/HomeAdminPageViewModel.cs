namespace BookingWebProject.Areas.Admin.Models
{
    using Core.Models.User;

    public class HomeAdminPageViewModel
    {
        public HomeAdminPageViewModel()
        {
            AllUsers = new List<UserViewModel>();
        }
        public int TotalReservationCount { get; set; }
        public int HotelReservationsCount { get; set; }
        public int RentCarsCount { get; set; }
        public IEnumerable<UserViewModel> AllUsers { get; set; }
    }
}
