namespace BookingWebProject.Core.Models.Account
{
    using System.ComponentModel.DataAnnotations;
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public string? ReturnUrl { get; set; }
    }
}
