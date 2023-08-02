namespace BookingWebProject.Areas.Admin.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;
    using Models.Hotel;
    using Infrastructure.Data.Models;
    using BookingWebProject.Core.Models.Picture;

    public class HotelAdminService : IHotelAdminService
    {
        private readonly BookingContext bookingContext;
        public HotelAdminService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<IEnumerable<HotelAllViewModel>> GetAllHotelsAsync()
        {
            IEnumerable<HotelAllViewModel> allHotels = await bookingContext.Hotels
                .Select(h => new HotelAllViewModel()
                {
                    Id = h.Id,
                    HotelName = h.Name,
                    StarsCount = h.StarRating,
                    IsDeleted = h.IsDeleted,
                    ImgPath = h.Pictures.First().Path
                })
                .ToArrayAsync();

            return allHotels;
        }
        public async Task<bool> CheckIfHotelIsAlredyDeletedAsync(int hotelId)
        {
            return await bookingContext.Hotels
                 .AnyAsync(h => h.Id == hotelId && h.IsDeleted);
        }

        public async Task DeleteHotelByIdAsync(int hotelId)
        {
            Hotel hotelToDelete = await bookingContext.Hotels
                 .FirstAsync(h => h.Id == hotelId);
            hotelToDelete.IsDeleted = true;

            await bookingContext.SaveChangesAsync();
        }

        public async Task RecoverHotelByIdAsync(int hotelId)
        {
            Hotel hotelToRecover = await bookingContext.Hotels
               .FirstAsync(h => h.Id == hotelId);
            hotelToRecover.IsDeleted = false;

            await bookingContext.SaveChangesAsync();
        }

        public async Task<bool> CheckIsHotelForRecoverExistByIdAsync(int hotelId)
        {
            return await bookingContext.Hotels
                .AnyAsync(h => h.IsDeleted && h.Id == hotelId);
        }

        public async Task<EditHotelViewModel> GetHotelToEditAsync(int hotelId)
        {
            EditHotelViewModel editHotelViewModel = await bookingContext.Hotels
                 .Where(h => h.Id == hotelId)
                 .Select(h => new EditHotelViewModel()
                 {
                     Id = h.Id,
                     StarRating = h.StarRating,
                     City = h.City,
                     Country = h.Country,
                     Description = h.Description,
                     HotelName = h.Name,
                     Pictures = h.Pictures.Select(p => new PictureViewModel()
                     {
                         Path = p.Path
                     })
                     .ToArray()
                 })
                 .FirstAsync();

            return editHotelViewModel;
        }
    }
}
