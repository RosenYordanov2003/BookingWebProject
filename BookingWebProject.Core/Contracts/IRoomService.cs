namespace BookingWebProject.Core.Contracts
{
    using Models.Room;
    public interface IRoomService
    {
        public Task<IEnumerable<RoomViewModel>> GetHotelRooms(int hotelId);
    }
}
