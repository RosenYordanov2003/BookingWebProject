namespace BookingWebProject.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using Areas.Admin.Contracts;
    using Areas.Admin.Services;
    using Areas.Admin.Models.RoomType;
    using Data;
    using Comparators;
    using static DatabaseSeeder;
    using BookingWebProject.Infrastructure.Migrations;

    [TestFixture]
    public class RoomTypeServiceTests
    {
        private BookingContext dbContext;
        private DbContextOptions<BookingContext> dbOptions;
        private IRoomTypeService roomTypeService;

        [SetUp]
        public void SetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<BookingContext>()
               .UseInMemoryDatabase("BookingSystemInMemory" + Guid.NewGuid().ToString())
               .Options;
            this.dbContext = new BookingContext(this.dbOptions, false);
            this.dbContext.Database.EnsureCreated();
            DatabaseSeeder.SeedDatabase(dbContext);
            roomTypeService = new RoomTypeService(dbContext);
        }
        [Test]
        public async Task TestGetAllAvailableRoomTypes1()
        {
            IEnumerable<RoomTypeViewModel> expectedRoomTypes = new List<RoomTypeViewModel>()
            {
                new RoomTypeViewModel()
                {
                     Id = roomType1.Id,
                     Name = roomType1.Name,
                },
                new RoomTypeViewModel()
                {
                     Id = roomType2.Id,
                     Name = roomType2.Name,
                },
                new RoomTypeViewModel()
                {
                     Id = roomType3.Id,
                     Name = roomType3.Name,
                }
            };
            IEnumerable<RoomTypeViewModel> actualRoomTypes = await this.roomTypeService.GetAllAvailableRoomTypesAsync();

            CollectionAssert.AreEqual(expectedRoomTypes, actualRoomTypes, new RoomTypeViewModelComparator());
        }
        [Test]
        public async Task TestGetAllAvailableRoomTypes2()
        {
            roomType1.IsDeleted = true;
            dbContext.SaveChanges();
            IEnumerable<RoomTypeViewModel> expectedRoomTypes = new List<RoomTypeViewModel>()
            {
                new RoomTypeViewModel()
                {
                     Id = roomType2.Id,
                     Name = roomType2.Name,
                },
                new RoomTypeViewModel()
                {
                     Id = roomType3.Id,
                     Name = roomType3.Name,
                }
            };
            IEnumerable<RoomTypeViewModel> actualRoomTypes = await this.roomTypeService.GetAllAvailableRoomTypesAsync();

            CollectionAssert.AreEqual(expectedRoomTypes, actualRoomTypes, new RoomTypeViewModelComparator());
        }
        [Test]
        public async Task TestgetAllRoomTypes1()
        {
            IEnumerable<RoomTypeViewModel> expectedRoomTypes = new List<RoomTypeViewModel>()
            {
                new RoomTypeViewModel()
                {
                     Id = roomType1.Id,
                     Name = roomType1.Name,
                },
                new RoomTypeViewModel()
                {
                     Id = roomType2.Id,
                     Name = roomType2.Name,
                },
                new RoomTypeViewModel()
                {
                     Id = roomType3.Id,
                     Name = roomType3.Name,
                }
            };
            IEnumerable<RoomTypeViewModel> actualRoomTypes = await this.roomTypeService.GetAllRomTypes();

            CollectionAssert.AreEqual(expectedRoomTypes, actualRoomTypes, new RoomTypeViewModelComparator());
        }
        [Test]
        public async Task TestgetAllRoomTypes2()
        {
            roomType2.IsDeleted = true;
            dbContext.SaveChanges();
            IEnumerable<RoomTypeViewModel> expectedRoomTypes = new List<RoomTypeViewModel>()
            {
                new RoomTypeViewModel()
                {
                     Id = roomType1.Id,
                     Name = roomType1.Name,
                },
                new RoomTypeViewModel()
                {
                     Id = roomType2.Id,
                     Name = roomType2.Name,
                },
                new RoomTypeViewModel()
                {
                     Id = roomType3.Id,
                     Name = roomType3.Name,
                }
            };
            IEnumerable<RoomTypeViewModel> actualRoomTypes = await this.roomTypeService.GetAllRomTypes();

            CollectionAssert.AreEqual(expectedRoomTypes, actualRoomTypes, new RoomTypeViewModelComparator());
        }
        [Test]
        public async Task TestCheckIfRoomTypeExistByIdAsyncShouldReturnTrue()
        {
            bool actualResult = await this.roomTypeService.CheckIfRoomTypeExistByIdAsync(roomType1.Id);

            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestCheckIfRoomTypeExistByIdAsyncShouldReturnFalse()
        {
            bool actualResult = await this.roomTypeService.CheckIfRoomTypeExistByIdAsync(10);

            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task CheckIfRoomTypeIsAlreadyDeletedShouldReturnFalse()
        {
            bool actualResult = await this.roomTypeService.CheckIfRoomTypeIsAlreadyDeletedByIdAsync(roomType1.Id);

            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task CheckIfRoomTypeIsAlreadyDeletedShouldReturnTrue()
        {
            roomType1.IsDeleted = true;
            dbContext.SaveChanges();
            bool actualResult = await this.roomTypeService.CheckIfRoomTypeIsAlreadyDeletedByIdAsync(roomType1.Id);

            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestDeleteRoomTypeAsync()
        {
            await this.roomTypeService.DeleteRoomTypeAsync(roomType1.Id);

            Assert.IsTrue(roomType1.IsDeleted);
        }
        [Test]
        public async Task TestCheckIfRoomTypeIsAlreadyRecoveredByIdShouldReturnTrue()
        {
            bool actualResult = await this.roomTypeService.CheckIfRoomTypeIsAlreadyRecoveredByIdAsync(roomType1.Id);
            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestCheckIfRoomTypeIsAlreadyRecoveredByIdShouldReturnFalse()
        {
            roomType1.IsDeleted = true;
            dbContext.SaveChanges();

            bool actualResult = await this.roomTypeService.CheckIfRoomTypeIsAlreadyRecoveredByIdAsync(roomType1.Id);
            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestRecoverRoomTypeById()
        {
            roomType1.IsDeleted = true;
            dbContext.SaveChanges();

            await this.roomTypeService.RecoverRoomTypeByIdAsync(roomType1.Id);

            Assert.IsFalse(roomType1.IsDeleted);
        }
        [Test]
        public async Task TestGetRoomTypeToEdit()
        {
            EditRoomTypeViewModel expectedRoomTypeViewModel = new EditRoomTypeViewModel()
            {
                PercentageIncrease = roomType1.IncreasePercentage,
                Name = roomType1.Name
            };

            EditRoomTypeViewModel actualRoomTypeViewModel = await this.roomTypeService.GetRoomTypeToEditByIdAsync(roomType1.Id);

            Assert.AreEqual(expectedRoomTypeViewModel.Name, actualRoomTypeViewModel.Name);
            Assert.AreEqual(expectedRoomTypeViewModel.PercentageIncrease, actualRoomTypeViewModel.PercentageIncrease);
        }
        [Test]
        public async Task TestEditRoomType()
        {
            EditRoomTypeViewModel editRoomTypeViewModel = new EditRoomTypeViewModel()
            {
                PercentageIncrease = roomType1.IncreasePercentage,
                Name = "Test"
            };
            await this.roomTypeService.EditRoomTypeAsync(roomType1.Id, editRoomTypeViewModel);

            Assert.AreEqual(roomType1.Name, editRoomTypeViewModel.Name);
        }
        [Test]
        public async Task TestCreateRoomType()
        {
            int currentRoomTypesInDataBase = this.dbContext.RoomTypes.Count();
            int expectedRoomTypesInDataBase = currentRoomTypesInDataBase + 1;
            EditRoomTypeViewModel editRoomTypeViewModel = new EditRoomTypeViewModel()
            {
                PercentageIncrease = roomType1.IncreasePercentage,
                Name = "Test"
            };
            await this.roomTypeService.CreateRoomTypeAsync(editRoomTypeViewModel);
            Assert.AreEqual(expectedRoomTypesInDataBase, dbContext.RoomTypes.Count());
        }


        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
