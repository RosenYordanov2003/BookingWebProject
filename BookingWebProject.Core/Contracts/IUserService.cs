namespace BookingWebProject.Core.Contracts
{
    using Models.User;
    public interface IUserService
    {
        Task<UserViewModel> GetUserByIdAsync(Guid id);
    }
}
