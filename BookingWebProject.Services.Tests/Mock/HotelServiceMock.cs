namespace BookingWebProject.Services.Tests.Moq
{
    using Core.Models.Hotel;
    using Core.Contracts;
    using global::Moq;
    using static DatabaseSeeder;

    public static class HotelServiceMoq
    {
        public static async Task<IHotelService> Instance()
        {
            IEnumerable<HotelCardViewModel> hotelCards = new List<HotelCardViewModel>()
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
            };
            var moqInstance = new Mock<IHotelService>();
            moqInstance.Setup(x => x.GetTopHotelsAsync())
                .ReturnsAsync(hotelCards);

            return moqInstance.Object;
        }
    }
}
