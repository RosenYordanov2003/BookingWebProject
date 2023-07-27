namespace BookingWebProject.Core.Services
{
    using Infrastructure.Data.Models;
    using Data;
    using Contracts;
    using Models.Comment;
    using Microsoft.EntityFrameworkCore;

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
        public async Task<bool> IsExist(int commentId)
        {
            return await bookingContext.Comments.AnyAsync(c => c.Id == commentId && !c.IsDeleted);
        }

        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            Comment commentToDelete = await bookingContext.Comments.FirstAsync(c => c.Id == commentId);
            commentToDelete.IsDeleted = true;
            await bookingContext.SaveChangesAsync();

            return true;
        }
        public async Task EditCommentAsync(EditCommentViewModel editCommentViewModel)
        {
            Comment commentToEdit = await bookingContext.Comments.FirstAsync(c => c.Id == editCommentViewModel.Id);
            commentToEdit.Description = editCommentViewModel.Description;
            await bookingContext.SaveChangesAsync();
        }
    }
}
