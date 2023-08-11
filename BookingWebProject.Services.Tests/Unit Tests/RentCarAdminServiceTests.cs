namespace BookingWebProject.Services.Tests.Unit_Tests
{
    using Microsoft.EntityFrameworkCore;
    using Areas.Admin.Contracts;
    using Areas.Admin.Services;
    using Data;
    using Areas.Admin.Models.RentCar;
    using Core.Models.Pager;
    using Comparators;
    using static DatabaseSeeder;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using System.ComponentModel.DataAnnotations.Schema;

    [TestFixture]
    public class RentCarAdminServiceTests
    {
        private DbContextOptions<BookingContext> dbOptions;
        private BookingContext dbContext;
        private IRentCarAdminService rentCarAdminService;


        [SetUp]
        public void SetUp()
        {
            dbOptions = new DbContextOptionsBuilder<BookingContext>()
                .UseInMemoryDatabase("BookingSystemInMemory" + Guid.NewGuid().ToString())
                .Options;
            dbContext = new BookingContext(dbOptions, false);
            dbContext.Database.EnsureCreated();
            SeedDatabase(dbContext);
            rentCarAdminService = new RentCarAdminService(dbContext);
        }
        [Test]
        public async Task TestGetAllCars()
        {
            IEnumerable<RentCarAdminViewModel> expectedCars = new List<RentCarAdminViewModel>()
            {
                new RentCarAdminViewModel()
                {
                   Id = car1.Id,
                   MakeType = car1.MakeType,
                   Model = car1.ModelType,
                   RentCount = car1.Reservations.Count(),
                   ImgPath = car1.CarImg,
                   IsDeleted = car1.IsDeleted,
                   Year = car1.Year
                },
                new RentCarAdminViewModel()
                {
                   Id = car2.Id,
                   MakeType = car2.MakeType,
                   Model = car2.ModelType,
                   RentCount = car1.Reservations.Count(),
                   ImgPath = car2.CarImg,
                   IsDeleted = car2.IsDeleted,
                   Year = car2.Year
                }
            };

            IEnumerable<RentCarAdminViewModel> actualCars = await this.rentCarAdminService.GetAllCarsAsync(new Pager(5, 1));

            CollectionAssert.AreEqual(expectedCars, actualCars, new RentCarAdminViewModelComparer());
        }
        [Test]
        public async Task TestGetAllCarsCount()
        {
            int expectedCarsCount = 2;
            int actualCarsCount = await this.rentCarAdminService.GetAllCarsCountAsync();
            Assert.AreEqual(expectedCarsCount, actualCarsCount);
        }
        [Test]
        public async Task TestGetRentCarToEdit()
        {
            EditRentCarViewModel expectedCarModel = new EditRentCarViewModel()
            {
                Id = car1.Id,
                MakeType = car1.MakeType,
                Model = car1.ModelType,
                DoorsCount = car1.DoorsCount,
                CarImg = car1.CarImg,
                FuelCapacity = car1.FuelCapacity,
                FuelConsumption = car1.FuelConsumption,
                Lattitude = car1.Lattitude,
                Longitude = car1.Longitude,
                Location = car1.Location,
                PeopleCapacity = car1.PeopleCapacity,
                Price = car1.PricePerDay,
                Transmission = car1.TransmissionType,
                Year = car1.Year
            };

            EditRentCarViewModel actualCarModel = await this.rentCarAdminService.GetRentCarToEditAsync(car1.Id);

            Assert.AreEqual(expectedCarModel.Id, actualCarModel.Id);
            Assert.AreEqual(expectedCarModel.MakeType, actualCarModel.MakeType);
            Assert.AreEqual(expectedCarModel.Model, actualCarModel.Model);
            Assert.AreEqual(expectedCarModel.DoorsCount, actualCarModel.DoorsCount);
            Assert.AreEqual(expectedCarModel.CarImg, actualCarModel.CarImg);
            Assert.AreEqual(expectedCarModel.FuelCapacity, actualCarModel.FuelCapacity);
            Assert.AreEqual(expectedCarModel.FuelConsumption, actualCarModel.FuelConsumption);
            Assert.AreEqual(expectedCarModel.Lattitude, actualCarModel.Lattitude);
            Assert.AreEqual(expectedCarModel.Longitude, actualCarModel.Longitude);
            Assert.AreEqual(expectedCarModel.Location, actualCarModel.Location);
            Assert.AreEqual(expectedCarModel.PeopleCapacity, actualCarModel.PeopleCapacity);
            Assert.AreEqual(expectedCarModel.Price, actualCarModel.Price);
            Assert.AreEqual(expectedCarModel.Transmission, actualCarModel.Transmission);
            Assert.AreEqual(expectedCarModel.Year, actualCarModel.Year);
        }
        [Test]
        public async Task TestEditCar()
        {
            EditRentCarViewModel expectedCarModel = new EditRentCarViewModel()
            {
                Id = car1.Id,
                MakeType = "Mercedes",
                Model = "GLE 350",
                DoorsCount = car1.DoorsCount,
                CarImg = car1.CarImg,
                FuelCapacity = car1.FuelCapacity,
                FuelConsumption = car1.FuelConsumption,
                Lattitude = car1.Lattitude,
                Longitude = car1.Longitude,
                Location = car1.Location,
                PeopleCapacity = car1.PeopleCapacity,
                Price = car1.PricePerDay,
                Transmission = car1.TransmissionType,
                Year = 2020
            };

            await this.rentCarAdminService.EditCarAsync(car1.Id, expectedCarModel);

            Assert.AreEqual(expectedCarModel.Id, car1.Id);
            Assert.AreEqual(expectedCarModel.MakeType, car1.MakeType);
            Assert.AreEqual(expectedCarModel.Model, car1.ModelType);
            Assert.AreEqual(expectedCarModel.DoorsCount, car1.DoorsCount);
            Assert.AreEqual(expectedCarModel.CarImg, car1.CarImg);
            Assert.AreEqual(expectedCarModel.FuelCapacity, car1.FuelCapacity);
            Assert.AreEqual(expectedCarModel.FuelConsumption, car1.FuelConsumption);
            Assert.AreEqual(expectedCarModel.Lattitude, car1.Lattitude);
            Assert.AreEqual(expectedCarModel.Longitude, car1.Longitude);
            Assert.AreEqual(expectedCarModel.Location, car1.Location);
            Assert.AreEqual(expectedCarModel.PeopleCapacity, car1.PeopleCapacity);
            Assert.AreEqual(expectedCarModel.Price, car1.PricePerDay);
            Assert.AreEqual(expectedCarModel.Transmission, car1.TransmissionType);
            Assert.AreEqual(expectedCarModel.Year, car1.Year);
        }
        [Test]
        public async Task TestIsCarExistByIdShouldReturnTrue()
        {
            bool actualResult = await this.rentCarAdminService.IsCarExistByIdAsync(car1.Id);

            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestIsCarExistByIdShouldReturnFalse()
        {
            bool actualResult = await this.rentCarAdminService.IsCarExistByIdAsync(3);

            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestCheckCarIsAlreadyDeletedShouldReturnTrue()
        {
            car1.IsDeleted = true;
            dbContext.SaveChanges();


            bool actualResult = await this.rentCarAdminService.CheckCarIsAlreadyDeleted(car1.Id);

            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestCheckCarIsAlreadyDeletedShouldReturnFalse()
        {

            bool actualResult = await this.rentCarAdminService.CheckCarIsAlreadyDeleted(car1.Id);

            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestDeleteCar()
        {
            await this.rentCarAdminService.DeleteCarByIdAsync(car1.Id);
            Assert.IsTrue(car1.IsDeleted);
        }
        [Test]
        public async Task TestCarIsAlreadyRecoverdShouldReturnTrue()
        {
            bool actualResult = await this.rentCarAdminService.CheckCarIsAlreadyRecoveredAsync(car1.Id);

            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestCarIsAlreadyRecoverdShouldReturnFalse()
        {
            await this.rentCarAdminService.DeleteCarByIdAsync(car1.Id);
            bool actualResult = await this.rentCarAdminService.CheckCarIsAlreadyRecoveredAsync(car1.Id);

            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestRecoverCar()
        {
            await this.rentCarAdminService.DeleteCarByIdAsync(car1.Id);
            await this.rentCarAdminService.RecoverCarByIdAsync(car1.Id);


            Assert.IsFalse(car1.IsDeleted);
        }
        [Test]
        public async Task TestCreateCarAsync()
        {
            int currrentCarsCountInDatabase = dbContext.RentCars.Count();
            int expectedCountCarsCountInDatabase = currrentCarsCountInDatabase + 1;

            EditRentCarViewModel car = new EditRentCarViewModel()
            {
                Id = 3,
                MakeType = "Mercedes",
                Model = "GLE 350",
                DoorsCount = car1.DoorsCount,
                CarImg = car1.CarImg,
                FuelCapacity = car1.FuelCapacity,
                FuelConsumption = car1.FuelConsumption,
                Lattitude = car1.Lattitude,
                Longitude = car1.Longitude,
                Location = car1.Location,
                PeopleCapacity = car1.PeopleCapacity,
                Price = car1.PricePerDay,
                Transmission = car1.TransmissionType,
                Year = 2020
            };

            await this.rentCarAdminService.CreateCarAsync(car);
            Assert.AreEqual(expectedCountCarsCountInDatabase, dbContext.RentCars.Count());
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
