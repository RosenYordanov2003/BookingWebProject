namespace BookingWebProject.Areas.Admin.Services
{
    using Data;
    using Contracts;
    using Core.Models.Benefits;
    using Microsoft.EntityFrameworkCore;

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
                 .Benefits.Where(b => !b.HotelBenefits.Any(hb => hb.BenefitId == b.Id && hb.HotelId == hotelId && !hb.IsDeleted))
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
    }
}
