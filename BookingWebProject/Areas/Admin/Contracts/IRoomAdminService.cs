﻿namespace BookingWebProject.Areas.Admin.Contracts
{
    using Models.Room;
    public interface IRoomAdminService
    {
        Task<IEnumerable<RoomAdminViewModel>>GetHotelRoomsByHotelIdAsync(int hotelId);
        Task<bool> IsRoomByGivenTypeExistsInHotel(int hotelId, int roomTypeId);
        Task<EditRoomViewModel> GetRoomToEditAsync(int roomTypeId, int hotelId);
        Task UpdateRoomsInHotelByRoomTypeIdAsync(int roomTypeId, int hotelId, EditRoomViewModel editRoomViewModel);
        Task AddRoomByGivenRoomTypeInHotelAsync(int hotelId, int roomtypeId);
    }
}
