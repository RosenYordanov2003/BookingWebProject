namespace BookingWebProject.Core.Services
{
    using BookingWebProject.Data;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
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
    }
}
