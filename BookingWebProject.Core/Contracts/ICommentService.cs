namespace BookingWebProject.Core.Contracts
{
    using Models.Comment;
    public interface ICommentService
    {
        Task CreateCommentAsync(PostCommentViewModel commentViewModel, Guid userId, string userName);
        Task<bool> IsExist(int commentId);
        Task<bool> DeleteCommentAsync(int commentId);
        Task EditCommentAsync(EditCommentViewModel editCommentViewModel);
    }
}
