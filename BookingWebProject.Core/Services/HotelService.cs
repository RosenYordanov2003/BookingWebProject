namespace BookingWebProject.Core.Services
{
    using Models.Picture;
    using Contracts;
    using Models.Hotel;
    using BookingWebProject.Data;
    using Microsoft.EntityFrameworkCore;

    public class HotelService : IHotelService
    {
        private readonly BookingContext bookingContext;
        public HotelService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<IEnumerable<HotelCardViewModel>> GetTopHotelsAsync()
        {
            IEnumerable<HotelCardViewModel> hotels = await bookingContext.Hotels.
                Include(h => h.Reservations).
                OrderByDescending(h => h.Reservations.Count)
                .ThenByDescending(h => h.StarRating)
                .Where(h => !h.IsDeleted)
                .Select(h => new HotelCardViewModel()
                {
                    Id = h.Id,
                    Name = h.Name,
                    Country = h.Country,
                    City = h.City,
                    Stars = h.StarRating,
                    Pictures = h.Pictures.Select(p => new PictureViewModel()
                    {
                        Path = p.Path,
                    }).ToList()
                })

                 .Take(4)
                 .ToListAsync();

            return hotels;
        }
    }
}
