namespace BookingWebProject.Core.Models.Reservation
{
    public class UserReservationViewModel
    {
        public Guid Id { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public decimal Price { get; init; }
    }
}
