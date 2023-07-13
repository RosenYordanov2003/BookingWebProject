namespace BookingWebProject.Infrastructure.Data.Configurations
{
    using Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    public class PackageEntityConfiguration : IEntityTypeConfiguration<RoomPackage>
    {
        public void Configure(EntityTypeBuilder<RoomPackage> builder)
        {
            builder.HasMany(p => p.Rooms)
                 .WithOne(r => r.Package)
                 .OnDelete(DeleteBehavior.NoAction);
            ICollection<RoomPackage> roomPackages = CreateRoomPackages();

            builder.HasData(roomPackages);
        }

        private ICollection<RoomPackage> CreateRoomPackages()
        {
            List<RoomPackage> roomPackages = new List<RoomPackage>()
            {
               new RoomPackage()
               {
                   Id = 1,
                   Name = "Breakfast",
                   Price = 0,
               },
               new RoomPackage()
               {
                   Id = 2,
                   Name = "Breakfast and Dinner",
                   Price = 70,
               },
               new RoomPackage()
               {
                   Id = 3,
                   Name = "All Inclusive",
                   Price = 100
               }
            };
            return roomPackages;
        }
    }
}
