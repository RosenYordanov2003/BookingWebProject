namespace BookingWebProject.Areas.Admin.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Admin.Contracts;
    using Admin.Models.Room;
    using Data;

    public class RoomAdminService : IRoomAdminService
    {
        private readonly BookingContext bookingContext;
        public RoomAdminService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<IEnumerable<RoomAdminViewModel>> GetHotelRoomsByHotelIdAsync(int hotelId)
        {
            IEnumerable<RoomAdminViewModel> hotelRooms = await bookingContext.Rooms
                .Where(r => r.HotelId == hotelId)
                .Select(r => new RoomAdminViewModel()
                {
                    Id = r.Id,
                    RoomTypeId = r.RoomTypeId,
                    RoomTypeName = r.RoomType.Name,
                    ImgPath = r.Pictures.Where(p => !p.IsDeleted).First().Path,
                    IsDeleted = r.IsDeleted,
                    PricePerNight = r.PricePerNight
                })
                .ToArrayAsync();
            return hotelRooms;
        }
    }
}
