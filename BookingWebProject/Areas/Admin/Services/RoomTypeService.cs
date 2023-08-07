namespace BookingWebProject.Areas.Admin.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;
    using Models.RoomType;
    using BookingWebProject.Infrastructure.Data.Models;

    public class RoomTypeService : IRoomTypeService
    {
        private readonly BookingContext bookingContext;
        public RoomTypeService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }
        public async Task<IEnumerable<RoomTypeViewModel>> GetAllAvailableRoomTypesAsync()
        {
            IEnumerable<RoomTypeViewModel> roomTypes = await bookingContext.RoomTypes
                .Where(rt => !rt.IsDeleted)
                 .Select(rt => new RoomTypeViewModel()
                 {
                     Id = rt.Id,
                     Name = rt.Name
                 })
                 .ToArrayAsync();
            return roomTypes;
        }

        public async Task<IEnumerable<RoomTypeAdminViewModel>> GetAllRomTypes()
        {
            IEnumerable<RoomTypeAdminViewModel> roomTypes = await bookingContext.RoomTypes
                 .Select(rt => new RoomTypeAdminViewModel()
                 {
                     Id = rt.Id,
                     Name = rt.Name,
                     IncreasePercentage = rt.IncreasePercentage,
                     IsDeleted = rt.IsDeleted

                 })
                 .ToArrayAsync();
            return roomTypes;
        }
        public async Task<bool> CheckIfRoomTypeExistByIdAsync(int roomTypeId)
        {
            return await bookingContext.RoomTypes.AnyAsync(rt => rt.Id == roomTypeId);
        }

        public async Task<bool> CheckIfRoomTypeIsAlreadyDeletedByIdAsync(int roomTypeId)
        {
            return await bookingContext.RoomTypes.AnyAsync(rt => rt.Id == roomTypeId && rt.IsDeleted);
        }
        public async Task DeleteRoomTypeAsync(int roomTypeId)
        {
            RoomType roomType = await FindRoomTypeByIdAsync(roomTypeId);
            roomType.IsDeleted = true;
            await bookingContext.SaveChangesAsync();
        }
        public async Task<bool> CheckIfRoomTypeIsAlreadyRecoveredByIdAsync(int roomTypeId)
        {
            return await bookingContext.RoomTypes.AnyAsync(rt => rt.Id == roomTypeId && !rt.IsDeleted);
        }

        public async Task RecoverRoomTypeAsync(int roomTypeId)
        {
            RoomType roomType = await FindRoomTypeByIdAsync(roomTypeId);
            roomType.IsDeleted = false;
            await bookingContext.SaveChangesAsync();
        }

        private async Task<RoomType> FindRoomTypeByIdAsync(int roomTypeId)
        {
            return await bookingContext.RoomTypes.FirstAsync(rt => rt.Id == roomTypeId);
        }
    }
}
