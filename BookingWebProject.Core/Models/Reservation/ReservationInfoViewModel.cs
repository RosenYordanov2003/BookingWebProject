namespace BookingWebProject.Core.Models.Reservation
{
    public class ReservationInfoViewModel
    {
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public Guid ReservationId { get; init; }
        public int PeopleCount { get; init; }
        public string Country { get; init; } = null!;
        public string City { get; init; } = null!;
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        //Room
        public string? HotelName { get; init; }
        public string? RoomName { get; init; }
        public string? RoomPackage { get; init; }
        public string? RoomPicture { get; init; }
        //Car
        public string? CarModel { get; init; }
        public string? CarMakeType { get; init; }
        public string? CarPicture { get; init; }
        public int? Year { get; init; }
        public string? TransimssionType { get; init; }
        public decimal TotalPrice { get; init; }
    }
}
