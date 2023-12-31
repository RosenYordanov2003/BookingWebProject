﻿namespace BookingWebProject.Areas.Admin.Contracts
{
    using Core.Models.Pager;
    using Models.Room;
    public interface IRoomAdminService
    {
        Task<IEnumerable<RoomAdminViewModel>>GetHotelRoomsByHotelIdAsync(int hotelId, Pager pager);
        Task<bool> IsRoomByGivenTypeExistsInHotel(int hotelId, int roomTypeId);
        Task<EditRoomViewModel> GetRoomToEditAsync(int roomTypeId, int hotelId);
        Task UpdateRoomsInHotelByRoomTypeIdAsync(int roomTypeId, int hotelId, EditRoomViewModel editRoomViewModel);
        Task AddRoomByGivenRoomTypeInHotelAsync(int hotelId, int roomtypeId);
        Task<IEnumerable<RoomAdminViewModel>> GetRoomByHotelIdAsync(int hotelId);
        Task<int> GetHotelRoomsCountAsync(int hotelId);
        Task<IEnumerable<RoomAdminViewModel>> GetRoomTypesInHotelByHotelIdAsync(int hotelId);
        Task<bool> CheckIsRoomExistByIdAsync(int roomId);
        Task<bool> CheckIfRoomIsAlreadyDeletedByGivenIdAsync(int roomId);
        Task DeleteRoomByIdAsync(int roomId);
        Task<bool> CheckIfRoomIsAlreadyRecoveredByIdAsync(int roomId);
        Task RecoverRoomByIdAsync(int roomId);
        Task<int> CreateRoomAsync(CreateRoomViewModel createRoomViewModel);
        Task CreateRoomImgsAsync(int roomId, CreateRoomViewModel createRoomViewModel);
    }
}
