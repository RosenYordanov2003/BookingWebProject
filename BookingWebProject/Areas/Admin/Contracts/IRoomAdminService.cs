namespace BookingWebProject.Areas.Admin.Contracts
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
    }
}
