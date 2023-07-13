namespace BookingWebProject.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class RoomBasis
    {
        public RoomBasis()
        {
            RoomBases = new List<RoomsBases>();
        }
        [Key]
        public int Id { get; init; }
        [Required]
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; }
        [Required]
        public string ClassIcon { get; set; } = null!;
        public ICollection<RoomsBases> RoomBases { get; set; }
    }
}
