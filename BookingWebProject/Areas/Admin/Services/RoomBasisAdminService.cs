namespace BookingWebProject.Areas.Admin.Services
{
    using Data;
    using Contracts;
    using Core.Models.RoomBasis;
    using Microsoft.EntityFrameworkCore;

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
                .Where(b => !b.RoomBases.Any(rb => rb.Room.RoomType.Id == roomTypeId && rb.Room.HotelId == hotelId))
                .Select(b => new RoomBasisViewModel()
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToArrayAsync();

            return otherRoomBasis;
        }
    }
}
