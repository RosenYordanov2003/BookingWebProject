namespace BookingWebProject.Areas.Admin.Services
{
    using Data;
    using Contracts;
    using Core.Models.Benefits;
    using Microsoft.EntityFrameworkCore;
    using BookingWebProject.Infrastructure.Data.Models;

    public class BenefitAdminService : IBenefitAdminService
    {
        private readonly BookingContext bookingContext;
        public BenefitAdminService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }
        public async Task<IEnumerable<BenefitViewModel>> GetOtherBenefitsAsync(int hotelId)
        {
            IEnumerable<BenefitViewModel> benefitsToAdd = await bookingContext
                 .Benefits.Where(b => !b.IsDeleted && !b.HotelBenefits.Any(hb => hb.BenefitId == b.Id && hb.HotelId == hotelId && !hb.IsDeleted))
                 .Select(b => new BenefitViewModel()
                 {
                     Id = b.Id,
                     BenefitIcon = b.ClassIcon,
                     Name = b.Name,
                     IsDeleted = b.IsDeleted
                 })
                 .ToArrayAsync();
            return benefitsToAdd;
        }
        public async Task<IEnumerable<BenefitViewModel>> GetAllHotelBenefitsAsync()
        {
            IEnumerable<BenefitViewModel> allHotelBenefits = await bookingContext
                 .Benefits
                 .Select(b => new BenefitViewModel()
                 {
                     Id = b.Id,
                     Name = b.Name,
                     IsDeleted = b.IsDeleted,
                     BenefitIcon = b.ClassIcon
                 })
                 .ToArrayAsync();

            return allHotelBenefits;
        }

        public async Task<bool> CheckIfBenefitExistByIdAsync(int benefitId)
        {
            return await bookingContext.Benefits
                 .AnyAsync(b => b.Id == benefitId);
        }

        public async Task<bool> CheckIfBenefitIsAlreadyDeletedAsync(int benefitId)
        {
            return await bookingContext.Benefits.AnyAsync(b => b.Id == benefitId && b.IsDeleted);
        }

        public async Task DeleteBenefitAsync(int benefitId)
        {
            Benefit benefit = await FindBenefitByIdAsync(benefitId);
            benefit.IsDeleted = true;
            await bookingContext.SaveChangesAsync();
        }
        private async Task<Benefit> FindBenefitByIdAsync(int benefitId)
        {
            Benefit benefit = await bookingContext.Benefits.FirstAsync(b => b.Id == benefitId);
            return benefit;
        }
    }
}
