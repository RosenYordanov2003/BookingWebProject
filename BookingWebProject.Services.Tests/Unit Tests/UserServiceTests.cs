namespace BookingWebProject.Services.Tests
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Core.Contracts;
    using Core.Models.User;
    using Core.Services;
    using Data;
    using Core.Models.Hotel;
    using Comparators;
    using BookingWebProject.Core.Models.Reservation;
    using Microsoft.AspNetCore.Http;
    using global::Moq;
    using static DatabaseSeeder;

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
        public async Task TestGetUserFavoriteHotels1()
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

        [Test]
        public async Task TestGetUserFavoriteHotels2()
        {
            hotel1.IsDeleted = true;
            dbContext.SaveChanges();

            IEnumerable<HotelViewModel> expectedFavoriteHotels = new List<HotelViewModel>()
            {

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

        [Test]
        public async Task TestGetUserReservationMethod()
        {

            IEnumerable<UserReservationViewModel> expectedUserReservations = new List<UserReservationViewModel>()
            {
                new UserReservationViewModel()
                {
                   Id = Guid.Parse("1A5B6A64-1A7A-4E88-90AE-011257E72A06"),
                   StartDate = DateTime.Parse("2023-08-06 00:00:00.0000000"),
                   EndDate = DateTime.Parse("2023-08-09 00:00:00.0000000"),
                   Price = 0,
                },
                new UserReservationViewModel()
                {
                     Id = Guid.Parse("0FA904EF-7DE8-49BA-986F-9ECB1580A195"),
                     StartDate = DateTime.Parse("2023-08-06 00:00:00.0000000"),
                     EndDate = DateTime.Parse("2023-08-09 00:00:00.0000000"),
                     Price = 0,
                },
                new UserReservationViewModel()
                {
                    Id = Guid.Parse("10672AC6-1BF2-4FED-A4DF-09CC18298D07"),
                    StartDate = DateTime.Parse("2023-08-06 00:00:00.0000000"),
                    EndDate = DateTime.Parse("2023-08-09 00:00:00.0000000"),
                    Price = 0,
                },
                new UserReservationViewModel()
                {
                     Id = Guid.Parse("2E09A998-07AB-4997-8D86-FC7D7E85E390"),
                     StartDate = DateTime.Parse("2023-08-03 00:00:00.0000000"),
                      EndDate = DateTime.Parse("2023-08-05 00:00:00.0000000"),
                },
                new UserReservationViewModel()
                {
                     Id = Guid.Parse("C93B9E3F-9EA2-4C91-9014-6E84618798C4"),
                     StartDate = DateTime.Parse("2023-08-03 00:00:00.0000000"),
                     EndDate = DateTime.Parse("2023-08-05 00:00:00.0000000"),
                     Price = 0,
                },
                new UserReservationViewModel()
                {
                     Id = Guid.Parse("B380CA76-B962-4EB6-9CB0-2BFDE906B5CC"),
                     StartDate = DateTime.Parse("2023-07-25 00:00:00.0000000"),
                     EndDate = DateTime.Parse("2023-07-27 00:00:00.0000000"),
                     Price = 0,
                },
                new UserReservationViewModel()
                {
                     Id = Guid.Parse("E09DB7FF-CD5F-4074-8991-FD5F54E98BAC"),
                     StartDate = DateTime.Parse("2023-07-21 00:00:00.0000000"),
                     EndDate = DateTime.Parse("2023-07-24 00:00:00.0000000"),
                     Price = 0,
                }
            };

            IEnumerable<UserReservationViewModel> actualUserReservations = await this.userService.GetUserReservationsAsync(Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"));

            CollectionAssert.AreEqual(expectedUserReservations, actualUserReservations, new UserReservationViewModelComparer());
        }

        [Test]
        public async Task TestRemoveProfilePicturePathFromUser()
        {
            UserInfoViewModel userInfoToSet = new UserInfoViewModel()
            {
                Id = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"),
                FirstName = "",
                LastName = "",
                Email = "testuser123@gmail.com",
                PhoneNumber = "",
                ProfilePicturePath = "testpath123"
            };

            await this.userService.SaveUserInfoAsync(Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"), userInfoToSet);
            await this.userService.DeleteUserProfilePictureAsync(Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"), "");

            UserInfoViewModel updatedUserInfo = await this.userService.GetUserInfoByIdAsync(Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"));

            Assert.IsNull(updatedUserInfo.ProfilePicturePath);
        }


        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
