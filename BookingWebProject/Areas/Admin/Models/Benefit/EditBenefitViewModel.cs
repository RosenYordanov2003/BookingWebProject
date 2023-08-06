namespace BookingWebProject.Areas.Admin.Models.Benefit
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.BenefitEntity;
    public class EditBenefitViewModel
    {
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        [Display(Name = "Benefit Name")]
        public string BenefitName { get; set; } = null!;
        [MaxLength(ClassIconMaxLength)]
        public string BenefitClassIcon { get; set; } = null!;
    }
}
