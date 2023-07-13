using BookingWebProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookingWebProject.Infrastructure.Data.Configurations
{
    public class RoomTypeEntityConfiguration
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            ICollection<RoomType> roomTypes = CreateRoomTypes();
            builder.HasMany(rt => rt.Rooms)
                .WithOne(rt => rt.RoomType)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasData(roomTypes);
        }

        private ICollection<RoomType> CreateRoomTypes()
        {
            List<RoomType> roomTypes = new List<RoomType>()
            {
                new RoomType()
                {
                    Id = 1,
                    Name = "Apartment",
                    IncreasePercentage = 40,
                },
                new RoomType()
                {
                    Id = 2,
                    Name = "Studio",
                    IncreasePercentage = 35
                },
                new RoomType()
                {
                    Id = 3,
                    Name = "Double bed",
                    IncreasePercentage = 30
                },
                new RoomType()
                {
                    Id = 4,
                    Name = "Village",
                    IncreasePercentage = 45
                },
                new RoomType()
                {
                    Id = 5,
                    Name = "Single bed",
                    IncreasePercentage = 0
                },
            };
            return roomTypes;
        }
    }
}
