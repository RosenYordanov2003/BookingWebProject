using BookingWebProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookingWebProject.Infrastructure.Data.Configurations
{
    public class BenefitEntityConfiguration : IEntityTypeConfiguration<Benefit>
    {
        public void Configure(EntityTypeBuilder<Benefit> builder)
        {
            ICollection<Benefit> benefits = CreateBenefits();
            builder.HasData(benefits);
        }
        private ICollection<Benefit> CreateBenefits()
        {
            List<Benefit> benefits = new List<Benefit>()
            {
                new Benefit()
                {
                    Id = 1,
                    Name = "Allow pets",
                    ClassIcon = "fa-solid fa-dog",
                },
                new Benefit()
                {
                    Id = 2,
                    Name = "Spa",
                    ClassIcon = "fa-solid fa-hot-tub-person"
                },
                new Benefit()
                {
                    Id = 3,
                    Name = "Room service",
                    ClassIcon = "fa-solid fa-bell-concierge"
                },
                new Benefit()
                {
                    Id = 4,
                    Name = "Gym",
                    ClassIcon = "fa-solid fa-dumbbell"
                },
                new Benefit()
                {
                    Id = 5,
                    Name = "Restaurant",
                    ClassIcon = "fa-solid fa-utensils"
                },
                new Benefit()
                {
                    Id = 6,
                    Name = "Parking",
                    ClassIcon = "fa-solid fa-square-parking"
                },
                new Benefit()
                {
                    Id = 7,
                    Name = "Pool",
                    ClassIcon = "fa-solid fa-water-ladder"
                },
                new Benefit()
                {
                    Id = 8,
                    Name = "Bar",
                    ClassIcon = "fa-solid fa-wine-glass"
                }
            };
            return benefits;
        }
    }
}
