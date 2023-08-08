namespace BookingWebProject.Areas.Admin.Contracts
{
    using Models.RoomPackage;
    public interface IRoomPackageAdminService
    {
        Task<IEnumerable<RoomPackageAdminViewModel>> GetAllRoomPackagesAsync();
        Task<bool> CheckIfPakcageExistsByIdAsync(int roomPackageId);
        Task<bool> CheckIfRoomPackageIsAlreadyDeletedByIdAsync(int roomPackageId);
        Task DeleteRoomPackageAsync(int roomPackageId);
        Task<bool> CheckIfRoomPackageIsAlreadyRecoveredByIdAsync(int roomPackageId);
        Task RecoverRoomPackageByIdAsync(int roomPackageId);
        Task<EditRoomPackageViewModel> GetRoomPackageToEditByIdAsync(int roomPackageId);
        Task EditRoomPackageAsync(int roomPackageId, EditRoomPackageViewModel editRoomPackageViewModel);
        Task CreateRoomPackageAsync(EditRoomPackageViewModel roomPackageToCreate);
    }
}
