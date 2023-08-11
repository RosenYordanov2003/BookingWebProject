using BookingWebProject.Services.Tests.Comparators;

namespace BookingWebProject.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts;
    using Data;
    using Core.Services;
    using Core.Models.RentCar;
    using Core.Models.RentCar.Enums;
    using Core.Models.Pager;
    using Infrastructure.Data.Enums;
    using static DatabaseSeeder;

    [TestFixture]
    public class RentCarServiceTests
    {
        private DbContextOptions<BookingContext> dbOptions;
        private BookingContext dbContext;
        private IRentCarService rentCarService;

        [SetUp]
        public void SetUp()
        {
            dbOptions = new DbContextOptionsBuilder<BookingContext>()
                .UseInMemoryDatabase("BookingSystemInMemory" + Guid.NewGuid().ToString())
                .Options;
            dbContext = new BookingContext(dbOptions, false);
            dbContext.Database.EnsureCreated();
            SeedDatabase(dbContext);
            rentCarService = new RentCarService(dbContext);
        }
        [Test]
        public async Task TestGetRentCarsCountShouldReturn2()
        {
            int expectedCountRentCars = 2;
            CarQuerViewModel carQuerViewModel = new CarQuerViewModel()
            {
                Brand = "Bmw",
                CarSortOption = CarSortOption.YearDescending,
                CurrentPage = 1,
                Pager = new Pager(10, 1),
            };
            int actualCount = await rentCarService.GetCarsCountAsync(carQuerViewModel);
            Assert.AreEqual(expectedCountRentCars, actualCount);
        }
        [Test]
        public async Task TestGetRentCarsCountShouldReturn1()
        {
            int expectedCountRentCars = 1;
            CarQuerViewModel carQuerViewModel = new CarQuerViewModel()
            {
                Brand = "Bmw",
                CarSortOption = CarSortOption.YearDescending,
                CurrentPage = 1,
                Pager = new Pager(10, 1),
                MinYear = 2020
            };
            int actualCount = await rentCarService.GetCarsCountAsync(carQuerViewModel);
            Assert.AreEqual(expectedCountRentCars, actualCount);
        }
        [Test]
        public async Task TestFilteringAndSortingRentCarMethod1()
        {
            AllCarsSortedAndFilteredDataModel expectedModel = new AllCarsSortedAndFilteredDataModel()
            {
                Cars = new List<CarViewModel>()
                {
                    new CarViewModel()
                    {
                        Id = car2.Id,
                        CarImg = car2.CarImg,
                        Location = car2.Location,
                        MakeType = car2.MakeType,
                        Model = car2.ModelType,
                        PricePerDay = car2.PricePerDay,
                        Year = car2.Year
                    },
                    new CarViewModel()
                    {
                        Id = car1.Id,
                        CarImg = car1.CarImg,
                        Location = car1.Location,
                        MakeType = car1.MakeType,
                        Model = car1.ModelType,
                        PricePerDay = car1.PricePerDay,
                        Year = car1.Year
                    }
                }
            };
            CarQuerViewModel carQuerViewModel = new CarQuerViewModel()
            {
                Brand = "Bmw",
                CarSortOption = CarSortOption.YearAscending,
                CurrentPage = 1,
                Pager = new Pager(10, 1),
                MinYear = 2015
            };

            AllCarsSortedAndFilteredDataModel actualModel = await rentCarService.AllCarsSortedAndFilteredDataModelAsync(carQuerViewModel);

            CollectionAssert.AreEqual(expectedModel.Cars, actualModel.Cars, new CarViewModelComparer());
        }
        [Test]
        public async Task TestFilteringAndSortingRentCarMethod2()
        {
            AllCarsSortedAndFilteredDataModel expectedModel = new AllCarsSortedAndFilteredDataModel()
            {
                Cars = new List<CarViewModel>()
                {
                    new CarViewModel()
                    {
                        Id = car1.Id,
                        CarImg = car1.CarImg,
                        Location = car1.Location,
                        MakeType = car1.MakeType,
                        Model = car1.ModelType,
                        PricePerDay = car1.PricePerDay,
                        Year = car1.Year
                    },
                    new CarViewModel()
                    {
                        Id = car2.Id,
                        CarImg = car2.CarImg,
                        Location = car2.Location,
                        MakeType = car2.MakeType,
                        Model = car2.ModelType,
                        PricePerDay = car2.PricePerDay,
                        Year = car2.Year
                    },
                }
            };
            CarQuerViewModel carQuerViewModel = new CarQuerViewModel()
            {
                Brand = "Bmw",
                CarSortOption = CarSortOption.PriceDescending,
                CurrentPage = 1,
                Pager = new Pager(10, 1),
                MinYear = 2015
            };

            AllCarsSortedAndFilteredDataModel actualModel = await rentCarService.AllCarsSortedAndFilteredDataModelAsync(carQuerViewModel);

            CollectionAssert.AreEqual(expectedModel.Cars, actualModel.Cars, new CarViewModelComparer());
        }
        [Test]
        public async Task TestFilteringAndSortingRentCarMethod3()
        {
            AllCarsSortedAndFilteredDataModel expectedModel = new AllCarsSortedAndFilteredDataModel()
            {
                Cars = new List<CarViewModel>()
                {
                    new CarViewModel()
                    {
                        Id = car2.Id,
                        CarImg = car2.CarImg,
                        Location = car2.Location,
                        MakeType = car2.MakeType,
                        Model = car2.ModelType,
                        PricePerDay = car2.PricePerDay,
                        Year = car2.Year
                    },
                    new CarViewModel()
                    {
                        Id = car1.Id,
                        CarImg = car1.CarImg,
                        Location = car1.Location,
                        MakeType = car1.MakeType,
                        Model = car1.ModelType,
                        PricePerDay = car1.PricePerDay,
                        Year = car1.Year
                    }
                }
            };
            CarQuerViewModel carQuerViewModel = new CarQuerViewModel()
            {
                Brand = "Bmw",
                CarSortOption = CarSortOption.PriceAscending,
                CurrentPage = 1,
                Pager = new Pager(10, 1),
                MinYear = 2015
            };

            AllCarsSortedAndFilteredDataModel actualModel = await rentCarService.AllCarsSortedAndFilteredDataModelAsync(carQuerViewModel);

            CollectionAssert.AreEqual(expectedModel.Cars, actualModel.Cars, new CarViewModelComparer());
        }
        [Test]
        public async Task TestFilteringAndSortingRentCarMethod4()
        {
            AllCarsSortedAndFilteredDataModel expectedModel = new AllCarsSortedAndFilteredDataModel()
            {
                Cars = new List<CarViewModel>()
                {

                }
            };
            CarQuerViewModel carQuerViewModel = new CarQuerViewModel()
            {
                Brand = "Bmw",
                CarSortOption = CarSortOption.PriceAscending,
                CurrentPage = 1,
                Pager = new Pager(10, 1),
                MinPrice = 200,
            };

            AllCarsSortedAndFilteredDataModel actualModel = await rentCarService.AllCarsSortedAndFilteredDataModelAsync(carQuerViewModel);

            CollectionAssert.AreEqual(expectedModel.Cars, actualModel.Cars, new CarViewModelComparer());
        }

        [Test]
        public async Task TestFilteringAndSortingRentCarMethod5()
        {
            AllCarsSortedAndFilteredDataModel expectedModel = new AllCarsSortedAndFilteredDataModel()
            {
                Cars = new List<CarViewModel>()
                {
                    new CarViewModel()
                    {
                        Id = car2.Id,
                        CarImg = car2.CarImg,
                        Location = car2.Location,
                        MakeType = car2.MakeType,
                        Model = car2.ModelType,
                        PricePerDay = car2.PricePerDay,
                        Year = car2.Year
                    }
                }
            };
            CarQuerViewModel carQuerViewModel = new CarQuerViewModel()
            {
                Brand = "Bmw",
                CarSortOption = CarSortOption.PriceAscending,
                CurrentPage = 1,
                Pager = new Pager(10, 1),
                MaxPrice = 170
            };

            AllCarsSortedAndFilteredDataModel actualModel = await rentCarService.AllCarsSortedAndFilteredDataModelAsync(carQuerViewModel);

            CollectionAssert.AreEqual(expectedModel.Cars, actualModel.Cars, new CarViewModelComparer());
        }
        [Test]
        public async Task TestFilteringAndSortingRentCarMethod6()
        {
            AllCarsSortedAndFilteredDataModel expectedModel = new AllCarsSortedAndFilteredDataModel()
            {
                Cars = new List<CarViewModel>()
                {
                    new CarViewModel()
                    {
                        Id = car2.Id,
                        CarImg = car2.CarImg,
                        Location = car2.Location,
                        MakeType = car2.MakeType,
                        Model = car2.ModelType,
                        PricePerDay = car2.PricePerDay,
                        Year = car2.Year
                    }
                }
            };
            CarQuerViewModel carQuerViewModel = new CarQuerViewModel()
            {
                Brand = "Bmw",
                CarSortOption = CarSortOption.PriceAscending,
                CurrentPage = 1,
                Pager = new Pager(10, 1),
                MaxYear = 2019
            };

            AllCarsSortedAndFilteredDataModel actualModel = await rentCarService.AllCarsSortedAndFilteredDataModelAsync(carQuerViewModel);

            CollectionAssert.AreEqual(expectedModel.Cars, actualModel.Cars, new CarViewModelComparer());
        }
        [Test]
        public async Task TestFilteringAndSortingRentCarMethod7()
        {
            car2.DoorsCount = 3;
            dbContext.SaveChanges();
            AllCarsSortedAndFilteredDataModel expectedModel = new AllCarsSortedAndFilteredDataModel()
            {
                Cars = new List<CarViewModel>()
                {
                    new CarViewModel()
                    {
                        Id = car1.Id,
                        CarImg = car1.CarImg,
                        Location = car1.Location,
                        MakeType = car1.MakeType,
                        Model = car1.ModelType,
                        PricePerDay = car1.PricePerDay,
                        Year = car1.Year
                    }
                }
            };
            CarQuerViewModel carQuerViewModel = new CarQuerViewModel()
            {
                Brand = "Bmw",
                CarSortOption = CarSortOption.PriceAscending,
                CurrentPage = 1,
                Pager = new Pager(10, 1),
                DoorsCount = 4,
            };

            AllCarsSortedAndFilteredDataModel actualModel = await rentCarService.AllCarsSortedAndFilteredDataModelAsync(carQuerViewModel);

            CollectionAssert.AreEqual(expectedModel.Cars, actualModel.Cars, new CarViewModelComparer());
        }
        [Test]
        public async Task TestFilteringAndSortingRentCarMethod8()
        {
            car1.MakeType = "Mercedes";
            dbContext.SaveChanges();

            AllCarsSortedAndFilteredDataModel expectedModel = new AllCarsSortedAndFilteredDataModel()
            {
                Cars = new List<CarViewModel>()
                {

                    new CarViewModel()
                    {
                        Id = car2.Id,
                        CarImg = car2.CarImg,
                        Location = car2.Location,
                        MakeType = car2.MakeType,
                        Model = car2.ModelType,
                        PricePerDay = car2.PricePerDay,
                        Year = car2.Year
                    },
                    new CarViewModel()
                    {
                        Id = car1.Id,
                        CarImg = car1.CarImg,
                        Location = car1.Location,
                        MakeType = car1.MakeType,
                        Model = car1.ModelType,
                        PricePerDay = car1.PricePerDay,
                        Year = car1.Year
                    }
                }
            };
            CarQuerViewModel carQuerViewModel = new CarQuerViewModel()
            {
                CarSortOption = CarSortOption.MakeTypeAscending,
                CurrentPage = 1,
                Pager = new Pager(10, 1),
            };

            AllCarsSortedAndFilteredDataModel actualModel = await rentCarService.AllCarsSortedAndFilteredDataModelAsync(carQuerViewModel);

            CollectionAssert.AreEqual(expectedModel.Cars, actualModel.Cars, new CarViewModelComparer());
        }
        [Test]
        public async Task TestFilteringAndSortingRentCarMethod9()
        {
            car1.MakeType = "Mercedes";
            dbContext.SaveChanges();

            AllCarsSortedAndFilteredDataModel expectedModel = new AllCarsSortedAndFilteredDataModel()
            {
                Cars = new List<CarViewModel>()
                {
                    new CarViewModel()
                    {
                        Id = car1.Id,
                        CarImg = car1.CarImg,
                        Location = car1.Location,
                        MakeType = car1.MakeType,
                        Model = car1.ModelType,
                        PricePerDay = car1.PricePerDay,
                        Year = car1.Year
                    },
                    new CarViewModel()
                    {
                        Id = car2.Id,
                        CarImg = car2.CarImg,
                        Location = car2.Location,
                        MakeType = car2.MakeType,
                        Model = car2.ModelType,
                        PricePerDay = car2.PricePerDay,
                        Year = car2.Year
                    }
                }
            };
            CarQuerViewModel carQuerViewModel = new CarQuerViewModel()
            {
                CarSortOption = CarSortOption.Default,
                CurrentPage = 1,
                Pager = new Pager(10, 1),
            };

            AllCarsSortedAndFilteredDataModel actualModel = await rentCarService.AllCarsSortedAndFilteredDataModelAsync(carQuerViewModel);

            CollectionAssert.AreEqual(expectedModel.Cars, actualModel.Cars, new CarViewModelComparer());
        }
        [Test]
        public async Task TestGetOrderCarAsyncMethod()
        {
            int expectedResult = 0;
            CarViewModel expectedModel = new CarViewModel()
            {
                Id = car1.Id,
                CarImg = car1.CarImg,
                Location = car1.Location,
                MakeType = car1.MakeType,
                Model = car1.ModelType,
                PricePerDay = car1.PricePerDay,
                Year = car1.Year
            };

            CarViewModel actualModel = await rentCarService.GetOrderCarAsync(car1.Id);
            Assert.AreEqual(0, new CarViewModelComparer().Compare(expectedModel, actualModel));
        }
        [Test]
        public async Task TestCheckIfCarExistByShouldReturnTrue()
        {
            bool actualResult = await rentCarService.CheckIfCarExistByIdAsync(1);

            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestCheckIfCarExistByShouldReturnFalse()
        {
            bool actualResult = await rentCarService.CheckIfCarExistByIdAsync(11);

            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestGetCarBrandsShouldReturnBmw()
        {
            IEnumerable<string> expectedBrands = new List<string>() { "Bmw" };

            IEnumerable<string> actualBrands = await rentCarService.GetAllBrandsAsync();

            CollectionAssert.AreEqual(expectedBrands, actualBrands);
        }
        [Test]
        public async Task TestGetCarBrandsShouldReturnNothing()
        {
            car1.IsDeleted = true;
            car2.IsDeleted = true;
            dbContext.SaveChanges();

            IEnumerable<string> expectedBrands = new List<string>() { };

            IEnumerable<string> actualBrands = await rentCarService.GetAllBrandsAsync();

            CollectionAssert.AreEqual(expectedBrands, actualBrands);
        }
        [Test]
        public async Task TestFindCarById()
        {
            int expectedResult = 0;
            CarDetailsViewModel expectedModel = new CarDetailsViewModel()
            {
                Id = car1.Id,
                MakeType = car1.MakeType,
                Model = car1.ModelType,
                PeopleCapacity = car1.PeopleCapacity,
                Location = car1.Location,
                Longitude = car1.Longitude,
                Latitude = car1.Lattitude,
                CarImg = car1.CarImg,
                DoorsCount = car1.DoorsCount,
                FuelCapacity = car1.FuelCapacity,
                FuelConsumption = car1.FuelConsumption,
                PricePerDay = car1.PricePerDay,
                Year = car1.Year,
                TransmissionType = car1.TransmissionType == TransmissionType.AutomaticTransmission ? "Automatic Transmission" : "Manual Transmission"
            };

            CarDetailsViewModel actualModel = await rentCarService.FindCarByIdAsync(car1.Id);

            Assert.AreEqual(expectedResult, new CarDetailsViewModelComparer().Compare(expectedModel, actualModel));
        }
        [Test]
        public async Task TestGetCarsByBrand()
        {
            IEnumerable<CarBrandViewModel> expectedCarBrandViewModels = new List<CarBrandViewModel>()
            {
                new CarBrandViewModel()
                {
                    Id = car2.Id,
                    MakeType = car2.MakeType,
                    Model = car2.ModelType,
                    CarImg = car2.CarImg
                }
            };

            IEnumerable<CarBrandViewModel> actualCarBrandViewModels = await rentCarService.GetCarsByBrandAsync(car1.MakeType, car1.Id);

            CollectionAssert.AreEqual(expectedCarBrandViewModels, actualCarBrandViewModels, new CarBrandViewModelComparer());
        }


        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
