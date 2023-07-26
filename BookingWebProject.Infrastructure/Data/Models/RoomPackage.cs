namespace BookingWebProject.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.RoomPackageEntity;
    public class RoomPackage
    {
        public RoomPackage()
        {
            Reservations = new List<Reservation>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        public ICollection<Reservation> Reservations { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
    }
}
