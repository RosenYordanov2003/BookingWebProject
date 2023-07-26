namespace BookingWebProject.Core.Models.Comment
{
    public class CommentViewModel
    {
        public int Id { get; init; }
        public string Description { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string UserName { get; set; } = null!;
        public string? UserPicturePath { get; set; }
        public Guid UserId { get; set; }
    }
}
