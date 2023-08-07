namespace BookingWebProject.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.RoomTypeEntity;
    public class RoomType
    {
        public RoomType()
        {
            Rooms = new List<Room>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(RoomTypeNameMaxValue)]
        public string Name { get; set; } = null!;
        public decimal IncreasePercentage { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public bool IsDeleted { get; set; }
    }
}
