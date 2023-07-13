namespace BookingWebProject.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.RoomPackageEntity;
    public class RoomPackage
    {
        public RoomPackage()
        {
            Rooms = new List<Room>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        public ICollection<Room> Rooms { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
    }
}
