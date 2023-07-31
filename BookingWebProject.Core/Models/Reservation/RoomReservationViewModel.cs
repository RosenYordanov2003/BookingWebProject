namespace BookingWebProject.Core.Models.Reservation
{
    using System.ComponentModel.DataAnnotations;
    using Room;
    using User;
    public class RoomReservationViewModel
    {
        public BookRoomViewModel Room { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public UserViewModel User { get; set; } = null!;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate >= EndDate)
            {
                yield return new ValidationResult("Start Rent Date must be before End Rent Date",
                    new[] { nameof(StartDate), nameof(EndDate) });
            }
        }
    }
}
