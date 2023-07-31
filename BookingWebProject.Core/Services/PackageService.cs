namespace BookingWebProject.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;
    using Models.RoomPackage;
    public class PackageService : IPackageService
    {
        private readonly BookingContext bookingContext;
        public PackageService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<IEnumerable<RoomPackageViewModel>> GetAllPackagesAsync()
        {
            IEnumerable<RoomPackageViewModel> allRoomPackages = await bookingContext.RoomPackages
                  .Select(rp => new RoomPackageViewModel()
                  {
                      Id = rp.Id,
                      Name = rp.Name,
                      Price = rp.Price
                  }).ToArrayAsync();

            return allRoomPackages;
        }
        public async Task<RoomPackageViewModel> GetPackageByIdAsync(int packageId)
        {
            RoomPackageViewModel roomPackage = await bookingContext
                 .RoomPackages
                 .Select(p => new RoomPackageViewModel()
                 {
                     Id = p.Id,
                     Name = p.Name,
                     Price = p.Price
                 })
                 .FirstAsync(p => p.Id == packageId);
            return roomPackage;
        }
    }
}
