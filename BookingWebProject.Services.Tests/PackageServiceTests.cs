namespace BookingWebProject.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts;
    using Core.Services;
    using Core.Models.RoomPackage;
    using Data;
    using Comparators;
    using static DatabaseSeeder;

    public class PackageServiceTests
    {
        private DbContextOptions<BookingContext> dbOptions;
        private BookingContext dbContext;
        private IPackageService packageService;
        [SetUp]
        public void SetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<BookingContext>()
                .UseInMemoryDatabase("BookingSystemInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new BookingContext(this.dbOptions, false);
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(dbContext);
            this.packageService = new PackageService(this.dbContext);
        }
        [Test]
        public async Task TestGetAllRoomPackagesMethod()
        {
            IEnumerable<RoomPackageViewModel> expectedRoomPackages = new List<RoomPackageViewModel>()
            {
                new RoomPackageViewModel()
                {
                    Id = 1,
                    Name = "Breakfast",
                    Price = 0,
                },
                new RoomPackageViewModel()
                {
                     Id = 2,
                     Name = "Breakfast and Dinner",
                     Price = 70,
                },
                new RoomPackageViewModel()
                {
                     Id = 3,
                     Name = "All Inclusive",
                     Price = 100
                },
            };

            IEnumerable<RoomPackageViewModel> actualRoomPackages = await this.packageService.GetAllPackagesAsync();

            CollectionAssert.AreEqual(expectedRoomPackages, actualRoomPackages, new RoomPackageViewModelComparer());
        }
        [Test]
        public async Task TestGetRoomPackageById()
        {
            int expectedResult = 0;
            RoomPackageViewModel expectedRoomPackage = new RoomPackageViewModel()
            {
                Id = 1,
                Name = "Breakfast",
                Price = 0,
            };
            RoomPackageViewModel actualRoomPackage = await this.packageService.GetPackageByIdAsync(1);
            Assert.AreEqual(expectedResult, new RoomPackageViewModelComparer().Compare(expectedRoomPackage, actualRoomPackage));
        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
