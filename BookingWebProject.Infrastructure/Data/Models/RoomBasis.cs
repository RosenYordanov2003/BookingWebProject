namespace BookingWebProject.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.RoomBasisEntity;
    public class RoomBasis
    {
        public RoomBasis()
        {
            RoomBases = new List<RoomsBases>();
        }
        [Key]
        public int Id { get; init; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; }
        [Required]
        [MaxLength(ClassIconMaxLength)]
        public string ClassIcon { get; set; } = null!;
        public ICollection<RoomsBases> RoomBases { get; set; }
    }
}
