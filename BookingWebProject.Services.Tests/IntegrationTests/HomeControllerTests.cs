namespace BookingWebProject.Services.Tests.IntegrationTests
{
    using global::Moq;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;
    using Controllers;
    using Core.Contracts;
    using Data;
    using Infrastructure.Data.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using static Services.Tests.Moq.HotelServiceMoq;
    using Core.Models.Hotel;
    using Microsoft.Extensions.DependencyInjection;

    [TestFixture]
    public class HomeControllerTests
    {
        private DbContextOptions<BookingContext> dbOptions;
        private HomeController homeController;
        private Mock<IMemoryCache> memoryCacheMock;
        private IHotelService hotelService;
        private Mock<UserManager<User>> userManagerMock;
        private Mock<RoleManager<IdentityRole<Guid>>> roleManagerMock;
        private Mock<BookingContext> bookingContextMock;
        private User user;

        [SetUp]
        public async Task SetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<BookingContext>()
              .UseInMemoryDatabase("BookingSystemInMemory" + Guid.NewGuid().ToString())
              .Options;

            memoryCacheMock = new Mock<IMemoryCache>();

            userManagerMock = new Mock<UserManager<User>>(
                              Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);

            roleManagerMock = new Mock<RoleManager<IdentityRole<Guid>>>(
               Mock.Of<IRoleStore<IdentityRole<Guid>>>(), null, null, null, null);


            bookingContextMock = new Mock<BookingContext>(dbOptions, false);
            hotelService = await Instance();

            user = new User()
            {
                Id = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"),
                UserName = "Test User",
                NormalizedUserName = "TEST USER",
                Email = "testuser123@gmail.com",
                NormalizedEmail = "TESTUSER123@GMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            homeController = new HomeController(
            hotelService,
            memoryCacheMock.Object,
            userManagerMock.Object,
            roleManagerMock.Object,
            bookingContextMock.Object);
        }
        [Test]
        public async Task TestWhenReturnRedirectToAdminAreaIndexAction1()
        {
            ClaimsIdentity adminClaimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, "Administrator"),
            }, "mock");
            adminClaimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Administrator"));

            ClaimsPrincipal principal = new ClaimsPrincipal(adminClaimsIdentity);

            // Set up the HttpContext with the authenticated user
            DefaultHttpContext httpContext = new DefaultHttpContext();
            httpContext.User = principal;

            // set ControllerContext
            // controller context and the http request that will be processed
            ControllerContext controllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };

            homeController.ControllerContext = controllerContext;

            IActionResult result = await homeController.Index();


            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            RedirectToActionResult redirectResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectResult.ActionName);
            Assert.AreEqual("Home", redirectResult.ControllerName);
            Assert.AreEqual("Admin", redirectResult.RouteValues["Area"]);
        }
        [Test]
        public async Task TestWhenReturnRedirectToAdminAreaIndexAction2()
        {
            ClaimsIdentity adminClaimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, "Administrator"),
            }, "mock");
            adminClaimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Moderator"));

            ClaimsPrincipal principal = new ClaimsPrincipal(adminClaimsIdentity);

            // Set up the HttpContext with the authenticated user
            DefaultHttpContext httpContext = new DefaultHttpContext();
            httpContext.User = principal;

            // set ControllerContext
            // controller context and the http request that will be processed
            ControllerContext controllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };

            homeController.ControllerContext = controllerContext;

            IActionResult result = await homeController.Index();


            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            RedirectToActionResult redirectResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectResult.ActionName);
            Assert.AreEqual("Home", redirectResult.ControllerName);
            Assert.AreEqual("Admin", redirectResult.RouteValues["Area"]);
        }

        [Test]
        public async Task ShouldReturnIndexView()
        {
            IEnumerable<HotelCardViewModel> hotels = await this.hotelService.GetTopHotelsAsync();

            //var cacheEntryMock = new Mock<ICacheEntry>();

            //memoryCacheMock.Setup(x => x.CreateEntry(It.IsAny<object>())).Returns(cacheEntryMock.Object);
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddMemoryCache()
                .BuildServiceProvider();
            IMemoryCache memoryCache = serviceProvider.GetService<IMemoryCache>();

            ClaimsIdentity userClaimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            });

           homeController = new HomeController(
           hotelService,
           memoryCache,
           userManagerMock.Object,
           roleManagerMock.Object,
           bookingContextMock.Object);

            ClaimsPrincipal principal = new ClaimsPrincipal(userClaimsIdentity);

            // Set up the HttpContext with the authenticated user
            DefaultHttpContext httpContext = new DefaultHttpContext();
            httpContext.User = principal;

            // set ControllerContext
            // controller context and the http request that will be processed
            ControllerContext controllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };

            homeController.ControllerContext = controllerContext;

            IActionResult result = await homeController.Index();

            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.IsNotNull(hotels);
            Assert.IsTrue(hotels.SequenceEqual(hotels));
        }

        [Test]
        public void Error_With404StatusCode_ReturnsError404View()
        {
            int statusCode = 404;

            IActionResult result = homeController.Error(statusCode);

            Assert.That(result, Is.InstanceOf<ViewResult>());
            ViewResult viewResult = result as ViewResult;
            Assert.AreEqual("Error404", viewResult.ViewName);
        }
        [Test]
        public void ErrorWith404StatusCodeReturnsError()
        {
            // Arrange
            int statusCode = 405;
            homeController = new HomeController(
               hotelService,
               memoryCacheMock.Object,
               userManagerMock.Object,
               roleManagerMock.Object,
               bookingContextMock.Object);


            IActionResult result = homeController.Error(statusCode);

            Assert.That(result, Is.InstanceOf<ViewResult>());
            ViewResult viewResult = result as ViewResult;
            Assert.AreEqual("Error", viewResult.ViewName);
        }
        [Test]
        public void ErrorWith404StatusCodeReturns404()
        {
            int statusCode = 400;

            IActionResult result = homeController.Error(statusCode);

            Assert.That(result, Is.InstanceOf<ViewResult>());
            ViewResult viewResult = result as ViewResult;
            Assert.AreEqual("Error404", viewResult.ViewName);
        }
        [Test]
        public void ErrorWithStatusCode401ShouldReturnsUnauthorized()
        {
            int statusCode = 401;

            IActionResult result = homeController.Error(statusCode);
            Assert.That(result, Is.InstanceOf<ViewResult>());
            ViewResult viewResult = result as ViewResult;
            Assert.AreEqual("Unauthorized", viewResult.ViewName);
        }
    }
}
