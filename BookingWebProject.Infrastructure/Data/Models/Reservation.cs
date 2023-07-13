namespace BookingWebProject.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.ReservationEntity;
    public class Reservation
    {
        public Reservation()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public int CountNights { get; set; }
        [ForeignKey(nameof(Room))]
        public int? RoomId { get; set; }
        public Room? Room { get; set; }
        public int? HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public int PeopleCount { get; set; }
        [ForeignKey(nameof(RentCar))]
        public int? RentCarId { get; set; }
        public RentCar? RentCar { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        [MaxLength(UserFirstNameMaxValue)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(UserLastNameMaxValue)]
        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress]
        [MaxLength(UserEmailAddressMaxValue)]
        public string EmailAddress { get; set; } = null!;
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public decimal TotalPrice { get; set; }
    }
}
