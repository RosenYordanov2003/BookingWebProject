namespace BookingWebProject.Services.Tests.Unit_Tests
{
    using Microsoft.EntityFrameworkCore;
    using Areas.Admin.Contracts;
    using Data;
    using BookingWebProject.Areas.Admin.Services;
    using Areas.Admin.Models.RoomBasis;
    using Comparators;
    using static DatabaseSeeder;
    using BookingWebProject.Core.Models.RoomBasis;

    [TestFixture]
    public class RoomBasisServiceTests
    {
        private BookingContext dbContext;
        private IRoomBasisService roomBasisService;
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
            roomBasisService = new RoomBasisService(dbContext);
        }
        [Test]
        public async Task GetAllAvailableRoomBasis()
        {
            IEnumerable<RoomBasisAdminViewModel> expectedRoomBasisViewModels = new List<RoomBasisAdminViewModel>()
            {
                new RoomBasisAdminViewModel()
                {
                    Id = 1,
                    Name = "Tv",
                    ClassIcon = "fa-solid fa-tv",
                },
                new RoomBasisAdminViewModel()
                {
                    Id = 2,
                    Name = "Free WiFi",
                    ClassIcon = "fa-solid fa-wifi"
                }
            };

            IEnumerable<RoomBasisAdminViewModel> actualRoomBasisViewModels = await this.roomBasisService.GetAllRoomBasisAsync();

            CollectionAssert.AreEqual(expectedRoomBasisViewModels, actualRoomBasisViewModels, new RoomBasisAdminViewModelComparer());
        }
        [Test]
        public async Task TestCheckIfRoomBasisExistByIdShouldReturnTrue()
        {
            bool actualResult = await this.roomBasisService.CheckIfRoomBasisExistByIdAsync(roomBasis1.Id);

            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestCheckIfRoomBasisExistByIdShouldReturnFalse()
        {
            bool actualResult = await this.roomBasisService.CheckIfRoomBasisExistByIdAsync(42);

            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestGetAllAvailableRoomBasis()
        {
            roomBasis1.IsDeleted = true;
            dbContext.SaveChanges();

            IEnumerable<RoomBasisViewModel> expectedRoomBasisViewModels = new List<RoomBasisViewModel>()
            {
                new RoomBasisAdminViewModel()
                {
                    Id = 2,
                    Name = "Free WiFi",
                    ClassIcon = "fa-solid fa-wifi"
                }
            };
            IEnumerable<RoomBasisViewModel> actualRoomBasis = await this.roomBasisService.GetAllAvailableRoomBasisAsync();

            CollectionAssert.AreEqual(expectedRoomBasisViewModels, actualRoomBasis, new RoomBasisViewModelComparer());
        }
        [Test]
        public async Task TestCheckIfRoomBasisIsAlreadyDeletedByIdShouldReturnTrue()
        {
            roomBasis1.IsDeleted = true;
            dbContext.SaveChanges();
            
            bool actualResult = await this.roomBasisService.CheckIfRoomBasisIsAlreadyDeletedByIdAsync(roomBasis1.Id);

            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestCheckIfRoomBasisIsAlreadyDeletedByIdShouldReturnFalse()
        {

            bool actualResult = await this.roomBasisService.CheckIfRoomBasisIsAlreadyDeletedByIdAsync(roomBasis1.Id);

            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestCheckIfRoomBasisIsAlreadyRecoveredShouldReturnTrue()
        {
            bool actualResult = await this.roomBasisService.CheckIfRoomBasisIsAlreadyRecoveredAsync(roomBasis1.Id);
            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestCheckIfRoomBasisIsAlreadyRecoveredShouldReturnFalse()
        {
            roomBasis1.IsDeleted = true;
            dbContext.SaveChanges();

            bool actualResult = await this.roomBasisService.CheckIfRoomBasisIsAlreadyRecoveredAsync(roomBasis1.Id);
            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestDeleteRoomBasisByIdAsync()
        {
            await this.roomBasisService.DeleteRoomBasisByIdAsync(roomBasis1.Id);

            Assert.IsTrue(roomBasis1.IsDeleted);
        }
        [Test]
        public async Task TestRecoverRoomBasisById()
        {
            roomBasis1.IsDeleted = true;
            dbContext.SaveChanges();

            await this.roomBasisService.RecoverRoomBasisByIdAsync(roomBasis1.Id);

            Assert.IsFalse(roomBasis1.IsDeleted);
        }
        [Test]
        public async Task TestGetRoomBasisToEditById()
        {
            EditRoomBasisViewModel expectedRoomBasisModel = new EditRoomBasisViewModel()
            {
                Name = roomBasis1.Name,
                ClassIcon = roomBasis1.ClassIcon
            };

            EditRoomBasisViewModel actualRoomBasisViewModel = await this.roomBasisService.GetRoomBasisToEditByIdAsync(roomBasis1.Id);

            Assert.AreEqual(expectedRoomBasisModel.Name, actualRoomBasisViewModel.Name);
            Assert.AreEqual(expectedRoomBasisModel.ClassIcon, actualRoomBasisViewModel.ClassIcon);
        }
        [Test]
        public async Task TestEditRoomBasis()
        {
            EditRoomBasisViewModel roomBasisModel = new EditRoomBasisViewModel()
            {
                Name = "Test",
                ClassIcon = roomBasis1.ClassIcon
            };

            await this.roomBasisService.EditRoomBasisAsync(roomBasis1.Id, roomBasisModel);

            Assert.AreEqual(roomBasisModel.Name, roomBasis1.Name);
        }
        [Test]
        public async Task TestCreateRoomBasis()
        {
            int currentCountRoomBasisInDatabase = dbContext.RoomBasis.Count();
            int expectedCountRoomBasisInDatabase = currentCountRoomBasisInDatabase + 1;
            EditRoomBasisViewModel roomBasisModel = new EditRoomBasisViewModel()
            {
                Name = "Test",
                ClassIcon = roomBasis1.ClassIcon
            };

            await this.roomBasisService.CreateRoomBasisAsync(roomBasisModel);

            Assert.AreEqual(expectedCountRoomBasisInDatabase, dbContext.RoomBasis.Count());
        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
