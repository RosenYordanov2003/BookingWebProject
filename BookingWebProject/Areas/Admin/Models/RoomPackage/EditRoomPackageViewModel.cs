namespace BookingWebProject.Areas.Admin.Models.RoomPackage
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.RoomPackageEntity;
    public class EditRoomPackageViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Range(typeof(decimal), MinPrice, MaxPrice)]
        public decimal Price { get; set; }
    }
}
