namespace BookingWebProject.Services.Tests.Unit_Tests
{
    using Microsoft.EntityFrameworkCore;
    using Areas.Admin.Contracts;
    using Data;
    using Areas.Admin.Services;
    using Areas.Admin.Models.RoomPackage;
    using Comparators;
    using static DatabaseSeeder;

    [TestFixture]
    public class RoomPackageAdminServiceTestscs
    {
        private BookingContext dbContext;
        private IRoomPackageAdminService roomPackageAdminService;
        private DbContextOptions<BookingContext> dbOptions;

        [SetUp]
        public void SetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<BookingContext>()
               .UseInMemoryDatabase("BookingSystemInMemory" + Guid.NewGuid().ToString())
               .Options;
            this.dbContext = new BookingContext(this.dbOptions, false);
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(dbContext);
            roomPackageAdminService = new RoomPackageAdminService(dbContext);
        }
        [Test]
        public async Task TestGetAllRoomPackagesAsync()
        {
            IEnumerable<RoomPackageAdminViewModel> expectedRoomPackages = new List<RoomPackageAdminViewModel>()
            {
                new RoomPackageAdminViewModel()
                {
                    Id = roomPackage1.Id,
                    Name = roomPackage1.Name,
                    Price = roomPackage1.Price,
                },
                new RoomPackageAdminViewModel()
                {
                    Id = roomPackage2.Id,
                    Name = roomPackage2.Name,
                    Price = roomPackage2.Price,
                },
                new RoomPackageAdminViewModel()
                {
                    Id = roomPackage3.Id,
                    Name = roomPackage3.Name,
                    Price = roomPackage3.Price,
                },
            };

            IEnumerable<RoomPackageAdminViewModel> actualRoomPackages = await this.roomPackageAdminService.GetAllRoomPackagesAsync();

            CollectionAssert.AreEqual(expectedRoomPackages, actualRoomPackages, new RoomPackageViewModelComparer());
        }
        [Test]
        public async Task TestCheckIfPakcageExistsByIdShouldReturnTrue()
        {
            bool actualResult = await this.roomPackageAdminService.CheckIfPakcageExistsByIdAsync(roomPackage1.Id);
            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestCheckIfPakcageExistsByIdShouldReturnFalse()
        {
            bool actualResult = await this.roomPackageAdminService.CheckIfPakcageExistsByIdAsync(11);
            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestCheckIfRoomPackageIsAlreadyDeletedByIdShouldReturnFalse()
        {
            bool actualResult = await this.roomPackageAdminService.CheckIfRoomPackageIsAlreadyDeletedByIdAsync(roomPackage1.Id);
            Assert.IsFalse(actualResult);
        }

        [Test]
        public async Task TestCheckIfRoomPackageIsAlreadyDeletedByIdShouldReturnTrue()
        {
            roomPackage1.IsDeleted = true;
            dbContext.SaveChanges();
            bool actualResult = await this.roomPackageAdminService.CheckIfRoomPackageIsAlreadyDeletedByIdAsync(roomPackage1.Id);
            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestDeleteRoomPackage()
        {
            await this.roomPackageAdminService.DeleteRoomPackageAsync(roomPackage1.Id);
            Assert.IsTrue(roomPackage1.IsDeleted);
        }
        [Test]
        public async Task TestCheckIfRoomPackageIsAlreadyRecoveredByIdShouldReturnTrue()
        {
            bool actualResult = await this.roomPackageAdminService.CheckIfRoomPackageIsAlreadyRecoveredByIdAsync(roomPackage1.Id);
            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestCheckIfRoomPackageIsAlreadyRecoveredByIdShouldReturnFalse()
        {
            roomPackage1.IsDeleted = true;
            dbContext.SaveChanges();
            bool actualResult = await this.roomPackageAdminService.CheckIfRoomPackageIsAlreadyRecoveredByIdAsync(roomPackage1.Id);
            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestRecoverRoomPackageById()
        {
            roomPackage1.IsDeleted = true;
            dbContext.SaveChanges();

            await this.roomPackageAdminService.RecoverRoomPackageByIdAsync(roomPackage1.Id);
            Assert.IsFalse(roomPackage1.IsDeleted);
        }
        [Test]
        public async Task TestGetRoomPackageToEditById()
        {
            EditRoomPackageViewModel expectedRoomPackage = new EditRoomPackageViewModel()
            {
                Name = roomPackage1.Name,
                Price = roomPackage1.Price,
            };
            EditRoomPackageViewModel actualRoomPackage = await this.roomPackageAdminService.GetRoomPackageToEditByIdAsync(roomPackage1.Id);

            Assert.AreEqual(expectedRoomPackage.Name, actualRoomPackage.Name);
            Assert.AreEqual(expectedRoomPackage.Price, actualRoomPackage.Price);
        }
        [Test]
        public async Task TestEditRoomPackage()
        {
            EditRoomPackageViewModel expectedRoomPackage = new EditRoomPackageViewModel()
            {
                Name = "Test",
                Price = 20,
            };
            await this.roomPackageAdminService.EditRoomPackageAsync(roomPackage1.Id, expectedRoomPackage);
            Assert.AreEqual(expectedRoomPackage.Name, roomPackage1.Name);
            Assert.AreEqual(expectedRoomPackage.Price, roomPackage1.Price);
        }
        [Test]
        public async Task TestCreateRoomPackage()
        {
            int currentRoomPackagesCountInDatabase = dbContext.RoomPackages.Count();
            int expectedRoomPackagesInDatabase = currentRoomPackagesCountInDatabase + 1;

            EditRoomPackageViewModel roomPackage = new EditRoomPackageViewModel()
            {
                Name = "Test",
                Price = 20,
            };

            await this.roomPackageAdminService.CreateRoomPackageAsync(roomPackage);

            Assert.AreEqual(expectedRoomPackagesInDatabase, dbContext.RoomPackages.Count());
        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
