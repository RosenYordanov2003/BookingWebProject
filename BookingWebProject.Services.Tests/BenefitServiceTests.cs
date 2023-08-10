namespace BookingWebProject.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Core.Contracts;
    using Core.Services;
    using Core.Models.Benefits;
    using Comparators;
    using static DatabaseSeeder;

    public class BenefitServiceTests
    {
        private DbContextOptions<BookingContext> dbOptions;
        private BookingContext dbContext;
        private IBenefitService benefitService;
        [SetUp]
        public void SetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<BookingContext>()
                .UseInMemoryDatabase("BookingSystemInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new BookingContext(this.dbOptions, false);
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(dbContext);
            this.benefitService = new BenefitService(this.dbContext);
        }

        [Test]
        public async Task TestGetAllBenefits()
        {
            IEnumerable<BenefitViewModel> expectedBenefits = new List<BenefitViewModel>()
           {
               new BenefitViewModel()
               {
                   Id = 1,
                   Name = "Allow pets",
                   BenefitIcon = "fa-solid fa-dog",
               },
               new BenefitViewModel()
               {
                    Id = 2,
                    Name = "Spa",
                    BenefitIcon = "fa-solid fa-hot-tub-person",
               },
               new BenefitViewModel()
               {
                   Id = 3,
                   Name = "Room service",
                   BenefitIcon = "fa-solid fa-bell-concierge"
               },
               new BenefitViewModel()
               {
                   Id = 4,
                   Name = "Gym",
                   BenefitIcon = "fa-solid fa-dumbbell"
               }
           };
            IEnumerable<BenefitViewModel> actualBenefits = await this.benefitService.GetAllBenefitsAsync();
            CollectionAssert.AreEqual(expectedBenefits, actualBenefits, new BenefitViewModelComparer());
        }
        [Test]
        public async Task TestGetAllBenefitsWithDeletedBenefit()
        {
            benefit2.IsDeleted = true;
            this.dbContext.SaveChanges();
           IEnumerable<BenefitViewModel> expectedBenefits = new List<BenefitViewModel>()
           {
               new BenefitViewModel()
               {
                   Id = 1,
                   Name = "Allow pets",
                   BenefitIcon = "fa-solid fa-dog",
               },
               new BenefitViewModel()
               {
                   Id = 3,
                   Name = "Room service",
                   BenefitIcon = "fa-solid fa-bell-concierge"
               },
               new BenefitViewModel()
               {
                   Id = 4,
                   Name = "Gym",
                   BenefitIcon = "fa-solid fa-dumbbell"
               }
           };
            IEnumerable<BenefitViewModel> actualBenefits = await this.benefitService.GetAllBenefitsAsync();
            CollectionAssert.AreEqual(expectedBenefits, actualBenefits, new BenefitViewModelComparer());
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
