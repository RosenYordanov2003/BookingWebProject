namespace BookingWebProject.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Core.Contracts;
    using Core.Services;
    using Core.Models.Hotel;
    using Core.Models.Hotel.Enums;
    using static DatabaseSeeder;
    using BookingWebProject.Infrastructure.Data.Models;
    using System.Linq;

    public class HotelServiceTests
    {
        private DbContextOptions<BookingContext> dbOptions;
        private BookingContext dbContext;
        private IHotelService hotelService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
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
                SelectedBenefitIds = new List<int>() { 10 },
                Country = "all",
                City = "all",
                HotelSortOption = HotelSortOption.ByStarRatingAscending,
            };
            int expectedResult = 1;
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
            IEnumerable<hotel>
        }
    }
}