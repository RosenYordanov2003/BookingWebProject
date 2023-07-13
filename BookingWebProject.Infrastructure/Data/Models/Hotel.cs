namespace BookingWebProject.Infrastructure.Data.Models
{
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidation.HotelEntity;
    public class Hotel
    {
        public Hotel()
        {
            Rooms = new List<Room>();
            Pictures = new List<Picture>();
            HotelBenefits = new List<HotelBenefits>();
            Comments = new List<Comment>();
            Reservations = new List<Reservation>();
            FavoriteHotels = new List<FavoriteHotels>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxCountryValue)]
        public string Country { get; set; } = null!;
        public int StarRating { get; set; }
        [Required]
        [MaxLength(MaxHotelNameValue)]
        public string Name { get; set; } = null!;

        [MaxLength(MaxDescriptionValue)]
        public string? Description { get; set; }
        [Column(TypeName = "decimal(17, 15)")]
        public decimal Longitude { get; set; }
        [Column(TypeName = "decimal(17, 15)")]
        public decimal Latitude { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        [MaxLength(MaxCityValue)]
        public string City { get; set; } = null!;
        public bool IsFavorite { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public List<HotelBenefits> HotelBenefits { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<FavoriteHotels> FavoriteHotels { get; set; }
    }
}
