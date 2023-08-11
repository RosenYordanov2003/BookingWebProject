namespace BookingWebProject.Services.Tests.Unit_Tests
{
    using Areas.Admin.Contracts;
    using Areas.Admin.Models.User;
    using Areas.Admin.Services;
    using Comparators;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using static DatabaseSeeder;

    [TestFixture]
    public class UserAdminServiceTests 
    {
        private BookingContext dbContext;
        private DbContextOptions<BookingContext> dbOptions;
        private IUserAdminService userAdminService;
        [SetUp]
        public void SetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<BookingContext>()
                .UseInMemoryDatabase("BookingSystemInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new BookingContext(this.dbOptions, false);
            this.dbContext.Database.EnsureCreated();

            this.userAdminService = new UserAdminService(dbContext);
        }
        [Test]
        public async Task TestGetAllUsersAsync()
        {
            IEnumerable<AllUsersViewModel> expectedUsers = new List<AllUsersViewModel>()
            {
                new AllUsersViewModel()
                {
                     Id = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"),
                     UserName = "Test User",
                     UserEmail = "testuser123@gmail.com",
                     FirstName = null,
                     LastName = null,
                     JoinTime = DateTime.Now,
                     ReservationsCount = 7,
                },
                new AllUsersViewModel()
                {
                    Id = Guid.Parse("ED842FDC-C71B-4FBC-8DF5-6F97CB73D622"),
                    UserName = "Admin",
                    FirstName = null,
                    LastName = null,
                    JoinTime = DateTime.Now,
                    ReservationsCount = 0,
                    UserEmail = "admin123@gmail.com"
                }
            };

            IEnumerable<AllUsersViewModel> actualUsers = await this.userAdminService.GetAllUsersAsync();

            CollectionAssert.AreEqual(expectedUsers, actualUsers, new AllUserViewModelComparer());
        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
   
}
