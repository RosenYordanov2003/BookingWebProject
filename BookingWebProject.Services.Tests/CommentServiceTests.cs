namespace BookingWebProject.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts;
    using Core.Services;
    using Data;
    using static DatabaseSeeder;
    using BookingWebProject.Core.Models.Comment;

    [TestFixture]
    public class CommentServiceTests
    {
        private DbContextOptions<BookingContext> dbOptions;
        private BookingContext dbContext;
        private ICommentService commentService;

        [SetUp]
        public void SetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<BookingContext>()
                .UseInMemoryDatabase("BookingSystemInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new BookingContext(this.dbOptions, false);
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(dbContext);
            this.commentService = new CommentService(this.dbContext);
        }
        [Test]
        public async Task TestCreateCommentMethod()
        {
            int expectedCountComments = 3;

            PostCommentViewModel commentViewModel = new PostCommentViewModel()
            {
                Description = "Test comment3",
                HotelId = 1,
            };
            Guid userId = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254");
            string userName = "Test User";

            await this.commentService.CreateCommentAsync(commentViewModel, userId, userName);

            Assert.AreEqual(expectedCountComments, this.dbContext.Comments.Count());
        }
        [Test]
        public async Task TestIfCommentExistsByIdShouldReturnTrue()
        {
            bool actualValue = await this.commentService.CheckIfCommentExistsByIdAsync(1);

            Assert.IsTrue(actualValue);
        }
        [Test]
        public async Task TestIfCommentExistsByIdShouldReturnFalse()
        {
            bool actualValue = await this.commentService.CheckIfCommentExistsByIdAsync(11);

            Assert.IsFalse(actualValue);
        }
        [Test]
        public async Task TestDeleteCommentMethod()
        {
            bool actualValue = await this.commentService.DeleteCommentAsync(1);

            Assert.IsTrue(comment1.IsDeleted);
        }
        [Test]
        public async Task TestEditCommentMethod()
        {
            string expectedCommentDescription = "Edited test comment1";
            EditCommentViewModel editCommentViewModel = new EditCommentViewModel()
            {
                Id = 1,
                Description = expectedCommentDescription
            };

            await this.commentService.EditCommentAsync(editCommentViewModel);

            Assert.AreEqual(expectedCommentDescription, comment1.Description);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
