namespace BookingWebProject.Core.Models.User
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.UserEntity;
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; init; } = null!;
        [Phone]
        [MaxLength(PhoneNumberMaxLength)]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
        [StringLength(FirstNameMaxValue, MinimumLength = FirstNameMinValue)]
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; } = null!;
        [StringLength(LastNameMaxValue, MinimumLength = LastNameMinValue)]
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; } = null!;
    }
}
