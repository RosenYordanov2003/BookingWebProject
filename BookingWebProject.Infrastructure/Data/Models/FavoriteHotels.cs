namespace BookingWebProject.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class FavoriteHotels
    {
        [ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; } = null!;

        [ForeignKey(nameof(User))]
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

    }
}
