namespace BookingWebProject.Core.Services
{
    using BookingWebProject.Data;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using Models.Room;
    public class RoomService : IRoomService
    {
        private readonly BookingContext bookingContext;
        public RoomService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<IEnumerable<RoomViewModel>> GetHotelRooms(int hotelId)
        {
            var hotelRooms = await bookingContext.Rooms
                  .Where(r => r.HotelId == hotelId)
                  .Select(r => new RoomViewModel()
                  {
                      Id = r.Id,
                      PricePerNight = r.PricePerNight,
                      Description = r.Description,
                      RoomCapacity = r.Capacity,
                      RoomType = r.RoomType.Name,
                      HotelName = r.Hotel.Name,
                      RoomPictures = r.Pictures.Select(p => new Models.Picture.PictureViewModel() { Path = p.Path }).ToArray()
                  })
                  .ToArrayAsync();
            return hotelRooms;
        }
    }
}
