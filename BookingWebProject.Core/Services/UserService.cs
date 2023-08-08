namespace BookingWebProject.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using Data;
    using Contracts;
    using Models.User;
    using Core.Models.Hotel;
    using Core.Models.Room;

    public class UserService : IUserService
    {
        private readonly BookingContext bookingContext;
        public UserService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<UserViewModel> GetUserByIdAsync(Guid id)
        {
            UserViewModel userViewModel = await bookingContext.Users
                 .Select(u => new UserViewModel()
                 {
                     Id = u.Id,
                     FirstName = u.FirstName,
                     LastName = u.LastName,
                     Email = u.Email,
                     PhoneNumber = u.PhoneNumber

                 }).FirstAsync(u => u.Id == id);
            return userViewModel;
        }

        public async Task<IEnumerable<HotelViewModel>> GetUserFavoriteHotelsAsync(Guid userId)
        {
            IEnumerable<HotelViewModel> userHotels = await bookingContext
                .FavoriteHotels
                .Where(fv => fv.UserId == userId)
                .Select(fvh => new HotelViewModel()
                {
                    Id = fvh.Hotel.Id,
                    Name = fvh.Hotel.Name,
                    StarRating = fvh.Hotel.StarRating,
                    City = fvh.Hotel.City,
                    Country = fvh.Hotel.Country,
                    IsFavorite = true,
                    PicturePath = fvh.Hotel.Pictures.First().Path,
                    CheapestHotelRoomViewModel = fvh.Hotel.Rooms
                   .Where(r => r.IsDeleted && !r.RoomType.IsDeleted)
                   .Select(r => new CheapestHotelRoomViewModel() { Id = r.Id, PricePerNight = r.PricePerNight })
                   .OrderBy(r => r.PricePerNight)
                   .FirstOrDefault()
                })
                .ToArrayAsync();

            return userHotels;
        }

        public async Task<UserInfoViewModel> GetUserInfoByIdAsync(Guid userId)
        {
            UserInfoViewModel userInfo = await bookingContext
                 .Users
                 .Where(u => u.Id == userId)
                 .Select(u => new UserInfoViewModel()
                 {
                     Email = u.Email,
                     PhoneNumber = u.PhoneNumber == null ? "" : u.PhoneNumber,
                     FirstName = u.FirstName ?? "",
                     LastName = u.LastName ?? "",
                     ProfilePicturePath = u.ProfilePicturePath,
                 }).FirstAsync();

            return userInfo;
        }
    }
}
