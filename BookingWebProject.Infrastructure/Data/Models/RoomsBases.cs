namespace BookingWebProject.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class RoomsBases
    {
        [ForeignKey(nameof(Room))]
        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;
        [ForeignKey(nameof(RoomBasis))]
        public int RoomBasisId { get; set; }
        public RoomBasis RoomBasis { get; set; } = null!;
        public bool IsDeleted { get; set; }
    }
}
