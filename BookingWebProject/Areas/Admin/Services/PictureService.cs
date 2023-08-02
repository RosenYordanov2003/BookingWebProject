namespace BookingWebProject.Areas.Admin.Services
{
    using Microsoft.EntityFrameworkCore;
    using Infrastructure.Data.Models;
    using Contracts;
    using Data;

    public class PictureService : IPictureService
    {
        private readonly BookingContext bookingContext;
        public PictureService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<bool> CheckIsPictureAlreadyDeleted(int pictureId)
        {
            return await bookingContext.Pictures.AnyAsync(p => p.Id == pictureId);
        }

        public async Task<bool> CheckIsPictureExistByIdAsync(int pictureId)
        {
            return await bookingContext.Pictures
                 .AnyAsync(p => p.Id == pictureId);
        }

        public async Task DeletePictureAsync(int pictureId)
        {
            Picture picture = await GetPictureByIdAsync(pictureId);
            picture.IsDeleted = true;
            await bookingContext.SaveChangesAsync();
        }
        public async Task<bool> CheckPictureIsAlreadyRecoveredAsync(int pictureId)
        {
            return await bookingContext.Pictures.AnyAsync(p => !p.IsDeleted && p.Id == pictureId);
        }

        public async Task RecoverPictureAsync(int pictureId)
        {
            Picture picture = await GetPictureByIdAsync(pictureId);
            picture.IsDeleted = false;
            await bookingContext.SaveChangesAsync();
        }

        private async Task<Picture> GetPictureByIdAsync(int pictureId)
        {
            Picture picture = await bookingContext.Pictures.FirstAsync(p => p.Id == pictureId);
            return picture;
        }
    }
}
