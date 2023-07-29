namespace BookingWebProject.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;
    using Models.Room;
    using BookingWebProject.Core.Models.Picture;
    using BookingWebProject.Core.Models.RoomBasis;

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


        public async Task<bool> IsRoomExistAsync(int roomId)
        {
            return await bookingContext.Rooms.AnyAsync(r => r.Id == roomId && !r.IsDeleted);
        }
        public async Task<RoomOrderInfoViewModel> GetORderRoomInfoAsync(int roomId)
        {
            RoomOrderInfoViewModel roomOrderInfoViewModel = await bookingContext.Rooms
                 .Select(r => new RoomOrderInfoViewModel()
                 {
                     Id = r.Id,
                     HotelId = r.HotelId,
                     Description = r.Description,
                     Name = r.RoomType.Name,
                     RoomCapacity = r.Capacity,
                     Price = r.PricePerNight,
                     RoomPictures = r.Pictures.Select(p => new PictureViewModel() { Path = p.Path }).ToArray(),
                     RoomBases = r.RoomBases.Select(rb => new RoomBasisViewModel() { Id = rb.RoomBasis.Id, Name = rb.RoomBasis.Name }).ToArray()
                 })
                 .FirstAsync(r => r.Id == roomId);
            return roomOrderInfoViewModel;
        }
    }
}
