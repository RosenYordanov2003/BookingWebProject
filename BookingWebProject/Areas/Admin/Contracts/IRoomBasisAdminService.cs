namespace BookingWebProject.Areas.Admin.Contracts
{
    using Core.Models.RoomBasis;
    public interface IRoomBasisAdminService
    {
        Task<IEnumerable<RoomBasisViewModel>> GetOtherRoomBasisAsync(int hotelId, int roomTypeId);
        Task<bool>IsRoomBasisExist(int hotelId, int roomTypeId, int roomBasisId);
        Task RemoveRoomBasisFromRoomsInHotelByGivenRoomTypeAsync(int hotelId, int roomTypeId, int roomBasisId);
    }
}
