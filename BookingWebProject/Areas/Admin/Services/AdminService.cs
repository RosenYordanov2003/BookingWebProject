namespace BookingWebProject.Areas.Admin.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;
    using Models;

    public class AdminService : IAdminService
    {
        private readonly BookingContext bookingContext;
        public AdminService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }
        public async Task<HomeAdminPageViewModel> GetStatisticsInfoAsync()
        {
            HomeAdminPageViewModel model = new HomeAdminPageViewModel();

            model.HotelReservationsCount = await bookingContext.Reservations
                .Where(r => r.Hotel != null && !r.Hotel.IsDeleted).CountAsync();

            model.RentCarsCount = await bookingContext.Reservations
                .Where(r => r.RentCar != null && !r.RentCar.IsDeleted).CountAsync();

            model.TotalReservationCount = model.HotelReservationsCount + model.RentCarsCount;

            return model;
        }
    }
}
