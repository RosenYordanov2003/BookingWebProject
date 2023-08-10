namespace BookingWebProject.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Hosting;
    using System.Collections.Generic;
    using Data;
    using Contracts;
    using Models.User;
    using Core.Models.Hotel;
    using Core.Models.Room;
    using Infrastructure.Data.Models;
    using Core.Models.Reservation;

    public class UserService : IUserService
    {
        private readonly BookingContext bookingContext;
        private readonly IWebHostEnvironment env;
        public UserService(BookingContext bookingContext, IWebHostEnvironment env)
        {
            this.bookingContext = bookingContext;
            this.env = env;
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
                .Where(fv => fv.UserId == userId && !fv.Hotel.IsDeleted)
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
                   .Where(r => !r.IsDeleted && !r.RoomType.IsDeleted)
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

        public async Task SaveUserInfoAsync(Guid userId, UserInfoViewModel userInfo)
        {
            User userToFind = await bookingContext.Users.FirstAsync(u => u.Id == userId);
            userToFind.FirstName = userInfo.FirstName;
            userToFind.LastName = userInfo.LastName;
            userToFind.PhoneNumber = userInfo.PhoneNumber;
            userToFind.ProfilePicturePath = userInfo.ProfilePicturePath;
            userToFind.Email = userInfo.Email;
            await bookingContext.SaveChangesAsync();
        }

        public async Task DeleteUserProfilePictureAsync(Guid userId, string path)
        {
            string profilePictureName = path.Split("\\")[2];
            string profilePicturesFolderPath = Path.GetFullPath(@"C:\\Users\\Home\\Desktop\\Booking App4\\BookingSystemProject\\wwwroot\\img\\ProfilePictures\\");
            string[] files = Directory.GetFiles(profilePicturesFolderPath, profilePictureName);
            if (files.Length > 0)
            {
                File.Delete(files[0]);
            }
            User user = await bookingContext.Users
                .FirstAsync(u => u.Id == userId);
            user.ProfilePicturePath = null;

            await bookingContext.SaveChangesAsync();
        }

        public async Task<string> UploadUserImageAsync(UserInfoViewModel userInfo, Guid userId)
        {
            string uniqueFileName = userId.ToString() + "_" + userInfo.ProfilePictureFile.FileName;

            string newFilePath = Path.Combine("img", "ProfilePictures", uniqueFileName);


            using (FileStream stream = new FileStream(Path.Combine(env.WebRootPath, newFilePath), FileMode.Create))
            {
                await userInfo.ProfilePictureFile.CopyToAsync(stream);
            }
            return newFilePath;
        }
        public async Task<IEnumerable<UserReservationViewModel>> GetUserReservationsAsync(Guid userId)
        {
            IEnumerable<UserReservationViewModel> userReservations = await bookingContext
                .Reservations
                .Where(r => r.UserId == userId)
                .Select(r => new UserReservationViewModel()
                {
                    Id = r.Id,
                    StartDate = r.StartDate,
                    EndDate = r.EndDate,
                    Price = r.TotalPrice,
                })
                .OrderByDescending(r => r.StartDate)
                .ToArrayAsync();
            return userReservations;
        }
    }
}
