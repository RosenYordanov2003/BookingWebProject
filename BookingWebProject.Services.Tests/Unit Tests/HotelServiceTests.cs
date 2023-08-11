namespace BookingWebProject.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Core.Contracts;
    using Core.Services;
    using Core.Models.Hotel;
    using Core.Models.Hotel.Enums;
    using Comparators;
    using Core.Models.Pager;
    using static DatabaseSeeder;

    [TestFixture]
    public class HotelServiceTests
    {
        private DbContextOptions<BookingContext> dbOptions;
        private BookingContext dbContext;
        private IHotelService hotelService;

        [SetUp]
        public void SetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<BookingContext>()
                .UseInMemoryDatabase("BookingSystemInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new BookingContext(this.dbOptions, false);
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(dbContext);
            this.hotelService = new HotelService(this.dbContext);
        }


        [Test]
        public async Task TestIsHotelExistsByHotelIdShouldReturnTrue()
        {
            bool actualResult = await this.hotelService.CheckIsHotelExistAsync(hotel1.Id);

            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestIsHotelExistsByIdShouldReturnFalse()
        {
            bool actualResult = await this.hotelService.CheckIsHotelExistAsync(100);

            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestHotelFiltersCountShouldReturn1()
        {
            HotelQueryViewModel hotelQueryViewModel = new HotelQueryViewModel()
            {
                SelectedBenefitIds = new List<int>() { 1 },
                Country = "all",
                City = "all",
                HotelSortOption = HotelSortOption.ByStarRatingAscending,
            };
            int expectedResult = 2;
            int actualResult = await hotelService.GetCountAsync(hotelQueryViewModel);

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public async Task TetGetTopHotelsByReservationCountShouldBeEqual()
        {
            IEnumerable<HotelCardViewModel> expectedTopHotels = new List<HotelCardViewModel>()
            {
                new HotelCardViewModel()
                {
                   Id = hotel1.Id,
                   City = hotel1.City,
                   Country = hotel1.Country,
                   Name = hotel1.Name,
                   Stars = hotel1.StarRating,
                },
                new HotelCardViewModel()
                {
                   Id = hotel2.Id,
                   City = hotel2.City,
                   Country = hotel2.Country,
                   Name = hotel2.Name,
                   Stars = hotel2.StarRating,
                },
                new HotelCardViewModel()
                {
                   Id = hotel3.Id,
                   City = hotel3.City,
                   Country = hotel3.Country,
                   Name = hotel3.Name,
                   Stars = hotel3.StarRating,
                },
                new HotelCardViewModel()
                {
                   Id = hotel4.Id,
                   City = hotel4.City,
                   Country = hotel4.Country,
                   Name = hotel4.Name,
                   Stars = hotel4.StarRating,
                }
            };

            IEnumerable<HotelCardViewModel> actualTopHotels = await this.hotelService.GetTopHotelsAsync();

            CollectionAssert.AreEqual(expectedTopHotels, actualTopHotels, new HotelCardViewModelComparer());
        }
        [Test]
        public async Task TetGetTopHotelsByReservationCountShouldNotBeEqual()
        {
            IEnumerable<HotelCardViewModel> expectedTopHotels = new List<HotelCardViewModel>()
            {
                new HotelCardViewModel()
                {
                   Id = hotel2.Id,
                   City = hotel2.City,
                   Country = hotel2.Country,
                   Name = hotel2.Name,
                   Stars = hotel2.StarRating,
                },
                 new HotelCardViewModel()
                {
                   Id = hotel1.Id,
                   City = hotel1.City,
                   Country = hotel1.Country,
                   Name = hotel1.Name,
                   Stars = hotel1.StarRating,
                },
                new HotelCardViewModel()
                {
                   Id = hotel3.Id,
                   City = hotel3.City,
                   Country = hotel3.Country,
                   Name = hotel3.Name,
                   Stars = hotel3.StarRating,
                },
                new HotelCardViewModel()
                {
                   Id = hotel4.Id,
                   City = hotel4.City,
                   Country = hotel4.Country,
                   Name = hotel4.Name,
                   Stars = hotel4.StarRating,
                }
            };

            IEnumerable<HotelCardViewModel> actualTopHotels = await this.hotelService.GetTopHotelsAsync();

            CollectionAssert.AreNotEqual(expectedTopHotels, actualTopHotels, new HotelCardViewModelComparer());
        }
        [Test]
        public async Task TestHotelsFiltering1()
        {
            AllHotelsSortedAndFilteredDataModel expectedHotels = new AllHotelsSortedAndFilteredDataModel()
            {
                Hotels = new List<HotelViewModel>()
                {
                  new HotelViewModel()
                  {
                    Id = hotel1.Id,
                    City = hotel1.City,
                    Country = hotel1.Country,
                    Name = hotel1.Name,
                    StarRating = hotel1.StarRating
                  },

                  new HotelViewModel()
                  {
                    Id = hotel3.Id,
                    City = hotel3.City,
                    Country = hotel3.Country,
                    Name = hotel3.Name,
                    StarRating = hotel1.StarRating
                  }
                }
            };

            HotelQueryViewModel hotelQueryViewModel = new HotelQueryViewModel()
            {
                City = "all",
                Country = "all",
                SelectedBenefitIds = new List<int>() { 1, 2 },
                HotelSortOption = HotelSortOption.ByCityDescending,
                Pager = new Pager(4, 1)
            };

            AllHotelsSortedAndFilteredDataModel actualHotels = await this.hotelService.GetAllHotelsSortedAndFilteredAsync(Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"), hotelQueryViewModel);

            CollectionAssert.AreEqual(expectedHotels.Hotels, actualHotels.Hotels, new HotelViewModelComparer());
        }
        [Test]
        public async Task TestHotelsFiltering2()
        {
            AllHotelsSortedAndFilteredDataModel expectedHotels = new AllHotelsSortedAndFilteredDataModel()
            {
                Hotels = new List<HotelViewModel>()
                {
                  new HotelViewModel()
                  {
                    Id = hotel1.Id,
                    City = hotel1.City,
                    Country = hotel1.Country,
                    Name = hotel1.Name,
                    StarRating = hotel1.StarRating
                  },

                  new HotelViewModel()
                  {
                    Id = hotel3.Id,
                    City = hotel3.City,
                    Country = hotel3.Country,
                    Name = hotel3.Name,
                    StarRating = hotel1.StarRating
                  }
                }
            };

            HotelQueryViewModel hotelQueryViewModel = new HotelQueryViewModel()
            {
                City = "all",
                Country = "all",
                SelectedBenefitIds = new List<int>() { 1, 2 },
                HotelSortOption = HotelSortOption.Default,
                Pager = new Pager(4, 1)
            };

            AllHotelsSortedAndFilteredDataModel actualHotels = await this.hotelService.GetAllHotelsSortedAndFilteredAsync(Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"), hotelQueryViewModel);

            CollectionAssert.AreEqual(expectedHotels.Hotels, actualHotels.Hotels, new HotelViewModelComparer());
        }
        [Test]
        public async Task TestHotelsFiltering3()
        {
            AllHotelsSortedAndFilteredDataModel expectedHotels = new AllHotelsSortedAndFilteredDataModel()
            {
                Hotels = new List<HotelViewModel>()
                {
                  new HotelViewModel()
                  {
                    Id = hotel3.Id,
                    City = hotel3.City,
                    Country = hotel3.Country,
                    Name = hotel3.Name,
                    StarRating = hotel1.StarRating
                  },
                  new HotelViewModel()
                  {
                    Id = hotel1.Id,
                    City = hotel1.City,
                    Country = hotel1.Country,
                    Name = hotel1.Name,
                    StarRating = hotel1.StarRating
                  }
                }
            };

            HotelQueryViewModel hotelQueryViewModel = new HotelQueryViewModel()
            {
                City = "all",
                Country = "all",
                SelectedBenefitIds = new List<int>() { 1, 2 },
                HotelSortOption = HotelSortOption.ByCityAscending,
                Pager = new Pager(4, 1)
            };

            AllHotelsSortedAndFilteredDataModel actualHotels = await this.hotelService.GetAllHotelsSortedAndFilteredAsync(Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"), hotelQueryViewModel);

            CollectionAssert.AreEqual(expectedHotels.Hotels, actualHotels.Hotels, new HotelViewModelComparer());
        }
        [Test]
        public async Task TestHotelsFiltering4()
        {
            AllHotelsSortedAndFilteredDataModel expectedHotels = new AllHotelsSortedAndFilteredDataModel()
            {
                Hotels = new List<HotelViewModel>()
                {
                  new HotelViewModel()
                  {
                    Id = hotel3.Id,
                    City = hotel3.City,
                    Country = hotel3.Country,
                    Name = hotel3.Name,
                    StarRating = hotel1.StarRating
                  }
                }
            };

            HotelQueryViewModel hotelQueryViewModel = new HotelQueryViewModel()
            {
                City = "Sofia",
                Country = "all",
                SelectedBenefitIds = new List<int>() { 1, 2 },
                HotelSortOption = HotelSortOption.ByCityAscending,
                Pager = new Pager(4, 1)
            };

            AllHotelsSortedAndFilteredDataModel actualHotels = await this.hotelService.GetAllHotelsSortedAndFilteredAsync(Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"), hotelQueryViewModel);

            CollectionAssert.AreEqual(expectedHotels.Hotels, actualHotels.Hotels, new HotelViewModelComparer());
        }
        [Test]
        public async Task TestHotelsFiltering5()
        {
            AllHotelsSortedAndFilteredDataModel expectedHotels = new AllHotelsSortedAndFilteredDataModel()
            {
                Hotels = new List<HotelViewModel>()
                {
                  new HotelViewModel()
                  {
                    Id = hotel4.Id,
                    City = hotel4.City,
                    Country = hotel4.Country,
                    Name = hotel4.Name,
                    StarRating = hotel4.StarRating
                  },

                  new HotelViewModel()
                  {
                    Id = hotel1.Id,
                    City = hotel1.City,
                    Country = hotel1.Country,
                    Name = hotel1.Name,
                    StarRating = hotel1.StarRating
                  },

                  new HotelViewModel()
                  {
                    Id = hotel2.Id,
                    City = hotel2.City,
                    Country = hotel2.Country,
                    Name = hotel2.Name,
                    StarRating = hotel2.StarRating
                  },

                  new HotelViewModel()
                  {
                    Id = hotel3.Id,
                    City = hotel3.City,
                    Country = hotel3.Country,
                    Name = hotel3.Name,
                    StarRating = hotel3.StarRating
                  },

                }
            };

            HotelQueryViewModel hotelQueryViewModel = new HotelQueryViewModel()
            {
                City = "all",
                Country = "all",
                SelectedBenefitIds = new List<int>(),
                HotelSortOption = HotelSortOption.ByCountryDescending,
                Pager = new Pager(4, 1)
            };

            AllHotelsSortedAndFilteredDataModel actualHotels = await this.hotelService.GetAllHotelsSortedAndFilteredAsync(Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"), hotelQueryViewModel);

            CollectionAssert.AreEqual(expectedHotels.Hotels, actualHotels.Hotels, new HotelViewModelComparer());
        }
        [Test]
        public async Task TestHotelsFiltering6()
        {
            AllHotelsSortedAndFilteredDataModel expectedHotels = new AllHotelsSortedAndFilteredDataModel()
            {
                Hotels = new List<HotelViewModel>()
                {

                  new HotelViewModel()
                  {
                    Id = hotel1.Id,
                    City = hotel1.City,
                    Country = hotel1.Country,
                    Name = hotel1.Name,
                    StarRating = hotel1.StarRating
                  },

                  new HotelViewModel()
                  {
                    Id = hotel2.Id,
                    City = hotel2.City,
                    Country = hotel2.Country,
                    Name = hotel2.Name,
                    StarRating = hotel2.StarRating
                  },

                  new HotelViewModel()
                  {
                    Id = hotel3.Id,
                    City = hotel3.City,
                    Country = hotel3.Country,
                    Name = hotel3.Name,
                    StarRating = hotel3.StarRating
                  },
                  new HotelViewModel()
                  {
                    Id = hotel4.Id,
                    City = hotel4.City,
                    Country = hotel4.Country,
                    Name = hotel4.Name,
                    StarRating = hotel4.StarRating
                  }

                }
            };

            HotelQueryViewModel hotelQueryViewModel = new HotelQueryViewModel()
            {
                City = "all",
                Country = "all",
                SelectedBenefitIds = new List<int>(),
                HotelSortOption = HotelSortOption.ByCountryAscending,
                Pager = new Pager(4, 1)
            };

            AllHotelsSortedAndFilteredDataModel actualHotels = await this.hotelService.GetAllHotelsSortedAndFilteredAsync(Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"), hotelQueryViewModel);

            CollectionAssert.AreEqual(expectedHotels.Hotels, actualHotels.Hotels, new HotelViewModelComparer());
        }
        [Test]
        public async Task TestHotelsFiltering7()
        {
            AllHotelsSortedAndFilteredDataModel expectedHotels = new AllHotelsSortedAndFilteredDataModel()
            {
                Hotels = new List<HotelViewModel>()
                {

                  new HotelViewModel()
                  {
                    Id = hotel1.Id,
                    City = hotel1.City,
                    Country = hotel1.Country,
                    Name = hotel1.Name,
                    StarRating = hotel1.StarRating
                  },

                  new HotelViewModel()
                  {
                    Id = hotel2.Id,
                    City = hotel2.City,
                    Country = hotel2.Country,
                    Name = hotel2.Name,
                    StarRating = hotel2.StarRating
                  },

                  new HotelViewModel()
                  {
                    Id = hotel3.Id,
                    City = hotel3.City,
                    Country = hotel3.Country,
                    Name = hotel3.Name,
                    StarRating = hotel3.StarRating
                  },

                }
            };

            HotelQueryViewModel hotelQueryViewModel = new HotelQueryViewModel()
            {
                City = "all",
                Country = "all",
                SelectedBenefitIds = new List<int>(),
                MinStarsCountFilter = 5,
                HotelSortOption = HotelSortOption.ByCountryAscending,
                Pager = new Pager(4, 1)
            };

            AllHotelsSortedAndFilteredDataModel actualHotels = await this.hotelService.GetAllHotelsSortedAndFilteredAsync(Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"), hotelQueryViewModel);

            CollectionAssert.AreEqual(expectedHotels.Hotels, actualHotels.Hotels, new HotelViewModelComparer());
        }
        [Test]
        public async Task TestHotelsFiltering8()
        {
            AllHotelsSortedAndFilteredDataModel expectedHotels = new AllHotelsSortedAndFilteredDataModel()
            {
                Hotels = new List<HotelViewModel>()
                {

                  new HotelViewModel()
                  {
                    Id = hotel4.Id,
                    City = hotel4.City,
                    Country = hotel4.Country,
                    Name = hotel4.Name,
                    StarRating = hotel4.StarRating
                  }

                }
            };

            HotelQueryViewModel hotelQueryViewModel = new HotelQueryViewModel()
            {
                City = "all",
                Country = "all",
                SelectedBenefitIds = new List<int>(),
                HotelSortOption = HotelSortOption.ByCountryAscending,
                MinStarsCountFilter = 2,
                MaxStarsCountFilter = 4,
                Pager = new Pager(4, 1)
            };

            AllHotelsSortedAndFilteredDataModel actualHotels = await this.hotelService.GetAllHotelsSortedAndFilteredAsync(Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"), hotelQueryViewModel);

            CollectionAssert.AreEqual(expectedHotels.Hotels, actualHotels.Hotels, new HotelViewModelComparer());
        }

        [Test]
        public async Task TestHotelsFiltering9()
        {
            AllHotelsSortedAndFilteredDataModel expectedHotels = new AllHotelsSortedAndFilteredDataModel()
            {
                Hotels = new List<HotelViewModel>()
                {

                  new HotelViewModel()
                  {
                    Id = hotel4.Id,
                    City = hotel4.City,
                    Country = hotel4.Country,
                    Name = hotel4.Name,
                    StarRating = hotel4.StarRating
                  }

                }
            };

            HotelQueryViewModel hotelQueryViewModel = new HotelQueryViewModel()
            {
                City = "Milan",
                Country = "Italy",
                SelectedBenefitIds = new List<int>(),
                HotelSortOption = HotelSortOption.ByCountryAscending,
                MinStarsCountFilter = 2,
                MaxStarsCountFilter = 4,
                Pager = new Pager(4, 1)
            };

            AllHotelsSortedAndFilteredDataModel actualHotels = await this.hotelService.GetAllHotelsSortedAndFilteredAsync(Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"), hotelQueryViewModel);

            CollectionAssert.AreEqual(expectedHotels.Hotels, actualHotels.Hotels, new HotelViewModelComparer());
        }
        [Test]
        public async Task TestHotelsFiltering10()
        {
            AllHotelsSortedAndFilteredDataModel expectedHotels = new AllHotelsSortedAndFilteredDataModel()
            {
                Hotels = new List<HotelViewModel>()
                {

                  new HotelViewModel()
                  {
                    Id = hotel1.Id,
                    City = hotel1.City,
                    Country = hotel1.Country,
                    Name = hotel1.Name,
                    StarRating = hotel1.StarRating
                  },

                  new HotelViewModel()
                  {
                    Id = hotel2.Id,
                    City = hotel2.City,
                    Country = hotel2.Country,
                    Name = hotel2.Name,
                    StarRating = hotel2.StarRating
                  },

                  new HotelViewModel()
                  {
                    Id = hotel3.Id,
                    City = hotel3.City,
                    Country = hotel3.Country,
                    Name = hotel3.Name,
                    StarRating = hotel3.StarRating
                  },
                  new HotelViewModel()
                  {
                    Id = hotel4.Id,
                    City = hotel4.City,
                    Country = hotel4.Country,
                    Name = hotel4.Name,
                    StarRating = hotel4.StarRating
                  }

                }
            };

            HotelQueryViewModel hotelQueryViewModel = new HotelQueryViewModel()
            {
                City = "all",
                Country = "all",
                SelectedBenefitIds = new List<int>(),
                HotelSortOption = HotelSortOption.ByStarRatingDescending,
                Pager = new Pager(4, 1)
            };

            AllHotelsSortedAndFilteredDataModel actualHotels = await this.hotelService.GetAllHotelsSortedAndFilteredAsync(Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"), hotelQueryViewModel);

            CollectionAssert.AreEqual(expectedHotels.Hotels, actualHotels.Hotels, new HotelViewModelComparer());
        }

        [Test]
        public async Task TestGetAllHotelCities()
        {
            IEnumerable<string> expectedCities = new List<string>() { "Velingrad", "Sofia", "Milan" };

            IEnumerable<string> actualCities = await this.hotelService.GetAllHotelCitiesAsync();

            CollectionAssert.AreEqual(expectedCities, actualCities);

        }
        [Test]
        public async Task TestGetHotelCountries()
        {
            IEnumerable<string> expectedHotelCountries = new List<string>() { "Bulgaria", "Italy" };

            IEnumerable<string> actualHotelCountries = await this.hotelService.GetAllHotelCountriesAsync();

            CollectionAssert.AreEqual(expectedHotelCountries, actualHotelCountries);
        }
        [Test]
        public async Task TestAddHotelToUserFavorites()
        {
            int expectedFavoriteHotelRecordsCount = 3;

            await this.hotelService.AddHotelToUserFavoriteHotels(3, Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"));

            Assert.AreEqual(expectedFavoriteHotelRecordsCount, this.dbContext.FavoriteHotels.Count());
        }
        [Test]
        public async Task TestRemoveHotelFromUserFavorites()
        {
            int expectedFavoriteHotelsRecordsCount = 2;

            await this.hotelService.AddHotelToUserFavoriteHotels(3, Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"));
            await this.hotelService.RemoveHotelFromUserFavoriteHotels(3, Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"));

            Assert.AreEqual(expectedFavoriteHotelsRecordsCount, this.dbContext.FavoriteHotels.Count());
        }
        [Test]
        public async Task TestGetHotelById()
        {
            HotelInfoViewModel expectedHotelViewModel = new HotelInfoViewModel()
            {
                Id = hotel4.Id,
                City = hotel4.City,
                Country = hotel4.Country,
                Name = hotel4.Name,
                Description = hotel4.Description,
                StarRating = hotel4.StarRating,
                Latitude = hotel4.Latitude,
                Longitude = hotel4.Longitude,
            };

            HotelInfoViewModel actualHotelViewModel = await this.hotelService.GetHotelByIdAsync(4, new Pager(5, 1));

            Assert.AreEqual(expectedHotelViewModel.Id, actualHotelViewModel.Id);
        }
        [Test]
        public async Task TestHotelCommentsCountShouldReturn2()
        {
            int expectedCommentsCount = 2;

            int actualCommentsCount = await this.hotelService.GetHotelCommentsCountAsync(1);

            Assert.AreEqual(expectedCommentsCount, actualCommentsCount);
        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}