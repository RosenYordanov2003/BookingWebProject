namespace BookingWebProject.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts;
    using Data;
    using Core.Services;
    using static DatabaseSeeder;
    using BookingWebProject.Core.Models.Reservation;
    using BookingWebProject.Core.Models.RentCar;
    using BookingWebProject.Core.Models.User;
    using BookingWebProject.Core.Models.Room;
    using BookingWebProject.Core.Models.RoomPackage;

    [TestFixture]
    public class ReservationServiceTests
    {
        private DbContextOptions<BookingContext> dbOptions;
        private BookingContext dbContext;
        private IReservationService reservationService;

        [SetUp]
        public void SetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<BookingContext>()
               .UseInMemoryDatabase("BookingSystemInMemory" + Guid.NewGuid().ToString())
               .Options;
            this.dbContext = new BookingContext(this.dbOptions, false);
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(dbContext);
            this.reservationService = new ReservationService(this.dbContext);
        }
        [Test]
        public async Task TestCarIsAlreadyReservedShouldReturnTrue1()
        {
            DateTime startDate = DateTime.Parse("2023-08-04 00:00:00.0000000");
            DateTime endDate = DateTime.Parse("2023-08-09 00:00:00.0000000");

            bool actualResult = await this.reservationService.CheckCarIsAlreadyReservedAsync(18, startDate, endDate);

            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestCarIsAlreadyReservedShouldReturnTrue2()
        {
            DateTime startDate = DateTime.Parse("2023-08-06 00:00:00.0000000");
            DateTime endDate = DateTime.Parse("2023-08-13 00:00:00.0000000");

            bool actualResult = await this.reservationService.CheckCarIsAlreadyReservedAsync(18, startDate, endDate);

            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestCarIsAlreadyReservedShouldReturnTrue3()
        {
            DateTime startDate = DateTime.Parse("2023-08-08 00:00:00.0000000");
            DateTime endDate = DateTime.Parse("2023-08-09 00:00:00.0000000");

            bool actualResult = await this.reservationService.CheckCarIsAlreadyReservedAsync(18, startDate, endDate);

            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestCarIsAlreadyReservedShouldReturnFalse()
        {
            DateTime startDate = DateTime.Parse("2023-07-21 00:00:00.0000000");
            DateTime endDate = DateTime.Parse("2023-08-01 00:00:00.0000000");

            bool actualResult = await this.reservationService.CheckCarIsAlreadyReservedAsync(18, startDate, endDate);

            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestCarIsAlreadyReservedShouldReturnFalse2()
        {
            DateTime startDate = DateTime.Parse("2023-08-10 00:00:00.0000000");
            DateTime endDate = DateTime.Parse("2023-08-13 00:00:00.0000000");

            bool actualResult = await this.reservationService.CheckCarIsAlreadyReservedAsync(18, startDate, endDate);

            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestRentCarMethod()
        {
            int expectedRentCarReservationsCount = 4;

            DateTime startDate = DateTime.Parse("2023-08-10 00:00:00.0000000");
            DateTime endDate = DateTime.Parse("2023-08-13 00:00:00.0000000");

            RentCarReservationViewModel rentCarReservationModel = new RentCarReservationViewModel()
            {
                CarlViewModel = new CarViewModel()
                {
                    Id = car2.Id,
                    CarImg = car2.CarImg,
                    Location = car2.Location,
                    MakeType = car2.MakeType,
                    Model = car2.ModelType,
                    PricePerDay = car2.PricePerDay,
                    Year = car2.Year
                },
                User = new UserViewModel()
                {
                    Id = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"),
                    Email = "testuser123@gmail.com",
                    FirstName = "Test",
                    LastName = "Testov"
                },
                StartRentDate = startDate,
                EndRentDate = endDate,
            };

            await this.reservationService.RentCarAsync(18, rentCarReservationModel);

            Assert.AreEqual(expectedRentCarReservationsCount, car2.Reservations.Count());
        }
        [Test]
        public async Task TestIsThereAvalilableRoomShouldReturnTrue1()
        {

            DateTime startDate = DateTime.Parse("2023-08-01 00:00:00.0000000");
            DateTime endDate = DateTime.Parse("2023-08-04 00:00:00.0000000");

            bool actualResult = await this.reservationService.IsThereAvalilableRoomAsync(1, "Apartment", startDate, endDate);

            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestIsThereAvalilableRoomShouldReturnTrue2()
        {
            DateTime startDate = DateTime.Parse("2023-08-10 00:00:00.0000000");
            DateTime endDate = DateTime.Parse("2023-08-14 00:00:00.0000000");

            bool actualResult = await this.reservationService.IsThereAvalilableRoomAsync(1, "Apartment", startDate, endDate);

            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestIsThereAvalilableRoomShouldReturnFalse1()
        {
            DateTime startDate = DateTime.Parse("2023-08-07 00:00:00.0000000");
            DateTime endDate = DateTime.Parse("2023-08-09 00:00:00.0000000");

            bool actualResult = await this.reservationService.IsThereAvalilableRoomAsync(1, "Apartment", startDate, endDate);

            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestIsThereAvalilableRoomShouldReturnFalse2()
        {
            DateTime startDate = DateTime.Parse("2023-08-03 00:00:00.0000000");
            DateTime endDate = DateTime.Parse("2023-08-12 00:00:00.0000000");

            bool actualResult = await this.reservationService.IsThereAvalilableRoomAsync(1, "Apartment", startDate, endDate);

            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestBookRoomMethod()
        {
            DateTime startDate = DateTime.Parse("2023-10-03 00:00:00.0000000");
            DateTime endDate = DateTime.Parse("2023-08-17 00:00:00.0000000");

            int expectedHotelReservationsCount = 5;

            decimal price = room1.PricePerNight + (room1.PricePerNight * room1.RoomType.IncreasePercentage) / 100;
            RoomReservationViewModel roomReservationViewModel = new RoomReservationViewModel()
            {
                Room = new BookRoomViewModel()
                {
                    ChildrenCount = 1,
                    AdultsCount = 2,
                    HotelId = 1,
                    Name = roomPackage1.Name,
                    Price = (price + roomPackage2.Price) * 3,
                    SelectedPackage = new RoomPackageViewModel()
                    {
                        Name = roomPackage2.Name,
                        Id = roomPackage2.Id,
                        Price = roomPackage2.Price
                    }
                },
                User = new UserViewModel()
                {
                    Id = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"),
                    Email = "testuser123@gmail.com",
                    FirstName = "Test",
                    LastName = "Testov"
                },
               StartDate = startDate,
               EndDate = endDate,
            };
            await this.reservationService.BookRoomAsync(roomReservationViewModel, Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"));

            Assert.AreEqual(expectedHotelReservationsCount, hotel1.Reservations.Count);
        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
