namespace BookingWebProject.Core.Contracts
{
    using Core.Models.Hotel;
    using Models.User;
    public interface IUserService
    {
        Task<UserViewModel> GetUserByIdAsync(Guid id);
        Task<IEnumerable<HotelViewModel>> GetUserFavoriteHotelsAsync(Guid userId);
        Task<UserInfoViewModel> GetUserInfoByIdAsync(Guid userId);
    }
}
