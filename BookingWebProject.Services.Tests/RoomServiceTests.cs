namespace BookingWebProject.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts;
    using Data;
    using Core.Services;
    using Core.Models.Room;
    using Services.Tests.Comparators;
    using Core.Models.RoomPackage;
    using static DatabaseSeeder;

    [TestFixture]
    public class RoomServiceTests
    {
        private BookingContext dbContext;
        private IRoomService roomService;
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
            this.roomService = new RoomService(this.dbContext);
        }
        [Test]
        public async Task TestGetHotelRooms()
        {
            IEnumerable<RoomViewModel> expectedHotelRooms = new List<RoomViewModel>()
            {
                new RoomViewModel()
                {
                      Id = room1.Id,
                      PricePerNight = room1.PricePerNight + (room1.PricePerNight * room1.RoomType.IncreasePercentage) / 100,
                      Description = room1.Description,
                      RoomCapacity = room1.Capacity,
                      RoomType = room1.RoomType.Name,
                      HotelName = room1.Hotel.Name,
                },
                new RoomViewModel()
                {
                      Id = room2.Id,
                      PricePerNight = room2.PricePerNight + (room2.PricePerNight * room2.RoomType.IncreasePercentage) / 100,
                      Description = room2.Description,
                      RoomCapacity = room2.Capacity,
                      RoomType = room2.RoomType.Name,
                      HotelName = room2.Hotel.Name,
                },
                new RoomViewModel()
                {
                      Id = room3.Id,
                      PricePerNight = room3.PricePerNight + (room3.PricePerNight * room3.RoomType.IncreasePercentage) / 100,
                      Description = room3.Description,
                      RoomCapacity = room3.Capacity,
                      RoomType = room3.RoomType.Name,
                      HotelName = room3.Hotel.Name,
                }
            };


            IEnumerable<RoomViewModel> actualHotelRooms = await this.roomService.GetHotelRooms(hotel1.Id);

            CollectionAssert.AreEqual(expectedHotelRooms, actualHotelRooms, new RoomViewModelComparer());
        }
        [Test]
        public async Task TestRoomExistMethodShouldReturnTrue()
        {
            bool actualResult = await this.roomService.IsRoomExistAsync(1);

            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestRoomExistMethodShouldReturnFalse()
        {
            bool actualResult = await this.roomService.IsRoomExistAsync(11);

            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestRoomExistMethodShouldReturnFalse1()
        {
            room1.IsDeleted = true;
            dbContext.SaveChanges();

            bool actualResult = await this.roomService.IsRoomExistAsync(1);

            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestGetORderRoomInfMethod()
        {
            int expectedResult = 0;
            RoomOrderInfoViewModel expectedRoomOderInfoViewModel = new RoomOrderInfoViewModel()
            {
                Id = room1.Id,
                HotelId = room1.HotelId,
                Description = room1.Description,
                Name = room1.RoomType.Name,
                RoomCapacity = room1.Capacity,
                Price = room1.PricePerNight + (room1.PricePerNight * room1.RoomType.IncreasePercentage) / 100,
            };

            RoomOrderInfoViewModel actualRoomOderInfoViewModel = await this.roomService.GetORderRoomInfoAsync(room1.Id);

            Assert.AreEqual(expectedResult, new RoomOrderInfoViewModelComparer().Compare(expectedRoomOderInfoViewModel, actualRoomOderInfoViewModel));
        }
        [Test]
        public async Task TestGetRoomToBookAsync()
        {

            int expectedResult = 0;

            RoomOrderInfoViewModel roomOrderInfoViewModel = new RoomOrderInfoViewModel()
            {
                Id = room1.Id,
                HotelId = room1.HotelId,
                Description = room1.Description,
                Name = room1.RoomType.Name,
                RoomCapacity = room1.Capacity,
                Price = room1.PricePerNight + (room1.PricePerNight * room1.RoomType.IncreasePercentage) / 100,
            };
            RoomPackageViewModel package = new RoomPackageViewModel()
            {
                Id = roomPackage2.Id,
                Name = roomPackage2.Name,
                Price = roomPackage2.Price
            };

            BookRoomViewModel expectedRoomToBookModel = new BookRoomViewModel()
            {
                AdultsCount = roomOrderInfoViewModel.AdultsCount,
                ChildrenCount = roomOrderInfoViewModel.ChildrenCount,
                HotelId = roomOrderInfoViewModel.HotelId,
                Name = roomOrderInfoViewModel.Name,
                SelectedPackage = package
            };
            decimal childrenPrice = roomOrderInfoViewModel.ChildrenCount > 0 ? (roomOrderInfoViewModel.Price - (roomOrderInfoViewModel.Price * 60 / 100)) * roomOrderInfoViewModel.ChildrenCount : 0;
            expectedRoomToBookModel.Price = (roomOrderInfoViewModel.Price * roomOrderInfoViewModel.AdultsCount) + childrenPrice;

            BookRoomViewModel actualRoomToBookModel = await this.roomService.GetRoomToBookAsync(roomOrderInfoViewModel, package);

            Assert.AreEqual(expectedResult, new BookRoomViewModelComparer().Compare(expectedRoomToBookModel, actualRoomToBookModel));
        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
