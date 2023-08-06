namespace BookingWebProject.Areas.Admin.Contracts
{
    using Core.Models.RoomBasis;
    public interface IRoomBasisService
    {
        Task<IEnumerable<RoomBasisViewModel>> GetAllRoomBasis();
    }
}
