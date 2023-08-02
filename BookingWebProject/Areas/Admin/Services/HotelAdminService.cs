namespace BookingWebProject.Areas.Admin.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;
    using Models.Hotel;

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
                    HotelId = h.Id,
                    HotelName = h.Name,
                    StarsCount = h.StarRating,
                    IsDeleted = h.IsDeleted,
                    ImgPath = h.Pictures.First().Path
                })
                .ToArrayAsync();

            return allHotels;
        }
    }
}
