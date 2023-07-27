namespace BookingWebProject.Core.Models.Comment
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.CommentEntity;
    public class PostCommentViewModel
    {
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Required]
        public string Description { get; set; } = null!;
        public int HotelId { get; set; }
    }
}
