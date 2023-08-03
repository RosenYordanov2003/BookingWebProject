namespace BookingWebProject.Areas.Admin.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;
    using Models.Hotel;
    using Infrastructure.Data.Models;
    using BookingWebProject.Core.Models.Picture;
    using BookingWebProject.Areas.Admin.Models.Picture;
    using BookingWebProject.Core.Models.Benefits;

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
            Hotel hotelToRecover = await FindHotelByIdAsync(hotelId);
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
                     Pictures = h.Pictures.Select(p => new PictureAdminViewModel()
                     {
                         Id = p.Id,
                         Path = p.Path,
                         IsDeleted = p.IsDeleted,
                     })
                     .ToArray(),
                     CurrentHotelBenefits = h.HotelBenefits.Select(hb => new BenefitViewModel()
                     {
                         Id = hb.BenefitId,
                         BenefitIcon = hb.Benefit.ClassIcon,
                         Name = hb.Benefit.Name,
                         IsDeleted = hb.IsDeleted,
                         
                     })
                 })
                 .FirstAsync();

            return editHotelViewModel;
        }

        public async Task EditHotelByIdAsync(int hotelId, EditHotelViewModel editHotelViewModel)
        {
            Hotel hotelToEdit = await FindHotelByIdAsync(hotelId);
            hotelToEdit.Name = editHotelViewModel.HotelName;
            hotelToEdit.StarRating = editHotelViewModel.StarRating;
            hotelToEdit.City = editHotelViewModel.City;
            hotelToEdit.Country = editHotelViewModel.Country;
            hotelToEdit.Description = editHotelViewModel.Description;

            await bookingContext.SaveChangesAsync();
        }

        private async Task<Hotel> FindHotelByIdAsync(int hotelId)
        {
             Hotel hotelToEdit = await bookingContext.Hotels
                .FirstAsync(h => h.Id == hotelId);

            return hotelToEdit;
        }

        public async Task<bool> CheckIsHotelBenefitExistAsync(int benefitId, int hotelId)
        {
            return await bookingContext.HotelBenefits
                 .AnyAsync(hb => hb.HotelId == hotelId && hb.BenefitId == benefitId);
        }

        public async Task<bool> CheckIsHotelBenefitIsAlreadyDeleted(int benefitId, int hotelId)
        {
          return await bookingContext.HotelBenefits
                .AnyAsync(hb => hb.HotelId == hotelId && hb.BenefitId == benefitId && !hb.IsDeleted);
        }

        public async Task DeleteHotelBenefitAsync(int benefitId, int hotelId)
        {
            HotelBenefits hotelBenefit = await bookingContext.HotelBenefits
                 .FirstAsync(hb => hb.HotelId == hotelId && hb.BenefitId == benefitId);

            hotelBenefit.IsDeleted = true;
            await bookingContext.SaveChangesAsync();
        }
    }
}
