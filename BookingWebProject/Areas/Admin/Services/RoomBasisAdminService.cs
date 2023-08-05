namespace BookingWebProject.Areas.Admin.Services
{
    using Data;
    using Contracts;
    using Core.Models.RoomBasis;
    using Microsoft.EntityFrameworkCore;
    using Infrastructure.Data.Models;

    public class RoomBasisAdminService : IRoomBasisAdminService
    {
        private readonly BookingContext bookingContext;
        public RoomBasisAdminService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<IEnumerable<RoomBasisViewModel>> GetOtherRoomBasisAsync(int hotelId, int roomTypeId)
        {
            IEnumerable<RoomBasisViewModel> otherRoomBasis = await bookingContext.RoomBasis
                .Where(b => !b.RoomBases.Any(rb => rb.Room.RoomType.Id == roomTypeId && rb.Room.HotelId == hotelId && !rb.IsDeleted))
                .Select(b => new RoomBasisViewModel()
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToArrayAsync();

            return otherRoomBasis;
        }

        public async Task<bool> IsRoomBasisExist(int hotelId, int roomTypeId, int roomBasisId)
        {
            return await bookingContext.RoomsBases.AnyAsync(rb => rb.RoomBasisId == roomBasisId && rb.Room.HotelId == hotelId && rb.Room.RoomTypeId == roomTypeId);
        }

        public async Task RemoveRoomBasisFromRoomsInHotelByGivenRoomTypeAsync(int hotelId, int roomTypeId, int roomBasisId)
        {
            IEnumerable<RoomsBases> roomBases = await bookingContext.RoomsBases
                 .Where(rb => rb.Room.HotelId == hotelId && rb.Room.RoomTypeId == roomTypeId && rb.RoomBasisId == roomBasisId)
                 .ToArrayAsync();
            foreach (RoomsBases roomBasis in roomBases)
            {
                roomBasis.IsDeleted = true;
            }
            await bookingContext.SaveChangesAsync();
        }
    }
}
