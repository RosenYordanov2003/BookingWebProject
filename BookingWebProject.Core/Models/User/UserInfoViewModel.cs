namespace BookingWebProject.Core.Models.User
{
    using Microsoft.AspNetCore.Http;
    public class UserInfoViewModel : UserViewModel
    {
        public IFormFile? ProfilePictureFile { get; set; }
        public string? ProfilePicturePath { get; set; }
    }
}
