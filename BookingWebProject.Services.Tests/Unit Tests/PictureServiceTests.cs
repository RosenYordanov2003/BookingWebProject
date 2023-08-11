namespace BookingWebProject.Services.Tests.Unit_Tests
{
    using Microsoft.EntityFrameworkCore;
    using Areas.Admin.Contracts;
    using BookingWebProject.Data;
    using BookingWebProject.Areas.Admin.Services;
    using static DatabaseSeeder;
    using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

    [TestFixture]
    public class PictureServiceTests
    {
        private DbContextOptions<BookingContext> dbOptions;
        private BookingContext dbContext;
        IPictureService pictureService;


        [SetUp]
        public void SetUp()
        {
            dbOptions = new DbContextOptionsBuilder<BookingContext>()
                .UseInMemoryDatabase("BookingSystemInMemory" + Guid.NewGuid().ToString())
                .Options;
            dbContext = new BookingContext(dbOptions, false);
            dbContext.Database.EnsureCreated();
            SeedDatabase(dbContext);
            pictureService = new PictureService(dbContext);
        }
        [Test]
        public async Task TestCheckIsPictureAlreadyDetedShouldReturnFalse()
        {
            bool actualResult = await this.pictureService.CheckIsPictureAlreadyDeleted(1);

            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestCheckIsPictureAlreadyDetedShouldReturnTrue()
        {

            await this.pictureService.DeletePictureAsync(1);
            bool actualResult = await this.pictureService.CheckIsPictureAlreadyDeleted(1);

            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestCheckIsPictureExistByIdShouldReturnTrue()
        {
            bool actualResult = await this.pictureService.CheckIsPictureExistByIdAsync(1);

            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestCheckIsPictureExistByIdShouldReturnFalse()
        {
            bool actualResult = await this.pictureService.CheckIsPictureExistByIdAsync(11);

            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestCheckPictureIsAlreadyRecoveredShouldReturnTrue()
        {
            bool actualResult = await this.pictureService.CheckPictureIsAlreadyRecoveredAsync(1);

            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestCheckPictureIsAlreadyRecoveredShouldReturnFalse()
        {
            await this.pictureService.DeletePictureAsync(1);
            bool actualResult = await this.pictureService.CheckPictureIsAlreadyRecoveredAsync(1);

            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestRecoverPictureById()
        {
            await this.pictureService.DeletePictureAsync(1);
            await this.pictureService.RecoverPictureAsync(1);

            bool actualResult = await this.pictureService.CheckPictureIsAlreadyRecoveredAsync(1);

            Assert.IsTrue(actualResult);

        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
