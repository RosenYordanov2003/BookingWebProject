namespace BookingWebProject.Core.Services
{
    using Contracts;
    using Models.Benefits;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class BenefitService : IBenefitService
    {
        private readonly BookingContext bookingContext;
        public BenefitService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<IEnumerable<BenefitViewModel>> GetAllBenefitsAsync()
        {
            IEnumerable<BenefitViewModel> benefits = await bookingContext
                 .Benefits.Where(b => !b.IsDeleted)
                 .Select(b => new BenefitViewModel()
                 {
                     Id = b.Id,
                     Name = b.Name,
                     BenefitIcon = b.ClassIcon
                 })
                 .ToArrayAsync();
            return benefits;
        }
    }
}
