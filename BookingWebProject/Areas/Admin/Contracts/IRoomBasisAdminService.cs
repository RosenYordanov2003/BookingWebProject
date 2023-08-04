namespace BookingWebProject.Areas.Admin.Contracts
{
    using Core.Models.RoomBasis;
    public interface IRoomBasisAdminService
    {
        Task<IEnumerable<RoomBasisViewModel>> GetOtherRoomBasisAsync(int hotelId, int roomTypeId);
    }
}
