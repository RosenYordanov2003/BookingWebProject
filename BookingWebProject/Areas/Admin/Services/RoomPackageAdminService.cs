namespace BookingWebProject.Areas.Admin.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;
    using Models.RoomPackage;
    using System;
    using BookingWebProject.Infrastructure.Data.Models;

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

        private async Task<RoomPackage> FindRoomPackageByIdAsync(int roomPackageId)
        {
            return await bookingContext.RoomPackages.FirstAsync(rp => rp.Id == roomPackageId);
        }
    }
}
