namespace BookingWebProject.Areas.Admin.Contracts
{
    using Models.RoomBasis;
    using Core.Models.RoomBasis;
    public interface IRoomBasisService
    {
        Task<IEnumerable<RoomBasisViewModel>> GetAllAvailableRoomBasisAsync();
        Task<IEnumerable<RoomBasisAdminViewModel>> GetAllRoomBasisAsync();
        Task<bool> CheckIfRoomBasisExistByIdAsync(int roomBasisId);
        Task<bool>CheckIfRoomBasisIsAlreadyDeletedByIdAsync(int roomBasisId);
        Task DeleteRoomBasisByIdAsync(int roomBasisId);
        Task<bool> CheckIfRoomBasisIsAlreadyRecoveredAsync(int roomBasisId);
        Task RecoverRoomBasisByIdAsync(int roomBasisId);
        Task<EditRoomBasisViewModel>GetRoomBasisToEditByIdAsync(int roomBasisId);
        Task EditRoomBasisAsync(int roomBasisId, EditRoomBasisViewModel editRoomBasisViewModel);
    }
}
