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
                      Name = rb.Name,
                      ClassIcon = rb.ClassIcon,
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
                        IsDeleted = rb.IsDeleted,
                        ClassIcon = rb.ClassIcon,
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
        public async Task<bool> CheckIfRoomBasisIsAlreadyRecoveredAsync(int roomBasisId)
        {
            return await bookingContext.RoomBasis.AnyAsync(rb => rb.Id == roomBasisId && !rb.IsDeleted);
        }

        public async Task RecoverRoomBasisByIdAsync(int roomBasisId)
        {
            RoomBasis roomBasisToRecover = await FindRoomBasisByIdAsync(roomBasisId);
            roomBasisToRecover.IsDeleted = false;
            await bookingContext.SaveChangesAsync();
        }
        public async Task<EditRoomBasisViewModel> GetRoomBasisToEditByIdAsync(int roomBasisId)
        {
            RoomBasis roomBasisToEdit = await FindRoomBasisByIdAsync(roomBasisId);
            return new EditRoomBasisViewModel() { Name = roomBasisToEdit.Name, ClassIcon = roomBasisToEdit.ClassIcon };
        }

        public async Task EditRoomBasisAsync(int roomBasisId, EditRoomBasisViewModel editRoomBasisViewModel)
        {
            RoomBasis roomBasisToEdit = await FindRoomBasisByIdAsync(roomBasisId);
            roomBasisToEdit.Name = editRoomBasisViewModel.Name;
            roomBasisToEdit.ClassIcon = editRoomBasisViewModel.ClassIcon;
            await bookingContext.SaveChangesAsync();
        }

        public async Task CreateRoomBasisAsync(EditRoomBasisViewModel editRoomBasisViewModel)
        {
            RoomBasis roomBais = new RoomBasis()
            {
                Name = editRoomBasisViewModel.Name,
                ClassIcon = editRoomBasisViewModel.ClassIcon
            };
            await bookingContext.RoomBasis.AddAsync(roomBais);
            await bookingContext.SaveChangesAsync();
        }
        private async Task<RoomBasis> FindRoomBasisByIdAsync(int roomBasisId)
        {
            return await bookingContext.RoomBasis.FirstAsync(rb => rb.Id == roomBasisId);
        }
    }
}
