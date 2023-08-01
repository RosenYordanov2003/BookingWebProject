namespace BookingWebProject.Areas.Admin.Models
{
    using BookingWebProject.Areas.Admin.Models.User;
    using Core.Models.User;

    public class HomeAdminPageViewModel
    {
        public HomeAdminPageViewModel()
        {
            AllUsers = new List<AllUsersViewModel>();
        }
        public int TotalReservationCount { get; set; }
        public int HotelReservationsCount { get; set; }
        public int RentCarsCount { get; set; }
        public IEnumerable<AllUsersViewModel> AllUsers { get; set; }
    }
}
