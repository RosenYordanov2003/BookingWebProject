namespace BookingWebProject.Areas.Admin.Models.Picture
{
    using Core.Models.Picture;
    public class PictureAdminViewModel : PictureViewModel
    {
        public int Id { get; init; }
        public bool IsDeleted { get; set; }
    }
}
