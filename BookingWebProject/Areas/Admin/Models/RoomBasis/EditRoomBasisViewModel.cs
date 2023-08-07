namespace BookingWebProject.Areas.Admin.Models.RoomBasis
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.RoomBasisEntity;
    public class EditRoomBasisViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [MaxLength(ClassIconMaxLength)]
        public string ClassIcon { get; set; } = null!;
    }
}
