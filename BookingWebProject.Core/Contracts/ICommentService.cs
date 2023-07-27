namespace BookingWebProject.Core.Contracts
{
    using Models.Comment;
    public interface ICommentService
    {
        Task CreateCommentAsync(PostCommentViewModel commentViewModel, Guid userId, string userName);
    }
}
