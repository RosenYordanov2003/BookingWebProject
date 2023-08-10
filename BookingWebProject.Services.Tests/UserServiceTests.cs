namespace BookingWebProject.Services.Tests
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Core.Contracts;
    using Core.Models.User;
    using Core.Services;
    using Data;
    using static DatabaseSeeder;
    using BookingWebProject.Core.Models.Hotel;
    using BookingWebProject.Services.Tests.Comparators;

    [TestFixture]
    public class UserServiceTest
    {
        //put your env web root;
        private const string envWebRootPath = @"C:\\Users\\Home\\Desktop\\Booking Web Project C# Web\\BookingWebProject\\BookingWebProject\\wwwroot";
        private BookingContext dbContext;
        private IUserService userService;
        private DbContextOptions<BookingContext> dbOptions;
        private Mock<IWebHostEnvironment> webHostenvironmentMock;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            webHostenvironmentMock = new Mock<IWebHostEnvironment>();

            webHostenvironmentMock.Setup(env => env.WebRootPath)
                .Returns(envWebRootPath);
        }
        [SetUp]
        public void SetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<BookingContext>()
               .UseInMemoryDatabase("BookingSystemInMemory" + Guid.NewGuid().ToString())
               .Options;
            this.dbContext = new BookingContext(this.dbOptions, false);
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(dbContext);
            this.userService = new UserService(this.dbContext, webHostenvironmentMock.Object);
        }
        [Test]
        public async Task TestGetUserById()
        {
            UserViewModel expectedUser = new UserViewModel()
            {
                Id = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"),
                FirstName = "",
                LastName = "",
                Email = "testuser123@gmail.com",
                PhoneNumber = null,
            };

            UserViewModel actualUser = await this.userService.GetUserByIdAsync(Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"));

            Assert.AreEqual(expectedUser.Id, actualUser.Id);
            Assert.AreEqual(expectedUser.Email, actualUser.Email);
        }
        [Test]
        public async Task TestGetUserInfoByIdAsync()
        {
            UserInfoViewModel expectedUserInfo = new UserInfoViewModel()
            {
                Id = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"),
                FirstName = "",
                LastName = "",
                Email = "testuser123@gmail.com",
                PhoneNumber = "",
            };

            UserInfoViewModel actualUserInfo = await this.userService.GetUserInfoByIdAsync(Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"));

            Assert.AreEqual(expectedUserInfo.FirstName, actualUserInfo.FirstName);
            Assert.AreEqual(expectedUserInfo.LastName, actualUserInfo.LastName);
            Assert.AreEqual(expectedUserInfo.Email, actualUserInfo.Email);
            Assert.AreEqual(expectedUserInfo.PhoneNumber, actualUserInfo.PhoneNumber);
        }
        [Test]
        public async Task TestSaveUserInfo()
        {
            UserInfoViewModel userInfoToUpdate = new UserInfoViewModel()
            {
                Id = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"),
                FirstName = "Gosho",
                LastName = "Tsvetanov",
                Email = "testuser123@gmail.com",
                PhoneNumber = "",
            };
            await this.userService.SaveUserInfoAsync(Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"), userInfoToUpdate);

            UserInfoViewModel updateUserInfo = await this.userService.GetUserInfoByIdAsync(Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"));
            Assert.AreEqual(userInfoToUpdate.FirstName, updateUserInfo.FirstName);
            Assert.AreEqual(userInfoToUpdate.LastName, updateUserInfo.LastName);
        }
        //[Test]
        //public async Task TestUploadUserImgAsync()
        //{
        //    var userId = Guid.NewGuid();
        //    var userInfo = new UserInfoViewModel
        //    {
        //        ProfilePictureFile = new Mock<IFormFile>().Object
        //    };

        //    var memoryStream = new MemoryStream(new byte[0]);
        //    var fileMock = new Mock<IFormFile>();
        //    fileMock.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), CancellationToken.None))
        //            .Returns(Task.CompletedTask)
        //            .Callback((Stream stream, CancellationToken token) => memoryStream.CopyTo(stream));

        //    userInfo.ProfilePictureFile = fileMock.Object;

        //    string actualPath = await userService.UploadUserImageAsync(userInfo, userId);
        //    actualPath = actualPath.Replace(Path.DirectorySeparatorChar, '/');

           
        //    Assert.AreEqual("img/ProfilePictures/" + userId.ToString() + "_" + userInfo.ProfilePictureFile.FileName, actualPath);
        //}
        [Test]
        public async Task TestGetUserFavoriteHotels()
        {
            IEnumerable<HotelViewModel> expectedFavoriteHotels = new List<HotelViewModel>()
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
            };

            IEnumerable<HotelViewModel> actualFavoriteHotels = await this.userService.GetUserFavoriteHotelsAsync(Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"));

            CollectionAssert.AreEqual(expectedFavoriteHotels, actualFavoriteHotels, new HotelViewModelComparer());
        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
