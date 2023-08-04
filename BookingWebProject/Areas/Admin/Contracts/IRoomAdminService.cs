namespace BookingWebProject.Areas.Admin.Contracts
{
    using Models.Room;
    public interface IRoomAdminService
    {
        Task<IEnumerable<RoomAdminViewModel>>GetHotelRoomsByHotelIdAsync(int hotelId);
    }
}
