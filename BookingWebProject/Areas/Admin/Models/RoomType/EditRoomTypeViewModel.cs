namespace BookingWebProject.Areas.Admin.Models.RoomType
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.RoomTypeEntity;
    public class EditRoomTypeViewModel
    {
        [Required]
        [StringLength(RoomTypeNameMaxValue, MinimumLength = RoomTypeNameMinValue)]
        public string Name { get; set; } = null!;
        [Range(typeof(decimal), MinPerentageIncrease, MaxPerentageIncrease)]
        [Display(Name = "Percentage Increase")]
        public decimal PercentageIncrease { get; set; }
    }
}
