namespace BookingWebProject.Services.Tests.Unit_Tests
{
    using Microsoft.EntityFrameworkCore;
    using Areas.Admin.Contracts;
    using Data;
    using Areas.Admin.Services;
    using static DatabaseSeeder;
    using BookingWebProject.Areas.Admin.Models;

    [TestFixture]
    public class AdminServiceTests
    {
        private BookingContext dbContext;
        private IAdminService adminService;
        private DbContextOptions<BookingContext> dbOptions;

        [SetUp]
        public void SetUp()
        {
            dbOptions = new DbContextOptionsBuilder<BookingContext>()
                .UseInMemoryDatabase("BookingSystemInMemory" + Guid.NewGuid().ToString())
                .Options;
            dbContext = new BookingContext(dbOptions, false);
            dbContext.Database.EnsureCreated();
            SeedDatabase(dbContext);
            adminService = new AdminService(dbContext);
        }
        [Test]
        public async Task GetStatisticMethod()
        {
            HomeAdminPageViewModel homeAdminPageViewModel = new HomeAdminPageViewModel()
            {
                HotelReservationsCount = 7,
                RentCarsCount = 6,
                TotalReservationCount = 13
            };

            HomeAdminPageViewModel actualHomeAdminPageViewModel = await this.adminService.GetStatisticsInfoAsync();

            Assert.AreEqual(homeAdminPageViewModel.RentCarsCount, actualHomeAdminPageViewModel.RentCarsCount);
            Assert.AreEqual(homeAdminPageViewModel.HotelReservationsCount, actualHomeAdminPageViewModel.HotelReservationsCount);
            Assert.AreEqual(homeAdminPageViewModel.TotalReservationCount, actualHomeAdminPageViewModel.TotalReservationCount);
        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
