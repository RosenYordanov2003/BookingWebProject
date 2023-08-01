namespace BookingWebProject.Areas.Admin.Models.User
{
    public class AllUsersViewModel
    {
        public string UserName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null!;
        public DateTime JoinTime { get; set; }
        //public int ReservationsCount { get; set; }
    }
}
