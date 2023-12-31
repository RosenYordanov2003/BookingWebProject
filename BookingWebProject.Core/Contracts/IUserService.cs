﻿namespace BookingWebProject.Core.Contracts
{
    using Models.Reservation;
    using Models.Hotel;
    using Models.User;
    public interface IUserService
    {
        Task<UserViewModel> GetUserByIdAsync(Guid id);
        Task<IEnumerable<HotelViewModel>> GetUserFavoriteHotelsAsync(Guid userId);
        Task<UserInfoViewModel> GetUserInfoByIdAsync(Guid userId);
        Task SaveUserInfoAsync(Guid userId, UserInfoViewModel userInfo);
        Task DeleteUserProfilePictureAsync(Guid userId, string path);
        Task<string> UploadUserImageAsync(UserInfoViewModel userInfo, Guid userId);
        Task<IEnumerable<UserReservationViewModel>> GetUserReservationsAsync(Guid userId);
    }
}
