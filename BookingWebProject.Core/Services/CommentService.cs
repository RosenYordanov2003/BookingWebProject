namespace BookingWebProject.Core.Services
{
    using Infrastructure.Data.Models;
    using Data;
    using Contracts;
    using Models.Comment;
    public class CommentService : ICommentService
    {
        private readonly BookingContext bookingContext;
        public CommentService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }
        public async Task CreateCommentAsync(PostCommentViewModel commentViewModel, Guid userId, string userName)
        {
            Comment comment = new Comment()
            {
                Description = commentViewModel.Description,
                CreatedDate = DateTime.Now,
                UserId = userId,
                HotelId = commentViewModel.HotelId,
                UserName = userName
            };
            await bookingContext.Comments.AddAsync(comment);
            await bookingContext.SaveChangesAsync();
        }
    }
}
