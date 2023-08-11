namespace BookingWebProject.Areas.Admin.Contracts
{
    using Models.RoomType;
    public interface IRoomTypeService
    {
        Task<IEnumerable<RoomTypeViewModel>> GetAllAvailableRoomTypesAsync();
        Task<IEnumerable<RoomTypeAdminViewModel>> GetAllRomTypes();
        Task<bool> CheckIfRoomTypeExistByIdAsync(int roomTypeId);
        Task<bool>CheckIfRoomTypeIsAlreadyDeletedByIdAsync(int roomTypeId);
        Task DeleteRoomTypeAsync(int roomTypeId);
        Task<bool> CheckIfRoomTypeIsAlreadyRecoveredByIdAsync(int roomTypeId);
        Task RecoverRoomTypeByIdAsync(int roomTypeId);
        Task<EditRoomTypeViewModel> GetRoomTypeToEditByIdAsync(int roomTypeId);
        Task EditRoomTypeAsync(int roomTypeId, EditRoomTypeViewModel editRoomTypeViewMode);
        Task CreateRoomTypeAsync(EditRoomTypeViewModel editRoomTypeViewModel);
    }
}
