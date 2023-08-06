namespace BookingWebProject.Areas.Admin.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;
    using Models.RoomType;

    public class RoomTypeService : IRoomTypeService
    {
        private readonly BookingContext bookingContext;
        public RoomTypeService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<IEnumerable<RoomTypeViewModel>> GetAllRoomTypesAsync()
        {
            IEnumerable<RoomTypeViewModel> roomTypes = await bookingContext.RoomTypes
                 .Select(rt => new RoomTypeViewModel()
                 {
                     Id = rt.Id,
                     Name = rt.Name
                 })
                 .ToArrayAsync();
            return roomTypes;
        }
    }
}
