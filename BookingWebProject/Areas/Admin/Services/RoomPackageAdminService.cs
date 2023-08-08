namespace BookingWebProject.Areas.Admin.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;
    using Models.RoomPackage;
    using Infrastructure.Data.Models;

    public class RoomPackageAdminService : IRoomPackageAdminService
    {
        private readonly BookingContext bookingContext;
        public RoomPackageAdminService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }
        public async Task<IEnumerable<RoomPackageAdminViewModel>> GetAllRoomPackagesAsync()
        {
            IEnumerable<RoomPackageAdminViewModel> allRoomPackages = await bookingContext
                 .RoomPackages
                 .Select(rp => new RoomPackageAdminViewModel()
                 {
                     Id = rp.Id,
                     Name = rp.Name,
                     IsDeleted = rp.IsDeleted,
                     Price = rp.Price
                 })
                 .ToArrayAsync();
            return allRoomPackages;
        }
        public async Task<bool> CheckIfPakcageExistsByIdAsync(int roomPackageId)
        {
            return await bookingContext.RoomPackages.AnyAsync(rp => rp.Id == roomPackageId);
        }

        public async Task<bool> CheckIfRoomPackageIsAlreadyDeletedByIdAsync(int roomPackageId)
        {
            return await bookingContext.RoomPackages.AnyAsync(rp => rp.Id == roomPackageId && rp.IsDeleted);
        }

        public async Task DeleteRoomPackageAsync(int roomPackageId)
        {
            RoomPackage roomPackage = await FindRoomPackageByIdAsync(roomPackageId);
            roomPackage.IsDeleted = true;
            await bookingContext.SaveChangesAsync();
        }
        public async Task<bool> CheckIfRoomPackageIsAlreadyRecoveredByIdAsync(int roomPackageId)
        {
            return await bookingContext.RoomPackages.AnyAsync(rp => rp.Id == roomPackageId && !rp.IsDeleted);
        }

        public async Task RecoverRoomPackageByIdAsync(int roomPackageId)
        {
            RoomPackage roomPackage = await FindRoomPackageByIdAsync(roomPackageId);
            roomPackage.IsDeleted = false;
            await bookingContext.SaveChangesAsync();
        }


        public async Task<EditRoomPackageViewModel> GetRoomPackageToEditByIdAsync(int roomPackageId)
        {
            RoomPackage roomPackageToEdit = await FindRoomPackageByIdAsync(roomPackageId);
            return new EditRoomPackageViewModel() { Name = roomPackageToEdit.Name, Price = roomPackageToEdit.Price };
        }

        public async Task EditRoomPackageAsync(int roomPackageId, EditRoomPackageViewModel editRoomPackageViewModel)
        {
            RoomPackage roomPackageToEdit = await FindRoomPackageByIdAsync(roomPackageId);
            roomPackageToEdit.Name = editRoomPackageViewModel.Name;
            roomPackageToEdit.Price = editRoomPackageViewModel.Price;
            await bookingContext.SaveChangesAsync();
        }
        public async Task CreateRoomPackageAsync(EditRoomPackageViewModel roomPackageToCreate)
        {
            RoomPackage roomPackage = new RoomPackage() { Name = roomPackageToCreate.Name, Price = roomPackageToCreate.Price };
            await bookingContext.RoomPackages.AddAsync(roomPackage);
            await bookingContext.SaveChangesAsync();
        }
        private async Task<RoomPackage> FindRoomPackageByIdAsync(int roomPackageId)
        {
            return await bookingContext.RoomPackages.FirstAsync(rp => rp.Id == roomPackageId);
        }

    }
}
