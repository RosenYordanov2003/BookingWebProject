namespace BookingWebProject.Core.Models.Account
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.UserEntity;
    public class RegisterViewModel
    {
        [Required]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
        public string Username { get; set; } = null!;
        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [EmailAddress]
        [Required]
        [StringLength(EmailAddressMaxValue, MinimumLength = EmailAddressMinValue)]
        public string Email { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
