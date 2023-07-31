namespace BookingWebProject.Core.Contracts
{
    using Models.RoomPackage;
    using Models.Room;
    public interface IRoomService
    {
        public Task<IEnumerable<RoomViewModel>> GetHotelRooms(int hotelId);
        public Task<bool> IsRoomExistAsync(int roomId);
        public Task<RoomOrderInfoViewModel> GetORderRoomInfoAsync(int roomId);
        public Task<BookRoomViewModel> GetRoomToBookAsync(RoomOrderInfoViewModel roomOrderInfoViewModel, RoomPackageViewModel package);
    }
}
