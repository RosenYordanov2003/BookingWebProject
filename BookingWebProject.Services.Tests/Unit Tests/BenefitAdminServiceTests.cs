namespace BookingWebProject.Services.Tests.Unit_Tests
{
    using Areas.Admin.Contracts;
    using Areas.Admin.Services;
    using Core.Models.Benefits;
    using Data;
    using Comparators;
    using Microsoft.EntityFrameworkCore;
    using static DatabaseSeeder;
    using Microsoft.AspNetCore.Components.Web;
    using BookingWebProject.Areas.Admin.Models.Benefit;

    [TestFixture]
    public class BenefitAdminServiceTests
    {
        private BookingContext dbContext;
        private DbContextOptions<BookingContext> dbOptions;
        private IBenefitAdminService benefitAdminService;

        [SetUp]
        public void SetUp()
        {
            dbOptions = new DbContextOptionsBuilder<BookingContext>()
                .UseInMemoryDatabase("BookingSystemInMemory" + Guid.NewGuid().ToString())
                .Options;
            dbContext = new BookingContext(dbOptions, false);
            dbContext.Database.EnsureCreated();
            SeedDatabase(dbContext);
            benefitAdminService = new BenefitAdminService(dbContext);
        }
        [Test]
        public async Task TestGetOtherBeenfits()
        {
            IEnumerable<BenefitViewModel> expectedBenefits = new List<BenefitViewModel>()
            {
                new BenefitViewModel()
                {
                    Id = benefit3.Id,
                    Name = benefit3.Name,
                    BenefitIcon = benefit3.ClassIcon,
                },
                new BenefitViewModel()
                {
                    Id = benefit4.Id,
                    Name = benefit4.Name,
                    BenefitIcon = benefit4.ClassIcon
                }
            };

            IEnumerable<BenefitViewModel> actualBenefits = await this.benefitAdminService.GetOtherBenefitsAsync(hotel1.Id);

            CollectionAssert.AreEqual(expectedBenefits, actualBenefits, new BenefitViewModelComparer());
        }
        [Test]
        public async Task TestGetAllBeenfits()
        {
            IEnumerable<BenefitViewModel> expectedBenefits = new List<BenefitViewModel>()
            {
                new BenefitViewModel()
                {
                    Id = benefit1.Id,
                    Name = benefit1.Name,
                    BenefitIcon = benefit1.ClassIcon,
                },
                new BenefitViewModel()
                {
                    Id = benefit2.Id,
                    Name = benefit2.Name,
                    BenefitIcon = benefit2.ClassIcon,
                },
                new BenefitViewModel()
                {
                    Id = benefit3.Id,
                    Name = benefit3.Name,
                    BenefitIcon = benefit3.ClassIcon,
                },
                new BenefitViewModel()
                {
                    Id = benefit4.Id,
                    Name = benefit4.Name,
                    BenefitIcon = benefit4.ClassIcon
                }
            };

            IEnumerable<BenefitViewModel> actualBenefits = await this.benefitAdminService.GetAllHotelBenefitsAsync();

            CollectionAssert.AreEqual(expectedBenefits, actualBenefits, new BenefitViewModelComparer());
        }
        [Test]
        public async Task TestCheckIfBenefitExistByIdShouldReturnTrue()
        {
            bool actualResult = await this.benefitAdminService.CheckIfBenefitExistByIdAsync(benefit1.Id);

            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestCheckIfBenefitExistByIdShouldReturnFalse()
        {
            bool actualResult = await this.benefitAdminService.CheckIfBenefitExistByIdAsync(40);

            Assert.IsFalse(actualResult);
        }
        [Test]
        public async  Task TestDeleteBenefit()
        {
            benefit1.IsDeleted = true;
            dbContext.SaveChanges();

            Assert.IsTrue(benefit1.IsDeleted);
        }
        [Test]
        public async Task TestCheckIfBenefitIsAlreadyDeletedShouldRetrunTrue()
        {
            benefit1.IsDeleted = true;
            dbContext.SaveChanges();

            bool actualResult = await this.benefitAdminService.CheckIfBenefitIsAlreadyDeletedAsync(benefit1.Id);

            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestCheckIfBenefitIsAlreadyDeletedShouldRetrunFalse()
        {
            bool actualResult = await this.benefitAdminService.CheckIfBenefitIsAlreadyDeletedAsync(benefit1.Id);

            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestCheckIfBenefitIsAlreadyRecoveredByIdShouldReturnTrue()
        {
            bool actualResult = await this.benefitAdminService.CheckIfBenefitIsAlreadyRecoveredByIdAsync(benefit1.Id);

            Assert.IsTrue(actualResult);
        }
        [Test]
        public async Task TestCheckIfBenefitIsAlreadyRecoveredByIdShouldReturnFalse ()
        {
            benefit1.IsDeleted = true;
            dbContext.SaveChanges();

            bool actualResult = await this.benefitAdminService.CheckIfBenefitIsAlreadyRecoveredByIdAsync(benefit1.Id);

            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestRecoverBenefit()
        {
            await this.benefitAdminService.DeleteBenefitAsync(benefit1.Id);
            await this.benefitAdminService.RecoverBenefitAsync(benefit1.Id);

            Assert.IsFalse(benefit1.IsDeleted);
        }
        [Test]
        public async Task TestGetBenefitToEdit()
        {
            EditBenefitViewModel expectedBenefitModel = new EditBenefitViewModel()
            {
                BenefitName = benefit1.Name,
                BenefitClassIcon = benefit1.ClassIcon
            };

            EditBenefitViewModel actualbenefit = await this.benefitAdminService.GetBenefitToEditAsync(benefit1.Id);

            Assert.AreEqual(expectedBenefitModel.BenefitName, actualbenefit.BenefitName);
            Assert.AreEqual(expectedBenefitModel.BenefitClassIcon, actualbenefit.BenefitClassIcon);
        }
        [Test]
        public async Task TestEditBenefit()
        {
            EditBenefitViewModel benefitModel = new EditBenefitViewModel()
            {
                BenefitName = "Test Benefit",
                BenefitClassIcon = "Test Icon"
            };
            await this.benefitAdminService.EditBenefitByIdAsync(benefit1.Id, benefitModel);

            Assert.AreEqual(benefitModel.BenefitName, benefit1.Name);
            Assert.AreEqual(benefitModel.BenefitClassIcon, benefit1.ClassIcon);
        }
        [Test]
        public async Task TestCreateBenefit()
        {
            int currentBenefitsCountInDatabase = dbContext.Benefits.Count();
            int expectedBeenefitsCountInDatabase = currentBenefitsCountInDatabase + 1;
            EditBenefitViewModel benefitModel = new EditBenefitViewModel()
            {
                BenefitName = "Test Benefit",
                BenefitClassIcon = "Test Icon"
            };

            await this.benefitAdminService.CreateBenefitAsync(benefitModel);

            Assert.AreEqual(expectedBeenefitsCountInDatabase, dbContext.Benefits.Count());
        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
