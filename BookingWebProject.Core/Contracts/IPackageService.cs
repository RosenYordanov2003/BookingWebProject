namespace BookingWebProject.Core.Contracts
{
    using Models.RoomPackage;
    public interface IPackageService
    {
        public Task<RoomPackageViewModel> GetPackageByIdAsync(int packageId);
        public Task<IEnumerable<RoomPackageViewModel>> GetAllPackagesAsync();
    }
}
