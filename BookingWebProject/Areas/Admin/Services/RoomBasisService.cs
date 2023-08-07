namespace BookingWebProject.Areas.Admin.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;
    using Core.Models.RoomBasis;
    using Admin.Models.RoomBasis;
    using Infrastructure.Data.Models;

    public class RoomBasisService : IRoomBasisService
    {
        private readonly BookingContext bookingContext;
        public RoomBasisService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }


        public async Task<IEnumerable<RoomBasisViewModel>> GetAllAvailableRoomBasisAsync()
        {
            IEnumerable<RoomBasisViewModel> allAvailableRoomBasis = await bookingContext.RoomBasis
                  .Where(rb => !rb.IsDeleted)
                  .Select(rb => new RoomBasisViewModel()
                  {
                      Id = rb.Id,
                      Name = rb.Name
                  })
                  .ToArrayAsync();

            return allAvailableRoomBasis;
        }

        public async Task<IEnumerable<RoomBasisAdminViewModel>> GetAllRoomBasisAsync()
        {
            IEnumerable<RoomBasisAdminViewModel> allRoomBasis = await bookingContext.RoomBasis
                    .Select(rb => new RoomBasisAdminViewModel()
                    {
                        Id = rb.Id,
                        Name = rb.Name,
                        IsDeleted = rb.IsDeleted
                    })
                    .ToArrayAsync();

            return allRoomBasis;
        }
        public async Task<bool> CheckIfRoomBasisExistByIdAsync(int roomBasisId)
        {
            return await bookingContext.RoomBasis.AnyAsync(rb => rb.Id == roomBasisId);
        }

        public async Task<bool> CheckIfRoomBasisIsAlreadyDeletedByIdAsync(int roomBasisId)
        {
            return await bookingContext.RoomBasis.AnyAsync(rb => rb.Id == roomBasisId && rb.IsDeleted);
        }

        public async Task DeleteRoomBasisByIdAsync(int roomBasisId)
        {
            RoomBasis roomBasisToDelete = await FindRoomBasisByIdAsync(roomBasisId);
            roomBasisToDelete.IsDeleted = true;
            await bookingContext.SaveChangesAsync();
        }
        private async Task<RoomBasis> FindRoomBasisByIdAsync(int roomBasisId)
        {
            return await bookingContext.RoomBasis.FirstAsync(rb => rb.Id == roomBasisId);
        }
    }
}
