namespace BookingWebProject.Core.Contracts
{
    using Models.RoomPackage;
    public interface IPackageService
    {
        public Task<IEnumerable<RoomPackageViewModel>> GetAllPackagesAsync();
    }
}
