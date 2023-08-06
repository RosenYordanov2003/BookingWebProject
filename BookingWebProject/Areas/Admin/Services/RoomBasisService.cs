namespace BookingWebProject.Areas.Admin.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;
    using Core.Models.RoomBasis;

    public class RoomBasisService : IRoomBasisService
    {
        private readonly BookingContext bookingContext;
        public RoomBasisService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<IEnumerable<RoomBasisViewModel>> GetAllRoomBasis()
        {
            IEnumerable<RoomBasisViewModel> allRoomBasis = await bookingContext.RoomBasis
                  .Select(rb => new RoomBasisViewModel()
                  {
                      Id = rb.Id,
                      Name = rb.Name
                  })
                  .ToArrayAsync();

            return allRoomBasis;
        }
    }
}
