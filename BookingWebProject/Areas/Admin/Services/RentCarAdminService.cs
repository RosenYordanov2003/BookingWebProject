namespace BookingWebProject.Areas.Admin.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;
    using Models.RentCar;

    public class RentCarAdminService : IRentCarAdminService
    {
        private readonly BookingContext bookingContext;
        public RentCarAdminService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<IEnumerable<RentCarAdminViewModel>> GetAllCarsAsync()
        {
            IEnumerable<RentCarAdminViewModel> cars = await bookingContext.RentCars
                 .Select(rc => new RentCarAdminViewModel()
                 {
                     Id = rc.Id,
                     MakeType = rc.MakeType,
                     Model = rc.ModelType,
                     RentCount = rc.Reservations.Count(),
                     ImgPath = rc.CarImg,
                     IsDeleted = rc.IsDeleted,
                     Year = rc.Year
                 })
                 .OrderBy(rc => rc.IsDeleted)
                 .ToArrayAsync();

            return cars;
        }
    }
}
